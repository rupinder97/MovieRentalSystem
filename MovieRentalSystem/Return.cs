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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
            grid.DataSource = new DBContextHelper().MoviesToBeReturned();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to reurn this rental?", "Return Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string Date = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToShortTimeString();
                DBContextHelper database = new DBContextHelper();
                database.ReturnMovie(Date, grid.SelectedRows[0].Cells[0].Value.ToString());
                MessageBox.Show("Movie Returned");

                grid.DataSource = new DBContextHelper().MoviesToBeReturned();
            }
        }
    }
}
