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
    public partial class Booking : Form
    {
        public Booking()
        {
            InitializeComponent();
        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            string constring = "Data Source=DESKTOP-4929NGJ;Initial Catalog=Airline;Integrated Security=True";
            string seat;
            string date ="";
            string AcID="";
            string FareID = "";
            int business =0 ;
            int middle=0;
            int economy=0;
            int prevSeat=0;
            SqlConnection Con = new SqlConnection(constring);
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
                {
                    
                string q = "select Booking.SeatNo, FlightShedule.FlightDate, FlightShedule.Aircraft, Capacity.BusinessClass,Capacity.MiddleClass, Capacity.EconomyClass, FlightShedule.FlID, FlightShedule.FareID from FlightShedule inner Join Aircrafts on Aircrafts.AcID = FlightShedule.Aircraft inner join Capacity on Aircrafts.AcID = Capacity.AcID left outer join Booking on Booking.Flight = FlightShedule.FlID  and Booking.SeatNo = (select max(SeatNo) from Booking where Class like '"+comboBox3.Text.ToString()+"')where FlightShedule.FlID = "+materialSingleLineTextField2.Text.ToString()+" ";
                SqlCommand cmd = new SqlCommand(q, Con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    AcID = reader["Aircraft"].ToString();
                    FareID = reader["FareID"].ToString();
                    date = reader["FlightDate"].ToString();
                    business = Int32.Parse(reader["BusinessClass"].ToString());
                    middle = Int32.Parse(reader["MiddleClass"].ToString());
                    economy = Int32.Parse(reader["EconomyClass"].ToString());
                    if ((reader["SeatNo"].ToString()).Equals(""))
                    {
                        prevSeat = 0;
                    }
                    else{
                        prevSeat = Int32.Parse(reader["SeatNo"].ToString());
                    }
                    reader.Close();
                    }
                }
            if (AcID.Equals(""))
            {
                MessageBox.Show("Insert Correct Flight ID");
            }
            else
            {
                if (((comboBox3.Text.ToString()).Equals("Business Class") && prevSeat == business) || ((comboBox3.Text.ToString()).Equals("Middle Class") && prevSeat == middle) || ((comboBox3.Text.ToString()).Equals("Economy Class") && prevSeat == economy))
                {
                    MessageBox.Show("Seats are full");
                }
                else
                {
                    try
                    {
                        seat = (prevSeat + 1).ToString();
                        string r = "insert into Booking values(GetDate(),'" + date + "'," + materialSingleLineTextField1.Text.ToString() + "," + AcID + ",'" + comboBox3.Text.ToString() + "', " + seat + "," + materialSingleLineTextField2.Text.ToString() + "," + FareID + ")";
                        SqlCommand cmd2 = new SqlCommand(r, Con);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Your Flight has been booked \n Seat Number " + seat);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter Correct data");
                    }
                    this.Close();
                }
            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            AddContact form = new AddContact();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
