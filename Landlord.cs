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
    public partial class Landlord : Form
    {
        public Landlord()
        {
            InitializeComponent();
            showland();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRHLV5I;Initial Catalog=HouseRentTuto;Integrated Security=True");
        private void showland()
        {
            con.Open();
            string query = "Select * from LandLordTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            land.DataSource = ds.Tables[0];
            con.Close();
        }
        private void resetdata()
        {
            PhoneTb.Text = "";
            GenCb.SelectedIndex = -1;
            LLnameTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (LLnameTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into LandLordTbl(LLName,LLPhone,LLGen)values(@LLN,@LLP,@LLG)", con);
                    cmd.Parameters.AddWithValue("@LLN", LLnameTb.Text);
                    cmd.Parameters.AddWithValue("@LLP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@LLG", GenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("LandLord Add");
                    con.Close();
                    resetdata();
                    showland();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        int key = 0;
        private void land_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LLnameTb.Text = land.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = land.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.Text = land.SelectedRows[0].Cells[3].Value.ToString();


            if (LLnameTb.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(land.SelectedRows[0].Cells[0].Value.ToString());

            }


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
                    SqlCommand cmd = new SqlCommand("delete from LandLordTbl where LLid=@Tkey", con);
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("LandLord Deleted");
                    con.Close();
                    resetdata();
                    showland();


                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (LLnameTb.Text == "" || PhoneTb.Text == "" || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Select Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update LandLordTbl set LLName=@LLN,LLPhone=@LLP, LLGen=@LLG where LLid=@Tkey", con);
                    cmd.Parameters.AddWithValue("@LLN", LLnameTb.Text);
                    cmd.Parameters.AddWithValue("@LLP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@LLG", GenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Tkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("LandLord Updated");
                    con.Close();
                    resetdata();
                    showland();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Landlord_Load(object sender, EventArgs e)
        {

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
            //this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }
    }
}
