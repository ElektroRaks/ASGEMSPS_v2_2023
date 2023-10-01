using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AGPMS_application.Properties;

namespace AGPMS_application.Model
{
    class dbconn
    {
        public MySqlConnection conn;

        public string Host { set; get; }
        public string UsID { set; get; }
        public string Pass { set; get; }
        public string conn_String;

        /* protected string h = Settings.Default["server"].ToString();
         protected string db = "asgemsps_db";
         protected string u = "gatepass";
         protected string p = "@dm1n_11++_Caps2";*/

       // protected string h;
        protected string db = "asgemsps_db";
        //protected string u;
       // protected string p;

        public void SaveConfig()
        {
            Settings.Default["server"]   = Host;
            Settings.Default["username"] = UsID;
            Settings.Default["password"] = Pass;
            Settings.Default.Save();
        }

        public void GetData()
        {
            conn_String = "server = " + Settings.Default["server"].ToString() + "; port=3306; username= " + Settings.Default["username"].ToString() + "; password =" + Settings.Default["password"].ToString() + "; database = " + db + "";
            conn = new MySqlConnection(conn_String);
        }

        public string GetConnectionString
        {
            get
            {
                conn_String = "server = " + Settings.Default["server"].ToString() + "; port=3306; username= " + Settings.Default["username"].ToString() + "; password =" + Settings.Default["password"].ToString() + "; database = " + db + "";
                return conn_String;
            }
        }

    }
}
