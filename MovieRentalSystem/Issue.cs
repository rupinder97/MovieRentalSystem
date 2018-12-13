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
    public partial class Issue : Form
    {
        private string Id;

        public Issue()
        {
            InitializeComponent();
        }

        public Issue(string Id)
        {
            this.Id = Id;
            InitializeComponent();
            movieid.Text = Id;
        }

        private void Issue_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb2.Text == "")
            {
                MessageBox.Show("Enter valid Customer ID");
            }
            else
            {
                string Date = DateTime.Now.ToString("MM/dd/yyyy") + " " + DateTime.Now.ToShortTimeString();
                DBContextHelper database = new DBContextHelper();
                database.IssueMovie(Id, customerid.Text, Date);

                MessageBox.Show("Movie Rented");
                Dispose();
            }
        }

        private void CustID_TextChanged(object sender, EventArgs e)
        {
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";

            DataTable table = new DBContextHelper().GetCustByID(customerid.Text);

            if (table.Rows.Count > 0)
            {
                tb1.Text = table.Rows[0]["FirstName"].ToString();
                tb2.Text = table.Rows[0]["LastName"].ToString();
                tb3.Text = table.Rows[0]["Address"].ToString();
                tb4.Text = table.Rows[0]["Phone"].ToString();
            }
        }
    }
}
