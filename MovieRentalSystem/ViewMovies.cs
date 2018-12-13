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
    public partial class ViewMovies : Form
    {
        public ViewMovies()
        {
            InitializeComponent();
        }

        private void ViewMovies_Load(object sender, EventArgs e)
        {
            grid.DataSource = new DBContextHelper().GetAllMovies();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditMovie obj = new EditMovie(grid.SelectedRows[0].Cells[0].Value.ToString());
            obj.ShowDialog();
            grid.DataSource = new DBContextHelper().GetAllMovies();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int copies = new DBContextHelper().CheckCopies(Convert.ToInt32(grid.SelectedRows[0].Cells[0].Value));
            if (copies > 0)
            {
                Issue issueRental = new Issue(grid.SelectedRows[0].Cells[0].Value.ToString());
                issueRental.ShowDialog();
                grid.DataSource = new DBContextHelper().GetAllMovies();
            }
            else
            {
                MessageBox.Show("No copy available to rent");
            }
        }
    }
}
