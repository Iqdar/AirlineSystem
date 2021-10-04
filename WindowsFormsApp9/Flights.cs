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
using System.Configuration;

namespace WindowsFormsApp9
{
    public partial class Flights : Form
    {
        public Flights()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Flights_Load(object sender, EventArgs e)
        {
            string constring = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";

            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                string q = "Select RouteCode from [dbo].[Routes]";
                SqlCommand cmd = new SqlCommand(q, Con);
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["RouteCode"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string conString = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
            SqlConnection Con = new SqlConnection(conString);
            Con.Open();
            String query = "select * from FlightShedule where RouteCode like '"+comboBox1.Text.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            Con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Booking form = new Booking();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
