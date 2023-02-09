using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UserManagement
{
    public partial class UserList : Form
    {
        Connection con = new Connection();
        string user = string.Empty;
        public UserList()
        {
            InitializeComponent();
        }

        public UserList(string username)
        {
            InitializeComponent();
            user = username;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UserList_Load(object sender, EventArgs e)
        {
            label_username.Text += " "+user;
            label_username.ForeColor= Color.Green;
            con.Open();
            string query = "select name,email,mobile,gender from users;";
            DataSet dt= new DataSet();
            //dt.Tables.Clear();
            dt= con.ExecuteDataSet(query);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor= Color.Black;
            dataGridView1.DataSource = dt.Tables["result"];
        }

        private void UserList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            Hide();
        }
    }
}
