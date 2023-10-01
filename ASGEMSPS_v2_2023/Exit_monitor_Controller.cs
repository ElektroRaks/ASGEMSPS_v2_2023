using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using AGPMS_application.Properties;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace AGPMS_application
{
    public partial class Exit_monitor_Controller : UserControl
    {
        MySqlConnection connection;
        MySqlCommand cm;
        public MySqlDataReader reader;
        dbconn Connect = new dbconn();

        public static Exit_monitor_Controller instance; // Other winform can access this.

        public Exit_monitor_Controller()
        {
            InitializeComponent();
            instance = this; 
        }
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void Exit_monitor_Controller_Load(object sender, EventArgs e)
        {
            txt_QRfocusfieldhidden.Focus();
        }
        


        private void Txt_QRfocusfieldhidden_TextChanged(object sender, EventArgs e)
        {
            
            Interval_activate_text_change.Start();
        }

        private void Interval_activate_text_change_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default["Current_UserExit"].ToString() != txt_QRfocusfieldhidden.Text)
                {
                    Settings.Default["Current_UserExit"] = txt_QRfocusfieldhidden.Text;
                    Settings.Default.Save();
                    string[] split_val = txt_QRfocusfieldhidden.Text.Split('=');
                    Console.WriteLine(split_val[0].ToString());
                    if (split_val[0].ToString() == "Personnel" || split_val[0].ToString() == "onnel")
                     {
                         string per_id = split_val[1].ToString();
                         Personnel_exit(per_id);
                         ActiveQrTxtboxFocus();
                     }
                     else if (split_val[0].ToString() == "Student")
                     {
                         string stu_id = split_val[1].ToString();
                         Student_exit(stu_id);
                         ActiveQrTxtboxFocus();

                     }
                     else
                     {
                         Console.WriteLine("Invalid qr code!");
                     }
                    ActiveQrTxtboxFocus();
                    txt_QRfocusfieldhidden.Text = string.Empty;

                }
                else
                {
                    Console.WriteLine("User (ID: " + txt_QRfocusfieldhidden.Text + " )already exit");
                    txt_QRfocusfieldhidden.Text = string.Empty;
                }
                Interval_activate_text_change.Stop();
            }
            catch (Exception ex)
            {
                txt_QRfocusfieldhidden.Text = string.Empty;
                Interval_activate_text_change.Stop();
                this.Alert("QR scan Error: " + ex.Message, Form_Alert.enmType.Error);
            }
        }

        public void Personnel_exit(string rcvpid)
        {
            Lbl_user_type.ForeColor = Color.DarkGreen;
            Lbl_user_type.Text = "Personnel";
            Lbl_Skip_login.Visible = false;
            try
            {
                Connect.GetData();
                connection = new MySqlConnection(Connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("\nServer Connected..\n");
                Console.WriteLine("Search value = " + rcvpid);
                Console.WriteLine(connection);
                String sql_select = "SELECT * FROM personnel_details WHERE pd_id = '" + rcvpid + "'";
                cm = new MySqlCommand(sql_select, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->> Data found = " + rcvpid);
                    Console.WriteLine(reader.GetString("pd_id") + " Fetch data...\n");

                    string users_id = reader.GetString("pd_id");
                    string fullname = reader.GetString("pd_fname") + " " + reader.GetString("pd_mname").Substring(0, 1) + ". " + reader.GetString("pd_lname");
                    string department = reader.GetString("pd_designation").Substring(4);
                    string img = reader.GetString("pd_image");

                    //   this.Alert("Scan suceessfully, Welcome to SRCB " + fullname, Form_Alert.enmType.Success);
                    reader.Close();
                    connection.Close();

                    lbl_id.Text = users_id;
                    lbl_name.Text = fullname.ToUpper();
                    lbl_timeout.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                    user_img.ImageLocation = @"C:\ASGEMSPS\Personnel img\" + img;

                        connection.Open();
                        String sql_update_exit = " SELECT * FROM in_out_log WHERE io_pd_id = '" + users_id + "' AND io_log_status ='" + 1 + "' ";
                        cm = new MySqlCommand(sql_update_exit, connection);
                        reader = cm.ExecuteReader();
                        reader.Read();
                        if (reader.HasRows)
                        {
                            Console.WriteLine("\n->>" + users_id + " - status is equal to 1 \n");
                            reader.Close();
                            // update log_stat to 0  
                            String sql_update = " UPDATE in_out_log SET io_log_status ='" + 0 + "', io_outstamp='"+ DateTime.Now.ToString("HH:mm") + "'  WHERE io_pd_id = '" + users_id + "' ";
                            cm = new MySqlCommand(sql_update, connection);
                            cm.ExecuteNonQuery();
                            Console.WriteLine("->>Update log_stat ,set time out, update log_stat to 0.\n");
                            connection.Close();
                            Console.WriteLine("->>MySql close.\n");
                            Exit_attendance(users_id);
                            Personnellog(users_id, fullname);
                            Monitoring_WF.instance.CountRestart();
                        }
                        else
                        {
                            Console.WriteLine("->>" + users_id + "- status is equal to 0! User skip login entry!\n");
                            Lbl_Skip_login.Visible = true;
                            reader.Close();
                            connection.Close();
                        }
                }
                else
                {
                    Console.WriteLine("Personnel id is not found in database record!");
                    reader.Close();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                this.Alert("Error! " + ex.Message, Form_Alert.enmType.Warning);
            }
            // Scan_timer.Start();

        }

        private void Exit_attendance(string users_id)
        {
            connection.Open();
            String sql_update_exit = " SELECT * FROM personnel_attendance WHERE pd_id = '" + users_id + "' AND att_log_status ='" + 1 + "' ";
            cm = new MySqlCommand(sql_update_exit, connection);
            reader = cm.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Console.WriteLine("\n->>" + users_id + "- status is equal to 1 \n");
                reader.Close();
                // update log_stat to 0  
                Console.WriteLine("\n->>Open connection\nUpdate attendance out\n");
                String sql_update = " UPDATE personnel_attendance SET att_log_status ='" + 0 + "', att_outlog='" + DateTime.Now.ToString("HH:mm") + "'  WHERE pd_id = '" + users_id + "' ";
                cm = new MySqlCommand(sql_update, connection);
                cm.ExecuteNonQuery();
                Console.WriteLine("->>Update log_stat ,set time out, update log_stat to 0.\n");
                connection.Close();
                Console.WriteLine("->>MySql close.\n");
            }
            else
            {
                Console.WriteLine("->>" + users_id + "- status is equal to 0! User skip login entry!\n");
                reader.Close();
                connection.Close();
            }
        }


        public void Student_exit(string rcvsid)
        {
            Lbl_user_type.ForeColor = Color.DarkGreen;
            Lbl_user_type.Text = "Student";
            try
            {
                Connect.GetData();
                connection = new MySqlConnection(Connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("Server Connected..\n");
                Console.WriteLine("Search value = " + rcvsid);
                Console.WriteLine(connection);
                String sql_select = "SELECT * FROM student_details WHERE sd_id = '" + rcvsid + "'";
                cm = new MySqlCommand(sql_select, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->> Data found = " + rcvsid);
                    Console.WriteLine(reader.GetString("sd_id") + " Fetch data...\n");

                    string users_id = reader.GetString("sd_id");
                    string fullname = reader.GetString("sd_fname") + " " + reader.GetString("sd_mname").Substring(0, 1) + ". " + reader.GetString("sd_lname");
                    string department = reader.GetString("sd_dept_prog").Substring(4);
                    string yearrlvl = reader.GetString("sd_yrlevel");
                    string guardianname = reader.GetString("sd_guardianname");
                    string mobile_number = reader.GetString("sd_contact_no");
                    string img = reader.GetString("sd_image");
                    
                    reader.Close();
                    connection.Close();

                    lbl_id.Text = users_id;
                    lbl_name.Text = fullname;
                    lbl_timeout.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                    user_img.ImageLocation = @"C:\ASGEMSPS\Student img\" + img;

                    Update_exit(users_id);
                    Sms_exit(users_id, fullname, mobile_number);
                    Studentlog(users_id, fullname);
                    Monitoring_WF.instance.CountRestart();
                }
                else
                {
                    Console.WriteLine("Student id is not found in database record!");
                    reader.Close();
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        private void Update_exit(string users_id) {
            try
            {
                connection.Open();
                String sql_update_exit = " SELECT * FROM in_out_log WHERE io_sd_id = '" + users_id + "' AND io_log_status ='" + 1 + "' ";
                cm = new MySqlCommand(sql_update_exit, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->>" + users_id + "- status is equal to 1 \n");
                    reader.Close();
                    // update log_stat to 0  
                    String sql_update = " UPDATE in_out_log SET io_log_status ='" + 0 + "', io_outstamp='" + DateTime.Now.ToString("HH:mm") + "'  WHERE io_sd_id = '" + users_id + "' ";
                    cm = new MySqlCommand(sql_update, connection);
                    cm.ExecuteNonQuery();
                    Console.WriteLine("->>Update log_stat ,set time out, update log_stat to 0.\n");
                    connection.Close();
                    Console.WriteLine("->>MySql close.\n");
                    Console.WriteLine("->>student exit.\n");
                }
                else
                {
                    Console.WriteLine("->>" + users_id + "- status is equal to 0! User skip login entry!\n");
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Users log
        private void Studentlog(string sid, string student_name)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string text = "Name: " + student_name
                              + " time stamp: " + time
                              + ", Status: inactive";

                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-student_entry.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine("ID: " + sid + ", " + text);
                }
                Console.WriteLine("Store data to text file sucess");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void Personnellog(string pid, string personnel_name)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string text = "Name: " + personnel_name
                              + " time stamp: " + time
                              + ", Status: inactive";
                
                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-personnel_entry.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(pid + "," + text);
                }
                Console.WriteLine("Store data to text file success");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //#END# Users Log

        // SMS Code
        public void Sms_exit(string id,string st_name, string mobile_number)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy")+" "+ DateTime.Now.ToString("h:mmtt");
                string msg = DateTime.Now.ToString("MM/dd/yyyy")
                              + "\nFrom: "
                              + Settings.Default.from_msg_entry.ToString()
                              + "\n\n"
                              + Settings.Default.Txt_msgentro_exit.ToString()
                              + " "+st_name+" "
                              + Settings.Default.Txt_msg_afterStudent_name_exit.ToString()
                              + " "+time+" "
                              + Settings.Default.Txt_msg_afterdate_exit.ToString()
                              +"\n"
                              + Settings.Default.Txt_endmsg_exit.ToString();

                string num = "0" + mobile_number;
                SerialPort sp = new SerialPort
                {
                    PortName = Settings.Default.gsm_port.ToString()
                };
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + num + "\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine(msg + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    Console.WriteLine("\n->>Send sms failed");
                    MsglogError(id, st_name);
                }
                else
                {
                    Console.WriteLine("\n->>Send sms success");
                    MsglogSuccess(id, st_name);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, Form_Alert.enmType.Error);
            }
        }


        private void MsglogSuccess(string sid, string st_name)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string msg = "From: "
                             + Settings.Default.from_msg_entry.ToString()
                             + "-"
                             + Settings.Default.Txt_msgentro_exit.ToString()
                             + " "+st_name+" "
                             + Settings.Default.Txt_msg_afterStudent_name_exit.ToString()
                             + " "+time+" "
                             + Settings.Default.Txt_msg_afterdate_exit.ToString()
                             + " "
                             + Settings.Default.Txt_endmsg_exit.ToString();
                
                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-msglog.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(sid + ", msg exit: " + msg + ", send status = error");
                }
                Console.WriteLine("Store data to text file sucess");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void MsglogError(string sid, string st_name)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string msg = "From: "
                             + Settings.Default.from_msg_entry.ToString()
                             + "-"
                             + Settings.Default.Txt_msgentro_exit.ToString()
                             + " "+st_name+" "
                             + Settings.Default.Txt_msg_afterStudent_name_exit.ToString()
                             + " "+time+" "
                             + Settings.Default.Txt_msg_afterdate_exit.ToString()
                             + " "
                             + Settings.Default.Txt_endmsg_exit.ToString();
            
                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-msglog.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(sid + ", msg exit: " + msg + ", send status = error");
                }
                Console.WriteLine("Store data to text file sucess");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //#END# SMS Code

        // ActiveControl Textbox for QR value forcus field
        public void ActiveQrTxtboxFocus()
        {
           txt_QRfocusfieldhidden.Focus();
        }

        private void Refresh_timer_Tick(object sender, EventArgs e)
        {
            ActiveQrTxtboxFocus();
        }

        



        // end bracket
    }
}
