﻿using HotelManagement.DAO;
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
        BindingSource roomlist = new BindingSource();
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
            LoadListRoom();
            addRoomBinding();
            LoadCategoryIntoCombobox(cbRoomCategory);
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
            txtServicesName.DataBindings.Add(new Binding("Text", dtgServices.DataSource, "servicename", true, DataSourceUpdateMode.Never));
            txtServicesID.DataBindings.Add(new Binding("Text", dtgServices.DataSource, "serviceid", true, DataSourceUpdateMode.Never));
            numServicePrice.DataBindings.Add(new Binding("Value", dtgServices.DataSource, "serviceprice", true, DataSourceUpdateMode.Never));
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

        void loadCategoryToComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "categoryname";
            cb.Refresh();
        }
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

        private void cboCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        void LoadListRoom()
        {
            dtgRoom.DataSource = RoomDAO.Instance.GetListRoom();
            
        }
        void addRoomBinding()
        {
            txtroomname.DataBindings.Add(new Binding("Text", dtgRoom.DataSource, "roomname", true, DataSourceUpdateMode.Never));
            txtroomid.DataBindings.Add(new Binding("Text", dtgRoom.DataSource, "roomid", true, DataSourceUpdateMode.Never));
            numRoomPrice.DataBindings.Add(new Binding("Value", dtgRoom.DataSource, "roomprice", true, DataSourceUpdateMode.Never));
            
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string name = txtroomname.Text;
            int cateid = (cbRoomCategory.SelectedItem as Category).CategoryID;
            float price = (float)numRoomPrice.Value;

            if (RoomDAO.Instance.InsertRoom(name, cateid,price))
            {
                MessageBox.Show("Thêm thành công");
                LoadListRoom();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm ");
            }
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "categoryname";
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            string name = txtroomname.Text;
            int cateid = (cbRoomCategory.SelectedItem as Category).CategoryID;
            float price = (float)numRoomPrice.Value;
            int roomid = Convert.ToInt32(txtroomid.Text);
            if (RoomDAO.Instance.UpdateRoom(roomid,name, cateid, price))
            {
                MessageBox.Show("Sửa  thành công");
                LoadListRoom();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm rồi đần ");
            }
        }
    }
}
