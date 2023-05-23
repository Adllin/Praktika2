using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Praktika2
{
    public partial class Form2 : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection;
        string myConnectionString;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;

        public Form2()
        {
            InitializeComponent();
            myConnectionString = "Server=127.0.0.1;Database=praktika2;Uid=root;Pwd=root;";

            try
            {
                connection = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
                connection.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM vhod WHERE login=@login AND password=@password", connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);

            if (Convert.ToInt32(command.ExecuteScalar()) > 0)
            {
                new Form1().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Ошибка ввода логина или пароля!");
            }

            connection.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
