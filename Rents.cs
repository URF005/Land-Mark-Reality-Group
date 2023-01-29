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
    public partial class Rents : Form
    {
        public Rents()
        {
            InitializeComponent();
            getapartment();
            gettenant();
            showrent();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRHLV5I;Initial Catalog=HouseRentTuto;Integrated Security=True");
        private void showrent()
        {
            con.Open();
            string query = "Select * from RentTbl  ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            rental.DataSource = ds.Tables[0];
            con.Close();
        }
        private void resetdata()
        {
            amountcb.Text = "";
            period.Text = "";
            apartcb.SelectedIndex = -1;
            tenantcb.SelectedIndex = -1;
        }

        private void getapartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Anum from ApartTbl ", con);
            SqlDataReader rdr;
            DataTable dt = new DataTable();
            dt.Columns.Add("Anum", typeof(int));
            rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            apartcb.ValueMember = "Anum";
            apartcb.DataSource = dt;
            con.Close();
        }
        private void gettenant()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Tenid from TenantTbl ", con);
            SqlDataReader rdr;
            DataTable dt = new DataTable();
            dt.Columns.Add("Tenid", typeof(int));
            rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            tenantcb.ValueMember = "Tenid";
            tenantcb.DataSource = dt;
            con.Close();
        }
        private void getcost()
        {
            con.Open();
            string query = "select * from ApartTbl where Anum= " + apartcb.SelectedValue.ToString() +"";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                amountcb.Text = dr["ACost"].ToString();
            }
            con.Close();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void rental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            apartcb.Text = rental.SelectedRows[0].Cells[1].Value.ToString();
            tenantcb.Text = rental.SelectedRows[0].Cells[2].Value.ToString();
            period.Text = rental.SelectedRows[0].Cells[3].Value.ToString();
            amountcb.Text = rental.SelectedRows[0].Cells[4].Value.ToString();
           


            if (apartcb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(rental.SelectedRows[0].Cells[0].Value.ToString());

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (apartcb.SelectedIndex == -1|| tenantcb.SelectedIndex== -1 || amountcb.Text == "" || period.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into RentTbl(Apartment,Tenant,Periood,Amount)values(@AAN,@AAA,@AAT,@AAC)", con);
                    cmd.Parameters.AddWithValue("@AAC", amountcb.Text);
                    cmd.Parameters.AddWithValue("@AAT", period.Text);
                    cmd.Parameters.AddWithValue("@AAN", apartcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AAA", tenantcb.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental details Add");
                    con.Close();
                    resetdata();
                    showrent();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Details");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from RentTbl where RCode=@Skey", con);
                    cmd.Parameters.AddWithValue("@Skey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Details Deleted");
                    con.Close();
                    resetdata();
                    showrent();


                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (amountcb.Text == "" || period.Text == "" ||tenantcb.SelectedIndex == -1 ||apartcb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Information");
            }
            else
            {
                try
                {
                  
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update RentTbl set Apartment=@AN,Tenant=@AA, Periood=@AT,Amount=@AC where RCode=@Akey", con);
                    cmd.Parameters.AddWithValue("@AN", apartcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AA", tenantcb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AT", period.Text);
                    cmd.Parameters.AddWithValue("@AC", amountcb.Text);
                    cmd.Parameters.AddWithValue("@Akey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment Updated");
                    con.Close();
                    resetdata();
                    showrent();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void apartcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
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
            Categories obj = new Categories ();
            obj.Show();
            //this.Hide();
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

        private void Rents_Load(object sender, EventArgs e)
        {

        }

        private void amountcb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void apartcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getcost();
        }
    }
}
