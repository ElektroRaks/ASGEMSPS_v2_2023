using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class GatePass_WF : Form
    {
        GuardonDuty_WF gon_wf = new GuardonDuty_WF();


        MySqlConnection connection;
        MySqlCommand cm;
        public MySqlDataReader reader;
        dbconn connect = new dbconn();

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        Result QRresult; // get the value of QRcode

        GatePassController gatepass = new GatePassController();
        SerialPort myport = new SerialPort();

        public string gid = Settings.Default.guard_id.ToString();
        public string fullname;
        public string department;
        public string course;
        public string grade;
        public string yearrlvl;
        public string img;
        public string mobile;
        public string contactname;
        public string designation;
        public string users_id;

        public string body_temp { set; get; }


        public GatePass_WF()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
            //this.Alert("GSM port is missing!", Form_Alert.enmType.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShadowForm1.SetShadowForm(this);
            menu_panel.Width = 43;
            DateTime_timer.Start();
            cb_cameraList.Items.Clear();
            cameraDevice();
            lbl_guard.Text ="Guard-"+ gid;
            start_camera.Visible = false;
            start_camera.Text = "";
            Settings.Default.TmpTemperature = "00.00";
            Settings.Default.Save();
            //Datatable.Rows.Add(4, "wew", "wew", "wewe", "wew", "wew", "wew", "wew");
        }

        private void GatePass_WF_Activated(object sender, EventArgs e)
        {
            auto_startcamera();
        }
        
        

 
        // camera scanner
        private void cameraDevice()
        {
            //camera
            try
            {
                int index = Convert.ToInt32(Settings.Default["maingate_camera"].ToString());
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                {
                    cb_cameraList.Items.Add(filterInfo.Name);
                }
                cb_cameraList.SelectedIndex = index;
            }
            catch (Exception)
            {
                try
                {
                    cb_cameraList.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    this.Alert("Camera device not found!", Form_Alert.EnmType.Warning);
                }

            }
        }

        private void cb_cameraList_SelectedValueChanged(object sender, EventArgs e)
        {
            //this.Alert("test", Form_Alert.enmType.Info);
            start_camera.Visible = true;
            start_camera.Text = "Save change camera";
        }

        private void start_camera_Click(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cb_cameraList.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                scan_timer.Start();
                Settings.Default["maingate_camera"] = Convert.ToInt32(cb_cameraList.SelectedIndex.ToString());
                Settings.Default.Save();
                start_camera.Visible = false;
                start_camera.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        public void auto_startcamera()
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[cb_cameraList.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                scan_timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Qr_cam_scan.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void scan_timer_Tick(object sender, EventArgs e)
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
                        string[] split_val = val.Split('-');

                        if (split_val[0].ToString()=="Personnel")
                        {
                            scan_timer.Stop();
                            personnel_Login(split_val[1].ToString());
                        }
                        else if (split_val[0].ToString() == "Student")
                        {
                            scan_timer.Stop();
                            student_login(split_val[1].ToString());
                        }
                        else
                        {
                            this.Alert("Invalid QR code!", Form_Alert.EnmType.Warning);
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

        private void reload_showInfo_Tick(object sender, EventArgs e)
        {
           
        }

        //-----------------------------------------------------------------------login process--------------------------
        public void personnel_Login(string personnel_id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("Server Connected");
                Console.WriteLine("Scan value = " + personnel_id);
                Console.WriteLine(connection);
                String sql = "SELECT * FROM gp_personnel_tb WHERE personnel_id = '" + personnel_id + "'";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetString("personnel_id") + "\n");

                    users_id    = reader.GetString("personnel_id");
                    fullname    = reader.GetString("fname_") + " " + reader.GetString("mname_").Substring(0, 1) + ". " + reader.GetString("lname_");
                    department  = reader.GetString("department_");
                    designation = reader.GetString("designation_");
                    img         = reader.GetString("img_");

                 //   this.Alert("Scan suceessfully, Welcome to SRCB " + fullname, Form_Alert.enmType.Success);
                    reader.Close();
                    connection.Close();

                    lbl_id.Text          = "ID.NO. " + personnel_id;
                    lbl_fullname.Text    = fullname;
                    if (department!= "not any")
                    {
                        lbl_department.Text = department;
                    }
                    lbl_designation.Text = designation;
                    lbl_Course.Text      = "----";
                    lbl_grade.Text       = "----";
                    lbl_timein.Text      = DateTime.Now.ToString("HH:mm");
                    user_img.ImageLocation = @"C:\AGPMS\Personnel img\" + img;

                    ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
                    sc.lbl_Name.Text = fullname;
                    sc.Userid = users_id;
                    sc.ShowDialog();


                    scan_timer.Start();
                }
                else
                {
                    Console.WriteLine("Personnel id not found in our record!");
                    reader.Close();
                    connection.Close();
                    this.Alert("Personnel id not found in our record!", Form_Alert.EnmType.Warning);
                    Thread.Sleep(1000);
                    scan_timer.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex.Message);
            }
        }

        public void student_login(string student_id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("Server Connected");
                Console.WriteLine("Scan value = " + student_id);
                Console.WriteLine(connection);
                String sql = "SELECT * FROM gp_student_tb WHERE student_id = '" + student_id + "'";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    Console.WriteLine(reader.GetString("student_id") + "\n");

                       users_id    = reader.GetString("student_id");
                       fullname    = reader.GetString("fname_") + " " + reader.GetString("mname_").Substring(0, 1) + ". " + reader.GetString("lname_");
                       department  = reader.GetString("department_");
                       course      = reader.GetString("course_");
                       grade       = reader.GetString("grade_");
                       yearrlvl    = reader.GetString("yearLevel_");
                       contactname = reader.GetString("contactname_");
                       mobile      = reader.GetString("contact_");
                       img         = reader.GetString("img_");

                       // this.Alert("Scan suceessfully, Welcome to SRCB " + fullname, Form_Alert.enmType.Success);
                        reader.Close();
                        connection.Close();
                    
                        lbl_id.Text          = "ID.NO. " + student_id;
                        lbl_fullname.Text    = fullname;
                        lbl_department.Text  = department;
                        lbl_designation.Text = "----";
                        lbl_Course.Text      = course + " - " + yearrlvl;
                        lbl_grade.Text       = grade;
                        lbl_timein.Text      = DateTime.Now.ToString("HH:mm");
                        user_img.ImageLocation = @"C:\AGPMS\Student img\" + img;

                   /* ScanbodyTempStudent_WF scanbodytempStudent = new ScanbodyTempStudent_WF();
                    scanbodytempStudent.userid = users_id;
                    scanbodytempStudent.mobile = mobile;
                    scanbodytempStudent.fullname = fullname;
                    scanbodytempStudent.contactname = contactname;
                    scanbodytempStudent.lbl_Name.Text = fullname;
                    scanbodytempStudent.ShowDialog();*/

                    scan_timer.Start();
                }
                else
                {
                    Console.WriteLine("Student id not found in our record!");
                    reader.Close();
                    connection.Close();
                    this.Alert("Student id not found in our record!", Form_Alert.EnmType.Warning);
                    Thread.Sleep(1000);
                    scan_timer.Start();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error " + ex.Message);
            }

        }
        //-----------------------------------------------------------------------login process endcode--------------------------




        // minor function

        private void DateTime_timer_Tick(object sender, EventArgs e)
        {
            date_time.Text = "Date: " + DateTime.Now.ToString("MM/dd/yyyy") + "   Time: " + DateTime.Now.ToString("HH:mm");
        }

        private void btn_changeDuty_Click(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
                myport.Close();
                this.Dispose();
                gon_wf.Show();
            }
            catch (Exception)
            {

            }
          
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            /*if (GroupBox3_table.Visible != true)
            {
                GroupBox3_table.Visible = true;
                btn__show_all.Visible = false;
            }
            else
            {
                GroupBox3_table.Visible = false;
                btn__show_all.Visible = true;
            }*/
        }

        private void GatePass_WF_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
                myport.Close();
            }
            catch (Exception)
            {

            }
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
                Setting_WF setting = new Setting_WF();
                setting.ShowDialog();
        }

        private void btn_menu__Click(object sender, EventArgs e)
        {
            //386, 45
            // 43, 45
            if (menu_panel.Width != 386)
            {
                btn_menu_.Image = Properties.Resources.close1;
                menu_panel.Visible = false;
                menu_panel.Width = 386;
                menu_animation.ShowSync(menu_panel);
            }
            else
            {
                btn_menu_.Image = Properties.Resources.menu;
                menu_panel.Visible = false;
                menu_panel.Width = 43;
                menu_animation.ShowSync(menu_panel);
            }

        }

        private void btn__show_all_Click(object sender, EventArgs e)
        {
            RecentGE_Table_WF rge_wf = new RecentGE_Table_WF();
            rge_wf.ShowDialog();
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (captureDevice.IsRunning)
            {
                captureDevice.Stop();
                this.Dispose();
            }
        }

        private void cb_usertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_usertype.Text == "Personnel")
            {
                if (txt_InputID.Text ==string.Empty)
                {
                    lbl_emty_tbID.Visible = true;
                    lbl_emty_tbID.Text = "Enter personnel id!";
                }
                else
                {
                    cb_usertype_error.Visible = false;
                    personnel_Login(txt_InputID.Text);
                }
                
            }
            if (cb_usertype.Text == "Student")
            {
                if (txt_InputID.Text == string.Empty)
                {
                    lbl_emty_tbID.Visible = true;
                    lbl_emty_tbID.Text = "Enter student id!";
                }
                else
                {
                    cb_usertype_error.Visible = false;
                    student_login(txt_InputID.Text);
                }
            }
            if (cb_usertype.Text == "Select type of user")
            {
               
                cb_usertype_error.Visible = true;
                cb_usertype_error.Text = "Select what type of user to login!";
                 
            }
        }

        private void txt_InputID_TextChanged(object sender, EventArgs e)
        {
            lbl_emty_tbID.Visible = false;
            cb_usertype_error.Visible = false;
            cb_usertype.SelectedIndex=0;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://localhost/srcbportallaravel/public/");
            }
            catch (Exception ex)
            {
                this.Alert("Error: "+ex.Message, Form_Alert.EnmType.Warning);
            }
        }

        private void show_scan_Click(object sender, EventArgs e)
        {
            ScanBodyTemp_WF sc = new ScanBodyTemp_WF();
            sc.ShowDialog();
        }

        private void reload_tempval_Tick(object sender, EventArgs e)
        {
                lbl_bodytemp.Text = Settings.Default.TmpTemperature.ToString();
        }

        private void lbl_bodytemp_TextChanged(object sender, EventArgs e)
        {
            int size = lbl_bodytemp.Text.Length;
            double temp = Convert.ToDouble(lbl_bodytemp.Text);
            Console.WriteLine(temp);
            if (size > 6)
            {
                lbl_bodytemp.Text = "00.00";
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

            }
        }
    }
}


// 726