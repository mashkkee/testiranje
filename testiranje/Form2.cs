using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testiranje
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
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
                string cmd = "INSERT INTO login(username, password) VALUES(@username, @password)";
                MySqlCommand c = new MySqlCommand(cmd, conn);
                c.Parameters.AddWithValue("@username", username);
                c.Parameters.AddWithValue("@password", password);
                try
                {
                    int status = c.ExecuteNonQuery();
                    if (status > 0)
                    {
                        MessageBox.Show("Register sucsess");
                        conn.Close();
                        Form login = new frmLogin();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Register failed");
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
