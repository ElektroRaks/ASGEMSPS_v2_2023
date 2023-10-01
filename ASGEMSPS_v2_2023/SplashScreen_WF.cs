using AGPMS_application.Model;
using System;
using System.Threading;
using System.Windows.Forms;
using AGPMS_application.Properties;
using AGPMS_application.Controller;
using MySql.Data.MySqlClient;

namespace AGPMS_application
{
    public partial class SplashScreen_WF : Form
    {
        dbconn connect = new dbconn();
        protected MySqlConnection connection;
        protected MySqlCommand cm;
        protected MySqlCommand cmd;
        protected MySqlDataReader reader;

        SplashController spc = new SplashController();
        GuardonDuty_WF gd_wf = new GuardonDuty_WF();
        int val_loading = 0;

        public SplashScreen_WF()
        {
            InitializeComponent();
        }

        private void SplashScreen_WF_Load(object sender, EventArgs e)
        {
            ShadowForm1.SetShadowForm(this);
        }

        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void Load_system_Tick(object sender, EventArgs e)
        {
            progressBar.Value = val_loading;
            lbl_process.Text = "Running program. . .";
            if (Settings.Default.last_use.ToString() != DateTime.Now.ToString("MM/dd/yyyy"))
            {
               // spc.CreateDirectory();
            }

            if (progressBar.Value == 29)
            {
                lbl_process.Text = "Please Wait for a while. . .";
            }
            if (progressBar.Value == 39)
            {
                Load_system.Stop();
                try
                {
                    /* System.Diagnostics.Process.Start("http://gatepass.srcbportal.ml/public/main-gate/synce-data");
                     Thread.Sleep(1000);*/
                    Load_system.Start();
                }
                catch (Exception ex)
                {
                    this.Alert(ex.Message, Form_Alert.EnmType.Warning);
                }
            }

            if (progressBar.Value == 49)
            {
                lbl_process.Text = "Please Wait for a while. . .";
            }
            if (progressBar.Value == 59)
            {
                Load_system.Stop();
                try
                {
                    /* Process.Start(@""+Settings.Default.xampp_pathfile.ToString());
                     Thread.Sleep(1000);*/
                    Load_system.Start();
                }
                catch (Exception ex)
                {
                    this.Alert(ex.Message, Form_Alert.EnmType.Warning);
                }
            }
            if (progressBar.Value == 79)
            {
                lbl_process.Text = "Checking local server connection . . .";
            }
            if (progressBar.Value == 99)
            {
                Load_system.Stop();
                lbl_process.Text = "Checking local server connection . . .";
                Thread.Sleep(5000);
                ShowConnectToDB();
            }
            val_loading++;
        }

        protected void ShowConnectToDB()
        {
            //open class
            connect.GetData();
            try
            {
                connect.conn.Open();
                this.Alert("System are connected to server", Form_Alert.EnmType.Welcome);
                connect.conn.Close();
                if (Settings.Default.last_use.ToString() != DateTime.Now.ToString("MM/dd/yyyy"))
                {
                   AutoSetAttendanceDefault();
                }
                else
                   {
                        gd_wf.Show();
                        this.Hide();
                   }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.Alert(ex.Message, Form_Alert.EnmType.Error);
                DBconfig_WF config = new DBconfig_WF();
                config.Show();
                this.Hide();
            }
        }

        protected void AutoSetAttendanceDefault()
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                Console.WriteLine(connection);
                String sql_select = "SELECT * FROM personnel_details";
                cm = new MySqlCommand(sql_select, connection);
                reader = cm.ExecuteReader();
                Console.WriteLine("\n->> Starting attendance set date to current date, set time to 00:00..\n");
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("pd_id") + " Update...\n");
                    string pid = reader.GetString("pd_id");
                    string inactivestat = reader.GetString("pd_active_stat");
                    int statuser = Convert.ToInt32(inactivestat);
                    if (statuser == 0)
                    {
                        this.Alert("Invalid QR code!", Form_Alert.EnmType.Warning);
                    }
                    else
                    {
                        spc.Insert(pid);
                        Thread.Sleep(800);
                    }
                }
                reader.Close();
                connection.Close();
                spc.CreateDirectory();
                gd_wf.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                this.Alert("Error! " + ex.Message, Form_Alert.EnmType.Warning);
            }
        }
        


        // end backet
    }
}
