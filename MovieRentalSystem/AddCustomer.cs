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
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tb1.Text == "" || tb2.Text == "" || tb3.Text == "" || tb.Text == "")
            {
                MessageBox.Show("****Fill mandatory fields*****");
            }
            else
            {
                DBContextHelper database = new DBContextHelper();
                database.CreateCust(tb1.Text, tb2.Text, tb3.Text, tb.Text);
                MessageBox.Show("Customer Added");
                Dispose();
            }
        }
    }
}
