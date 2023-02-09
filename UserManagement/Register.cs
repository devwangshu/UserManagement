using System.ComponentModel;

namespace UserManagement
{
    public partial class Register : Form
    {
        string name, email, mobile, gender, dob, password;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn signIn  = new SignIn();
            signIn.Show();
            this.Hide();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Name should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox1, "");
            }
        }

        Connection con = new Connection();
        public Register()
        {
            InitializeComponent();
            name = string.Empty;
            email = string.Empty;
            mobile = string.Empty;
            gender = string.Empty;
            dob = string.Empty;
            password = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            email = textBox2.Text;
            mobile = textBox3.Text;
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            else { gender = radioButton2.Text; }

            dob = dateTimePicker1.Text;
            password = textBox4.Text;

            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "")
                {

                    con.Open();
                    string query = "insert into users values('','" + name + "','" + email + "','" + mobile + "','" + gender + "','" + dob + "','" + password + "')";
                    Console.WriteLine(query);
                    MessageBox.Show(query);

                    int effected_row = con.ExecuteNonQuery(query);
                    if (effected_row != -1)
                    {

                        MessageBox.Show("Thanks for Registration... Now you can login.");
                        Hide();
                        SignIn signIn = new SignIn();
                        signIn.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Somthing went wrong..Please contact to admin.", "Information");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill the details", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error", "Information");
            }

        }
    }
}
