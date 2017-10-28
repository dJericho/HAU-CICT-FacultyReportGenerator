using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReportGenerator
{
    class Connector
    {
        private MySqlConnection dbConnect;
        private string connectionString;
        private MySqlDataAdapter adp;
        public Connector(String ip, int port, String name, String password, String databaseName)
        {
            connectionString =
                "datasource=" + ip +
                ";port=" + port +
                ";username=" + name +
                ";password=" + password +
                ";database=" + databaseName +
                ";Convert Zero DateTime = true";
        }
        public Connector()
        {
            connectionString =
                "datasource=localhost"+
                ";port=3306"+
                ";username=root"+
                ";password="+
                ";database=cict-hau"+
                ";Convert Zero DateTime = true";
        }
        public bool openConnection()
        {
            dbConnect = new MySqlConnection(connectionString);
            try
            {
                dbConnect.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return true; //FAILED CONNECTION
            }
        }
        public bool closeConnection()
        {
            try
            {
                dbConnect.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false; //FAILED TO CLOSE CONNECTION
            }
        }
        public DataTable getData(string query)
        {
            DataTable ds = new DataTable();
            using (adp = new MySqlDataAdapter(query, dbConnect))
                adp.Fill(ds);

            return ds;
        }
        public long addData(string query)
        {
            try
            {
                openConnection();
                MySqlCommand cmd = new MySqlCommand(query, dbConnect);
                Console.WriteLine(query);
                //cmd.ExecuteNonQuery();
                MySqlDataReader read = cmd.ExecuteReader();
                read.Close();
                closeConnection();
                //cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return -1;
            }
        }
        public bool deleteData(string query)
        {
            try
            {
                openConnection();
                MySqlCommand cmd = new MySqlCommand(query, dbConnect);
                Console.WriteLine(query);
                cmd.ExecuteNonQuery();
                closeConnection();
                //cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return false;
            }
        }
        public bool login(string name, string pass)
        {
            string query = String.Format("select id, password from faculty where " +
                "id like '{0}' and password like '{1}';", name, pass);
            Console.WriteLine(query);
            openConnection();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            using (MySqlDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    if (read.GetString(0) != null && read.GetString(1) != null)
                    {
                        CurrentUser.user = FacultyVM.getFaculty(read.GetInt32(0));
                        closeConnection();
                        return true;
                    }
                }
            }
            closeConnection();
            return false;

        }
    }
}
