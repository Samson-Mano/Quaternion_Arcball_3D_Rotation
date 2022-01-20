using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Arcball_3dRotation
{
    public class threeD_rotation
    {
        private readonly object matrixLock = new object();
        private ArcBall arcball_control = new ArcBall(100, 100);

        Matrix4f Last_transformation = new Matrix4f();
        Matrix4f This_transformation = new Matrix4f();

        public double[,] rotation_matrix
        {
            get { return This_transformation.rotationM; }
        }

        public Quaternion4f rotation_matrix_quaternion
        {
            get { return This_transformation.m_quat; }
        }

        public threeD_rotation()
        {
            // set initial rotation
        }

        public void paint_rotation_values(Graphics gr0, int mp_width, int mp_height, bool IsleftDrag)
        {
            // Start and End Vector
            string svect_str = string.Format("Start Vector : ({0}, {1}, {2})" + Environment.NewLine, arcball_control.start_vector.xi, arcball_control.start_vector.yj, arcball_control.start_vector.zk);
            string evect_str = string.Format("End Vector : ({0}, {1}, {2})" + Environment.NewLine, arcball_control.end_vector.xi, arcball_control.end_vector.yj, arcball_control.end_vector.zk);

            gr0.DrawString(svect_str + evect_str, new Font("Verdana", 8), Brushes.DarkGreen, new PointF(-(float)(mp_width * 0.5f), (float)(mp_height * 0.5f) - 240));

            // Last Transformation Quaternion
            string last_quat_str = string.Format("{0}i + {1}j + {2}k + {3} ", Last_transformation.m_quat.x, Last_transformation.m_quat.y, Last_transformation.m_quat.z, Last_transformation.m_quat.w);
            string paint_qstr2 = "Last Transformation Quaternion:" + Environment.NewLine + last_quat_str;

            gr0.DrawString(paint_qstr2, new Font("Verdana", 8), Brushes.DarkRed, new PointF(-(float)(mp_width * 0.5f), (float)(mp_height * 0.5f) - 200));

            // Last Transformation Rotation
            string last_rot_str_row1 = string.Format("| {0} {1} {2} |" + Environment.NewLine, Last_transformation.rotationM[0, 0], Last_transformation.rotationM[0, 1], Last_transformation.rotationM[0, 2]);
            string last_rot_str_row2 = string.Format("| {0} {1} {2} |" + Environment.NewLine, Last_transformation.rotationM[1, 0], Last_transformation.rotationM[1, 1], Last_transformation.rotationM[1, 2]);
            string last_rot_str_row3 = string.Format("| {0} {1} {2} |" + Environment.NewLine, Last_transformation.rotationM[2, 0], Last_transformation.rotationM[2, 1], Last_transformation.rotationM[2, 2]);
            // string last_rot_str_row4 = string.Format("| {0} {1} {2} {3} |" + Environment.NewLine, Last_transformation.rotationM[3, 0], Last_transformation.rotationM[3, 1], Last_transformation.rotationM[3, 2], Last_transformation.rotationM[3, 3]);

            string last_rot_str = last_rot_str_row1 + last_rot_str_row2 + last_rot_str_row3;

            gr0.DrawString(last_rot_str, new Font("Verdana", 8), Brushes.DarkRed, new PointF(-(float)(mp_width * 0.5f), (float)(mp_height * 0.5f) - 160));

            // This Transformation Quaternion
            string this_quat_str = string.Format("{0}i + {1}j + {2}k + {3} ", This_transformation.m_quat.x, This_transformation.m_quat.y, This_transformation.m_quat.z, This_transformation.m_quat.w);
            string paint_qstr1 = "This Transformation Quaternion:" + Environment.NewLine + this_quat_str;

            gr0.DrawString(paint_qstr1, new Font("Verdana", 8), Brushes.DarkBlue, new PointF(-(float)(mp_width * 0.5f), (float)(mp_height * 0.5f) - 100));

            // This Transformation Rotation
            string this_rot_str_row1 = string.Format("| {0} {1} {2} |" + Environment.NewLine, This_transformation.rotationM[0, 0], This_transformation.rotationM[0, 1], This_transformation.rotationM[0, 2]);
            string this_rot_str_row2 = string.Format("| {0} {1} {2} |" + Environment.NewLine, This_transformation.rotationM[1, 0], This_transformation.rotationM[1, 1], This_transformation.rotationM[1, 2]);
            string this_rot_str_row3 = string.Format("| {0} {1} {2} |" + Environment.NewLine, This_transformation.rotationM[2, 0], This_transformation.rotationM[2, 1], This_transformation.rotationM[2, 2]);
            // string this_rot_str_row4 = string.Format("| {0} {1} {2} {3} |" + Environment.NewLine, This_transformation.rotationM[3, 0], This_transformation.rotationM[3, 1], This_transformation.rotationM[3, 2], This_transformation.rotationM[3, 3]);

            string this_rot_str = this_rot_str_row1 + this_rot_str_row2 + this_rot_str_row3;

            gr0.DrawString(this_rot_str, new Font("Verdana", 8), Brushes.DarkBlue, new PointF(-(float)(mp_width * 0.5f), (float)(mp_height * 0.5f) - 60));

            if (IsleftDrag == true)
            {
                // Paint vectors
               //  arcball_control.paint_vectors(gr0, rotation_matrix);
            }

        }

        public void startRotationDrag(PointF MousePt)
        {
            /* SyncLock is used to protect data from being updated by more than one thread simultaneously. 
             * If the statements that manipulate the data must go to completion without interruption,
             * put them inside a SyncLock block.
             */
            lock (matrixLock)
            {
                // Last Transformation = This Transformation
                Last_transformation = new Matrix4f(This_transformation.m_quat);
            }
            arcball_control.mouse_down(MousePt);
        }

        public void Rotationdrag(PointF MousePt)
        {
            // Update End Vector And Get Rotation As Quaternion
            Quaternion4f ThisQuat = arcball_control.mouse_drag(MousePt);

            lock (matrixLock)
            {
                // Perform Rotation (convert quaternion to rotation matrix)
                This_transformation = new Matrix4f(ThisQuat);
                // Amend it to previous rotation
                This_transformation = Matrix4f.Quaternion_multiply(This_transformation, Last_transformation);
            }
        }

        public void set_predetermined_rotation(Quaternion4f q_matrix)
        {
            // Set the pre-determined rotation matrix
            This_transformation = new Matrix4f(q_matrix);
        }

        public void update_arcball(double MPWidth, double MPHeight)
        {
            arcball_control = new ArcBall(MPWidth, MPHeight);
        }

        public class ArcBall
        {
            Vector3f StVec = new Vector3f(0, 0, 0); // Saved Click Vector
            Vector3f EnVec = new Vector3f(0, 0, 0); // Saved Drag Vector
            double adjusted_width, adjusted_height;
            private double canvas_width, canvas_height;

            public Vector3f start_vector { get { return StVec; } }

            public Vector3f end_vector { get { return EnVec; } }

            public ArcBall(double new_width, double new_height)
            {
                StVec = new Vector3f(0, 0, 0);
                EnVec = new Vector3f(0, 0, 0);
               // set_bounds(new_width, new_height);

                // Set adjustment factor for width/height
                adjusted_width = 1.0f / ((new_width - 1.0f) * 0.5f);
                adjusted_height = 1.0f / ((new_height - 1.0f) * 0.5f);

                canvas_width = new_width;
                canvas_height = new_height;
            }

            public Vector3f map_to_sphere(PointF tempPt)
            {
                double tx, ty;
                Vector3f vector;

                // Adjust point coords and scale down to range of [-1 ... 1]
                tx = 1.0f - (tempPt.X * this.adjusted_width);
                ty = 1.0f - (tempPt.Y * this.adjusted_height);

                // Compute square of the length of the vector from this point to the center
                double quadrance = ((tx * tx) + (ty * ty));

                if (quadrance > 1.0f)
                {
                    // the point is mapped outside the sphere... (length > radius squared)
                    // Compute a normalizing factor (radius / length)
                    double norm = 1.0f / Math.Sqrt(quadrance);
                    vector = new Vector3f(tx * norm, ty * norm, 0.0f);
                }
                else
                {
                    // the point is mapped inside the sphere... (length <= radius squared)
                    // return a vector to a point mapped inside the sphere sqrt(radius squared - length)
                    vector = new Vector3f(tx, ty, Math.Sqrt(1.0f - quadrance));
                }
                return vector;
            }

            public void mouse_down(PointF curr_Pt)
            {
                // Mouse down -> Map to sphere the clicked point
                this.StVec = map_to_sphere(curr_Pt);
            }

            public Quaternion4f mouse_drag(PointF curr_Pt)
            {
                Quaternion4f newRot;

                // Mouse drag -> Actively map the drag pt to sphere
                this.EnVec = map_to_sphere(curr_Pt);

                // Compute the vector perpendicular to the begin and end vectors
                Vector3f Perp = Vector3f.cross_product(StVec, EnVec);

                if (Perp.vector_length() > 0.000001f)
                {
                    // return the perpendicular vector as the transform after all
                    //  w is cosine (theta / 2), where theta is the rotation angle
                    newRot = new Quaternion4f(Perp.xi, Perp.yj, Perp.zk, Vector3f.dot_product(StVec, EnVec));
                }
                else
                {
                    newRot = new Quaternion4f(0, 0, 0, 1);
                }
                return newRot;
            }

            public void paint_vectors(Graphics gr0, double[,] rot_matrix)
            {
                double[,] null_rot = new double[4, 4];
                null_rot[0, 0] = 1.0f;
                null_rot[1, 1] = 1.0f;
                null_rot[2, 2] = 1.0f;

                draw_obj_store.point3d origin = new draw_obj_store.point3d(-97, 0, 0, 0);
                origin.set_screent_pt = null_rot;

                //double st_v_x = ((1.0f - start_vector.xi) / this.adjusted_width);
                //double st_v_y = ((1.0f - start_vector.yj) / this.adjusted_height);
                //double c =(canvas_width * canvas_width + canvas_height * canvas_height);
                //double st_v_z =Math.Sqrt(Math.Abs( c - (((st_v_x* st_v_x)/(canvas_width * canvas_width)) + ((st_v_y* st_v_y)/(canvas_height * canvas_height)))));
                double vect_scale = 300f;

                double st_v_x = -start_vector.xi* vect_scale;
                double st_v_y = -start_vector.yj* vect_scale;
                double st_v_z = start_vector.zk* vect_scale;

                draw_obj_store.point3d st_vector = new draw_obj_store.point3d(-97, st_v_x, st_v_y, st_v_z);
               st_vector.set_screent_pt = null_rot;

                double ed_v_x = -end_vector.xi* vect_scale;
                double ed_v_y = -end_vector.yj* vect_scale;
                double ed_v_z = end_vector.zk* vect_scale;

                draw_obj_store.point3d ed_vector = new draw_obj_store.point3d(-97, ed_v_x, ed_v_y, ed_v_z);
                ed_vector.set_screent_pt = null_rot;

              Vector3f n_vector =    Vector3f.cross_product(StVec, EnVec);

                double n_v_x = -n_vector.xi * vect_scale;
                double n_v_y = -n_vector.yj * vect_scale;
                double n_v_z = n_vector.zk * vect_scale;

                draw_obj_store.point3d n_vector_pt = new draw_obj_store.point3d(-97, n_v_x, n_v_y, n_v_z);
                n_vector_pt.set_screent_pt = null_rot;

                
                using (Pen p1 = new Pen(Brushes.DarkGray,4))
                {
                    Point[] pth_pts = new Point[] { new Point(-2,-2), new Point(0, 0), new Point(2,-2) };
                    System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                    pth.AddLines(pth_pts);
                    System.Drawing.Drawing2D.CustomLineCap pth_cap = new System.Drawing.Drawing2D.CustomLineCap(null, pth);

                    p1.CustomEndCap = pth_cap;

                    // Paint start vector
                    p1.Color = Color.CadetBlue;
                    gr0.DrawLine(p1, origin.get_screen_pt, st_vector.get_screen_pt);

                    // Pain end vector
                    p1.Color = Color.MediumOrchid;
                    gr0.DrawLine(p1, origin.get_screen_pt, ed_vector.get_screen_pt);

                    // Paint Perpendicular vector
                    p1.Color = Color.YellowGreen;
                    gr0.DrawLine(p1, origin.get_screen_pt, n_vector_pt.get_screen_pt);
                }

            }
        }

        public class Vector3f
        {
            private double _xi, _yj, _zk;

            public double xi { get { return _xi; } }
            public double yj { get { return _yj; } }
            public double zk { get { return _zk; } }

            public Vector3f(double t_xi, double t_yj, double t_zk)
            {
                _xi = t_xi;
                _yj = t_yj;
                _zk = t_zk;
            }

            public static Vector3f cross_product(Vector3f v1, Vector3f v2)
            {
                return (new Vector3f((v1.yj * v2.zk) - (v1.zk * v2.yj),
                    (v1.zk * v2.xi) - (v1.xi * v2.zk),
                     (v1.xi * v2.yj) - (v1.yj * v2.xi)));
            }

            public static double dot_product(Vector3f v1, Vector3f v2)
            {
                return ((v1.xi * v2.xi) + (v1.yj * v2.yj) + (v1.zk + v2.zk));
            }

            public double vector_length()
            {
                return (Math.Sqrt((_xi * _xi) + (_yj * _yj) + (_zk * _zk)));
            }
        }

        public class Quaternion4f
        {
            private double _x, _y, _z, _w;

            public double x { get { return _x; } }
            public double y { get { return _y; } }
            public double z { get { return _z; } }
            public double w { get { return _w; } }

            public Quaternion4f(double tx, double ty, double tz, double tw)
            {
                // Constructor 1 x,y,z,w
                _x = tx;
                _y = ty;
                _z = tz;
                _w = tw;

                normailze_quaternion();
            }

            public Quaternion4f(double[,] rot_matrix)
            {
                double trace = rot_matrix[0, 0] + rot_matrix[1, 1] + rot_matrix[2, 2]; // I removed + 1.0f; see discussion with Ethan
                if (trace > 0)
                {// I changed M_EPSILON to 0
                    double s = 0.5f / Math.Sqrt(trace + 1.0f);
                    this._w = 0.25f / s;
                    this._x = (rot_matrix[2, 1] - rot_matrix[1, 2]) * s;
                    this._y = (rot_matrix[0, 2] - rot_matrix[2, 0]) * s;
                    this._z = (rot_matrix[1, 0] - rot_matrix[0, 1]) * s;
                }
                else
                {
                    if (rot_matrix[0, 0] > rot_matrix[1, 1] && rot_matrix[0, 0] > rot_matrix[2, 2])
                    {
                        double s = 2.0f * Math.Sqrt(1.0f + rot_matrix[0, 0] - rot_matrix[1, 1] - rot_matrix[2, 2]);
                        this._w = (rot_matrix[2, 1] - rot_matrix[1, 2]) / s;
                        this._x = 0.25f * s;
                        this._y = (rot_matrix[0, 1] + rot_matrix[1, 0]) / s;
                        this._z = (rot_matrix[0, 2] + rot_matrix[2, 0]) / s;
                    }
                    else if (rot_matrix[1, 1] > rot_matrix[2, 2])
                    {
                        double s = 2.0f * Math.Sqrt(1.0f + rot_matrix[1, 1] - rot_matrix[0, 0] - rot_matrix[2, 2]);
                        this._w = (rot_matrix[0, 2] - rot_matrix[2, 0]) / s;
                        this._x = (rot_matrix[0, 1] + rot_matrix[1, 0]) / s;
                        this._y = 0.25f * s;
                        this._z = (rot_matrix[1, 2] + rot_matrix[2, 1]) / s;
                    }
                    else
                    {
                        double s = 2.0f * Math.Sqrt(1.0f + rot_matrix[2, 2] - rot_matrix[0, 0] - rot_matrix[1, 1]);
                        this._w = (rot_matrix[1, 0] - rot_matrix[0, 1]) / s;
                        this._x = (rot_matrix[0, 2] + rot_matrix[2, 0]) / s;
                        this._y = (rot_matrix[1, 2] + rot_matrix[2, 1]) / s;
                        this._z = 0.25f * s;
                    }
                }
            }

            private void normailze_quaternion()
            {
                double norm = Math.Sqrt((w * w) + (x * x) + (y * y) + (z * z));
                if (norm != 0)
                {
                    // To avoid NAN error
                    this._x = this._x / norm;
                    this._y = this._y / norm;
                    this._z = this._z / norm;
                    this._w = this._w / norm;
                }

            }

            public double[,] get_rotationM()
            {
                // 4 x 4 Matrix
                double[,] rslt = new double[4, 4];
                // normailze_quaternion();

                // First row of the rotation matrix
                rslt[0, 0] = 2 * (w * w + x * x) - 1;
                rslt[0, 1] = 2 * (x * y - w * z);
                rslt[0, 2] = 2 * (x * z + w * y);
                rslt[0, 3] = 0.0;

                // Second row of the rotation matrix
                rslt[1, 0] = 2 * (x * y + w * z);
                rslt[1, 1] = 2 * (w * w + y * y) - 1;
                rslt[1, 2] = 2 * (y * z - w * x);
                rslt[1, 3] = 0.0;

                // Third row of the rotation matrix
                rslt[2, 0] = 2 * (x * z - w * y);
                rslt[2, 1] = 2 * (y * z + w * x);
                rslt[2, 2] = 2 * (w * w + z * z) - 1;
                rslt[2, 3] = 0.0;

                // (Dummy) Fourth row of the rotation matrix
                rslt[3, 0] = 0.0;
                rslt[3, 1] = 0.0;
                rslt[3, 2] = 0.0;
                rslt[3, 3] = 0.0;

                return rslt;
            }

            public static Quaternion4f quaternion_multiply(Quaternion4f Q1, Quaternion4f Q2)
            {
                // Multiplying two quaternions together has the effect of performing one rotation around an axis
                // and then performing another rotation about around an axis.
                double q1q2_w, q1q2_x, q1q2_y, q1q2_z;

                // Computer the product of the two quaternions, term by term
                q1q2_w = (Q1.w * Q2.w) - (Q1.x * Q2.x) - (Q1.y * Q2.y) - (Q1.z * Q2.z);
                q1q2_x = (Q1.w * Q2.x) + (Q1.x * Q2.w) + (Q1.y * Q2.z) - (Q1.z * Q2.y);
                q1q2_y = (Q1.w * Q2.y) - (Q1.x * Q2.z) + (Q1.y * Q2.w) + (Q1.z * Q2.x);
                q1q2_z = (Q1.w * Q2.z) + (Q1.x * Q2.y) - (Q1.y * Q2.x) + (Q1.z * Q2.w);

                // Create the final quaternion
                Quaternion4f rslt_q = new Quaternion4f(q1q2_x, q1q2_y, q1q2_z, q1q2_w);
                // rslt_q.normailze_quaternion();
                return rslt_q;
            }
        }

        public class Matrix4f
        {
            // 4 x 4 Matrix
            private double[,] _rotationM = new double[4, 4];

            private Quaternion4f _m_quat;

            public double[,] rotationM
            {
                get { return _rotationM; }
                set
                {
                    // used in matrix multiplication & preset view
                    _rotationM = value;
                }
            }

            public Quaternion4f m_quat
            { get { return _m_quat; } }

            public Matrix4f()
            {
                // Empty constructor
                for (int i = 0; i < 4; i++)
                {
                    this._rotationM[i, i] = 1.0F;
                }

                // Isometric 1 as default
                this._rotationM[0, 0] = 0.67969810962677;
                this._rotationM[0, 1] = 0.718355774879456;
                this._rotationM[0, 2] = -0.148240596055985;

                this._rotationM[1, 0] = 0.199809849262238;
                this._rotationM[1, 1] = -0.375794619321823;
                this._rotationM[1, 2] = -0.904905796051025;

                this._rotationM[2, 0] = -0.705752372741699;
                this._rotationM[2, 1] = 0.585442781448364;
                this._rotationM[2, 2] = -0.398961365222931;

                // Initialize the quaternion with the rotation matrix
                this._m_quat = new Quaternion4f(_rotationM);
            }

            public Matrix4f(Quaternion4f qf)
            {
                // Constructor 1 Quaternion
                this._m_quat = new Quaternion4f(qf.x, qf.y, qf.z, qf.w);
                this._rotationM = this._m_quat.get_rotationM();
            }

            public Matrix4f(double[,] rot_m)
            {
                // Constructor 2 Rotation matrix
                this._rotationM = rot_m;
                this._m_quat = new Quaternion4f(rot_m);
            }

            public static Matrix4f Matrix_multiply(Matrix4f m1, Matrix4f m2)
            {
                double[,] rslt = new double[4, 4];

                int i, j, k;

                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        double mat_elm = 0.0;
                        for (k = 0; k < 4; k++)
                        {
                            mat_elm = mat_elm + (m1.rotationM[i, k] * m2.rotationM[k, j]);
                        }
                        rslt[i, j] = mat_elm;
                    }
                }

                // Quaternion4f rslt_in_quaternion = Quaternion4f.quaternion_multiply(m1.this_quat, m2.this_quat);


                // Matrix4f mult_rslt = new Matrix4f( rslt);
                // mult_rslt.rotationM = rslt_in_quaternion.get_rotationM(); // set the rotation matrix
                return (new Matrix4f(rslt));
            }

            public static Matrix4f Quaternion_multiply(Matrix4f m1, Matrix4f m2)
            {
                Quaternion4f rslt = Quaternion4f.quaternion_multiply(m1.m_quat, m2.m_quat);
                return (new Matrix4f(rslt));
            }
        }
    }
}
