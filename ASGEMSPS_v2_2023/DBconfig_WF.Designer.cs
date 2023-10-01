namespace AGPMS_application
{
    partial class DBconfig_WF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBconfig_WF));
            this.btn_Submit = new Guna.UI2.WinForms.Guna2Button();
            this.txt_pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_root = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_Server = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pass_err = new System.Windows.Forms.Label();
            this.user_err = new System.Windows.Forms.Label();
            this.server_err = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.formradius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.formshadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Btn_close = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Animated = true;
            this.btn_Submit.BorderRadius = 5;
            this.btn_Submit.CheckedState.Parent = this.btn_Submit;
            this.btn_Submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Submit.CustomImages.Parent = this.btn_Submit;
            this.btn_Submit.FillColor = System.Drawing.Color.Black;
            this.btn_Submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Submit.ForeColor = System.Drawing.Color.White;
            this.btn_Submit.HoverState.Parent = this.btn_Submit;
            this.btn_Submit.Location = new System.Drawing.Point(65, 545);
            this.btn_Submit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.ShadowDecoration.Parent = this.btn_Submit;
            this.btn_Submit.Size = new System.Drawing.Size(405, 49);
            this.btn_Submit.TabIndex = 7;
            this.btn_Submit.Text = "Connect";
            this.btn_Submit.Click += new System.EventHandler(this.Btn_Submit_Click);
            // 
            // txt_pass
            // 
            this.txt_pass.Animated = true;
            this.txt_pass.BorderColor = System.Drawing.Color.Silver;
            this.txt_pass.BorderRadius = 5;
            this.txt_pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_pass.DefaultText = "";
            this.txt_pass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_pass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_pass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_pass.DisabledState.Parent = this.txt_pass;
            this.txt_pass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_pass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_pass.FocusedState.Parent = this.txt_pass;
            this.txt_pass.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txt_pass.ForeColor = System.Drawing.Color.Black;
            this.txt_pass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_pass.HoverState.Parent = this.txt_pass;
            this.txt_pass.Location = new System.Drawing.Point(64, 481);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txt_pass.PlaceholderText = "";
            this.txt_pass.SelectedText = "";
            this.txt_pass.ShadowDecoration.Parent = this.txt_pass;
            this.txt_pass.Size = new System.Drawing.Size(406, 49);
            this.txt_pass.TabIndex = 6;
            // 
            // txt_root
            // 
            this.txt_root.Animated = true;
            this.txt_root.BorderColor = System.Drawing.Color.Silver;
            this.txt_root.BorderRadius = 5;
            this.txt_root.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_root.DefaultText = "";
            this.txt_root.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_root.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_root.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_root.DisabledState.Parent = this.txt_root;
            this.txt_root.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_root.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_root.FocusedState.Parent = this.txt_root;
            this.txt_root.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txt_root.ForeColor = System.Drawing.Color.Black;
            this.txt_root.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_root.HoverState.Parent = this.txt_root;
            this.txt_root.Location = new System.Drawing.Point(64, 389);
            this.txt_root.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txt_root.Name = "txt_root";
            this.txt_root.PasswordChar = '\0';
            this.txt_root.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txt_root.PlaceholderText = "";
            this.txt_root.SelectedText = "";
            this.txt_root.ShadowDecoration.Parent = this.txt_root;
            this.txt_root.Size = new System.Drawing.Size(406, 49);
            this.txt_root.TabIndex = 6;
            // 
            // txt_Server
            // 
            this.txt_Server.Animated = true;
            this.txt_Server.BorderColor = System.Drawing.Color.Silver;
            this.txt_Server.BorderRadius = 5;
            this.txt_Server.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Server.DefaultText = "";
            this.txt_Server.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Server.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Server.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Server.DisabledState.Parent = this.txt_Server;
            this.txt_Server.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Server.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Server.FocusedState.Parent = this.txt_Server;
            this.txt_Server.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txt_Server.ForeColor = System.Drawing.Color.Black;
            this.txt_Server.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Server.HoverState.Parent = this.txt_Server;
            this.txt_Server.Location = new System.Drawing.Point(64, 299);
            this.txt_Server.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txt_Server.Name = "txt_Server";
            this.txt_Server.PasswordChar = '\0';
            this.txt_Server.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txt_Server.PlaceholderText = "";
            this.txt_Server.SelectedText = "";
            this.txt_Server.ShadowDecoration.Parent = this.txt_Server;
            this.txt_Server.Size = new System.Drawing.Size(406, 49);
            this.txt_Server.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(60, 449);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(60, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Username";
            // 
            // pass_err
            // 
            this.pass_err.AutoSize = true;
            this.pass_err.BackColor = System.Drawing.Color.Transparent;
            this.pass_err.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_err.ForeColor = System.Drawing.Color.White;
            this.pass_err.Location = new System.Drawing.Point(349, 446);
            this.pass_err.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pass_err.Name = "pass_err";
            this.pass_err.Size = new System.Drawing.Size(20, 28);
            this.pass_err.TabIndex = 8;
            this.pass_err.Text = "-";
            // 
            // user_err
            // 
            this.user_err.AutoSize = true;
            this.user_err.BackColor = System.Drawing.Color.Transparent;
            this.user_err.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_err.ForeColor = System.Drawing.Color.White;
            this.user_err.Location = new System.Drawing.Point(349, 356);
            this.user_err.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user_err.Name = "user_err";
            this.user_err.Size = new System.Drawing.Size(20, 28);
            this.user_err.TabIndex = 8;
            this.user_err.Text = "-";
            // 
            // server_err
            // 
            this.server_err.AutoSize = true;
            this.server_err.BackColor = System.Drawing.Color.Transparent;
            this.server_err.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.server_err.ForeColor = System.Drawing.Color.White;
            this.server_err.Location = new System.Drawing.Point(349, 268);
            this.server_err.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.server_err.Name = "server_err";
            this.server_err.Size = new System.Drawing.Size(20, 28);
            this.server_err.TabIndex = 8;
            this.server_err.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(60, 268);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Server";
            // 
            // formradius
            // 
            this.formradius.BorderRadius = 10;
            this.formradius.TargetControl = this;
            // 
            // DragControl
            // 
            this.DragControl.TargetControl = this;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(13, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Server Connection Config";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::AGPMS_application.Properties.Resources.ASGEMSPS_Logo;
            this.guna2PictureBox1.Location = new System.Drawing.Point(115, 95);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(318, 146);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 10;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // Btn_close
            // 
            this.Btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_close.BorderRadius = 10;
            this.Btn_close.CheckedState.Parent = this.Btn_close;
            this.Btn_close.CustomImages.Parent = this.Btn_close;
            this.Btn_close.FillColor = System.Drawing.Color.Black;
            this.Btn_close.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Btn_close.ForeColor = System.Drawing.Color.White;
            this.Btn_close.HoverState.Parent = this.Btn_close;
            this.Btn_close.Image = ((System.Drawing.Image)(resources.GetObject("Btn_close.Image")));
            this.Btn_close.Location = new System.Drawing.Point(482, 9);
            this.Btn_close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_close.Name = "Btn_close";
            this.Btn_close.ShadowDecoration.Parent = this.Btn_close;
            this.Btn_close.Size = new System.Drawing.Size(45, 42);
            this.Btn_close.TabIndex = 15;
            this.Btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // DBconfig_WF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 656);
            this.Controls.Add(this.Btn_close);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Server);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_err);
            this.Controls.Add(this.server_err);
            this.Controls.Add(this.user_err);
            this.Controls.Add(this.txt_root);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.txt_pass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DBconfig_WF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBconfig_WF";
            this.Load += new System.EventHandler(this.DBconfig_WF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_Submit;
        private Guna.UI2.WinForms.Guna2TextBox txt_pass;
        private Guna.UI2.WinForms.Guna2TextBox txt_Server;
        private Guna.UI2.WinForms.Guna2TextBox txt_root;
        private Guna.UI2.WinForms.Guna2Elipse formradius;
        private Guna.UI2.WinForms.Guna2ShadowForm formshadow;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label pass_err;
        private System.Windows.Forms.Label user_err;
        private System.Windows.Forms.Label server_err;
        private Guna.UI2.WinForms.Guna2Button Btn_close;
    }
}