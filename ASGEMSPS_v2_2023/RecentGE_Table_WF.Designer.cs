namespace AGPMS_application
{
    partial class RecentGE_Table_WF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.formradius = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.GroupBox3_table = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.Datatable = new Guna.UI2.WinForms.Guna2DataGridView();
            this.RowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_id_view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depart_view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.body_temp_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_in_view = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time_out_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close = new Guna.UI2.WinForms.Guna2ControlBox();
            this.GroupBox3_table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Datatable)).BeginInit();
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
            // GroupBox3_table
            // 
            this.GroupBox3_table.Controls.Add(this.guna2TextBox2);
            this.GroupBox3_table.Controls.Add(this.Datatable);
            this.GroupBox3_table.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.GroupBox3_table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox3_table.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.GroupBox3_table.ForeColor = System.Drawing.Color.White;
            this.GroupBox3_table.Location = new System.Drawing.Point(0, 51);
            this.GroupBox3_table.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox3_table.Name = "GroupBox3_table";
            this.GroupBox3_table.ShadowDecoration.Parent = this.GroupBox3_table;
            this.GroupBox3_table.Size = new System.Drawing.Size(1744, 660);
            this.GroupBox3_table.TabIndex = 1;
            this.GroupBox3_table.Text = "RECENT GATE ENTRY";
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.FocusedState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox2.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.HoverState.Parent = this.guna2TextBox2;
            this.guna2TextBox2.IconLeft = global::AGPMS_application.Properties.Resources.icons8_search_64px;
            this.guna2TextBox2.Location = new System.Drawing.Point(1025, 0);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PasswordChar = '\0';
            this.guna2TextBox2.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.guna2TextBox2.PlaceholderText = "Search. . .";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.ShadowDecoration.Parent = this.guna2TextBox2;
            this.guna2TextBox2.Size = new System.Drawing.Size(701, 38);
            this.guna2TextBox2.TabIndex = 1;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.Guna2TextBox2_TextChanged);
            // 
            // Datatable
            // 
            this.Datatable.AllowUserToAddRows = false;
            this.Datatable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Datatable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Datatable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Datatable.BackgroundColor = System.Drawing.Color.White;
            this.Datatable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Datatable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Datatable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Datatable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Datatable.ColumnHeadersHeight = 45;
            this.Datatable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowCount,
            this.user_id_view,
            this.name_view,
            this.depart_view,
            this.body_temp_,
            this.date_view,
            this.time_in_view,
            this.time_out_});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Datatable.DefaultCellStyle = dataGridViewCellStyle3;
            this.Datatable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Datatable.EnableHeadersVisualStyles = false;
            this.Datatable.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Datatable.Location = new System.Drawing.Point(0, 53);
            this.Datatable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Datatable.Name = "Datatable";
            this.Datatable.ReadOnly = true;
            this.Datatable.RowHeadersVisible = false;
            this.Datatable.RowHeadersWidth = 51;
            this.Datatable.RowTemplate.Height = 35;
            this.Datatable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Datatable.Size = new System.Drawing.Size(1744, 607);
            this.Datatable.TabIndex = 0;
            this.Datatable.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.Datatable.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Datatable.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Datatable.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Datatable.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Datatable.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Datatable.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Datatable.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Datatable.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(35)))), ((int)(((byte)(67)))));
            this.Datatable.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Datatable.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.Datatable.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Datatable.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Datatable.ThemeStyle.HeaderStyle.Height = 45;
            this.Datatable.ThemeStyle.ReadOnly = true;
            this.Datatable.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Datatable.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Datatable.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Datatable.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Datatable.ThemeStyle.RowsStyle.Height = 35;
            this.Datatable.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.Datatable.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.Datatable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Datatable_CellContentClick);
            // 
            // RowCount
            // 
            this.RowCount.HeaderText = "#";
            this.RowCount.MinimumWidth = 6;
            this.RowCount.Name = "RowCount";
            this.RowCount.ReadOnly = true;
            // 
            // user_id_view
            // 
            this.user_id_view.HeaderText = "User ID";
            this.user_id_view.MinimumWidth = 6;
            this.user_id_view.Name = "user_id_view";
            this.user_id_view.ReadOnly = true;
            // 
            // name_view
            // 
            this.name_view.HeaderText = "Full name";
            this.name_view.MinimumWidth = 6;
            this.name_view.Name = "name_view";
            this.name_view.ReadOnly = true;
            // 
            // depart_view
            // 
            this.depart_view.HeaderText = "Department";
            this.depart_view.MinimumWidth = 6;
            this.depart_view.Name = "depart_view";
            this.depart_view.ReadOnly = true;
            // 
            // body_temp_
            // 
            this.body_temp_.HeaderText = "Body temperature";
            this.body_temp_.MinimumWidth = 6;
            this.body_temp_.Name = "body_temp_";
            this.body_temp_.ReadOnly = true;
            // 
            // date_view
            // 
            this.date_view.HeaderText = "Date";
            this.date_view.MinimumWidth = 6;
            this.date_view.Name = "date_view";
            this.date_view.ReadOnly = true;
            // 
            // time_in_view
            // 
            this.time_in_view.HeaderText = "Time in";
            this.time_in_view.MinimumWidth = 6;
            this.time_in_view.Name = "time_in_view";
            this.time_in_view.ReadOnly = true;
            // 
            // time_out_
            // 
            this.time_out_.HeaderText = "Time out";
            this.time_out_.MinimumWidth = 6;
            this.time_out_.Name = "time_out_";
            this.time_out_.ReadOnly = true;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.FillColor = System.Drawing.Color.Transparent;
            this.close.HoverState.Parent = this.close;
            this.close.IconColor = System.Drawing.Color.Black;
            this.close.Location = new System.Drawing.Point(1683, 0);
            this.close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close.Name = "close";
            this.close.ShadowDecoration.Parent = this.close;
            this.close.Size = new System.Drawing.Size(60, 55);
            this.close.TabIndex = 2;
            // 
            // RecentGE_Table_WF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1744, 711);
            this.Controls.Add(this.GroupBox3_table);
            this.Controls.Add(this.close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RecentGE_Table_WF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RecentGE_Table_WF";
            this.Load += new System.EventHandler(this.RecentGE_Table_WF_Load);
            this.GroupBox3_table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Datatable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowForm ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse formradius;
        private Guna.UI2.WinForms.Guna2GroupBox GroupBox3_table;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;
        private Guna.UI2.WinForms.Guna2DataGridView Datatable;
        private Guna.UI2.WinForms.Guna2ControlBox close;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn depart_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn body_temp_;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_in_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn time_out_;
    }
}