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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-M4RB1S2;Initial Catalog=Players;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE players SET F_name = @F_name, L_name = @L_name, Age = @Age, Rolee = @Rolee, runs = @runs, wickets = @wickets, average = @average WHERE Jersey = @Jersey";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@F_name", textBox2.Text);
                    command.Parameters.AddWithValue("@L_name", textBox3.Text);
                    command.Parameters.AddWithValue("@Age", int.Parse(textBox4.Text));
                    command.Parameters.AddWithValue("@Rolee", textBox5.Text);
                    command.Parameters.AddWithValue("@runs", long.Parse(textBox6.Text));
                    command.Parameters.AddWithValue("@wickets", long.Parse(textBox7.Text));
                    command.Parameters.AddWithValue("@average", float.Parse(textBox8.Text));
                    command.Parameters.AddWithValue("@Jersey", int.Parse(textBox1.Text));

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Data updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Data update failed!");
                    }
                }
            }
        }
    }
}
