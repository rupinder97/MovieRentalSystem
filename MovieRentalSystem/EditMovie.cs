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
    public partial class EditMovie : Form
    {
        string MovieId;
        public EditMovie()
        {
            InitializeComponent();
        }

        public EditMovie(string Id)
        {
            MovieId = Id;
            InitializeComponent();
            DataTable table = new DBContextHelper().GetMovieByMovieID(MovieId);
            tb1.Text = table.Rows[0]["Rating"].ToString();
            tb2.Text = table.Rows[0]["Title"].ToString();
            tb3.Text = table.Rows[0]["Year"].ToString();
            tb4.Text = table.Rows[0]["Copies"].ToString();
            tb5.Text = table.Rows[0]["Plot"].ToString();
            tb6.Text = table.Rows[0]["Genre"].ToString();
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
                database.UpdateMovie(tb1.Text, tb2.Text, tb3.Text, rental.ToString(), tb4.Text, tb5.Text, tb6.Text, MovieId);
                MessageBox.Show("Movie Updated");
                Dispose();
            }
        }
    }
}
