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
    public partial class Form6 : Form
    {
        public static string name;
        public static string id;
        public Form6()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm1 = new Form1();
            fm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form16 f16 = new Form16();
            f16.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Form15 f15 = new Form15();
        //    f15.Show();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Form18 f18 = new Form18();
        //    f18.Show();
        //}
    }
}
