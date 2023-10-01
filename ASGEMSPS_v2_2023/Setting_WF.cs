using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AGPMS_application.Properties;

namespace AGPMS_application
{
    public partial class Setting_WF : Form
    {
        string[] _portLists;
       // SerialPort sp;
        FilterInfoCollection filterInfoCollection;
        SerialPort sp = new SerialPort();

        int hide_alert = 0;
        public static Setting_WF intance;

        public Setting_WF()
        {
            InitializeComponent();
            intance = this;
        }

        public void Alert(string msg, Form_Alert.EnmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
            //this.Alert("GSM port is missing!", Form_Alert.enmType.Error);
        }

        private void Setting_WF_Activated(object sender, EventArgs e)
        {
           
        }

        private void Setting_WF_Load(object sender, EventArgs e)
        {
            ShadowForm1.SetShadowForm(this);
            _portLists = SerialPort.GetPortNames();
            cb_gsm_portlist.Items.AddRange(_portLists);
            cb_port_arduinoList.Items.AddRange(_portLists);
            cb_gsm_portlist.Text = Settings.Default.gsm_port.ToString();
            cb_port_arduinoList.Text = Settings.Default.arduino_port.ToString();
            CameraMaingate();
            Count_MesgChar();
            Oldmsg_entry();
            Btn_save_msg_exit.Enabled = false;
            Txt_youngest.Text = Settings.Default["youngest"].ToString();
            Txt_oldest.Text = Settings.Default["Oldest"].ToString();
            Type_Msg_restriction_old();
        }

        private void Refresh__Click(object sender, EventArgs e)
        {
            cb_gsm_portlist.Items.Clear();
            cb_port_arduinoList.Items.Clear();
            _portLists = SerialPort.GetPortNames();
            cb_gsm_portlist.Items.AddRange(_portLists);
            cb_port_arduinoList.Items.AddRange(_portLists);
            cb_gsm_portlist.Text = Settings.Default.gsm_port.ToString();
            cb_port_arduinoList.Text = Settings.Default.arduino_port.ToString();
            CameraMaingate();
        }

        private void CameraMaingate()
        {
            //camera
            try
            {
                int index = Convert.ToInt32(Settings.Default["maingate_camera"].ToString());
                filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo filterInfo in filterInfoCollection)
                {
                    cb_camera_entry.Items.Add(filterInfo.Name);
                }
                cb_camera_entry.SelectedIndex = index;
            }
            catch (Exception)
            {
                    this.Alert("Camera device not found!", Form_Alert.EnmType.Warning);
            }
        }

        private void Message_richTextBox_TextChanged(object sender, EventArgs e)
        {
            Count_MesgChar();
        }

        // Count character of the message
        private void Count_MesgChar()
        {
            string CountMsgchar = Message_richTextBox.Text;
            Char_count.Text = "Characters: "+CountMsgchar.Length+"   Words: " + (CountMsgchar.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length).ToString();
        }

        // Auto refresh and write text
        private void Type_Msg()
        {
            string date = DateTime.Now.ToString("h:mmtt");
            Message_richTextBox.Text = DateTime.Now.ToString("MM/dd/yyyy")
                                + "\n\nFrom:"
                                + Txt_from.Text 
                                + "\n\n" 
                                +Txt_msgentro.Text
                                +" [ Student name ] "
                                +Txt_msg_afterStudent_name.Text
                                +" "
                                + date
                                +" "
                                + Txt_msg_afterdate.Text
                                + "[ 35.15° ]"
                                + Txt_endmsg.Text;
        }
        // Show old msg entry
        private void Oldmsg_entry()
        {
            string date =DateTime.Now.ToString("h:mmtt");
            Message_richTextBox.Text = DateTime.Now.ToString("MM/dd/yyyy")
                              + "\n\nFrom: "
                              + Settings.Default.from_msg_entry.ToString() 
                              + "\n\n" 
                              + Settings.Default.line2_msg_entry.ToString()
                              + " [ Student name ] " 
                              + Settings.Default.line3_msg_entry.ToString()
                              +" "
                              + date
                              +" "
                              + Settings.Default.line4_msg_entry.ToString()
                              +  " [ 35.15° ] "
                              + Settings.Default.line5_msg_entry.ToString();

            Txt_from.Text = Settings.Default.from_msg_entry.ToString();
            Txt_msgentro.Text = Settings.Default.line2_msg_entry.ToString();
            Txt_msg_afterStudent_name.Text = Settings.Default.line3_msg_entry.ToString();
            Txt_msg_afterdate.Text = Settings.Default.line4_msg_entry.ToString();
            Txt_endmsg.Text = Settings.Default.line5_msg_entry.ToString();

        }

        //Alert timer to hide after 10 second
        private void AlertTimer_hide_Tick(object sender, EventArgs e)
        {
            hide_alert++;
            if (hide_alert==10)
            {
                AlertTimer_hide.Stop();
                hide_alert = 0;
                Alert_succes1.Visible = false;
                Alert_success2.Visible = false;
                Savesuccess.Visible = false;
            }
        }



        // try to send message 
        private void Btn_send_Click(object sender, EventArgs e)
        {
            string mobile_num = Txt_moblie_number.Text;
                if (mobile_num=="")
                {
                    this.Alert("Please input your mobile number.", Form_Alert.EnmType.Warning);
                }
                else if(mobile_num.Length>10)
                {
                    this.Alert("Mobile number is above 10 characters", Form_Alert.EnmType.Warning);
                }
                else if (mobile_num.Length < 10)
                {
                    this.Alert("Mobile number is below 10 characters", Form_Alert.EnmType.Warning);
                }
                else
                {
                    GSM_modem();
                }
                
        }

        private void GSM_modem()
        {
            try
            {
                string msg = Message_richTextBox.Text;

                string num = "+63"+Txt_moblie_number.Text;
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
                sp.WriteLine(msg + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    this.Alert("Send sms failed!", Form_Alert.EnmType.Warning);
                }
                else
                {
                    this.Alert("Send sms success", Form_Alert.EnmType.Success);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message+" Can't send a message!", Form_Alert.EnmType.Error);
            }
           
        }

        // Save message to settings
        private void Btn_save_msg_entry_Click(object sender, EventArgs e)
        {
            Settings.Default.from_msg_entry = Txt_from.Text;
            Settings.Default.line2_msg_entry = Txt_msgentro.Text;
            Settings.Default.line3_msg_entry = Txt_msg_afterStudent_name.Text;
            Settings.Default.line4_msg_entry = Txt_msg_afterdate.Text;
            Settings.Default.line5_msg_entry = Txt_endmsg.Text;
            Settings.Default.Save();
            Alert_success2.Visible = true;
            AlertTimer_hide.Start();
        }

        // writing to message box
        private void Txt_from_TextChanged(object sender, EventArgs e)
        {
            Type_Msg();
        }
        // writing to message box
        private void Txt_msgentro_TextChanged(object sender, EventArgs e)
        {
            Type_Msg();
        }
        // writing to message box
        private void Txt_msg_afterStudent_name_TextChanged(object sender, EventArgs e)
        {
            Type_Msg();
        }
        // writing to message box
        private void Txt_msg_afterdate_TextChanged(object sender, EventArgs e)
        {
            Type_Msg();
        }
        // writing to message box
        private void Txt_endmsg_TextChanged(object sender, EventArgs e)
        {
            Type_Msg();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            if (Lbl_openstat.Text == "monitor")
            {
              this.Close();
            }
            if (Lbl_openstat.Text == "config")
            {
                MessageBox.Show(this, "The system is needed to restart. \nPlease run this system again.", "Message Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void Btn_show_entry_msg_Click(object sender, EventArgs e)
        {
            Lbl_endmsg.Text = "End message after body temperature :";
            Btn_save_msg_exit.Enabled = false;
            Btn_save_msg_entry.Enabled = true;
            Oldmsg_entry();
        }

        private void Btn_show_exit_msg_Click(object sender, EventArgs e)
        {
            Lbl_endmsg.Text = "End message";
            Btn_save_msg_entry.Enabled = false;
            Btn_save_msg_exit.Enabled = true;
            Oldmsg_exit();
        }

        // saving exit message
        private void Btn_save_msg_exit_Click(object sender, EventArgs e)
        {
            
            Settings.Default.from_msg_entry = Txt_from.Text;
            Settings.Default.Txt_msgentro_exit = Txt_msgentro.Text;
            Settings.Default.Txt_msg_afterStudent_name_exit = Txt_msg_afterStudent_name.Text;
            Settings.Default.Txt_msg_afterdate_exit = Txt_msg_afterdate.Text;
            Settings.Default.Txt_endmsg_exit = Txt_endmsg.Text;
            Settings.Default.Save();
            Alert_success2.Visible = true;
            AlertTimer_hide.Start();
        }

        private void Oldmsg_exit()
        {
            string date = DateTime.Now.ToString("h:mmtt");
            Message_richTextBox.Text = DateTime.Now.ToString("MM/dd/yyyy")
                              + "\n\nFrom: "
                              + Settings.Default.from_msg_entry.ToString()
                              + "\n\n"
                              + Settings.Default.Txt_msgentro_exit.ToString()
                              + " ( 'Student name' ) "
                              + Settings.Default.Txt_msg_afterStudent_name_exit.ToString()
                              + " "+ date + " "
                              + Settings.Default.Txt_msg_afterdate_exit.ToString()
                              + Settings.Default.Txt_endmsg_exit.ToString();

            Txt_from.Text = Settings.Default.from_msg_entry.ToString();
            Txt_msgentro.Text = Settings.Default.Txt_msgentro_exit.ToString();
            Txt_msg_afterStudent_name.Text = Settings.Default.Txt_msg_afterStudent_name_exit.ToString();
            Txt_msg_afterdate.Text = Settings.Default.Txt_msg_afterdate_exit.ToString();
            Txt_endmsg.Text = Settings.Default.Txt_endmsg_exit.ToString();

        }

        private void Txt_moblie_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Txt_moblie_number_TextChanged(object sender, EventArgs e)
        {
           
            if (System.Text.RegularExpressions.Regex.IsMatch(Txt_moblie_number.Text, "[^0-9]"))
            {
                this.Alert("Please enter only numbers.", Form_Alert.EnmType.Warning);
                Txt_moblie_number.Text = Txt_moblie_number.Text.Remove(Txt_moblie_number.Text.Length - 1);
            }
        }

        // Save device connection to settings
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_camera_entry.SelectedItem == null)
                {
                    MessageBox.Show("Webcam port required!", "Warning");
                }
                if (cb_port_arduinoList.SelectedItem==null)
                {
                    MessageBox.Show("Arduino port required!", "Warning");
                }
                if (cb_gsm_portlist.SelectedItem==null)
                {
                    MessageBox.Show("Gsm port required!", "Warning");
                }
                if (cb_gsm_portlist.SelectedItem != null && cb_port_arduinoList.SelectedItem != null && cb_camera_entry.SelectedItem != null)
                {
                    Settings.Default["maingate_camera"] = Convert.ToInt32(cb_camera_entry.SelectedIndex.ToString());
                    Settings.Default["gsm_port"] = cb_gsm_portlist.SelectedItem.ToString();
                    Settings.Default["arduino_port"] = cb_port_arduinoList.SelectedItem.ToString();
                    Settings.Default.Save();
                    // Entry_monitor_Controller.instance.Reload_port();
                    Alert_succes1.Visible = true;
                    AlertTimer_hide.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
            
        }

        private void Btn_Save_age_setting_Click(object sender, EventArgs e)
        {
            Settings.Default["youngest"] = Convert.ToInt32(Txt_youngest.Text);
            Settings.Default["Oldest"] = Convert.ToInt32(Txt_oldest.Text);
            Settings.Default.Save();
            Savesuccess.Visible = true;
            AlertTimer_hide.Start();
        }
        

        private void Type_Msg_restriction_old()
        {
            Txt_intro_restriction.Text =Settings.Default["Txt_intro_restrict_msg"].ToString();
            Txt_after_restriction.Text = Settings.Default["Txt_after_restrict_msg"].ToString();
            Txt_end_restriction.Text = Settings.Default["Txt_end_restrict_msg"].ToString();
            Type_Msg_restriction();
        }

        // Auto refresh and write text
        private void Type_Msg_restriction()
        {
            string date = DateTime.Now.ToString("h:mmtt");
            Message_age_restriction.Text = DateTime.Now.ToString("MM/dd/yyyy")
                                + "\n\nFrom:"
                                + Settings.Default.from_msg_entry.ToString()
                                + "\n\n"
                                + Txt_intro_restriction.Text
                                + " [Student name] "
                                + Txt_after_restriction.Text
                                + " [ age variable value ] "
                                + Txt_end_restriction.Text;
        }

        private void Txt_intro_restriction_TextChanged(object sender, EventArgs e)
        {
            Type_Msg_restriction();
        }

        private void Txt_after_restriction_TextChanged(object sender, EventArgs e)
        {
            Type_Msg_restriction();
        }

        private void Txt_end_restriction_TextChanged(object sender, EventArgs e)
        {
            Type_Msg_restriction();
        }

        private void Btn_save_msg_restriction_Click(object sender, EventArgs e)
        {
            Settings.Default["Txt_intro_restrict_msg"] = Txt_intro_restriction.Text;
            Settings.Default["Txt_after_restrict_msg"] = Txt_after_restriction.Text;
            Settings.Default["Txt_end_restrict_msg"] = Txt_end_restriction.Text;
            Settings.Default.Save();
            Alert2.Visible = true;
            Alert_timer2_hide.Start();
        }

        int hide_alert2 = 0;
        private void Alert_timer2_hide_Tick(object sender, EventArgs e)
        {
            hide_alert2++;
            if (hide_alert2 == 10)
            {
                Alert_timer2_hide.Stop();
                hide_alert2 = 0;
                Alert2.Visible = false;
            }
        }

        private void InputNum_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(InputNum.Text, "[^0-9]"))
            {
                this.Alert("Please enter mobile number.", Form_Alert.EnmType.Warning);
                Txt_moblie_number.Text = InputNum.Text.Remove(InputNum.Text.Length - 1);
            }
        }

        private void Btn_send_restric_msg_Click(object sender, EventArgs e)
        {
            string mobile_num = InputNum.Text;
            if (mobile_num == "")
            {
                this.Alert("Please input your mobile number.", Form_Alert.EnmType.Warning);
            }
            else if (mobile_num.Length > 10)
            {
                this.Alert("Mobile number is above 10 characters", Form_Alert.EnmType.Warning);
            }
            else if (mobile_num.Length < 10)
            {
                this.Alert("Mobile number is below 10 characters", Form_Alert.EnmType.Warning);
            }
            else
            {
                GSM_modem_restric();
            }

        }

        private void GSM_modem_restric()
        {
            try
            {
                string msg = Message_age_restriction.Text;

                string num = "+63" + InputNum.Text;
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
                sp.WriteLine(msg + Environment.NewLine);
                Thread.Sleep(100);
                sp.Write(new byte[] { 26 }, 0, 1);
                Thread.Sleep(100);

                var response = sp.ReadExisting();
                if (response.Contains("ERROR"))
                {
                    this.Alert("Send sms failed!", Form_Alert.EnmType.Warning);
                }
                else
                {
                    this.Alert("Send sms success", Form_Alert.EnmType.Success);
                }
                sp.Close();
            }
            catch (Exception ex)
            {
                this.Alert(ex.Message + " Can't send a message!", Form_Alert.EnmType.Error);
            }

        }



        //end bracket
    }
}
