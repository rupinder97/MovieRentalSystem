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
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
            gridc.DataSource = new DBContextHelper().GetMostValuedCust();
            gridm.DataSource = new DBContextHelper().GetBestSellers();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            
        }
    }
}
