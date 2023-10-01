using System;
using System.Drawing;
using System.Windows.Forms;
using AGPMS_application.Model;
using AGPMS_application.Properties;

namespace AGPMS_application
{
    public partial class DBconfig_WF : Form
    {
        dbconn Connect = new dbconn();
        GuardonDuty_WF Gon_wf = new GuardonDuty_WF();
        

        public DBconfig_WF()
        {
            InitializeComponent();
            //label5.Text = Settings.Default.server.ToString();
        }
      
        private void DBconfig_WF_Load(object sender, EventArgs e)
        {
            formshadow.SetShadowForm(this);
        }
        

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (txt_Server.Text=="")
            {
                server_err.Text = "field required!";
                server_err.ForeColor = Color.Red;
            }
            if (txt_root.Text == "")
            {
                user_err.Text = "field required!";
                user_err.ForeColor = Color.Red;
            }
           /* if (txt_pass.Text == "")
            {
                pass_err.Text = "field required!";
                pass_err.ForeColor = Color.Red;
            }*/
            if (txt_Server.Text != "" && txt_root.Text != "")
            {
                Save_cannection();
            }
            
        }

        protected void Save_cannection()
        {
            Settings.Default["server"] = txt_Server.Text;
            Settings.Default["username"] = txt_root.Text;
            Settings.Default["password"] = txt_pass.Text;
            Settings.Default.Save();
            Console.WriteLine("Save Config Connection success");
            ShowConnectToDB();
        }

        protected void ShowConnectToDB()
        {
            try
            {
                Connect.GetData();
                Connect.conn.Open();
                MessageBox.Show(this, "System is now connected to server.\nNext step is the Settings config.", "Message Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Setting_WF setting = new Setting_WF();
                setting.Lbl_openstat.Text = "config";
                setting.Show();
                Connect.conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(this, ex.Message, "Server connection Error!", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                if (result == DialogResult.Abort)
                {
                    this.Close();
                }
                else if(result == DialogResult.Retry) {
                    ShowConnectToDB();
                }  
                else {
                    this.Close();
                }
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
