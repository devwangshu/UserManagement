using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement
{
    internal class Connection
    {
        MySqlConnection conn;
        string myConnectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString; // from app.config file
        /*static string host = "localhost";
        static string database = "dew";
        static string userDB = "root";
        static string password = "";*/

        //public static string strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
        public bool Open()
        {
            //MessageBox.Show(con_string);
            try
            {
                //strProvider = "server=" + host + ";Database=" + database + ";User ID=" + userDB + ";Password=" + password;
                //conn = new MySqlConnection(strProvider);
                conn = new MySqlConnection(myConnectionString);
                conn.Open();
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Connection Error ! " + er.Message, "Information");
            }
            return false;
        }
        public void Close()
        {
            conn.Close();
            conn.Dispose();
        }
        public DataSet ExecuteDataSet(string sql)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds, "result");
                return ds;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                int affected;
                MySqlTransaction mytransaction = conn.BeginTransaction();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                affected = cmd.ExecuteNonQuery();
                mytransaction.Commit();
                return affected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return -1;
        }
    }
}
