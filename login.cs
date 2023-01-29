namespace LRG
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();

        }
        private void Reset()
        {
            user.Text = "";
            pass.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text== "")
            {
                MessageBox.Show("Please enter both");
            }
            else if(user.Text == "admin" || pass.Text == "qwerty")
            {
                Owners obj = new Owners();
                obj.Show();
                this.Hide();
                Reset();

            }
            else
            {
                MessageBox.Show("Wrong Passward or Username");
                Reset();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}