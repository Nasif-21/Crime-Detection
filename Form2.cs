using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Crime_Detection
{
    public partial class Form2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from person_tbl where username=@user and password=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                con.Open();
                SqlDataReader sda = cmd.ExecuteReader();
                if (sda.HasRows == true)
                {
                    MessageBox.Show("Login Sucessful", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form7 f7 = new Form7();
                    f7.Show();

                }
                else

                    MessageBox.Show("Login Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                con.Close();

            }
        
            else
            {
                MessageBox.Show("Fill the text box", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            
            
               
        }
          private void button3_Click(object sender, EventArgs e)
            {
                this.Hide();

                Form1 fm1 = new Form1();
                fm1.Show();
            }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.error;
                errorProvider2.SetError(this.textBox2, "Fill the Field");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.check;
                // errorProvider1.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.error;
                errorProvider1.SetError(this.textBox1, "Fill the Field");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.check;
                // errorProvider1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

           
}


       

      
    

