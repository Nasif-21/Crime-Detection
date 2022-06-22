using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crime_Detection
{
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void Form22_Load(object sender, EventArgs e)
        {

        }

        private void Form22_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form20 f20 = new Form20();
            f20.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Issue warrent","Printing warrent",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //this.Hide();
            //Form23 f23 = new Form23();
            //f23.Show();
        }
    }
}
