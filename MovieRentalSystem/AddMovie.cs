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
    public partial class AddMovie : Form
    {
        public AddMovie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b;

            if (tb1.Text == "" || tb2.Text == "" || tb3.Text == "" || tb4.Text == "" || tb5.Text == "" || tb6.Text == "")
            {
                MessageBox.Show("****Fill mandatory fields*****");
            }
            else if (!int.TryParse(tb3.Text, out a) || !(int.TryParse(tb4.Text, out b)))
            {
                MessageBox.Show("Year and Copies must be a correct value");
            }
            else
            {
                int rental = 0;
                if ((DateTime.Now.Year - a) > 5)
                {
                    rental = 2;
                }
                else
                {
                    rental = 5;
                }

                DBContextHelper database = new DBContextHelper();
                database.CreateMovie(tb1.Text, tb2.Text, tb3.Text, rental.ToString(), tb4.Text, tb5.Text, tb6.Text);

                MessageBox.Show("Movie Added");
            }
        }
    }
}
