using System;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;
using System.IO.Ports;
using AGPMS_application.Properties;
using System.IO;

namespace AGPMS_application.Controller
{
    class GatePassController
    {

        MySqlConnection connection;
        MySqlCommand cm;
        public MySqlDataReader reader;
        dbconn connect = new dbconn();
       
        public string guardonduty_id = Settings.Default.guard_on_duty.ToString();
        string Usertemp;


        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
            Usertemp = Settings.Default.TmpTemperature.ToString();
        }

        // Student Code
        public void StudentEntrystatus(string student_id, string temp, string st_name,string mobile_number, string guardianname)
        {
            connect.GetData();
            connection = new MySqlConnection(connect.GetConnectionString);

            connection.Open();
            Console.WriteLine("Seach ID and check log_status");
            Console.WriteLine("Search id = " + student_id);
            String sql = " SELECT * FROM in_out_log WHERE io_sd_id = '" + student_id + "' AND io_log_status ='" +1+"' ";
            cm = new MySqlCommand(sql, connection);
            reader = cm.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Console.WriteLine(student_id + "- status is equal to 1! \n");
                reader.Close();
                String sql_update = " UPDATE in_out_log SET io_log_status ='" +0+ "' WHERE io_sd_id = '" + student_id + "' ";
                cm = new MySqlCommand(sql_update, connection);
                cm.ExecuteNonQuery();
                Console.WriteLine("->>Update log_stat to 0.\n");
              
                connection.Close();
                Console.WriteLine("->>MySql close.\n");

                Studentstore(student_id, temp, st_name, mobile_number,  guardianname);
                Studentlog(student_id, st_name, temp);
            }
            else
            {
                Console.WriteLine(student_id + "- status is equal to 0! \n");
                reader.Close();
                connection.Close();
                Studentstore(student_id, temp, st_name, mobile_number, guardianname);
            }
        }

        public void Studentstore(string rcvst_id, string temp, string st_name, string mobile_number, string guardianname )
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql_insert = " insert into in_out_log(io_sd_id,gond_id,io_temperature,io_date,io_instamp,io_log_status)values('" + rcvst_id + "','" + guardonduty_id + "','" + temp + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm") + "','" + 1 + "') ";
                cm = new MySqlCommand(sql_insert, connection);
                Console.WriteLine("->>" + rcvst_id + "Storing to gate entry success\n");
                cm.ExecuteNonQuery();
                connection.Close();
                Sms_entry(rcvst_id, temp, st_name, mobile_number, guardianname);
                Monitoring_WF.instance.CountRestart();

                double convert_temp = Convert.ToDouble(temp);
                if (convert_temp >= 37.00)
                {
                    // Temperature is above normal get current id
                    GetStudentCurrentio_ID(rcvst_id);
                }
                else
                {
                    Console.WriteLine("->>Temperature is Normal\n");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        // #END# Student Code

        // Personnel Code
        public void PersonnelEntrystatus(string personnel_id, string personnel_name, string temp)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("\nSeach ID and check log_status");
                Console.WriteLine("Search data = " + personnel_id);
                //Console.WriteLine(connection);
                String sql = " SELECT * FROM in_out_log WHERE io_pd_id = '" + personnel_id + "' AND io_log_status ='" + 1 + "' ";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->>"+personnel_id + "- status is equal to 1! \n");
                    reader.Close();
                    // update log_stat to 0  
                    String sql_update = " UPDATE in_out_log SET io_log_status ='" + 0 + "' WHERE io_pd_id = '" + personnel_id + "' ";
                    cm = new MySqlCommand(sql_update, connection);
                    cm.ExecuteNonQuery();
                    Console.WriteLine("->>Update log_stat success.\n");
                
                    connection.Close();
                    Console.WriteLine("->>MySql close.\n");
                    Personnelstore(personnel_id, temp);
                   // Personnellog(personnel_id, personnel_name, temp);
                }
                else
                {
                    Console.WriteLine("->>"+personnel_id + "- status is equal to 0! \n");
                    reader.Close();
                    connection.Close();
                    Personnelstore(personnel_id, temp);
                } 
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }

        public void Personnelstore(string rcv_pid, string temp)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                String sql_insert = "insert into in_out_log(io_pd_id,gond_id,io_temperature,io_date,io_instamp,io_log_status)values('" + rcv_pid + "','" + guardonduty_id + "','" + temp + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm") + "','" + 1 + "')";
                cm = new MySqlCommand(sql_insert, connection);
                Console.WriteLine("->>"+ rcv_pid + "Storing to gate entry success\n");
                cm.ExecuteNonQuery();
                connection.Close();
                Monitoring_WF.instance.CountRestart();

                double convert_temp = Convert.ToDouble(temp);
                if (convert_temp >= 37.00)
                {
                    // Temperature is above normal get current id
                    GetPersonnelCurrentio_ID(rcv_pid);
                }
                else
                {
                    Console.WriteLine("->>Temperature is Normal\n");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void AttendanceStatus(string pid)
        {
            try
            {
                Console.WriteLine("\nSeach ID and check log_status");
                Console.WriteLine("Search data = " + pid);

                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql_insert = " SELECT * FROM personnel_attendance WHERE pd_id = '" + pid + "' AND att_log_status ='" + 1 + "' ";
                cm = new MySqlCommand(sql_insert, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine("\n->>Personnel attendance\n->>" + pid + "- Deleted data with attendance status = 2 \n");
                    reader.Close();
                    
                   /* String sql_delete = "DELETE FROM personnel_attendance  WHERE  pd_id = '" + pid + "' and att_date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and att_log_status = '" + 2 + "'";
                    cm = new MySqlCommand(sql_delete, connection);
                    cm.ExecuteNonQuery();
                    Console.WriteLine("->>" + pid + "-Deleted data with attendance status = 2 success\n");
                    connection.Close();*/

                    String sql_update = " UPDATE personnel_attendance SET att_log_status ='" + 0 + "' WHERE pd_id = '" + pid + "' ";
                    cm = new MySqlCommand(sql_update, connection);
                    cm.ExecuteNonQuery();
                    Console.WriteLine("->>Update Attendance log status 1 to 0.. success.\n");
                    connection.Close();

                    Console.WriteLine("->>MySql connection close.\n");
                   // AttendanceUpdateStat(pid);
                    AttendanceStore(pid);
                }
                else
                {
                    Console.WriteLine("\n->>Personnel attendance\n->>" + pid + "- status is equal to 0! \n");
                    reader.Close();
                    connection.Close();
                    AttendanceStore(pid);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void AttendanceDeleteStat2(string pid)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql_delete = "DELETE FROM personnel_attendance  WHERE  pd_id = '" + pid + "' and att_date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and att_log_status = '" + 2 + "'";
                cm = new MySqlCommand(sql_delete, connection);
                Console.WriteLine("->>" + pid + "-Deleted data with attendance status = 2 success\n");
                cm.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AttendanceUpdateStat(string pid)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql_update = " UPDATE personnel_attendance SET att_log_status ='" + 0 + "' WHERE pd_id = '" + pid + "' ";
                cm = new MySqlCommand(sql_update, connection);
                cm.ExecuteNonQuery();
                Console.WriteLine("->>Update Attendance log status success.\n");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AttendanceStore(string pid)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql = "insert into personnel_attendance(pd_id, att_date, att_inlog, att_log_status)values('" + pid + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm") + "','" + 1 + "')";
                cm = new MySqlCommand(sql, connection);
                Console.WriteLine("->>" + pid + "Storing to attendance success\n");
                cm.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        
        //#END# Personnel Code

        // Users log
        private void Studentlog(string sid, string student_name, string temp)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string text = "Name: " + student_name
                              + " time stamp: " + time
                              + " Temperature: " + temp + ", Status: Active";

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
        public void Personnellog(string pid, string personnel_name, string temp)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string text = "Name: "+personnel_name+ " time stamp: " + time + " Temperature: " + temp + ", Status: Active";
               
                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-personnel_entry.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(pid + "," + text);
                    writer.Close();
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

        // Store to contact tracing
        public void GetStudentCurrentio_ID(string user_id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                Console.WriteLine("Search id = " + user_id);
                String sql = " SELECT * FROM in_out_log WHERE io_sd_id = '" + user_id + "' AND io_date ='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND io_instamp = '" + DateTime.Now.ToString("HH:mm") + "' ";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine(user_id + "- get current io_id \n");
                    string io_id = reader.GetString("io_id");
                    reader.Close();
                    Console.WriteLine("->> Current io_id="+ io_id + "\n");
                    connection.Close();
                    Console.WriteLine("->>MySql close.\n");
                    Store_withHighTemp(io_id);
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void GetPersonnelCurrentio_ID(string user_id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                Console.WriteLine("Search id = " + user_id);
                String sql = " SELECT * FROM in_out_log WHERE io_pd_id = '" + user_id + "' AND io_date ='" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND io_instamp = '" + DateTime.Now.ToString("HH:mm") + "' ";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine(user_id + "- get current io_id \n");
                    string io_id = reader.GetString("io_id");
                    reader.Close();
                    Console.WriteLine("->> Current io_id" + io_id + "\n");
                    connection.Close();
                    Console.WriteLine("->>MySql close.\n");
                    Store_withHighTemp(io_id);
                    reader.Close();
                    connection.Close();
                }
                else
                {
                    reader.Close();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void Store_withHighTemp(string io_rcvs_id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql_insert = " insert into contact_tracing(ct_io_id, ct_date)values('" + io_rcvs_id + "','" + DateTime.Now.ToString("yyyy-MM-dd")+"') ";
                cm = new MySqlCommand(sql_insert, connection);
                Console.WriteLine("->>" + io_rcvs_id + "Storing to contact tracing success\n");
                cm.ExecuteNonQuery();
                connection.Close();
                Monitoring_WF.instance.CountRestart();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }

        }
        //#END# Store to contact tracing

        // SMS Code
        public void Sms_entry(string id, string temp, string st_name, string mobile_number, string guardianname)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string msg = DateTime.Now.ToString("MM/dd/yyyy")
                              + "\nFrom: "
                              + Settings.Default.from_msg_entry.ToString()
                              + "\n\n"
                              + Settings.Default.line2_msg_entry.ToString()
                              + " "+st_name+" "
                              + Settings.Default.line3_msg_entry.ToString()
                              + " "+time+" "
                              + Settings.Default.line4_msg_entry.ToString()
                              + " " + temp + "* "
                              + Settings.Default.line5_msg_entry.ToString();

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
                    MsglogError(id, st_name, temp);
                }
                else
                {
                    Console.WriteLine("\n->>Send sms success");
                    MsglogSuccess(id, st_name, temp);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, Form_Alert.EnmType.Error);
            }
        }


        private void MsglogSuccess(string sid, string student_name, string temp)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string msg =  "From: "
                              + Settings.Default.from_msg_entry.ToString()
                              + "-"
                              + Settings.Default.line2_msg_entry.ToString()
                              + " "+student_name+" "
                              + Settings.Default.line3_msg_entry.ToString()
                              + " "+time+" "
                              + Settings.Default.line4_msg_entry.ToString()
                              + " "+ temp + ""
                              + Settings.Default.line5_msg_entry.ToString();

                string filepath = @"C:\ASGEMSPS\csv\"+ DateTime.Now.ToString("yyyy-MM-dd") + "-msglog.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(sid + ", msg entry: " + msg + ", send status = Success");
                }
                Console.WriteLine("Store data to text file sucess");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void MsglogError(string sid, string student_name, string temp)
        {
            try
            {
                string time = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToString("h:mmtt");
                string msg = "From: "
                              + Settings.Default.from_msg_entry.ToString()
                              + "-"
                              + Settings.Default.line2_msg_entry.ToString()
                              + " "+student_name+" "
                              + Settings.Default.line3_msg_entry.ToString()
                              + " "+time+" "
                              + Settings.Default.line4_msg_entry.ToString()
                              + " "+ temp + " "
                              + Settings.Default.line5_msg_entry.ToString();

                string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-msglog.txt";
                using (StreamWriter writer = new StreamWriter(filepath,true))
                {
                    writer.WriteLine(sid + ", msg entry: " + msg + ", send status = Error");
                }
                Console.WriteLine("Store data to text file sucess");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
        }
        //#END# SMS Code


    }
}
