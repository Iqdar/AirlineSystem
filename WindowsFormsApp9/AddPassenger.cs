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
using System.Media;
namespace WindowsFormsApp9
{
    public partial class AddPassenger : Form
    {
        public AddPassenger()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if ((materialSingleLineTextField1.Text.ToString()).Equals("") || (materialSingleLineTextField2.Text.ToString()).Equals("") || (materialSingleLineTextField3.Text.ToString()).Equals("") || (materialSingleLineTextField4.Text.ToString()).Equals(""))
            {
                MessageBox.Show("Please complete the form first");
            }
            else
            {
                string constring = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
                string maxID;
                string CNid;
                int ID = 0;
                int ContactID = 0;
                SqlConnection Con = new SqlConnection(constring);
                Con.Open();
                if (Con.State == System.Data.ConnectionState.Open)
                {
                    string a = "select max(PsID) as PSID from Passengers";
                    SqlCommand cmd1 = new SqlCommand(a, Con);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        maxID = reader["PSID"].ToString();
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
                    string b = "select max(CnID) as CnID from ContactDetails";
                    SqlCommand cmd2 = new SqlCommand(b, Con);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        CNid = reader2["CnID"].ToString();
                        ContactID = Int32.Parse(CNid) ;
                        reader2.Close();
                    }
                    try
                    {
                        string q = "insert into Passengers values('" + ID.ToString() + "','" + materialSingleLineTextField1.Text.ToString() + "','" + materialSingleLineTextField2.Text.ToString() + "','" + materialSingleLineTextField3.Text.ToString() + "','" + materialSingleLineTextField4.Text.ToString() + "', '" + ContactID.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(q, Con);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception) {
                        MessageBox.Show("Enter Correct age");
                    }
                }
                MessageBox.Show("The ID of new Passenger" +ID);
                AddPassengerMessage form = new AddPassengerMessage();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void materialSingleLineTextField3_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
