using MySql.Data;
using MySql.Data.MySqlClient;
namespace testiranje
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string connString = "server=localhost;database=testiranje;username=root;password=;";
            MySqlConnection conn = new MySqlConnection(connString);
            using (conn)
            {
                conn.Open();
                string cmd = "SELECT * FROM login WHERE username = @uname AND password = @upwd";
                MySqlCommand c = new MySqlCommand(cmd, conn);
                c.Parameters.AddWithValue("@uname", username);
                c.Parameters.AddWithValue("@upwd", password);
                try
                {
                    MySqlDataReader reader = c.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login sucsess");
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new frmRegister();
            frm.Show();
            this.Hide();
        }
    }
}
