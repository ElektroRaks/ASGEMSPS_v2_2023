namespace AGPMS_application
{
    partial class ScanBodyTemp_WF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanBodyTemp_WF));
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.lbl_info = new System.Windows.Forms.Label();
            this.guna2CircleButton3 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_abovenormal = new System.Windows.Forms.Label();
            this.lbl_nomal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_usertype = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.counter = new System.Windows.Forms.Label();
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Open_arduino_interval = new System.Windows.Forms.Timer(this.components);
            this.Count_toclose = new System.Windows.Forms.Timer(this.components);
            this.Lbl_temp2 = new System.Windows.Forms.Label();
            this.Btn_refreshscanner = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this;
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_info.Location = new System.Drawing.Point(25, 89);
            this.lbl_info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(630, 58);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "Please use your wrist for scanning body temperature.\r\n ";
            // 
            // guna2CircleButton3
            // 
            this.guna2CircleButton3.CheckedState.Parent = this.guna2CircleButton3;
            this.guna2CircleButton3.CustomImages.Parent = this.guna2CircleButton3;
            this.guna2CircleButton3.FillColor = System.Drawing.Color.Crimson;
            this.guna2CircleButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton3.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton3.HoverState.Parent = this.guna2CircleButton3;
            this.guna2CircleButton3.Location = new System.Drawing.Point(444, 171);
            this.guna2CircleButton3.Margin = new System.Windows.Forms.Padding(4);
            this.guna2CircleButton3.Name = "guna2CircleButton3";
            this.guna2CircleButton3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton3.ShadowDecoration.Parent = this.guna2CircleButton3;
            this.guna2CircleButton3.Size = new System.Drawing.Size(13, 12);
            this.guna2CircleButton3.TabIndex = 13;
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.CheckedState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.CustomImages.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton2.HoverState.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Location = new System.Drawing.Point(292, 171);
            this.guna2CircleButton2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.ShadowDecoration.Parent = this.guna2CircleButton2;
            this.guna2CircleButton2.Size = new System.Drawing.Size(13, 12);
            this.guna2CircleButton2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(33, 194);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "YOUR BODY TEMPERATURE";
            // 
            // lbl_abovenormal
            // 
            this.lbl_abovenormal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_abovenormal.AutoSize = true;
            this.lbl_abovenormal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_abovenormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_abovenormal.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_abovenormal.Location = new System.Drawing.Point(460, 165);
            this.lbl_abovenormal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_abovenormal.Name = "lbl_abovenormal";
            this.lbl_abovenormal.Size = new System.Drawing.Size(184, 25);
            this.lbl_abovenormal.TabIndex = 10;
            this.lbl_abovenormal.Text = "ABOVE NORMAL";
            // 
            // lbl_nomal
            // 
            this.lbl_nomal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_nomal.AutoSize = true;
            this.lbl_nomal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nomal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nomal.ForeColor = System.Drawing.Color.LightGray;
            this.lbl_nomal.Location = new System.Drawing.Point(307, 165);
            this.lbl_nomal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_nomal.Name = "lbl_nomal";
            this.lbl_nomal.Size = new System.Drawing.Size(103, 25);
            this.lbl_nomal.TabIndex = 11;
            this.lbl_nomal.Text = "NORMAL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.lbl_usertype);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 57);
            this.panel1.TabIndex = 15;
            // 
            // lbl_usertype
            // 
            this.lbl_usertype.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_usertype.AutoSize = true;
            this.lbl_usertype.BackColor = System.Drawing.Color.Transparent;
            this.lbl_usertype.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usertype.ForeColor = System.Drawing.Color.White;
            this.lbl_usertype.Location = new System.Drawing.Point(571, 16);
            this.lbl_usertype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_usertype.Name = "lbl_usertype";
            this.lbl_usertype.Size = new System.Drawing.Size(98, 25);
            this.lbl_usertype.TabIndex = 11;
            this.lbl_usertype.Text = "Usertype";
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.ForeColor = System.Drawing.Color.White;
            this.lbl_Name.Location = new System.Drawing.Point(32, 16);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(68, 25);
            this.lbl_Name.TabIndex = 11;
            this.lbl_Name.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(602, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Close:";
            // 
            // counter
            // 
            this.counter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.counter.AutoSize = true;
            this.counter.BackColor = System.Drawing.Color.Transparent;
            this.counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counter.ForeColor = System.Drawing.Color.DimGray;
            this.counter.Location = new System.Drawing.Point(673, 242);
            this.counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(24, 25);
            this.counter.TabIndex = 11;
            this.counter.Text = "0";
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.TargetControl = this.panel1;
            // 
            // Open_arduino_interval
            // 
            this.Open_arduino_interval.Enabled = true;
            this.Open_arduino_interval.Interval = 10;
            this.Open_arduino_interval.Tick += new System.EventHandler(this.Open_arduino_interval_Tick_1);
            // 
            // Count_toclose
            // 
            this.Count_toclose.Interval = 1000;
            this.Count_toclose.Tick += new System.EventHandler(this.Count_toclose_Tick);
            // 
            // Lbl_temp2
            // 
            this.Lbl_temp2.AutoSize = true;
            this.Lbl_temp2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_temp2.Location = new System.Drawing.Point(79, 140);
            this.Lbl_temp2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_temp2.Name = "Lbl_temp2";
            this.Lbl_temp2.Size = new System.Drawing.Size(140, 51);
            this.Lbl_temp2.TabIndex = 12;
            this.Lbl_temp2.Text = "00.00";
            this.Lbl_temp2.TextChanged += new System.EventHandler(this.Lbl_temp2_TextChanged_1);
            // 
            // Btn_refreshscanner
            // 
            this.Btn_refreshscanner.BackColor = System.Drawing.Color.Transparent;
            this.Btn_refreshscanner.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_refreshscanner.CheckedState.Parent = this.Btn_refreshscanner;
            this.Btn_refreshscanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_refreshscanner.HoverState.Image = global::AGPMS_application.Properties.Resources.refresh;
            this.Btn_refreshscanner.HoverState.ImageSize = new System.Drawing.Size(15, 15);
            this.Btn_refreshscanner.HoverState.Parent = this.Btn_refreshscanner;
            this.Btn_refreshscanner.Image = global::AGPMS_application.Properties.Resources.refresh;
            this.Btn_refreshscanner.ImageSize = new System.Drawing.Size(15, 15);
            this.Btn_refreshscanner.Location = new System.Drawing.Point(679, 59);
            this.Btn_refreshscanner.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_refreshscanner.Name = "Btn_refreshscanner";
            this.Btn_refreshscanner.PressedState.Image = global::AGPMS_application.Properties.Resources.refresh;
            this.Btn_refreshscanner.PressedState.ImageSize = new System.Drawing.Size(16, 16);
            this.Btn_refreshscanner.PressedState.Parent = this.Btn_refreshscanner;
            this.Btn_refreshscanner.Size = new System.Drawing.Size(44, 34);
            this.Btn_refreshscanner.TabIndex = 16;
            this.Btn_refreshscanner.UseTransparentBackground = true;
            this.Btn_refreshscanner.Click += new System.EventHandler(this.Btn_refreshscanner_Click);
            // 
            // ScanBodyTemp_WF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 278);
            this.Controls.Add(this.Btn_refreshscanner);
            this.Controls.Add(this.Lbl_temp2);
            this.Controls.Add(this.counter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2CircleButton3);
            this.Controls.Add(this.guna2CircleButton2);
            this.Controls.Add(this.lbl_abovenormal);
            this.Controls.Add(this.lbl_nomal);
            this.Controls.Add(this.lbl_info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScanBodyTemp_WF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScanBodyTemp_WF";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ScanBodyTemp_WF_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lbl_info;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton3;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
        private System.Windows.Forms.Label lbl_abovenormal;
        private System.Windows.Forms.Label lbl_nomal;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private System.Windows.Forms.Timer Open_arduino_interval;
        public System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Timer Count_toclose;
        private System.Windows.Forms.Label Lbl_temp2;
        public System.Windows.Forms.Label lbl_usertype;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_refreshscanner;
    }
}