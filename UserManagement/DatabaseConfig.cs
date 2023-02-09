using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace UserManagement
{
    public partial class DatabaseConfig : Form
    {
        string hostname, username, password, database;

        private void button2_Click(object sender, EventArgs e)
        {
            hostname = textBox1.Text;
            username = textBox2.Text;
            password = textBox3.Text;
            database = textBox4.Text;

            try
            {
                MySqlConnection conn;
                string strProvider = "server=" + hostname + ";Database=" + database + ";User ID=" + username + ";Password=" + password;
                conn = new MySqlConnection(strProvider);
                conn.Open();
                label_result.Text = "Connection Success";
                label_result.ForeColor= System.Drawing.Color.Green;
            }
            catch (Exception er)
            {
                label_result.Text = "Connection Fail"+er.Message;
                label_result.ForeColor = System.Drawing.Color.Red;
            }
        }

        public DatabaseConfig()
        {
            InitializeComponent();
            hostname = string.Empty;
            username = string.Empty;
            password = string.Empty;
            database = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hostname = textBox1.Text; 
            username = textBox2.Text;
            password = textBox3.Text;
            database = textBox4.Text;


            XmlDocument xDoc = new XmlDocument();
            //string sFileName = "App.config";
            string sFileName = @"C:\Users\user0581\Desktop\Dew\UserManagement\UserManagement\App.config";
            //string sFileName = "\UserManagement\App.config"

            string key = "MyKey";
            string val = "false";
            string mysqlprovidername = "MySql.Data.MySqlClient";
            try
            {
                XmlDeclaration xmlDeclaration = xDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xDoc.DocumentElement;
                xDoc.InsertBefore(xmlDeclaration, root);

                XmlElement root1 = xDoc.CreateElement("configuration");
                XmlElement id = xDoc.CreateElement("appSettings");
                XmlElement add = xDoc.CreateElement("add");
                add.SetAttribute("key", key);
                add.SetAttribute("value", val);
                id.AppendChild(add);
                root1.AppendChild(id);

                XmlElement constr = xDoc.CreateElement("connectionStrings");
                XmlElement add1 = xDoc.CreateElement("add");
                add1.SetAttribute("name", "MySQL");
                //string ssss = "SERVER = 127.0.0.1; DATABASE = dew; UID = root; PASSWORD = ";
                string ssss = "SERVER = "+hostname+"; DATABASE = "+database+"; UID = "+username+"; PASSWORD = "+password+"";
                add1.SetAttribute("connectionString", ssss);
                add1.SetAttribute("providerName", mysqlprovidername);
                constr.AppendChild(add1);
                root1.AppendChild(constr);

                xDoc.AppendChild(root1);



                xDoc.Save(sFileName);
                xDoc = null;
                MessageBox.Show("Configurations saved successfully.","Information");
                /*SplashScreen sp = new SplashScreen();
                this.Hide();
                sp.Show();*/
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("replaceConfigSettings()" + ex.Message);
                xDoc = null;
            }
        }
    }
}
