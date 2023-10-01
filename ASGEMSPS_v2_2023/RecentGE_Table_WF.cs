using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGPMS_application
{
    public partial class RecentGE_Table_WF : Form
    {
        public RecentGE_Table_WF()
        {
            InitializeComponent();
        }

        private void RecentGE_Table_WF_Load(object sender, EventArgs e)
        {
            ShadowForm1.SetShadowForm(this);
            Datatable.Rows.Add(1, "wew", "wew", "wewe", "wew", "wew", "wew", "wew");
            Datatable.Rows.Add(2, "wew", "wew", "wewe", "wew", "wew", "wew", "wew");
            Datatable.Rows.Add(3, "wew", "wew", "wewe", "wew", "wew", "wew", "wew");
            Datatable.Rows.Add(4, "wew", "wew", "wewe", "wew", "wew", "wew", "wew");
        }

        private void Datatable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
