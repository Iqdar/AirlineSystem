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
    public partial class ViewPassenger : Form
    {
        public ViewPassenger()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if((materialSingleLineTextField1.Text.ToString()).Equals("") && (materialSingleLineTextField2.Text.ToString()).Equals(""))
            {
                MessageBox.Show("Insert the data");
            }
            else
            {
                if ((materialSingleLineTextField1.Text.ToString()).Equals(""))
                {
                    string conString = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
                    SqlConnection Con = new SqlConnection(conString);
                    Con.Open();
                    String query = "select * from Passengers where Name like '" + materialSingleLineTextField2.Text.ToString() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    Con.Close();
                }
                else 
                {
                    try
                    {
                        string conString = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
                        SqlConnection Con = new SqlConnection(conString);
                        Con.Open();
                        String query = "select * from Passengers where PsID = " + materialSingleLineTextField1.Text.ToString() + "";
                        SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        Con.Close();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Wrong ID inserted");
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
