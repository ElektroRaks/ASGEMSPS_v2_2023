using AGPMS_application.Model;
using AGPMS_application.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AGPMS_application
{
    public partial class Monitoring_WF : Form
    {
        public static Monitoring_WF instance;
        private MySqlDataReader reader;
        MySqlCommand cm;
        dbconn Connect = new dbconn();
        private MySqlConnection connection;
        public string gid = Settings.Default.guard_id.ToString();

        public Monitoring_WF()
        {
            InitializeComponent();
            instance = this;
        }

        private void Monitoring_WF_Load(object sender, EventArgs e)
        {
            Guard_monitor();
            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
            Entry_monitor_Controller entryuser = new Entry_monitor_Controller();
            AddUserControlPanel(entryuser);
            CountRestart();
            string toogle = Settings.Default["toogle_restrict18"].ToString();
            if (toogle=="true")
            {
                TSwitch_Restriction.Checked = true;
            }
            else
            {
                TSwitch_Restriction.Checked = false;
            }
        }

        private void AddUserControlPanel(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_entryinside1.Controls.Clear();
            panel_entryinside1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void AddUserControlPanelExit(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel_entryinside1.Controls.Clear();
            panel_entryinside1.Controls.Add(userControl);
            userControl.BringToFront();
        }


        private void Guard_monitor()
        {
            Connect.GetData();
            connection = new MySqlConnection(Connect.GetConnectionString);

            connection.Open();
            Console.WriteLine("Scan value = " + gid);
            Lbl_id.Text = gid;
           //Console.WriteLine(connection);
           string datelogin = DateTime.Now.ToString("yyyy-MM-dd");
            String sql = " SELECT * FROM guardonduty WHERE gd_id = '" + gid + "' AND gond_date = '" + datelogin + "' ORDER BY gond_id DESC ";
            cm = new MySqlCommand(sql, connection);
            reader = cm.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Console.WriteLine(gid + " Fetch current login id of guard on duty.\n");

                string timein = reader.GetString("gond_timein").Substring(0, 5);
                string gond_id = reader.GetString("gond_id");
                Settings.Default["guard_on_duty"] = gond_id;
                Settings.Default.Save();
                reader.Close();

                Console.WriteLine(gond_id + " Current id...\n");
               

                String sql_join = " SELECT * FROM guard_details WHERE gd_id = '" + gid + "' ";
                cm = new MySqlCommand(sql_join, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Lbl_guardname.Text = reader.GetString("gd_fname") + " " + reader.GetString("gd_mname").Substring(0, 1) + ". " + reader.GetString("gd_lname");
                    Lbl_timein.Text =  timein;
                    Guard_img.ImageLocation = @"C:\ASGEMSPS\Guard img\" + reader.GetString("gd_image").ToString();
                    reader.Close();
                }

                connection.Close();
                Console.WriteLine("->MySql close.\n");
            }
            else
            {
                Console.WriteLine(gid + "- status is equal to 0! \n");
                reader.Close();
                connection.Close();
            }
        }



        // Left side at the buttom show message
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        // Age restriction code
        private void TSwitch_Restriction_CheckedChanged(object sender, EventArgs e)
        {
            int young_age = Convert.ToInt32(Settings.Default["youngest"].ToString());
            int old_age = Convert.ToInt32(Settings.Default["Oldest"].ToString());

            if (TSwitch_Restriction.Checked==true)
            {
                Lbl_enable_disable.Text = "Enable";
                Lbl_enable_disable.ForeColor = Color.MediumSeaGreen;
                Lbl_age_restrict.Text = "Age Restriction for youngest("+ young_age + ") and Oldest(" + old_age+")";
                Lbl_age_restrict.Visible = true;
                Settings.Default["toogle_restrict18"] = "true";
                Settings.Default.Save();
            }
            if (TSwitch_Restriction.Checked == false)
            {
                Lbl_enable_disable.Text = "Disable";
                Lbl_enable_disable.ForeColor = Color.Black;
                Lbl_age_restrict.Visible = false;
                Settings.Default["toogle_restrict18"] = "false";
                Settings.Default.Save();
            }
            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
        }
        

        // Monitor winForm buttons and basic funtion
        private void Timer_datetime_Tick(object sender, EventArgs e)
        {
            Lbl_datetime.Text = "Date: " + DateTime.Now.ToString("MM/dd/yyyy") + "   Time: " + DateTime.Now.ToString("HH:mm:ss");
            //CountRestart();
        }

        private void Btn_admin_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://localhost/Automated_School_Gate_Entry_caps2/public/");
            }
            catch (Exception ex)
            {
                this.Alert("Error: " + ex.Message, Form_Alert.enmType.Warning);
            }
        }
       
        
        private void Btn_close_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close this?", "Message Close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Settings.Default["Camera_status"] = "Active";
                Settings.Default.Save();
                Waiting_loader.Visible = true;
                Waiting_loader.Value = 0;
                Lbl_waiting_loader.Visible = true;
                Closing_wf_load.Start();
            }
            else
            {

            }
            
        }

        private void Closing_wf_load_Tick(object sender, EventArgs e)
        {
            Waiting_loader.Value += 1;
            if (Waiting_loader.Value == 100)
            {
                Lbl_waiting_loader.Visible = false;
                Waiting_loader.Visible = false;
                Guard_Logout();
                Application.Exit();
            }
        }

        private void Btn_Gshifting_Click(object sender, EventArgs e)
        {
            Settings.Default["Camera_status"] = "Disable_Guardlogin";
            Settings.Default.Save();
            Waiting_loader.Visible = true;
            Waiting_loader.Value = 0;
            Lbl_waiting_loader.Visible = true;
            Guard_Logout();
          //  this.Hide();
        }

        private void Guard_Logout()
        {
            string guardonduty_id_logout = Settings.Default["guard_on_duty"].ToString();
            string datelogin = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                connection.Open();
                String sql_update_exit = " SELECT * FROM guardonduty WHERE gond_id = '" + guardonduty_id_logout + "' AND gond_date ='" + datelogin + "' ";
                cm = new MySqlCommand(sql_update_exit, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->>" + guardonduty_id_logout + "- status is equal to 1 \n");
                    reader.Close();
                    Console.WriteLine("->>Guard logout.\n->>Update time logout.\n");
                    String sql_update = " UPDATE guardonduty SET gond_timeout='" + DateTime.Now.ToString("HH:mm") + "'  WHERE gond_id = '" + guardonduty_id_logout + "' ";
                    cm = new MySqlCommand(sql_update, connection);
                    cm.ExecuteNonQuery();
                    Console.WriteLine("->>Update log_stat ,set time out, update log_stat to 0.\n");
                    connection.Close();
                    Console.WriteLine("->>MySql close.\n");

                    string dateCreated = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                    string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-guardonduty.txt";
                    using (StreamWriter writer = new StreamWriter(filepath, true))
                    {
                        writer.WriteLine("ID: " + Lbl_id.Text +", Name: "+ Lbl_guardname.Text + ", DateTime: " + dateCreated + ", On duty Status: inactive");
                    }
                    Loadnig.Start();
                }
                else
                {
                    Console.WriteLine("->>" + guardonduty_id_logout + "- status is equal to 0! User skip login entry!\n");
                    reader.Close();
                    connection.Close();
                    Loadnig.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("->>" + ex.Message + "\n");
            }
          

        }

        private void Loadnig_Tick(object sender, EventArgs e)
        {
            Waiting_loader.Value += 1;
            if (Waiting_loader.Value==100)
            {
                Loadnig.Stop();
                Lbl_waiting_loader.Visible = false;
                Waiting_loader.Visible = false;
                GuardonDuty_WF guardlogin_wf = new GuardonDuty_WF();
                guardlogin_wf.Show();
                this.Hide();
            }
            
        }

        private void Btn_settings_Click(object sender, EventArgs e)
        {
            
            Btn_ClickMe.Visible = true;
            Setting_WF setting = new Setting_WF();
            setting.Lbl_openstat.Text = "monitor";
            setting.Show();
        }

        public void CountRestart()
        {
            CountEntry();
            CountInsidetheCampus();
            CountHighTemp();
        }

        private void CountEntry()
        {
            string datenow = DateTime.Now.ToString("yyyy-MM-dd");

            connection.Open();
            String sql_update_exit = " SELECT COUNT(*) FROM in_out_log WHERE io_date = '" + datenow + "' ";
            cm = new MySqlCommand(sql_update_exit, connection);
            long count = (long)cm.ExecuteScalar();
            connection.Close();
            Lbl_count_entry.Text = count.ToString();
        }

        private void CountInsidetheCampus()
        {
            string datenow = DateTime.Now.ToString("yyyy-MM-dd");

            connection.Open();
            String sql_update_exit = " SELECT COUNT( * ) FROM in_out_log WHERE io_date = '" + datenow + "' AND io_log_status= '" + 1 + "'";
            cm = new MySqlCommand(sql_update_exit, connection);
            long count = (long)cm.ExecuteScalar();
            connection.Close();
            label9.Text = count.ToString();
        }

        private void CountHighTemp()
        {
            string datenow = DateTime.Now.ToString("yyyy-MM-dd");

            connection.Open();
            String sql_update_exit = " SELECT COUNT(*) FROM contact_tracing WHERE ct_date= '" + datenow + "'";
            cm = new MySqlCommand(sql_update_exit, connection);
            long count = (long)cm.ExecuteScalar();
            connection.Close();
            label11.Text = count.ToString();
        }

        private void Btn_ClickMe_Click(object sender, EventArgs e)
        {
            Btn_ClickMe.Visible = false;
            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
        }

        private void Exit_monitor_Controller1_Load(object sender, EventArgs e)
        {

        }

        private void Exit_monitor_Controller1_Click(object sender, EventArgs e)
        {
            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
        }

        private void Panel_entryinside1_Paint(object sender, PaintEventArgs e)
        {

        }








        // end bracket
    }
}
