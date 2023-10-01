using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;
using AGPMS_application.Controller;
using AGPMS_application.Properties;
using System.Threading;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace AGPMS_application
{
    public partial class GuardonDuty_WF : Form
    {

        MySqlConnection connection;
        MySqlCommand cm;
        public MySqlDataReader reader;
        dbconn connect = new dbconn();
        GuardLoginController guardlogin = new GuardLoginController();

        FilterInfoCollection filterInfoCollection;
        public VideoCaptureDevice captureDevice;
        private Result QRresult; // get the value of QRcode
        

        public static GuardonDuty_WF instance;
        public GuardonDuty_WF()
        {
            InitializeComponent();
            instance = this;
          
        }

        private void GuardonDuty_WF_Load(object sender, EventArgs e)
        {
            ShadowForm1.SetShadowForm(this);
            CameraDevice();
            Auto_startcamera();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Settings.Default["Camera_status"] = "Enable";
            Settings.Default.Save();
            captureDevice.Stop();
            Application.Exit();
        }


        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }



        public void CameraDevice()
        {
            //camera
            try
            {
                int index = Convert.ToInt32(Settings.Default["maingate_camera"].ToString());
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                {
                    ComboBox_device.Items.Add(filterInfo.Name);
                }
                ComboBox_device.SelectedIndex = index;
            }
            catch (Exception)
            {
                try
                {
                    ComboBox_device.SelectedIndex = 0;
                }
                catch (Exception)
                {
                    this.Alert("Camera device not found!", Form_Alert.EnmType.Warning);
                    this.Alert("Please ckeck camera connection!", Form_Alert.EnmType.Warning);
                }

            }

        }

        private void Start_camera_Click(object sender, EventArgs e)
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
                Scan_timer.Start();
                Settings.Default["maingate_camera"] = Convert.ToInt32(ComboBox_device.SelectedIndex.ToString());
                Settings.Default.Save();
                Start_camera.Text = "Change WebCam";
                // error.DefaultIfEmpty();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        public void Auto_startcamera()
        {
            try
            {
                captureDevice = new VideoCaptureDevice(filterInfoCollection[ComboBox_device.SelectedIndex].MonikerString);
                captureDevice.NewFrame += CaptureDevice_NewFrame;
                captureDevice.Start();
                Scan_timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Qr_cam_scan.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Scan_timer_Tick_1(object sender, EventArgs e)
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
                        Scan_timer.Stop();
                        Login(val);
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }


        public void Login(string passcode)
        {
            // this.Alert("passcode: "+ passcode, Form_Alert.enmType.Info);

            try
            {
                GuardonDuty_WF guardon = new GuardonDuty_WF();

                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);

                connection.Open();
                Console.WriteLine("Server Connected");
                Console.WriteLine("Scan Id = " + passcode);
                Console.WriteLine(connection);
                String sql = "SELECT * FROM guard_details WHERE gd_qrpasscode = '" + passcode + "'";
                cm = new MySqlCommand(sql, connection);
                reader = cm.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    string guard_id = reader.GetString("gd_id");
                    string guard_name = reader.GetString("gd_lname")+","+ reader.GetString("gd_fname");
                    Console.WriteLine(guard_id + "\n");
                    Settings.Default.guard_id = guard_id;
                    Settings.Default.Save();
                    reader.Close();


                    connect.GetData();
                    connection = new MySqlConnection(connect.GetConnectionString);
                    connection.Open();
                    string dateCreated = DateTime.Now.ToString("yyyy-MM-dd") + " " + DateTime.Now.ToString("hh:mm:ss tt");
                    String sql_insert = " insert into guardonduty(gd_id,gond_date,gond_timein) values ('" + guard_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("HH:mm") + "') ";
                    cm = new MySqlCommand(sql_insert, connection);
                    Console.WriteLine("->Store success");
                    cm.ExecuteNonQuery();
                    connection.Close();

                    string filepath = @"C:\ASGEMSPS\csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-guardonduty.txt";
                    using (StreamWriter writer = new StreamWriter(filepath, true))
                    {
                        writer.WriteLine("ID: " + guard_id +", Name: "+ guard_name + ", DateTime: " + dateCreated +", On duty Status: Active");
                    }

                    captureDevice.Stop();
                    Qr_cam_scan.Image = AGPMS_application.Properties.Resources.Disable_scanner;
                    Thread.Sleep(1000);
                    Show_monitor();
                    this.Hide();
                }
                else
                {
                    Console.WriteLine("Passcode not match!");
                    reader.Close();
                    connection.Close();
                    this.Alert("Access Denied - Invalid QRcode Passcode!", Form_Alert.EnmType.Warning);
                    Scan_timer.Start();
                    //guardon.Show();
                    Thread.Sleep(1000);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
                this.Alert("Error! " + ex.Message, Form_Alert.EnmType.Warning);
            }


        }

        public void Show_monitor()
        {
            if (Settings.Default["Camera_status"].ToString() == "Disable")
            {
                Settings.Default["Camera_status"] = "Enable";
                Settings.Default.Save();
                Monitoring_WF monitor_wf = new Monitoring_WF();
                monitor_wf.Show();
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                Hideme(); // close mother form
            }
            else
            {
                Monitoring_WF monitor_wf = new Monitoring_WF();
                monitor_wf.Show();
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                Hideme();
            }

        }

        public void Hideme()
        {
            captureDevice.Stop();
            this.Dispose();
        }

        private void Start_camera_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (captureDevice.IsRunning)
                {
                    captureDevice.Stop();
                }
                Settings.Default["maingate_camera"] = Convert.ToInt32(ComboBox_device.SelectedIndex.ToString());
                Settings.Default.Save();
                Start_camera.Text = "Change WebCam";
                Auto_startcamera();
                // error.DefaultIfEmpty();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }
    }
}
