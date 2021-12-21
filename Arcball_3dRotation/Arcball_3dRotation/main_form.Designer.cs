namespace Arcball_3dRotation
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main_form));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.loadObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sphereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cylinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kleinBottleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMatrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.isometricView2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isometricView1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftsideViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.main_pic = new System.Windows.Forms.Panel();
            this.mt_pic = new System.Windows.Forms.PictureBox();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            this.bottomViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.main_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mt_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadObjectToolStripMenuItem,
            this.objectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // loadObjectToolStripMenuItem
            // 
            this.loadObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem,
            this.sphereToolStripMenuItem,
            this.cylinderToolStripMenuItem,
            this.donutToolStripMenuItem,
            this.kleinBottleToolStripMenuItem});
            this.loadObjectToolStripMenuItem.Name = "loadObjectToolStripMenuItem";
            this.loadObjectToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.loadObjectToolStripMenuItem.Text = "Load";
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cubeToolStripMenuItem.Text = "Cube";
            this.cubeToolStripMenuItem.Click += new System.EventHandler(this.cubeToolStripMenuItem_Click);
            // 
            // sphereToolStripMenuItem
            // 
            this.sphereToolStripMenuItem.Name = "sphereToolStripMenuItem";
            this.sphereToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.sphereToolStripMenuItem.Text = "Sphere";
            this.sphereToolStripMenuItem.Click += new System.EventHandler(this.sphereToolStripMenuItem_Click);
            // 
            // cylinderToolStripMenuItem
            // 
            this.cylinderToolStripMenuItem.Name = "cylinderToolStripMenuItem";
            this.cylinderToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.cylinderToolStripMenuItem.Text = "Cylinder";
            this.cylinderToolStripMenuItem.Click += new System.EventHandler(this.cylinderToolStripMenuItem_Click);
            // 
            // donutToolStripMenuItem
            // 
            this.donutToolStripMenuItem.Name = "donutToolStripMenuItem";
            this.donutToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.donutToolStripMenuItem.Text = "Donut";
            this.donutToolStripMenuItem.Click += new System.EventHandler(this.donutToolStripMenuItem_Click);
            // 
            // kleinBottleToolStripMenuItem
            // 
            this.kleinBottleToolStripMenuItem.Name = "kleinBottleToolStripMenuItem";
            this.kleinBottleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.kleinBottleToolStripMenuItem.Text = "Klein Bottle";
            this.kleinBottleToolStripMenuItem.Click += new System.EventHandler(this.kleinBottleToolStripMenuItem_Click);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPointsToolStripMenuItem,
            this.showLinesToolStripMenuItem,
            this.showFaceToolStripMenuItem,
            this.showMatrixToolStripMenuItem});
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.objectToolStripMenuItem.Text = "Object";
            // 
            // showPointsToolStripMenuItem
            // 
            this.showPointsToolStripMenuItem.Checked = true;
            this.showPointsToolStripMenuItem.CheckOnClick = true;
            this.showPointsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPointsToolStripMenuItem.Name = "showPointsToolStripMenuItem";
            this.showPointsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showPointsToolStripMenuItem.Text = "Show Points";
            this.showPointsToolStripMenuItem.Click += new System.EventHandler(this.showPointsToolStripMenuItem_Click);
            // 
            // showLinesToolStripMenuItem
            // 
            this.showLinesToolStripMenuItem.Checked = true;
            this.showLinesToolStripMenuItem.CheckOnClick = true;
            this.showLinesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLinesToolStripMenuItem.Name = "showLinesToolStripMenuItem";
            this.showLinesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showLinesToolStripMenuItem.Text = "Show Lines";
            this.showLinesToolStripMenuItem.Click += new System.EventHandler(this.showLinesToolStripMenuItem_Click);
            // 
            // showFaceToolStripMenuItem
            // 
            this.showFaceToolStripMenuItem.Checked = true;
            this.showFaceToolStripMenuItem.CheckOnClick = true;
            this.showFaceToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFaceToolStripMenuItem.Name = "showFaceToolStripMenuItem";
            this.showFaceToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showFaceToolStripMenuItem.Text = "Show Faces";
            this.showFaceToolStripMenuItem.Click += new System.EventHandler(this.showFaceToolStripMenuItem_Click);
            // 
            // showMatrixToolStripMenuItem
            // 
            this.showMatrixToolStripMenuItem.Checked = true;
            this.showMatrixToolStripMenuItem.CheckOnClick = true;
            this.showMatrixToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showMatrixToolStripMenuItem.Name = "showMatrixToolStripMenuItem";
            this.showMatrixToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.showMatrixToolStripMenuItem.Text = "Show Matrix";
            this.showMatrixToolStripMenuItem.Click += new System.EventHandler(this.showMatrixToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.isometricView2ToolStripMenuItem,
            this.isometricView1ToolStripMenuItem,
            this.leftsideViewToolStripMenuItem,
            this.rightSideViewToolStripMenuItem,
            this.topViewToolStripMenuItem,
            this.bottomViewToolStripMenuItem,
            this.frontViewToolStripMenuItem,
            this.backViewToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(55, 24);
            this.toolStripDropDownButton1.Text = "View";
            // 
            // isometricView2ToolStripMenuItem
            // 
            this.isometricView2ToolStripMenuItem.Name = "isometricView2ToolStripMenuItem";
            this.isometricView2ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.isometricView2ToolStripMenuItem.Text = "Isometric view 2";
            this.isometricView2ToolStripMenuItem.Click += new System.EventHandler(this.isometricView2ToolStripMenuItem_Click);
            // 
            // isometricView1ToolStripMenuItem
            // 
            this.isometricView1ToolStripMenuItem.Name = "isometricView1ToolStripMenuItem";
            this.isometricView1ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.isometricView1ToolStripMenuItem.Text = "Isometric view 1";
            this.isometricView1ToolStripMenuItem.Click += new System.EventHandler(this.isometricView1ToolStripMenuItem_Click);
            // 
            // leftsideViewToolStripMenuItem
            // 
            this.leftsideViewToolStripMenuItem.Name = "leftsideViewToolStripMenuItem";
            this.leftsideViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.leftsideViewToolStripMenuItem.Text = "Left Side view";
            this.leftsideViewToolStripMenuItem.Click += new System.EventHandler(this.leftsideViewToolStripMenuItem_Click);
            // 
            // topViewToolStripMenuItem
            // 
            this.topViewToolStripMenuItem.Name = "topViewToolStripMenuItem";
            this.topViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.topViewToolStripMenuItem.Text = "Top view";
            this.topViewToolStripMenuItem.Click += new System.EventHandler(this.topViewToolStripMenuItem_Click);
            // 
            // frontViewToolStripMenuItem
            // 
            this.frontViewToolStripMenuItem.Name = "frontViewToolStripMenuItem";
            this.frontViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.frontViewToolStripMenuItem.Text = "Front view";
            this.frontViewToolStripMenuItem.Click += new System.EventHandler(this.frontViewToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(201, 21);
            this.toolStripStatusLabel1.Text = "Left Click and Drag to Rotate";
            // 
            // main_pic
            // 
            this.main_pic.BackColor = System.Drawing.Color.White;
            this.main_pic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.main_pic.Controls.Add(this.mt_pic);
            this.main_pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_pic.Location = new System.Drawing.Point(0, 28);
            this.main_pic.Name = "main_pic";
            this.main_pic.Size = new System.Drawing.Size(800, 396);
            this.main_pic.TabIndex = 2;
            this.main_pic.SizeChanged += new System.EventHandler(this.main_pic_SizeChanged);
            this.main_pic.Paint += new System.Windows.Forms.PaintEventHandler(this.main_pic_Paint);
            this.main_pic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.main_pic_MouseDown);
            this.main_pic.MouseMove += new System.Windows.Forms.MouseEventHandler(this.main_pic_MouseMove);
            this.main_pic.MouseUp += new System.Windows.Forms.MouseEventHandler(this.main_pic_MouseUp);
            // 
            // mt_pic
            // 
            this.mt_pic.BackColor = System.Drawing.Color.Transparent;
            this.mt_pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mt_pic.Enabled = false;
            this.mt_pic.Location = new System.Drawing.Point(0, 0);
            this.mt_pic.Name = "mt_pic";
            this.mt_pic.Size = new System.Drawing.Size(796, 392);
            this.mt_pic.TabIndex = 0;
            this.mt_pic.TabStop = false;
            // 
            // timer_main
            // 
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // bottomViewToolStripMenuItem
            // 
            this.bottomViewToolStripMenuItem.Name = "bottomViewToolStripMenuItem";
            this.bottomViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.bottomViewToolStripMenuItem.Text = "Bottom view";
            this.bottomViewToolStripMenuItem.Click += new System.EventHandler(this.bottomViewToolStripMenuItem_Click);
            // 
            // backViewToolStripMenuItem
            // 
            this.backViewToolStripMenuItem.Name = "backViewToolStripMenuItem";
            this.backViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.backViewToolStripMenuItem.Text = "Back view";
            this.backViewToolStripMenuItem.Click += new System.EventHandler(this.backViewToolStripMenuItem_Click);
            // 
            // rightSideViewToolStripMenuItem
            // 
            this.rightSideViewToolStripMenuItem.Name = "rightSideViewToolStripMenuItem";
            this.rightSideViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.rightSideViewToolStripMenuItem.Text = "Right Side view";
            this.rightSideViewToolStripMenuItem.Click += new System.EventHandler(this.rightSideViewToolStripMenuItem_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.main_pic);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main_form";
            this.Text = "ArcBall 3D Rotation ------------ Programmed by Samson Mano <saminnx@gmail.com>";
            this.Load += new System.EventHandler(this.main_form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.main_pic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mt_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel main_pic;
        private System.Windows.Forms.PictureBox mt_pic;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLinesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem isometricView2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isometricView1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftsideViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frontViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem showMatrixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sphereToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cylinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donutToolStripMenuItem;
        private System.Windows.Forms.Timer timer_main;
        private System.Windows.Forms.ToolStripMenuItem kleinBottleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightSideViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backViewToolStripMenuItem;
    }
}

