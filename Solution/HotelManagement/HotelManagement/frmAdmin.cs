using HotelManagement.DAO;
using HotelManagement.DTO;
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
        BindingSource serviceList = new BindingSource();
        public frmAdmin()
        {
            InitializeComponent();
            Load();
        }

        #region methods
        void Load()
        {
            dtgServices.DataSource = serviceList;
            LoadDateTimePickerOrder();
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListService();
            AddServiceBinding();
        }
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
        void AddServiceBinding()
        {
            txtServicesName.DataBindings.Add(new Binding("Text", dtgServices.DataSource, "ServiceName"));
            txtServicesID.DataBindings.Add(new Binding("Text", dtgServices.DataSource, "ServiceID"));
            numServicePrice.DataBindings.Add(new Binding("Value", dtgServices.DataSource, "ServicePrice"));
        }
        void LoadListService()
        {
            serviceList.DataSource = ServiceDAO.Instance.GetListService();
        }


        #endregion
        #region events
        private void btnViewServices_Click(object sender, EventArgs e)
        {
            LoadListService();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }




        #endregion

        private void txtServiceID_TextChange(object sender, EventArgs e)
        {
            if (dtgServices.SelectedCells.Count > 0)
            {
                //int id = (int)dtgServices.SelectedCells[0].OwningRow.Cells["RoomId"].Value;
                //if (Int32.TryParse(txtCategoryID.Text, out id))
                //{
                //    Room room = RoomDAO.Instance.GetRoomById(id);
                //    cbRoomCategory.SelectedItem = room;

                //    int index = -1;
                //    int i = 0;
                //    foreach (Room item in cbRoomCategory.Items)
                //    {
                //        if(item.ID == room.Roomid)
                //    }
                //}
            }

        }

        private void btnAddServices_Click(object sender, EventArgs e)
        {
            string name = txtServicesName.Text;
            //int serviceID = (cboCatge./*SelectedItem*/ as Category).CategoryID;
            float price = (float)numServicePrice.Value;

            if(ServiceDAO.Instance.InsertService(name,price))
            {
                MessageBox.Show("Thêm Service thành công");
                LoadListService();  
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm");

            }
        }
    }
}
