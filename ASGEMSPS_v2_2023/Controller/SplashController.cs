using AGPMS_application.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AGPMS_application.Controller;
using MySql.Data.MySqlClient;
using AGPMS_application.Model;

namespace AGPMS_application.Controller
{
    class SplashController
    {
        dbconn connect = new dbconn();
        protected MySqlConnection connection;
        protected MySqlCommand cmd;

        public void CreateDirectory()
        {
            Settings.Default.last_use = DateTime.Now.ToString("MM/dd/yyyy");
            Settings.Default.Save();
            string path           = @"C:\ASGEMSPS";
            string CsvFolder      = Path.Combine(path, "csv");
            string CsvFile1       = Path.Combine(path, @"csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-personnel_entry.txt");
            string CsvFile2       = Path.Combine(path, @"csv\"+ DateTime.Now.ToString("yyyy-MM-dd")+"-msglog.txt");
            string CsvFile3       = Path.Combine(path, @"csv\"+ DateTime.Now.ToString("yyyy-MM-dd")+ "-student_entry.txt");
            string CsvFile4       = Path.Combine(path, @"csv\" + DateTime.Now.ToString("yyyy-MM-dd") + "-guardonduty.txt");
            string PersonnelImage = Path.Combine(path, "Personnel img");
            string StudentImage   = Path.Combine(path, "Student img");
            string StudentGuard   = Path.Combine(path, "Guard img");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                string install = @"C:\ASGEMSPS\Installed at.txt";
                using (StreamWriter sw = File.CreateText(install))
                {
                    sw.WriteLine("\n========ASGEMSPS installed========");
                    sw.WriteLine(DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToString("HH:mm tt"));
                }
                string Readme = @"C:\ASGEMSPS\Readme.txt";
                using (StreamWriter sw = File.CreateText(Readme))
                {
                    sw.WriteLine("\n========READ ME========");
                    sw.WriteLine("\n----------------------------------");
                    sw.WriteLine("\n<TEXT>");
                }
            }

            if (!Directory.Exists(CsvFolder))
            {
                Directory.CreateDirectory(CsvFolder);
                Thread.Sleep(1000);            }

            if (!Directory.Exists(PersonnelImage))
            {
                Directory.CreateDirectory(PersonnelImage);
            }

            if (!Directory.Exists(StudentImage))
            {
                Directory.CreateDirectory(StudentImage);
            }

            if (!Directory.Exists(StudentGuard))
            {
                Directory.CreateDirectory(StudentGuard);
            }
            GenerateCsvFile(CsvFile1, CsvFile2 , CsvFile3, CsvFile4);
        }

        public void GenerateCsvFile( string CsvFile1, string CsvFile2, string CsvFile3, string CsvFile4)
        {
            if (File.Exists(@CsvFile1))
            {
                File.Delete(@CsvFile1);
                Console.WriteLine("Deleted old file");
            }
            StreamWriter file = new StreamWriter(@CsvFile1, true);
            file.Close();

            if (File.Exists(@CsvFile2))
            {
                File.Delete(@CsvFile2);
                Console.WriteLine("Deleted old file");
            }
            StreamWriter file2 = new StreamWriter(@CsvFile2, true);
            file2.Close();

            if (File.Exists(@CsvFile3))
            {
                File.Delete(@CsvFile3);
                Console.WriteLine("Deleted old file");
            }
            StreamWriter file3 = new StreamWriter(@CsvFile3, true);
            file3.Close();

            if (File.Exists(@CsvFile4))
            {
                File.Delete(@CsvFile4);
                Console.WriteLine("Deleted old file");
            }
            StreamWriter file4 = new StreamWriter(@CsvFile4, true);
            file4.Close();
        }

        public void Insert(string id)
        {
            try
            {
                connect.GetData();
                connection = new MySqlConnection(connect.GetConnectionString);
                connection.Open();
                String sql = "insert into personnel_attendance(pd_id, att_date,att_log_status)values('" + id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + 2 + "')";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
              //  this.Alert("Error! " + ex.Message, Form_Alert.enmType.Warning);
            }

        }


    }
}
