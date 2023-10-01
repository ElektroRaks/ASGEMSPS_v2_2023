namespace AGPMS_application
{
    partial class Exit_monitor_Controller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.user_img = new System.Windows.Forms.PictureBox();
            this.Lbl_user_type = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_timeout = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_QRfocusfieldhidden = new System.Windows.Forms.TextBox();
            this.Refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator4 = new Guna.UI2.WinForms.Guna2Separator();
            this.Interval_activate_text_change = new System.Windows.Forms.Timer(this.components);
            this.Lbl_Skip_login = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.user_img)).BeginInit();
            this.SuspendLayout();
            // 
            // user_img
            // 
            this.user_img.Image = global::AGPMS_application.Properties.Resources.profile_user;
            this.user_img.Location = new System.Drawing.Point(64, 47);
            this.user_img.Name = "user_img";
            this.user_img.Size = new System.Drawing.Size(207, 204);
            this.user_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.user_img.TabIndex = 1;
            this.user_img.TabStop = false;
            // 
            // Lbl_user_type
            // 
            this.Lbl_user_type.AutoSize = true;
            this.Lbl_user_type.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_user_type.ForeColor = System.Drawing.Color.Silver;
            this.Lbl_user_type.Location = new System.Drawing.Point(13, 288);
            this.Lbl_user_type.Name = "Lbl_user_type";
            this.Lbl_user_type.Size = new System.Drawing.Size(156, 18);
            this.Lbl_user_type.TabIndex = 28;
            this.Lbl_user_type.Text = "Personnel/Student";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(14, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "User : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(14, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "Name : ";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_name.Location = new System.Drawing.Point(14, 413);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(40, 17);
            this.lbl_name.TabIndex = 31;
            this.lbl_name.Text = "- - - -";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(14, 453);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 32;
            this.label9.Text = "Time out : ";
            // 
            // lbl_timeout
            // 
            this.lbl_timeout.AutoSize = true;
            this.lbl_timeout.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_timeout.Location = new System.Drawing.Point(18, 476);
            this.lbl_timeout.Name = "lbl_timeout";
            this.lbl_timeout.Size = new System.Drawing.Size(40, 17);
            this.lbl_timeout.TabIndex = 33;
            this.lbl_timeout.Text = "- - - -";
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_id.Location = new System.Drawing.Point(14, 351);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(40, 17);
            this.lbl_id.TabIndex = 31;
            this.lbl_id.Text = "- - - -";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(14, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "ID : ";
            // 
            // txt_QRfocusfieldhidden
            // 
            this.txt_QRfocusfieldhidden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_QRfocusfieldhidden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_QRfocusfieldhidden.Location = new System.Drawing.Point(254, 591);
            this.txt_QRfocusfieldhidden.Name = "txt_QRfocusfieldhidden";
            this.txt_QRfocusfieldhidden.Size = new System.Drawing.Size(69, 13);
            this.txt_QRfocusfieldhidden.TabIndex = 34;
            this.txt_QRfocusfieldhidden.TextChanged += new System.EventHandler(this.Txt_QRfocusfieldhidden_TextChanged);
            // 
            // Refresh_timer
            // 
            this.Refresh_timer.Interval = 50;
            this.Refresh_timer.Tick += new System.EventHandler(this.Refresh_timer_Tick);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(17, 308);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(303, 10);
            this.guna2Separator1.TabIndex = 35;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(17, 371);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(303, 10);
            this.guna2Separator2.TabIndex = 36;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Location = new System.Drawing.Point(17, 433);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(303, 10);
            this.guna2Separator3.TabIndex = 36;
            // 
            // guna2Separator4
            // 
            this.guna2Separator4.Location = new System.Drawing.Point(17, 496);
            this.guna2Separator4.Name = "guna2Separator4";
            this.guna2Separator4.Size = new System.Drawing.Size(303, 10);
            this.guna2Separator4.TabIndex = 36;
            // 
            // Interval_activate_text_change
            // 
            this.Interval_activate_text_change.Interval = 500;
            this.Interval_activate_text_change.Tick += new System.EventHandler(this.Interval_activate_text_change_Tick);
            // 
            // Lbl_Skip_login
            // 
            this.Lbl_Skip_login.AutoSize = true;
            this.Lbl_Skip_login.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Skip_login.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Skip_login.Location = new System.Drawing.Point(61, 132);
            this.Lbl_Skip_login.Name = "Lbl_Skip_login";
            this.Lbl_Skip_login.Size = new System.Drawing.Size(218, 36);
            this.Lbl_Skip_login.TabIndex = 28;
            this.Lbl_Skip_login.Text = "This user has skipped the  \r\nQR code scan for entry.";
            this.Lbl_Skip_login.Visible = false;
            // 
            // Exit_monitor_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_timeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.Lbl_Skip_login);
            this.Controls.Add(this.Lbl_user_type);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.user_img);
            this.Controls.Add(this.txt_QRfocusfieldhidden);
            this.Controls.Add(this.guna2Separator4);
            this.Controls.Add(this.guna2Separator3);
            this.Controls.Add(this.guna2Separator2);
            this.Controls.Add(this.guna2Separator1);
            this.Name = "Exit_monitor_Controller";
            this.Size = new System.Drawing.Size(340, 616);
            this.Load += new System.EventHandler(this.Exit_monitor_Controller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.user_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox user_img;
        private System.Windows.Forms.Label Lbl_user_type;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_timeout;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_QRfocusfieldhidden;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator4;
        private System.Windows.Forms.Timer Interval_activate_text_change;
        public System.Windows.Forms.Timer Refresh_timer;
        private System.Windows.Forms.Label Lbl_Skip_login;
    }
}
