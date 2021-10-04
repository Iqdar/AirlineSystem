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

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Passengers form = new Passengers();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conString = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
            SqlConnection Con = new SqlConnection(conString);
            Con.Open();
            String query = " select * from FlightShedule where FlightDate = cast(getDate() as date)";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            Con.Close();
        }
        private void GetData(string selectCommand)
        {
           
        }


        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Flights form = new Flights();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            Booking form = new Booking();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
