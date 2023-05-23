using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.MonthCalendar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Praktika2
{
    public partial class Form1 : Form
    {
        MySql.Data.MySqlClient.MySqlConnection connection;
        string myConnectionString;
        MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter;

        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string raion = this.textBox1.Text;
            string stoimost = (textBox2.Text);
            string ploschad = textBox3.Text;
            string k_prestig = textBox4.Text;

            string query = "INSERT INTO ishod_danie (raion, stoimost, ploschad, k_prestig) VALUES (@raion, @stoimost, @ploschad, @k_prestig)";

            var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@raion", raion);
            command.Parameters.AddWithValue("@stoimost", stoimost);
            command.Parameters.AddWithValue("@ploschad", ploschad);
            command.Parameters.AddWithValue("@k_prestig", k_prestig);
            command.ExecuteNonQuery();

            try
            {
                MessageBox.Show("Данные успешно добавлены в базу данных.");
                string queryy = "SELECT * FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
                string raion = this.textBox5.Text;
                if (int.TryParse(raion, out int number))
                {
                    MessageBox.Show("Неправильное значение");
                    return;
                }
                string query = "DELETE FROM ishod_danie WHERE raion = @raion";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@raion", raion);
                command.ExecuteNonQuery();

                try
                {
                    MessageBox.Show("Данные удалены");
                    string queryy = "SELECT * FROM shet";
                    mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(queryy, connection);
                    DataTable table = new DataTable();
                    mySqlDataAdapter.Fill(table);

                    dataGridView1.DataSource = new BindingSource(table, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT raion FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT stoimost FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT ploschad FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT k_prestig FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT * FROM shet";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT raion FROM shet order by raion";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            {
                string query = "SELECT raion FROM shet order by raion desc";
                mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySqlDataAdapter.Fill(table);

                dataGridView1.DataSource = new BindingSource(table, null);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string query = "SELECT stoimost FROM shet order by stoimost";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string query = "SELECT stoimost FROM shet order by stoimost desc";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string query = "SELECT ploschad FROM shet order by ploschad";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string query = "SELECT ploschad FROM shet order by ploschad desc";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string query = "SELECT k_prestig FROM shet order by k_prestig";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string query = "SELECT k_prestig FROM shet order by k_prestig desc";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM shet order by raion";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM shet order by raion desc";
            mySqlDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            mySqlDataAdapter.Fill(table);

            dataGridView1.DataSource = new BindingSource(table, null);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
