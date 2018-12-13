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
    public partial class ViewCustomer : Form
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomer obj = new EditCustomer(grid.SelectedRows[0].Cells[0].Value.ToString());

            obj.ShowDialog();
            grid.DataSource = new DBContextHelper().GetAllCust();
        }

        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            grid.DataSource = new DBContextHelper().GetAllCust();
        }
    }
}
