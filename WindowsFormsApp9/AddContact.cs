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
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text.ToString()).Equals("") || (materialSingleLineTextField1.Text.ToString()).Equals("") || (materialSingleLineTextField2.Text.ToString()).Equals("") || (materialSingleLineTextField3.Text.ToString()).Equals(""))
            {
                MessageBox.Show("Please complete the form first");
            }
            else
            {
                string constring = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
                string maxID;
                string STid;
                int ID = 0;
                int StateID = 0;
                SqlConnection Con = new SqlConnection(constring);
                Con.Open();
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    string a = "select max(CnID) as CNID from ContactDetails";
                    SqlCommand cmd1 = new SqlCommand(a, Con);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        maxID = reader["CNID"].ToString();
                        if (maxID.Equals(""))
                        {
                            ID = 1;
                        }
                        else
                        {
                            ID = Int32.Parse(maxID) + 1;
                        }
                        reader.Close();
                    }
                    string b = "select * from [State] where StateName like '" + comboBox1.Text.ToString() + "'";
                    SqlCommand cmd2 = new SqlCommand(b, Con);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        STid = reader2["StID"].ToString();
                        StateID = Int32.Parse(STid) + 1;
                        reader2.Close();
                    }

                    string q = "insert into ContactDetails values('" + ID.ToString() + "','" + materialSingleLineTextField1.Text.ToString() + "','" + materialSingleLineTextField2.Text.ToString() + "','"  + materialSingleLineTextField3.Text.ToString() + "', '" + StateID.ToString()+ "')";
                    SqlCommand cmd = new SqlCommand(q, Con);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        AddPassenger form = new AddPassenger();
                        this.Hide();
                        form.ShowDialog();
                        this.Close();
                    }
                    catch (Exception) {
                        MessageBox.Show("The state you entered is incorrect");
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            string constring = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";

            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                string q = "Select StateName from [dbo].[State]";
                SqlCommand cmd = new SqlCommand(q, Con);
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["StateName"]);
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Error");
                }
            }
        }
    }
}
