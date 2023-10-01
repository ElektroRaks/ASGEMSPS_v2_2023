using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using AGPMS_application.Properties;
using System.IO;

namespace AGPMS_application.Controller
{
    class GuardLoginController
    {
        MySqlConnection connection;
        MySqlCommand cm ;
        dbconn connect = new dbconn();
        
        public string guard_id { set; get; }
        public string passcode { set; get; }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        public void store(string gid_val)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                string dateCreated = DateTime.Now.ToString("yyyy-MM-dd")+" "+ DateTime.Now.ToString("hh:mm:ss");
                String sql = "insert into gp_guardonduty_tb(gid,datenow_,timeIn_,created_at,updated_at)values('" + gid_val + "','" + DateTime.Now.ToString("MM/dd/yyyy") + "','" + DateTime.Now.ToString("HH:mm") + "','" + dateCreated + "','" + dateCreated + "')";
                cm = new MySqlCommand(sql, connection);
                Console.Write("->Store success");
                cm.ExecuteNonQuery();
                connection.Close();
                
                StringBuilder csvcontent = new StringBuilder();
                csvcontent.AppendLine(gid_val + "," + DateTime.Now.ToString("MM/dd/yyyy") + "," + DateTime.Now.ToString("HH:mm"));
                string csvpath = @"C:\AGPMS\csv\guardonduty.csv";
                File.AppendAllText(csvpath, csvcontent.ToString());
                Console.Write("->Store data to onduty.csv file success");
            }
            catch (Exception ex)    
            {
                Console.Write(ex.Message);
            }
        }

    }
}
