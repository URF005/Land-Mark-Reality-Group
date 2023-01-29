using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace LRG
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
            showcat();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRHLV5I;Initial Catalog=HouseRentTuto;Integrated Security=True");
        private void showcat()
        {
            con.Open();
            string query = "Select * from CategoryTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            cat.DataSource = ds.Tables[0];
            con.Close();
        }
        private void resetdata()
        {
            catname.Text = "";
            catremarks.Text = "";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (catname.Text == "" || catremarks.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CategoryTbl(Category,Remarks)values(@CN,@CP)", con);
                    cmd.Parameters.AddWithValue("@CN", catname.Text);
                    cmd.Parameters.AddWithValue("@CP", catremarks.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Add");
                    con.Close();
                    resetdata();
                    showcat();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Categories_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a tenant");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from CategoryTbl where CNum=@Tkey", con);
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Category Deleted");
                    con.Close();
                    resetdata();
                    showcat();


                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);

                }
            }

        }
        int key = 0;
        private void cat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catname.Text = cat.SelectedRows[0].Cells[1].Value.ToString();
            catremarks.Text = cat.SelectedRows[0].Cells[2].Value.ToString();

            if (catname.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(cat.SelectedRows[0].Cells[0].Value.ToString());

            }

        }
    }
}
