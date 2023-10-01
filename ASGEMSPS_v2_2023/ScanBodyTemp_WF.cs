using AGPMS_application.Controller;
using AGPMS_application.Properties;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;

namespace AGPMS_application
{
    public partial class ScanBodyTemp_WF : Form
    {
        SerialPort myport = new SerialPort();
        int interv = 0;
        int countdown = 5;
        GatePassController gatepass = new GatePassController();

       // MySqlConnection connection;
       // MySqlCommand cm;
        public MySqlDataReader reader;
        dbconn connect = new dbconn();
        
        public string gid = Settings.Default.guard_id.ToString();

        private string tempVal;
        public string Temval
        {
            get { return tempVal; }
            set { tempVal = value; }
        }

        public string Userid { set; get; }
        public string Moblile_number { set; get; }
        public string Gurdianname { set; get; }

        public static ScanBodyTemp_WF instance;

        public ScanBodyTemp_WF()
        {
            InitializeComponent();
            instance = this;
        }

        private void ScanBodyTemp_WF_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            Console.WriteLine("\nScanTemp for: " + Userid);
            Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
        }

        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        

        private void OpenArduinoConnection()
        {
            try
            {
                //scan_again.Visible = false;
                if (Settings.Default.arduino_port.ToString() != "")
                {
                    myport.PortName = Settings.Default.arduino_port.ToString();
                    myport.BaudRate = Convert.ToInt32(Settings.Default.arduino_BaudRate.ToString());
                    myport.Open();

                    if (true)
                    {
                        string data_rcv = myport.ReadLine();
                        myport.Close();
                        Lbl_temp2.Text = data_rcv.Substring(0,5);
                        Console.WriteLine(data_rcv.Substring(0, 5));
                        myport.Close();
                        Evaluate_temp(data_rcv);
                    }
                }
            }
            catch (Exception)
            {
               return;
            }
        }

        

        private void Count_toclose_Tick(object sender, EventArgs e)
        {
            countdown--;
            counter.Text = countdown.ToString();
            if (countdown == 3)
            {
                this.Alert("Login suceessfully, Welcome to SRCB " + lbl_Name.Text, Form_Alert.EnmType.Success);
            }
            if (countdown == 0)
            {
                Count_toclose.Stop();
                Exit_monitor_Controller.instance.ActiveQrTxtboxFocus();
                this.Dispose();
            }
        }

        private void Open_arduino_interval_Tick_1(object sender, EventArgs e)
        {
            if (interv == 50)
            {
                OpenArduinoConnection();
            }
            interv++;
        }

        private void Lbl_temp2_TextChanged_1(object sender, EventArgs e)
        {
           
        }

        private void Evaluate_temp(string get_tempval)
        {
            try
            {
                int size = get_tempval.Length;
                double temp = Convert.ToDouble(get_tempval.Substring(0, 5));
                Console.WriteLine(temp);
                if (size > 6)
                {
                    Lbl_temp2.ForeColor = Color.DarkRed;
                    Lbl_temp2.Text = "scan again!";
                   // this.Alert("Please scan again!", Form_Alert.enmType.Warning);
                    Console.WriteLine("Data length:" + size);
                    OpenArduinoConnection();
                }
                else
                {
                    if (temp >= 37.00)
                    {
                        Lbl_temp2.ForeColor = Color.DarkRed;
                        lbl_abovenormal.ForeColor = Color.DarkRed;
                        lbl_nomal.ForeColor = Color.LightGray;
                      //  this.Alert("Your body temparature is above 37°", Form_Alert.enmType.Warning);
                        Entry_monitor_Controller.instance.Lbl_temp2.Text = get_tempval.Substring(0, 5).ToString();
                        Count_toclose.Start();
                       Settings.Default.TmpTemperature = get_tempval.Substring(0, 5).ToString();
                       Settings.Default.Save();
                    }
                    else
                    {
                        Lbl_temp2.ForeColor = Color.Black;
                        lbl_nomal.ForeColor = Color.Green;
                        lbl_abovenormal.ForeColor = Color.LightGray;
                        Entry_monitor_Controller.instance.Lbl_temp2.Text = get_tempval.Substring(0, 5).ToString();
                        Count_toclose.Start();
                       Settings.Default.TmpTemperature = get_tempval.Substring(0, 5).ToString();
                       Settings.Default.Save();
                    }

                }
            }
            catch (Exception ex)
            {
                // this.Alert("Error: "+ex.Message, Form_Alert.enmType.Error);
                MessageBox.Show("dani ang error", ex.Message);
            }
        }

        private void Btn_refreshscanner_Click(object sender, EventArgs e)
        {
            OpenArduinoConnection();
        }

        // end bracket
    }
}
