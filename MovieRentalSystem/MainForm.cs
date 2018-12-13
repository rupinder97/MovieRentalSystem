using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new AddCustomer());
        }

        void MethodToReuseDialogDisplay(Form o)
        {
            o.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new ViewCustomer());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new ViewMovies());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new AddMovie());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new ViewMovies());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new Return());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MethodToReuseDialogDisplay(new Reports());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
