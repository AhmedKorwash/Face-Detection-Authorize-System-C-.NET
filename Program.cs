using MySql.Data.MySqlClient;
using Social_Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDetection
{
    public delegate void RunMainPage();
    public delegate void RunFaceDetection();
    class Program
    {
        public static string ConnectionString = "datasource=localhost;port=3306;database=processor;username=root;password=01024873097KOKO";
        public static MySqlConnection conn1;
        private static MySqlDataReader reader;
        private static RunMainPage login;
        public Program()
        {
            conn1 = new MySqlConnection(ConnectionString);
            conn1.Open();
            login = new RunMainPage(RunMain);
            RunFaceDetection face = new RunFaceDetection(RunFace);
        }
        public static void FillLoginAuth(string user)
        {
            string query = "SELECT * FROM acc WHERE user='" + user + "'";
            MySqlCommand cmd = new MySqlCommand(query, Program.conn1);
            reader = cmd.ExecuteReader();
            while (Program.reader.Read())
            {
                UserLogin.Email = Program.reader["email"].ToString();
                UserLogin.Code = Program.reader["code"].ToString();
                UserLogin.Username = Program.reader["user"].ToString();
                UserLogin.UID = Program.reader["id"].ToString();
                UserLogin.Phone = Program.reader["Phone"].ToString();
            }
            Program.reader.Close();
        }
        private static void RunMain()
        {
            System.Threading.Thread th = new System.Threading.Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //MainFormDialog is Main Form you need to Open When You Login
                Application.Run(new MainFormDialog());
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private static void RunFace()
        {
            System.Threading.Thread th = new Thread(() =>
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FaceDetectionLogin(login));
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    }
    public class UserLogin
    {
        public static string Username;
        public static string Email;
        public static string Code;
        public static string UID;
        public static string Phone;
    }
}
