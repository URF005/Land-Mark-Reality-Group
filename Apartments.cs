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
    public partial class Apartments : Form
    {
        public Apartments()
        {
            InitializeComponent();
            getcategories();
            getowner();
            showaprt();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NRHLV5I;Initial Catalog=HouseRentTuto;Integrated Security=True");
        private void showaprt()
        {
            con.Open();
            string query = "Select * from ApartTbl  ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            aparts.DataSource = ds.Tables[0];
            con.Close();
        }
        private void resetdata()
        {
            apadress.Text = "";
            apname.Text = "";
            apcost.Text = "";
            aptype.SelectedIndex = -1;
            apowners.SelectedIndex = -1;
        }

        private void getcategories()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select CNum from CategoryTbl ",con);
            SqlDataReader rdr;
            DataTable dt=new DataTable();
            dt.Columns.Add("CNum",typeof(int));
            rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            aptype.ValueMember = "CNum";
            aptype.DataSource = dt;
            con.Close();
        }
        private void getowner()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select LLid from LandLordTbl ", con);
            SqlDataReader rdr;
            DataTable dt = new DataTable();
            dt.Columns.Add("LLid", typeof(int));
            rdr = cmd.ExecuteReader();
            dt.Load(rdr);
            apowners.ValueMember = "LLid";
            apowners.DataSource = dt;
            con.Close();

        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (apname.Text == "" || apcost.Text == "" || apadress.Text == ""||apowners.SelectedIndex==-1||apowners.SelectedIndex==-1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ApartTbl(AName,AAddress,AType,ACost,AOwner)values(@AAN,@AAA,@AAT,@AAC,@AAO)", con);
                    cmd.Parameters.AddWithValue("@AAN", apname.Text);
                    cmd.Parameters.AddWithValue("@AAA", apadress.Text);
                    cmd.Parameters.AddWithValue("@AAC", apcost.Text);
                    cmd.Parameters.AddWithValue("@AAT", aptype.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AAO", apowners.SelectedValue.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment Add");
                    con.Close();
                    resetdata();
                    showaprt();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void Apartments_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void aparts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            apname.Text = aparts.SelectedRows[0].Cells[1].Value.ToString();
            apadress.Text = aparts.SelectedRows[0].Cells[2].Value.ToString();
            aptype.Text = aparts.SelectedRows[0].Cells[3].Value.ToString();
            apcost.Text = aparts.SelectedRows[0].Cells[4].Value.ToString();
            apowners.Text = aparts.SelectedRows[0].Cells[5].Value.ToString();


            if (apname.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(aparts.SelectedRows[0].Cells[0].Value.ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select a Apartment");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ApartTbl where Anum=@Skey", con);
                    cmd.Parameters.AddWithValue("@Skey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment Deleted");
                    con.Close();
                    resetdata();
                    showaprt();


                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (apname.Text == "" || apcost.Text == "" || apadress.Text == "" || apowners.SelectedIndex == -1 || aptype.SelectedIndex == -1)
            {
                MessageBox.Show("Select Information");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update ApartTbl set AName=@AN,AAddress=@AA, AType=@AT,ACost=@AC,AOwner=@AO where Anum=@Akey", con);
                    cmd.Parameters.AddWithValue("@AN", apname.Text);
                    cmd.Parameters.AddWithValue("@AA", apadress.Text);
                    cmd.Parameters.AddWithValue("@AT", aptype.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AC", apcost.Text);
                    cmd.Parameters.AddWithValue("@AO", apowners.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Akey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment Updated");
                    con.Close();
                    resetdata();
                    showaprt ();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {
            login obj = new login();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Categories obj = new Categories();
            obj.Show();
            //this.Hide();
        }
    }
}
