using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Arcball_3dRotation
{
    class draw_obj_store
    {
        private readonly object paintLock = new object();
        private List<point3d> pts = new List<point3d>();
        private List<line3d> lines = new List<line3d>();
        private List<polygon3d> poly = new List<polygon3d>();
        private List<int> poly_paint_order_ids = new List<int>();

        private static double poly_z_max = 0.0;
        private static double poly_z_min = 0.0;
        // private static double[,] rotation_matrix = new double[2,3];

        public draw_obj_store(int itm)
        {
            switch (itm)
            {
                case 1: // Cube
                    {
                        extract_model(Properties.Resources.cube_1);
                        break;
                    }
                case 2: // Sphere
                    {
                        extract_model(Properties.Resources.sphere_1);
                        break;
                    }
                case 3: // Sphere
                    {
                        extract_model(Properties.Resources.cylinder_1);
                        break;
                    }
                case 4: // DoNut
                    {
                        extract_model(Properties.Resources.donut_1);
                        break;
                    }
                case 5: // Klein Bottle
                    {
                        extract_model(Properties.Resources.klein_bottle_1);
                        break;
                    }
            }

        }

        public void extract_model(string resource_data)
        {
            // Set the new instances for the drawing objects
            pts = new List<point3d>();
            lines = new List<line3d>();
            poly = new List<polygon3d>();

            // Read the resource data
            using (StringReader reader = new StringReader(resource_data))
            {
                string str_line;
                double scale_fctr = 1.0;
                int read_flg = 0;

                while ((str_line = reader.ReadLine()) != null)
                {

                    string[] str_word;

                    if (read_flg == 0)
                    {
                        str_line = str_line.Replace(" ", "");
                        str_word = str_line.Split(',');

                        if (str_word[0] == "$$$$SCALE")
                        {
                            scale_fctr = double.Parse(str_word[1]);
                        }

                        if (str_line == "$$$$POINTS")
                        {
                            read_flg = 1;
                        }
                        continue;
                    }

                    if (read_flg == 1)
                    {
                        // Read the points
                        str_line = str_line.Replace(" ", "");
                        if (str_line == "$$$$POLYGON")
                        {
                            read_flg = 2;
                            continue;
                        }
                        str_word = str_line.Split(',');

                        // Parse the point data
                        int nd_id = int.Parse(str_word[0]);
                        double x = double.Parse(str_word[1]);
                        double y = double.Parse(str_word[2]);
                        double z = double.Parse(str_word[3]);

                        // Add to the points list
                        pts.Add(new point3d(nd_id, x * scale_fctr, y * scale_fctr, z * scale_fctr));
                        continue;
                    }

                    if (read_flg == 2)
                    {
                        // Read the polygons
                        str_line = str_line.Replace(" ", "");
                        if (str_line == "$$$$")
                        {
                            read_flg = 3;
                            continue;
                        }

                        str_word = str_line.Split(',');

                        // Parse the polygon data
                        int poly_id = int.Parse(str_word[0]);
                        List<int> poly_nd_ids = new List<int>();

                        // Get all the node ids
                        int i = 0;
                        for (i = 1; i < str_word.Count(); i++)
                        {
                            poly_nd_ids.Add(pts.FindIndex(obj => obj.nd_id == int.Parse(str_word[i])));
                        }

                        // Add to the polygon list
                        poly.Add(new polygon3d(poly_id, poly_nd_ids, ref pts));

                        // Create lines for wire frame
                        line3d temp_lin;
                        for (i = 0; i < poly_nd_ids.Count - 1; i++)
                        {
                            temp_lin = new line3d(poly_nd_ids[i], poly_nd_ids[i + 1], ref pts);

                            if (lines.Exists(obj => obj.Equals(temp_lin) == true) == false)
                            {
                                lines.Add(temp_lin);
                            }
                        }

                        // Add the final line
                        temp_lin = new line3d(poly_nd_ids[poly_nd_ids.Count - 1], poly_nd_ids[0], ref pts);
                        if (lines.Exists(obj => obj.Equals(temp_lin) == true) == false)
                        {
                            lines.Add(temp_lin);
                        }
                    }

                }
            }
        }

        public void update_graphics_rotation(double[,] r_matrix)
        {
            lock (paintLock)
            {
                // update all the points with the rotation matrix
                for (int i = 0; i < pts.Count; i++)
                {
                    pts[i].set_screent_pt = r_matrix;
                }

                // variable to store the paint order
                poly_paint_order_ids = new List<int>();

                for (int i = 0; i < poly.Count; i++)
                {
                    poly[i].set_z_order = r_matrix;
                    // Sort the Z level 
                    // Indexing the z order 
                    poly_paint_order_ids.Insert(insert_sorted_list(poly_paint_order_ids, poly, poly[i].Z_level), i);
                }


                poly_z_max = poly[poly_paint_order_ids[poly_paint_order_ids.Count - 1]].Z_level;
                poly_z_min = poly[poly_paint_order_ids[0]].Z_level;
            }
        }

        public int insert_sorted_list(List<int> z_sorted_index, List<polygon3d> poly_z, double current_z)
        {
            int i;
            for (i = (z_sorted_index.Count - 1); i >= 0; i--)
            {
                double z_values = poly_z[z_sorted_index[i]].Z_level;
                if (z_values < current_z)
                {
                    return (i + 1);
                }
            }
            return 0;
        }

        public void paint_all(ref Graphics gr0, double[,] r_matrix )
        {
            // Paint points
            if (global_static.is_showpts == true)
            {
                foreach (point3d pt in pts)
                {
                    pt.paint_pt(ref gr0);
                }
            }

            // Paint polygons
            if (global_static.is_showpolygons == true)
            {
                foreach (int z_index in poly_paint_order_ids)
                {
                    poly[z_index].paint_polygon(ref gr0, ref pts, poly_z_max, poly_z_min);
                }

            }

            // Paint Lines
            gr0.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (global_static.is_showlines == true)
            {
                foreach (line3d ln in lines)
                {
                    ln.paint_line(ref gr0, ref pts);
                }
            }

        }


        public class point3d
        {
            private int _nd_id;
            private double _x, _y, _z;
            private PointF screen_pt;

            public double x { get { return _x; } }

            public double y { get { return _y; } }

            public double z { get { return _z; } }

            public int nd_id
            {
                get { return _nd_id; }
            }

            public point3d(int t_nd_id, double tx, double ty, double tz)
            {
                _nd_id = t_nd_id;
                _x = tx;
                _y = ty;
                _z = tz;
            }

            public PointF get_screen_pt
            {
                get { return screen_pt; }
            }

            public double[,] set_screent_pt
            {
                // write only property to update the 3d point to 2d screen point
                set
                {
                    double sx, sy;
                    sx = value[0, 0] * _x + value[0, 1] * _y + value[0, 2] * _z;
                    sy = value[1, 0] * _x + value[1, 1] * _y + value[1, 2] * _z;
                    screen_pt = new PointF((float)sx, (float)sy);
                }
            }

            public point3d get_mid(List<point3d> pts)
            {
                int id = -10 * pts.Count;
                double x = 0, y = 0, z = 0;

                for (int i = 0; i < pts.Count; i++)
                {
                    x = x + pts[i]._x;
                    y = y + pts[i]._y;
                    z = z + pts[i]._z;
                }

                x = x / pts.Count;
                y = y / pts.Count;
                z = z / pts.Count;

                return new point3d(id, x, y, z);
            }

            public void paint_pt(ref Graphics gr0)
            {
                gr0.FillEllipse(Brushes.BlueViolet, screen_pt.X - 2, screen_pt.Y - 2, 4, 4);
            }
        }

        public class line3d
        {
            int start_nd_index;
            int end_nd_index;
            point3d _ln_center;

            public point3d ln_center
            {
                get { return _ln_center; }
                set { _ln_center = value; }
            }

            public override bool Equals(object obj)
            {
                return ((this.start_nd_index == ((line3d)obj).start_nd_index) &&
                        (this.end_nd_index == ((line3d)obj).end_nd_index)) ||
                        ((this.start_nd_index == ((line3d)obj).end_nd_index) &&
                        (this.end_nd_index == ((line3d)obj).start_nd_index));

            }

            public line3d(int n1, int n2, ref List<point3d> pts)
            {
                start_nd_index = n1;
                end_nd_index = n2;
                _ln_center = new point3d(-13, 0, 0, 0).get_mid(new List<point3d> { pts[n1], pts[n2] });
            }

            public void paint_line(ref Graphics gr0, ref List<point3d> all_pts)
            {
                gr0.DrawLine(new Pen(Brushes.DarkBlue, 1), all_pts[start_nd_index].get_screen_pt, all_pts[end_nd_index].get_screen_pt);

                //  _ln_center.paint_pt(ref gr0);
            }

            public override int GetHashCode()
            {
                return start_nd_index.GetHashCode() ^ end_nd_index.GetHashCode();
            }
        }

        public class polygon3d
        {
            int poly_id;
            List<int> poly_nd_id = new List<int>();
            point3d _poly_center;
            double _Z_level;

            public double Z_level { get { return _Z_level; } }

            public point3d poly_center
            {
                get { return _poly_center; }
                set { _poly_center = value; }
            }

            public double[,] set_z_order
            {
                set
                {
                    _poly_center.set_screent_pt = value;
                    _Z_level = (_poly_center.x * value[2, 0] + _poly_center.y * value[2, 1] + _poly_center.z * value[2, 2]);
                }
            }

            public polygon3d(int tpoly_id, List<int> t_poly_nd_id, ref List<point3d> pts)
            {
                poly_id = tpoly_id;
                poly_nd_id = t_poly_nd_id;

                List<point3d> temp_pts = new List<point3d>();
                foreach (int i in t_poly_nd_id)
                {
                    temp_pts.Add(pts[i]);
                }
                _poly_center = new point3d(-13, 0, 0, 0).get_mid(temp_pts);
            }

            public void paint_polygon(ref Graphics gr0, ref List<point3d> all_pts, double z_max, double z_min)
            {
                // gr0.DrawLine(new Pen(Brushes.DarkBlue, 2), all_pts[start_nd_index].get_screen_pt, all_pts[end_nd_index].get_screen_pt);

                double z_normailed = ((_Z_level - z_min) / (z_max - z_min));

                //if (double.IsNaN(z_normailed) == true)
                //{
                //    int stop = 0;
                //    stop = 1;

                //}

                //    return;

                int alpha = (int)((1 - z_normailed));

                Color poly_color = HSLtoRGB(15, z_normailed, 0.5);
                SolidBrush br = new SolidBrush(poly_color);


                PointF[] poly_pts = new PointF[poly_nd_id.Count];

                for (int i = 0; i < poly_nd_id.Count; i++)
                {
                    poly_pts[i] = all_pts[poly_nd_id[i]].get_screen_pt;
                }

                gr0.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                gr0.FillPolygon(br, poly_pts);

                // gr0.DrawString(((int)(_Z_level - z_min)).ToString(), new Font("Verdana", 10), Brushes.Black, _poly_center.get_screen_pt);
                // _poly_center.paint_pt(ref gr0);
            }


            // 0    : blue   (hsl(240, 100%, 50%))
            // 0.25 : cyan   (hsl(180, 100%, 50%))
            // 0.5  : green  (hsl(120, 100%, 50%))
            // 0.75 : yellow (hsl(60, 100%, 50%))
            // 1    : red    (hsl(0, 100%, 50%))
            // The below code is from https://www.programmingalgorithms.com/algorithm/hsl-to-rgb
            public static Color HSLtoRGB(double hsl_H, double hsl_S, double hsl_L)
            {

                int r = 0;
                int g = 0;
                int b = 0;

                if (hsl_S == 0)
                {
                    r = g = b = (int)(hsl_L * 255);
                }
                else
                {
                    double v1, v2;
                    double hue = hsl_H / 360;

                    v2 = (hsl_L < 0.5) ? (hsl_L * (1 + hsl_S)) : ((hsl_L + hsl_S) - (hsl_L * hsl_S));
                    v1 = 2 * hsl_L - v2;

                    r = (int)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
                    g = (int)(255 * HueToRGB(v1, v2, hue));
                    b = (int)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
                }

                return Color.FromArgb(180, r, g, b);
            }

            private static double HueToRGB(double v1, double v2, double vH)
            {
                if (vH < 0)
                    vH += 1;

                if (vH > 1)
                    vH -= 1;

                if ((6 * vH) < 1)
                    return (v1 + (v2 - v1) * 6 * vH);

                if ((2 * vH) < 1)
                    return v2;

                if ((3 * vH) < 2)
                    return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

                return v1;
            }
        }

    }
}
