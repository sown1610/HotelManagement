using HotelManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            LoadAccountList();
        }

        private void LoadAccountList()
        {
            string query = "exec USP_GetAccountByUserName @username";
            DataProvider provider = new DataProvider();
            dtgAccount.DataSource = provider.ExecuteQuery(query,new object[] {"sa"});


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtServicesName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dtgServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
