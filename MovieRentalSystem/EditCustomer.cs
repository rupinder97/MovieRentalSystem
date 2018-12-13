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
    public partial class EditCustomer : Form
    {
        string Id;

        public EditCustomer()
        {
            InitializeComponent();
        }

        public EditCustomer(string Id)
        {
            this.Id = Id;
            DataTable table = new DBContextHelper().GetCustByID(Id);
            InitializeComponent();
            tb1.Text = table.Rows[0]["FirstName"].ToString();
            tb2.Text = table.Rows[0]["LastName"].ToString();
            tb3.Text = table.Rows[0]["Address"].ToString();
            tb4.Text = table.Rows[0]["Phone"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb1.Text == "" || tb2.Text == "" || tb3.Text == "" || tb4.Text == "")
            {
                MessageBox.Show("****Fill mandatory fields*****");
            }
            else
            {
                DBContextHelper database = new DBContextHelper();
                database.UpdateCust(tb1.Text, tb2.Text, tb3.Text, tb4.Text, Id);
                MessageBox.Show("Customer Updated");
                Dispose();
            }
        }
    }
}
