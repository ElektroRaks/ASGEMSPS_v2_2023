namespace AGPMS_application
{
    partial class PortConnection_Control1er
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
            this.alert_succes1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_camera_entry = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cb_gsm_portlist = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_port_arduinoList = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Save = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AlertTimer_hide = new System.Windows.Forms.Timer(this.components);
            this.alert_succes1.SuspendLayout();
            this.SuspendLayout();
            // 
            // alert_succes1
            // 
            this.alert_succes1.BackColor = System.Drawing.Color.ForestGreen;
            this.alert_succes1.BorderRadius = 5;
            this.alert_succes1.Controls.Add(this.label8);
            this.alert_succes1.Location = new System.Drawing.Point(31, 31);
            this.alert_succes1.Name = "alert_succes1";
            this.alert_succes1.ShadowDecoration.Parent = this.alert_succes1;
            this.alert_succes1.Size = new System.Drawing.Size(519, 42);
            this.alert_succes1.TabIndex = 17;
            this.alert_succes1.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(198, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Save success!";
            // 
            // cb_camera_entry
            // 
            this.cb_camera_entry.BackColor = System.Drawing.Color.Transparent;
            this.cb_camera_entry.BorderThickness = 2;
            this.cb_camera_entry.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_camera_entry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_camera_entry.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_camera_entry.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_camera_entry.FocusedState.Parent = this.cb_camera_entry;
            this.cb_camera_entry.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cb_camera_entry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_camera_entry.HoverState.Parent = this.cb_camera_entry;
            this.cb_camera_entry.ItemHeight = 30;
            this.cb_camera_entry.ItemsAppearance.Parent = this.cb_camera_entry;
            this.cb_camera_entry.Location = new System.Drawing.Point(31, 124);
            this.cb_camera_entry.Name = "cb_camera_entry";
            this.cb_camera_entry.ShadowDecoration.Parent = this.cb_camera_entry;
            this.cb_camera_entry.Size = new System.Drawing.Size(228, 36);
            this.cb_camera_entry.TabIndex = 14;
            // 
            // cb_gsm_portlist
            // 
            this.cb_gsm_portlist.BackColor = System.Drawing.Color.Transparent;
            this.cb_gsm_portlist.BorderThickness = 2;
            this.cb_gsm_portlist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_gsm_portlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gsm_portlist.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_gsm_portlist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_gsm_portlist.FocusedState.Parent = this.cb_gsm_portlist;
            this.cb_gsm_portlist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cb_gsm_portlist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_gsm_portlist.HoverState.Parent = this.cb_gsm_portlist;
            this.cb_gsm_portlist.ItemHeight = 30;
            this.cb_gsm_portlist.ItemsAppearance.Parent = this.cb_gsm_portlist;
            this.cb_gsm_portlist.Location = new System.Drawing.Point(32, 198);
            this.cb_gsm_portlist.Name = "cb_gsm_portlist";
            this.cb_gsm_portlist.ShadowDecoration.Parent = this.cb_gsm_portlist;
            this.cb_gsm_portlist.Size = new System.Drawing.Size(228, 36);
            this.cb_gsm_portlist.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(27, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "GATE ENTRY CAMERA:";
            // 
            // cb_port_arduinoList
            // 
            this.cb_port_arduinoList.BackColor = System.Drawing.Color.Transparent;
            this.cb_port_arduinoList.BorderThickness = 2;
            this.cb_port_arduinoList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_port_arduinoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_port_arduinoList.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_port_arduinoList.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cb_port_arduinoList.FocusedState.Parent = this.cb_port_arduinoList;
            this.cb_port_arduinoList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cb_port_arduinoList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_port_arduinoList.HoverState.Parent = this.cb_port_arduinoList;
            this.cb_port_arduinoList.ItemHeight = 30;
            this.cb_port_arduinoList.ItemsAppearance.Parent = this.cb_port_arduinoList;
            this.cb_port_arduinoList.Location = new System.Drawing.Point(323, 124);
            this.cb_port_arduinoList.Name = "cb_port_arduinoList";
            this.cb_port_arduinoList.ShadowDecoration.Parent = this.cb_port_arduinoList;
            this.cb_port_arduinoList.Size = new System.Drawing.Size(228, 36);
            this.cb_port_arduinoList.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "GSM MODEM PORT:";
            // 
            // Btn_Save
            // 
            this.Btn_Save.Animated = true;
            this.Btn_Save.BorderRadius = 5;
            this.Btn_Save.CheckedState.Parent = this.Btn_Save;
            this.Btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Save.CustomImages.Parent = this.Btn_Save;
            this.Btn_Save.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.Btn_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Save.ForeColor = System.Drawing.Color.White;
            this.Btn_Save.HoverState.Parent = this.Btn_Save;
            this.Btn_Save.Location = new System.Drawing.Point(33, 254);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.ShadowDecoration.Parent = this.Btn_Save;
            this.Btn_Save.Size = new System.Drawing.Size(518, 39);
            this.Btn_Save.TabIndex = 12;
            this.Btn_Save.Text = "Save";
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(319, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "ARDUINO PORT:";
            // 
            // AlertTimer_hide
            // 
            this.AlertTimer_hide.Tick += new System.EventHandler(this.AlertTimer_hide_Tick);
            // 
            // PortConnection_Control1er
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.alert_succes1);
            this.Controls.Add(this.cb_camera_entry);
            this.Controls.Add(this.cb_gsm_portlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_port_arduinoList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.label4);
            this.Name = "PortConnection_Control1er";
            this.Size = new System.Drawing.Size(587, 321);
            this.Load += new System.EventHandler(this.PortConnection_Control1er_Load);
            this.alert_succes1.ResumeLayout(false);
            this.alert_succes1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel alert_succes1;
        private System.Windows.Forms.Label label8;
        private Guna.UI2.WinForms.Guna2ComboBox cb_camera_entry;
        private Guna.UI2.WinForms.Guna2ComboBox cb_gsm_portlist;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cb_port_arduinoList;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button Btn_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer AlertTimer_hide;
    }
}
