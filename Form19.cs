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
    public partial class Form19 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["abc"].ConnectionString;
        public Form19()
        {
            InitializeComponent();
            BindGridView();
        }

        private void Form19_Load(object sender, EventArgs e)
        {

        }

        private void Form19_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form17 f17 = new Form17();
            f17.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into ft_tbl values(@crime,@no_of_criminals,@area,@sample_type,@date,@collected_sample,@time_of_crime,@cid)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@crime", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@no_of_criminals", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@area", textBox1.Text);
            cmd.Parameters.AddWithValue("@sample_type", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@collected_sample", textBox3.Text);
            cmd.Parameters.AddWithValue("@time_of_crime", textBox2.Text);
            cmd.Parameters.AddWithValue("@cid", textBox4.Text);


            //cmd.Parameters.AddWithValue("@picture", );
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data inserted sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data  is not inserted ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        void BindGridView()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from  ft_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 50;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  ft_tbl where cid=@cid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@cid", textBox4.Text);
            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Deleted", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data  not deleted ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update ft_tbl set crime=@crime,no_of_criminals=@no_of_criminals,area=@area,sample_type=@sample_type,date=@date,collected_sample=@collected_sample,time_of_crime=@time_of_crime,cid=@cid where cid=@cid ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@crime", comboBox1.SelectedItem);
            cmd.Parameters.AddWithValue("@no_of_criminals", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@area", textBox1.Text);
            cmd.Parameters.AddWithValue("@sample_type", comboBox2.SelectedItem);
            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@collected_sample", textBox3.Text);
            cmd.Parameters.AddWithValue("@time_of_crime", textBox2.Text);
            cmd.Parameters.AddWithValue("@cid", textBox4.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                MessageBox.Show("Data Updated sucessfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data  is not Updated ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[1].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[4].Value);
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text= dataGridView1.SelectedRows[0].Cells[6].Value.ToString();


        }
    }
}
