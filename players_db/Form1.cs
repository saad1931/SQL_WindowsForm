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

namespace players_db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-M4RB1S2;Initial Catalog=Players;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO players (Jersey, F_name, L_name, age, Rolee, runs, wickets, average) VALUES (@Jersey, @F_name, @L_name, @age, @Rolee, @runs, @wickets, @average)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Jersey", int.Parse(textBox1.Text));
                    command.Parameters.AddWithValue("@F_name", textBox2.Text);
                    command.Parameters.AddWithValue("@L_name", textBox3.Text);
                    command.Parameters.AddWithValue("@age", int.Parse(textBox4.Text));
                    command.Parameters.AddWithValue("@Rolee", textBox5.Text);
                    command.Parameters.AddWithValue("@runs", long.Parse(textBox6.Text));
                    command.Parameters.AddWithValue("@wickets", long.Parse(textBox7.Text));
                    command.Parameters.AddWithValue("@average", float.Parse(textBox8.Text));

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data inserted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Data insertion failed!");
                    }
                }
            }
        }
    }
}

