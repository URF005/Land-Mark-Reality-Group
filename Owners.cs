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
    public partial class Owners : Form
    {
        public Owners()
        {
            InitializeComponent();
            showtenants();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRHLV5I;Initial Catalog=HouseRentTuto;Integrated Security=True");
        private void showtenants()
        {
            con.Open();
            string query = "Select * from TenantTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Tenants.DataSource = ds.Tables[0];
            con.Close();
        }
        private void resetdata()
        {
            phoneTb.Text = "";
            Gencb.SelectedIndex = -1;
            TnameTb.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)

        {

            Close();
        }

        private void Owners_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("delete from TenantTbl where TenId=@Tkey", con);
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Deleted");
                    con.Close();
                    resetdata();
                    showtenants();


                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);

                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (TnameTb.Text == "" || phoneTb.Text == "" || Gencb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into TenantTbl(TenName,TenPhone,TenGen)values(@TN,@TP,@TG)", con);
                    cmd.Parameters.AddWithValue("@TN", TnameTb.Text);
                    cmd.Parameters.AddWithValue("@TP", phoneTb.Text);
                    cmd.Parameters.AddWithValue("@TG", Gencb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Add");
                    con.Close();
                    resetdata();
                    showtenants();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void Tenants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TnameTb.Text = Tenants.SelectedRows[0].Cells[1].Value.ToString();
            phoneTb.Text = Tenants.SelectedRows[0].Cells[2].Value.ToString();
            Gencb.Text = Tenants.SelectedRows[0].Cells[3].Value.ToString();
            

            if (TnameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(Tenants.SelectedRows[0].Cells[0].Value.ToString());

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (TnameTb.Text == "" || phoneTb.Text == "" || Gencb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update TenantTbl set TenName=@TN,TenPhone=@TP, TenGen=@TG where TenId=@Tkey", con);
                    cmd.Parameters.AddWithValue("@TN", TnameTb.Text);
                    cmd.Parameters.AddWithValue("@TP", phoneTb.Text);
                    cmd.Parameters.AddWithValue("@TG", Gencb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tenant Updated");
                    con.Close();
                    resetdata();
                    showtenants();


                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Owners obj = new Owners();
            obj.Show();
            this.Hide();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Apartments obj = new Apartments();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Landlord obj = new Landlord();
            obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Rents obj = new Rents();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Categories obj = new Categories();
            obj.Show();
           // this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}