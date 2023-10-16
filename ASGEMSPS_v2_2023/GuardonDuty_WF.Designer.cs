namespace AGPMS_application
{
    partial class GuardonDuty_WF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuardonDuty_WF));
            this.ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.formradius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_cameraList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.Start_camera = new Guna.UI2.WinForms.Guna2Button();
            this.Scan_timer = new System.Windows.Forms.Timer(this.components);
            this.ComboBox_device = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Qr_cam_scan = new System.Windows.Forms.PictureBox();
            this.guna2CirclePictureBox4 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.Btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Qr_cam_scan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // formradius
            // 
            this.formradius.BorderRadius = 10;
            this.formradius.TargetControl = this;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.Location = new System.Drawing.Point(-5, 58);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1001, 15);
            this.guna2Separator1.TabIndex = 15;
            this.guna2Separator1.UseTransparentBackground = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label4.Location = new System.Drawing.Point(16, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Guard Login";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label1.Location = new System.Drawing.Point(119, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 28);
            this.label1.TabIndex = 38;
            this.label1.Text = "Scan you QR code";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label2.Location = new System.Drawing.Point(49, 468);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "Select Camera";
            // 
            // cb_cameraList
            // 
            this.cb_cameraList.BackColor = System.Drawing.Color.Transparent;
            this.cb_cameraList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_cameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cameraList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_cameraList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_cameraList.FocusedState.Parent = this.cb_cameraList;
            this.cb_cameraList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cb_cameraList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_cameraList.HoverState.Parent = this.cb_cameraList;
            this.cb_cameraList.ItemHeight = 30;
            this.cb_cameraList.ItemsAppearance.Parent = this.cb_cameraList;
            this.cb_cameraList.Location = new System.Drawing.Point(59, 468);
            this.cb_cameraList.Name = "cb_cameraList";
            this.cb_cameraList.ShadowDecoration.Parent = this.cb_cameraList;
            this.cb_cameraList.Size = new System.Drawing.Size(261, 36);
            this.cb_cameraList.TabIndex = 37;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 5;
            this.guna2Panel2.Controls.Add(this.Qr_cam_scan);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(53, 170);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Depth = 10;
            this.guna2Panel2.ShadowDecoration.Enabled = true;
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(348, 294);
            this.guna2Panel2.TabIndex = 34;
            // 
            // Start_camera
            // 
            this.Start_camera.Animated = true;
            this.Start_camera.BackColor = System.Drawing.Color.Transparent;
            this.Start_camera.BorderRadius = 5;
            this.Start_camera.CheckedState.Parent = this.Start_camera;
            this.Start_camera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start_camera.CustomImages.Parent = this.Start_camera;
            this.Start_camera.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Start_camera.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Start_camera.ForeColor = System.Drawing.Color.White;
            this.Start_camera.HoverState.Parent = this.Start_camera;
            this.Start_camera.Location = new System.Drawing.Point(53, 545);
            this.Start_camera.Margin = new System.Windows.Forms.Padding(4);
            this.Start_camera.Name = "Start_camera";
            this.Start_camera.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Start_camera.ShadowDecoration.Parent = this.Start_camera;
            this.Start_camera.Size = new System.Drawing.Size(348, 44);
            this.Start_camera.TabIndex = 36;
            this.Start_camera.Text = "Change WebCam";
            this.Start_camera.Click += new System.EventHandler(this.Start_camera_Click_1);
            // 
            // Scan_timer
            // 
            this.Scan_timer.Enabled = true;
            this.Scan_timer.Tick += new System.EventHandler(this.Scan_timer_Tick_1);
            // 
            // ComboBox_device
            // 
            this.ComboBox_device.BackColor = System.Drawing.Color.Transparent;
            this.ComboBox_device.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBox_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_device.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBox_device.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBox_device.FocusedState.Parent = this.ComboBox_device;
            this.ComboBox_device.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBox_device.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ComboBox_device.HoverState.Parent = this.ComboBox_device;
            this.ComboBox_device.ItemHeight = 30;
            this.ComboBox_device.ItemsAppearance.Parent = this.ComboBox_device;
            this.ComboBox_device.Location = new System.Drawing.Point(53, 493);
            this.ComboBox_device.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox_device.Name = "ComboBox_device";
            this.ComboBox_device.ShadowDecoration.Parent = this.ComboBox_device;
            this.ComboBox_device.Size = new System.Drawing.Size(347, 36);
            this.ComboBox_device.TabIndex = 39;
            // 
            // Qr_cam_scan
            // 
            this.Qr_cam_scan.Location = new System.Drawing.Point(20, 20);
            this.Qr_cam_scan.Margin = new System.Windows.Forms.Padding(4);
            this.Qr_cam_scan.Name = "Qr_cam_scan";
            this.Qr_cam_scan.Size = new System.Drawing.Size(311, 256);
            this.Qr_cam_scan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Qr_cam_scan.TabIndex = 0;
            this.Qr_cam_scan.TabStop = false;
            // 
            // guna2CirclePictureBox4
            // 
            this.guna2CirclePictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox4.Image = global::AGPMS_application.Properties.Resources.Security_pana;
            this.guna2CirclePictureBox4.Location = new System.Drawing.Point(406, 106);
            this.guna2CirclePictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.guna2CirclePictureBox4.Name = "guna2CirclePictureBox4";
            this.guna2CirclePictureBox4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox4.ShadowDecoration.Parent = this.guna2CirclePictureBox4;
            this.guna2CirclePictureBox4.Size = new System.Drawing.Size(546, 500);
            this.guna2CirclePictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox4.TabIndex = 33;
            this.guna2CirclePictureBox4.TabStop = false;
            this.guna2CirclePictureBox4.UseTransparentBackground = true;
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_close.BackColor = System.Drawing.Color.Transparent;
            this.Btn_close.BorderRadius = 10;
            this.Btn_close.CheckedState.Parent = this.Btn_close;
            this.Btn_close.CustomImages.Parent = this.Btn_close;
            this.Btn_close.FillColor = System.Drawing.Color.Transparent;
            this.Btn_close.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Btn_close.ForeColor = System.Drawing.Color.White;
            this.Btn_close.HoverState.Parent = this.Btn_close;
            this.Btn_close.Image = global::AGPMS_application.Properties.Resources.icons8_close_22;
            this.Btn_close.Location = new System.Drawing.Point(933, 14);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.ShadowDecoration.Parent = this.Btn_close;
            this.Btn_close.Size = new System.Drawing.Size(45, 42);
            this.Btn_close.TabIndex = 17;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // GuardonDuty_WF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(996, 669);
            this.Controls.Add(this.ComboBox_device);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.Start_camera);
            this.Controls.Add(this.guna2CirclePictureBox4);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GuardonDuty_WF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuardonDuty_WF";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GuardonDuty_WF_Load);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Qr_cam_scan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse formradius;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button Btn_close;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cb_cameraList;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.PictureBox Qr_cam_scan;
        private Guna.UI2.WinForms.Guna2Button Start_camera;
        private System.Windows.Forms.Timer Scan_timer;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBox_device;
    }
}