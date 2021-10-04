using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Passengers : Form
    {
        public Passengers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            AddContact form = new AddContact();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            DeletePassenger form = new DeletePassenger();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            ViewPassenger form = new ViewPassenger();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
