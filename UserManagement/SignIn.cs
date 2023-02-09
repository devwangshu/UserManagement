using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using Org.BouncyCastle.Utilities.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UserManagement
{
    public partial class SignIn : Form
    {
        Connection con = new Connection();
        public SignIn()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register register= new Register();
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            string username = "";
            /* ================ORACLE CONNECTION TEST=================
            try
            {
            // please replace the connection string attribute settings
                    //(DESCRIPTION = (CONNECT_DATA = (SERVICE_NAME =))(ADDRESS = (PROTOCOL = tcp)(HOST = 127.0.0.1)(PORT = 1521)))
                string constr = "user id=DEW@xe;password=cdac1234;data source=xe;Validate connection=true";
                string oradb = "Data Source=(DESCRIPTION =" + "(ADDRESS = (PROTOCOL = TCP)(HOST = 127.0.0.1)(PORT = 1521))" + "(CONNECT_DATA =" + "(SERVER = DEDICATED)" + "(SERVICE NAME = )+ \"(validate connection = true)));" + "User Id= DEW@xe;Password=cdac1234;";

            OracleConnection con = new OracleConnection(oradb);
                con.Open();
                MessageBox.Show("Connected to Oracle Database {0}", con.ServerVersion);
                con.Dispose();
            }
            catch (OracleException ex) // catches only Oracle errors
            {
                switch (ex.Number)
                {
                    case 1:
                        MessageBox.Show("Error attempting to insert duplicate data.");
                        break;
                    case 12545:
                        MessageBox.Show("The database is unavailable.");
                        break;
                    default:
                        MessageBox.Show("Database error: " + ex.Message.ToString());
                        break;
                }
            }
            catch (Exception ex) // catches any error
            {
                MessageBox.Show(ex.Message.ToString());
            }
            ========END ORACLE CONNECTION===============

            */

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    con.Open();
                    string query = "select * from users WHERE email ='" + textBox1.Text + "' AND password ='" + textBox2.Text + "'";
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            string id1 = row["id"].ToString();
                            username = row["name"].ToString();
                            
                        }
                        MessageBox.Show("Login Success...Welcome: " + username);
                        UserList userList = new UserList(username);
                        userList.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Credential", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");
            }

        }

        private void SignIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
