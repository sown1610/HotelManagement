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
            LoadDateTimePickerOrder();
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);

        }

        #region methods
        void LoadDateTimePickerOrder()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);

            //tháng hiện tại + thêm 1 tháng rồi - 1 ngày == cuối tháng
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);

        }
            void LoadListOrderByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvOrder.DataSource = OrderDAO.Instance.GetOrderListByDate(checkIn, checkOut);

        }


        #endregion
        #region events
        



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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        #endregion

        
    }
}
