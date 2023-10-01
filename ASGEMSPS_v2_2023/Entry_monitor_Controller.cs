using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;
using AGPMS_application.Properties;
using AGPMS_application.Controller;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace AGPMS_application
{
    public partial class Entry_monitor_Controller : UserControl
    {

        MySqlConnection connection;
        MySqlCommand cm;
        MySqlDataReader reader;
        dbconn connect = new dbconn();

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice CaptureDevice;
        Result QRresult; // get the value of QRcode

        GatePassController gatepass = new GatePassController();
        SerialPort myport = new SerialPort();
        SerialPort sp = new SerialPort();

        public string gid = Settings.Default.guard_id.ToString();
        public string fullname;
        public string department;
        public string course;
        public string grade;
        public string yearrlvl;
        public string img;
        public string mobile_number;
        public string guardianname;
        public string designation;
        public string users_id;

         public static Entry_monitor_Controller instance;

        public Entry_monitor_Controller()
        {
            InitializeComponent();
            instance = this;
        }

        private void Entry_monitor_Controller_Load(object sender, EventArgs e)
        {
            Cb_cameraList.Items.Clear();
            CameraDevice();
            Settings.Default.TmpTemperature = "00.00";
            Settings.Default.Save();
        }
        

        // Left side at the buttom show message
        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        // List of the camera device
        private void CameraDevice()
        {
            //camera
            try
            {
                int index = Convert.ToInt32(Settings.Default["maingate_camera"].ToString());
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                {
                    Cb_cameraList.Items.Add(filterInfo.Name);
                }
                Cb_cameraList.SelectedIndex = index;
            }
            catch (Exception)
            {
                try
                {
                    Cb_cameraList.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    this.Alert("Camera device not found!", Form_Alert.enmType.Warning);
                    Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                }

            }
        }

        // Select list of device
        private void Cb_cameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default["maingate_camera"] = Convert.ToInt32(Cb_cameraList.SelectedIndex.ToString());
            Settings.Default.Save();
            Auto_startcamera();
        }

        // auto start camera has been selected
        public void Auto_startcamera()
        {
            try
            {
                CaptureDevice = new VideoCaptureDevice(filterInfoCollection[Cb_cameraList.SelectedIndex].MonikerString);
                CaptureDevice.NewFrame += CaptureDevice_NewFrame;
                CaptureDevice.Start();
                Scan_timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
            }
        }

        // Processing capture image to new frame
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Qr_cam_scan.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        // Timer method for scanning image and get the value of the QR code
        private void Scan_timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Qr_cam_scan.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    QRresult = barcodeReader.Decode((Bitmap)Qr_cam_scan.Image);
                    if (QRresult != null)
                    {
                        string val = QRresult.ToString();
                        string[] split_val = val.Split('=');

                        if (split_val[0].ToString() == "Personnel")
                        {
                            Scan_timer.Stop();
                            // personnel class
                            Personnel_Login(split_val[1].ToString());
                        }
                        else if (split_val[0].ToString() == "Student")
                        {
                            Scan_timer.Stop();
                            //student class
                            string st_id = split_val[1].ToString();
                            Student_login(st_id);
                        }
                        else
                        {
                            this.Alert("Invalid QR code!", Form_Alert.enmType.Warning);
                            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                        }
                        Thread.Sleep(2000);

                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        
        // reload device connection  after settings changes
        public void Reload_port()
        {
            CaptureDevice.Stop();
            Cb_cameraList.Items.Clear();
            CameraDevice();
        }

        // Users login Method

        public void Personnel_Login(string rcvpid)
        {
            Lbl_user_type.ForeColor = Color.DarkGreen;
            Lbl_user_type.Text = "Personnel";
            Lbl_dept_type.Text = "Designation";
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

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

                    users_id = reader.GetString("pd_id");
                    fullname = reader.GetString("pd_fname") + " "+reader.GetString("pd_mname").Substring(0,1)+". " + reader.GetString("pd_lname");
                    string bdate = reader.GetString("pd_bdate");
                    //department = reader.GetString("pd_designation").Substring(4);
                    department = reader.GetString("pd_designation");
                    string[] split_val = department.Split(',');
                    img = reader.GetString("pd_image");
                    string inactivestat = reader.GetString("pd_active_stat");
                    reader.Close();
                    connection.Close();
                    int statuser = Convert.ToInt32(inactivestat);
                    if (statuser == 0)
                    {
                        this.Alert("Invalid QR code!", Form_Alert.enmType.Warning);
                        Scan_timer.Start();
                    }
                    else
                    {
                        Lbl_user_id.Text = users_id.ToUpper();
                        lbl_name.Text = fullname.ToUpper();
                        Lbl_department.Text = split_val[1].ToUpper()+ split_val[2].ToUpper();
                        lbl_timein.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                        user_img.ImageLocation = @"C:\ASGEMSPS\Personnel img\" + img;
                        
                        Console.WriteLine(bdate);
                        string[] split_bday = bdate.Split('-');
                        string str_bdate = split_bday[0].ToString() + "" + split_bday[1].ToString() + "" + split_bday[2].ToString();
                        Console.WriteLine("Student date: " + str_bdate);
                        int int_bdate = Convert.ToInt32(str_bdate);
                        int int_datenow = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                        int age_total = (int_datenow - int_bdate) / 10000;
                        Console.WriteLine("( " + int_datenow + "-" + str_bdate + ") / 10000");
                        string str_age = age_total.ToString().Substring(0, 2);
                        int age = Convert.ToInt32(str_age);
                        Console.WriteLine("Student age: " + age);

                        string toogle = Settings.Default["toogle_restrict18"].ToString();
                        int young_age = Convert.ToInt32(Settings.Default["youngest"].ToString());
                        int old_age = Convert.ToInt32(Settings.Default["Oldest"].ToString());
                        if (toogle == "true")
                        {
                            if (age > old_age)
                            {
                                Console.WriteLine("Above "+ old_age + " is not allowed to enter!");
                                this.Alert("Sorry, above age " + old_age + " is not allowed to enter!", Form_Alert.enmType.Warning);
                                Scan_timer.Start();
                            }
                            else
                            {

                                ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
                                sc.lbl_Name.Text = fullname;
                                sc.Userid = users_id;
                                sc.lbl_usertype.Text = "Personnel";
                                sc.Show();
                                Scan_timer.Start();
                            }
                        }
                        else
                        {
                            ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
                            sc.lbl_Name.Text = fullname;
                            sc.Userid = users_id;
                            sc.lbl_usertype.Text = "Personnel";
                            sc.Show();
                            Scan_timer.Start();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Personnel id is not found in database record!");
                    reader.Close();
                    connection.Close();
                    this.Alert("Personnel id is not found in database record!", Form_Alert.enmType.Warning);
                    Thread.Sleep(1000);
                    Scan_timer.Start();
                    Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                this.Alert("Error! " + ex.Message, Form_Alert.enmType.Warning);
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
            }
        }

        public void Student_login(string rcvsid)
        {
            //  this.Alert("User ID" + student_id, Form_Alert.enmType.Info);
            Lbl_user_type.ForeColor = Color.DarkGreen;
            Lbl_user_type.Text = "Student";
            Lbl_dept_type.Text = "Programs/Grade";
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

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

                    users_id    = reader.GetString("sd_id");
                    fullname    = reader.GetString("sd_fname") + " "+ reader.GetString("sd_mname").Substring(0,1)+"."+ reader.GetString("sd_lname");
                    department  = reader.GetString("sd_dept_prog").Substring(4);
                    yearrlvl    = reader.GetString("sd_yrlevel");
                    guardianname = reader.GetString("sd_guardianname");
                    mobile_number = reader.GetString("sd_contact_no");
                    string bdate = reader.GetString("sd_bdate");
                    string inactivestat = reader.GetString("sd_active_stat");
                    img         = reader.GetString("sd_image");
                    reader.Close();
                    connection.Close();

                    int statuser = Convert.ToInt32(inactivestat);
                    if (statuser == 0)
                    {
                        this.Alert("Invalid QR code!", Form_Alert.enmType.Warning);
                        Scan_timer.Start();
                    }
                    else
                    {
                        Lbl_user_id.Text = users_id;
                        lbl_name.Text = fullname.ToUpper();
                        Lbl_department.Text = department.ToUpper() + "-" + yearrlvl;
                        lbl_timein.Text = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                        user_img.ImageLocation = @"C:\ASGEMSPS\Student img\" + img;

                        Console.WriteLine(bdate);
                        string[] split_bday = bdate.Split('-');
                        string str_bdate = split_bday[0].ToString() + "" + split_bday[1].ToString() + "" + split_bday[2].ToString();
                        Console.WriteLine("Student date: " + str_bdate);
                        int int_bdate = Convert.ToInt32(str_bdate);
                        int int_datenow = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                        int age_total = (int_datenow - int_bdate) / 10000;
                        Console.WriteLine("( " + int_datenow + "-" + str_bdate + ") / 10000");
                        string str_age = age_total.ToString().Substring(0, 2);
                        int age = Convert.ToInt32(str_age);
                        Console.WriteLine("Student age: " + age);

                        string toogle = Settings.Default["toogle_restrict18"].ToString();
                        int young_age = Convert.ToInt32(Settings.Default["youngest"].ToString());
                        int old_age = Convert.ToInt32(Settings.Default["Oldest"].ToString());
                        if (toogle == "true")
                        {
                            if (age < young_age)
                            {
                                Console.WriteLine("Below age"+ young_age + " is not allowed to enter!");
                                this.Alert("Sorry, below age " + young_age + " is not allowed to enter!", Form_Alert.enmType.Warning);
                                Send_sms_age_restriction(fullname, mobile_number);
                                Scan_timer.Start();
                            }
                            else
                            {
                                ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
                                sc.lbl_Name.Text = fullname;
                                sc.Userid = users_id;
                                sc.lbl_usertype.Text = "Student";
                                sc.ShowDialog();
                                Scan_timer.Start();
                            }
                        }
                        else
                        {
                            ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
                            sc.lbl_Name.Text = fullname;
                            sc.Userid = users_id;
                            sc.lbl_usertype.Text = "Student";
                            sc.ShowDialog();
                            Scan_timer.Start();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Student id is not found in database record!");
                    reader.Close();
                    connection.Close();
                    this.Alert("Student id is not found in database record!", Form_Alert.enmType.Warning);
                    Thread.Sleep(1000);
                    Scan_timer.Start();
                    Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                this.Alert("Error! " + ex.Message, Form_Alert.enmType.Warning);
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
            }
        }
        // #END# Login method

        //Send msg for age restriction
        private void Send_sms_age_restriction(string stname , string mobile)
        {
            try
            {
                string date = DateTime.Now.ToString("h:mmtt");
                string Msg = DateTime.Now.ToString("MM/dd/yyyy")
                                + "\n\nFrom:"
                                + Settings.Default.from_msg_entry.ToString()
                                + "\n\n"
                                + Settings.Default["Txt_intro_restrict_msg"].ToString()
                                + " [ Student name ] "
                                + Settings.Default["Txt_after_restrict_msg"].ToString()
                                + " [ age variable value ] "
                                + Settings.Default["Txt_end_restrict_msg"].ToString();

                string num = "+63" + mobile;
                sp.PortName = Settings.Default.gsm_port.ToString();
                sp.Open();
                sp.WriteLine("AT" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine("AT+CMGS=\"" + num + "\"" + Environment.NewLine);
                Thread.Sleep(100);
                sp.WriteLine(Msg + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    this.Alert("Send sms failed!", Form_Alert.enmType.Warning);
                }
                else
                {
                    this.Alert("Send sms success", Form_Alert.enmType.Success);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message + " Can't send a message!", Form_Alert.enmType.Error);
            }
        }
        // #END# Send msg for age restriction

        private void Reload_tempval_Tick(object sender, EventArgs e)
        {
            Lbl_temp2.Text = Settings.Default.TmpTemperature.ToString();
        }


        // If Monitor_WF is close, this method will be auto close the running camera device
        private void Camera_status_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Settings.Default["Camera_status"].ToString()=="Active")
                {
                    Settings.Default["Camera_status"] = "Disable";
                    Settings.Default.Save();
                    Qr_cam_scan.Image = Resources.Disable_scanner;
                    Stop_CapturedDevice();
                }
                if (Settings.Default["Camera_status"].ToString() == "Enable")
                {
                    if (CaptureDevice.IsRunning)
                    {
                        // no program to execute
                    }
                    else
                    {
                        Settings.Default["Camera_status"] = "Disable";
                        Settings.Default.Save();
                        CaptureDevice.Start();
                    }
                }
                if (Settings.Default["Camera_status"].ToString() == "Disable_Guardlogin")
                {
                    Settings.Default["Camera_status"] = "Disable";
                    Settings.Default.Save();
                    Qr_cam_scan.Image = Resources.Disable_scanner;
                    Stop_CapturedDevice();
                }

            }
            catch (Exception ex)
            {
                this.Alert(ex.Message, Form_Alert.enmType.Error);
            }
            
        }

        private void Stop_CapturedDevice()
        {
            CaptureDevice.Stop();
        }

        private void Lbl_temp2_TextChanged(object sender, EventArgs e)
        {
            int size = Lbl_temp2.Text.Length;
            double temp = Convert.ToDouble(Lbl_temp2.Text);
            Console.WriteLine(temp);
            if (size > 6)
            {
                Lbl_temp2.Text = "00.00";
            }
            else
            {
                if (temp >= 37.00)
                {
                    lbl_abovenormal.ForeColor = Color.DarkRed;
                    lbl_nomal.ForeColor = Color.LightGray;
                }
                else
                {
                    lbl_nomal.ForeColor = Color.Green;
                    lbl_abovenormal.ForeColor = Color.LightGray;
                }
                Action_store();
            }
        }

        private void Action_store()
        {
            try
            {
                GatePassController gatepass = new GatePassController();
                if (Lbl_user_type.Text == "Student"){
                    gatepass.StudentEntrystatus(Lbl_user_id.Text ,Lbl_temp2.Text, lbl_name.Text , mobile_number, guardianname);
                }
                if (Lbl_user_type.Text == "Personnel"){
                    gatepass.PersonnelEntrystatus(Lbl_user_id.Text, lbl_name.Text, Lbl_temp2.Text);
                    gatepass.AttendanceDeleteStat2(Lbl_user_id.Text);
                    gatepass.AttendanceStatus(Lbl_user_id.Text);
                    gatepass.Personnellog(Lbl_user_id.Text, lbl_name.Text, Lbl_temp2.Text);
                }
            }
            catch (Exception ex)
            {
                this.Alert("Action Store Error! "+ex.Message, Form_Alert.enmType.Warning);
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
            }
        }










        //end of the program close bracket
    }
}
