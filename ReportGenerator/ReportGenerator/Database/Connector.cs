using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace ReportGenerator
{
    class SqlConnector
    {
        private MySqlConnection dbConnect;
        private string connectionString;
        private MySqlDataAdapter adp;
        public SqlConnector(String ip, int port, String name, String password, String databaseName)
        {
            connectionString =
                "datasource=" + ip +
                ";port=" + port +
                ";username=" + name +
                ";password=" + password +
                ";database=" + databaseName+
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
    }
}
