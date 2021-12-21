using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcball_3dRotation
{
    public partial class main_form : Form
    {
        private bool IsleftDrag = false;
        private animate_rotation_control anim_control;
        private threeD_rotation threeD_control = new threeD_rotation();
        private PointF MidPt = new PointF(0, 0);
        private draw_obj_store draw_obj = new draw_obj_store(1);

        public main_form()
        {
            InitializeComponent();
        }

        #region "Main Panel code controlled events"
        private void main_pic_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.TranslateTransform(MidPt.X, MidPt.Y);

            if (IsleftDrag == false)
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Paint rotation center
            e.Graphics.DrawLine(Pens.Black, -5, 0, 5, 0);
            e.Graphics.DrawLine(Pens.Black, 0, -5, 0, 5);

            Graphics gr0 = e.Graphics;
            draw_obj.paint_all(ref gr0, threeD_control.rotation_matrix);

            // Paint the rotation variables
            if (global_static.is_showmatrix == true)
            {
                threeD_control.paint_rotation_values(gr0, main_pic.Width, main_pic.Height,IsleftDrag);
            }
        }

        private void main_pic_SizeChanged(object sender, EventArgs e)
        {
            MidPt = new PointF((main_pic.Width * 0.5f), (main_pic.Height * 0.5f));
            threeD_control.update_arcball(main_pic.Width, main_pic.Height);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }
        #endregion

        #region "Main Panel mouse events"
        private void main_pic_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Rotate operation starts
                IsleftDrag = true;
                // RotateStartDrag = new PointF(e.X, e.Y);
                threeD_control.startRotationDrag(new PointF(e.X, e.Y));
                draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            }
            mt_pic.Refresh();
        }

        private void main_pic_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsleftDrag == true)
            {
                // Rotate operation in progress
                threeD_control.Rotationdrag(new PointF(e.X, e.Y));
                draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
                mt_pic.Refresh();
            }
        }

        private void main_pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Rotate operation stops
                IsleftDrag = false;
            }
            mt_pic.Refresh();
        }
        #endregion

        #region "Menu objects user events"

        private void showPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global_static.is_showpts = showPointsToolStripMenuItem.Checked;
            mt_pic.Refresh();

        }

        private void showLinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global_static.is_showlines = showLinesToolStripMenuItem.Checked;
            mt_pic.Refresh();
        }

        private void showFaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global_static.is_showpolygons = showFaceToolStripMenuItem.Checked;
            mt_pic.Refresh();
        }

        private void showMatrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            global_static.is_showmatrix = showMatrixToolStripMenuItem.Checked;
            mt_pic.Refresh();
        }

        private void cubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw_obj = new draw_obj_store(1);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        private void sphereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw_obj = new draw_obj_store(2);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        private void cylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw_obj = new draw_obj_store(3);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        private void donutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw_obj = new draw_obj_store(4);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        private void kleinBottleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw_obj = new draw_obj_store(5);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        private void frontViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Front view
            anim_control = new animate_rotation_control(3, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void topViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anim_control = new animate_rotation_control(1, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void leftsideViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Left side view
            anim_control = new animate_rotation_control(2, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void rightSideViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Rigt side view
            anim_control = new animate_rotation_control(7, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void bottomViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Bottom view
            anim_control = new animate_rotation_control(6, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void backViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Back view
            anim_control = new animate_rotation_control(8, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void isometricView1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Isometric view 1
            anim_control = new animate_rotation_control(4, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void isometricView2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Isometric view 2
            anim_control = new animate_rotation_control(5, threeD_control.rotation_matrix_quaternion);

            threeD_control.set_predetermined_rotation(anim_control.pview_Q);

            // Set iterative rotation
            timer_main.Start();
            mt_pic.Refresh();
        }

        private void timer_main_Tick(object sender, EventArgs e)
        {
            bool continue_anim = anim_control.animate_preset_rotation();

            if (continue_anim == false)
            {
                timer_main.Stop();
                draw_obj.update_graphics_rotation(anim_control.pview_Q.get_rotationM());
                mt_pic.Refresh();
            }
            else
            {
                // anim_control.animate_preset_rotation();
                draw_obj.update_graphics_rotation(anim_control.inter_Q.get_rotationM());
                mt_pic.Refresh();
            }

        }
        #endregion

        private void main_form_Load(object sender, EventArgs e)
        {
            MidPt = new PointF((main_pic.Width * 0.5f), (main_pic.Height * 0.5f));
            threeD_control.update_arcball(main_pic.Width, main_pic.Height);

            // Timer variable
            timer_main.Interval = 100;

            draw_obj = new draw_obj_store(1);
            draw_obj.update_graphics_rotation(threeD_control.rotation_matrix);
            mt_pic.Refresh();
        }

        public class animate_rotation_control
        {
            private int timer_tick_control = 0;
     
            threeD_rotation.Quaternion4f _curr_Q;
            threeD_rotation.Quaternion4f _inter_Q; // Intermediate rotation quaternion
            threeD_rotation.Quaternion4f _pview_Q; // Final rotation quaternion

            public threeD_rotation.Quaternion4f inter_Q
            { get { return _inter_Q; } }

            public threeD_rotation.Quaternion4f pview_Q
            { get { return _pview_Q; } }


            public animate_rotation_control(int view_type, threeD_rotation.Quaternion4f current_Q)
            {
                timer_tick_control = 0;
                set_final_rot_matrix(view_type);

                // Current view rotation Quaternion
                _curr_Q = new threeD_rotation.Quaternion4f(current_Q.x, current_Q.y, current_Q.z, current_Q.w);
            }

            private void set_final_rot_matrix(int v_type)
            {
                switch (v_type)
                {
                    case 1:
                        {
                            // Top view
                            _pview_Q = new threeD_rotation.Quaternion4f(1.000000000000000, 0.000000000000000, 0.000000000000000, 0.000000000000000);
                            break;
                        }
                    case 2:
                        {
                            // Left Side view
                            _pview_Q = new threeD_rotation.Quaternion4f(-0.500000000000000, -0.500000000000000, 0.500000000000000, -0.500000000000000);
                            break;
                        }
                    case 3:
                        {
                            // Front view
                            _pview_Q = new threeD_rotation.Quaternion4f(0.707106781186547, 0.000000000000000, 0.000000000000000, 0.707106781186547);
                            break;
                        }
                    case 4:
                        {
                            // Isometric view 1
                            _pview_Q = new threeD_rotation.Quaternion4f(0.783334873181886, 0.293031006143046, -0.272550411718805, 0.475642228031299);
                            break;
                        }
                    case 5:
                        {
                            // Isometric view 2
                            _pview_Q = new threeD_rotation.Quaternion4f(0.376691123199379, 0.824789807607495, -0.390767474556833, 0.158513143439520);
                            break;
                        }
                    case 6:
                        {
                            // Bottom view
                            _pview_Q = new threeD_rotation.Quaternion4f(0.000000000000000, 0.000000000000000, 1.000000000000000, 0.000000000000000);
                            break;
                        }
                    case 7:
                        {
                            // Right Side view
                            _pview_Q = new threeD_rotation.Quaternion4f(0.500000000000000, -0.500000000000000, 0.500000000000000, 0.500000000000000);
                            break;
                        }
                    case 8:
                        {
                            // Back view
                            _pview_Q = new threeD_rotation.Quaternion4f(0.000000000000000, 0.707106781186547, -0.707106781186547, 0.000000000000000);
                            break;
                        }

                        //                        x y   z w
                        //Front view  0.707106781186547   0.000000000000000   0.000000000000000   0.707106781186547
                        //Back view   0.000000000000000   0.707106781186547 - 0.707106781186547  0.000000000000000
                        //Top view    1.000000000000000   0.000000000000000   0.000000000000000   0.000000000000000
                        //Bottom view 0.000000000000000   0.000000000000000   1.000000000000000   0.000000000000000
                        //Left Side view - 0.500000000000000 - 0.500000000000000  0.500000000000000 - 0.500000000000000
                        //Right Side view 0.500000000000000 - 0.500000000000000  0.500000000000000   0.500000000000000


                        //Isometric 1 0.783334873181886   0.293031006143046 - 0.272550411718805  0.475642228031299
                        //Isometric 2 0.376691123199379   0.824789807607495 - 0.390767474556833  0.158513143439520


                }
            }

            public bool animate_preset_rotation()
            {
                if (timer_tick_control == 10)
                {
                    timer_tick_control = 0;
                    return false; // False means stop the clock
                }
                else
                {
                    timer_tick_control++;
                    double ticker_t = (timer_tick_control / 10.0f);

                    double tx, ty, tz, tw;

                    tx = (_curr_Q.x * (1 - ticker_t)) + (_pview_Q.x * ticker_t);
                    ty = (_curr_Q.y * (1 - ticker_t)) + (_pview_Q.y * ticker_t);
                    tz = (_curr_Q.z * (1 - ticker_t)) + (_pview_Q.z * ticker_t);
                    tw = (_curr_Q.w * (1 - ticker_t)) + (_pview_Q.w * ticker_t);

                    _inter_Q = new threeD_rotation.Quaternion4f(tx, ty, tz, tw);

                    return true; // continue Tick
                }
            }
        }

    }
}
