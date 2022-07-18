﻿using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelManagement
{
    public partial class frmManager : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public frmManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadRoom();
            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            
        }

        void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += "(" + LoginAccount.DisplayName + ")";
        }
        void LoadCategory()
        {
            List<Category> categoryList = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "categoryname";
        }
        void LoadRoomByCategoryID(int id)
        {
            List<Room> listroom = RoomDAO.Instance.GetRoomByID(id);
            cbRoom.DataSource = listroom;
            cbRoom.DisplayMember = "roomname";
        }
        void LoadService()
        {
            List<Service> listservice = ServiceDAO.Instance.GetListService();
            cbService.DataSource = listservice;
            cbService.DisplayMember = "servicename";
        }
        #region Method
        void LoadRoom()
        {
            flpRoom.Controls.Clear();
            List<Room> roomList = RoomDAO.Instance.LoadRoomList();
            foreach (Room item in roomList)
            {
                Button btn = new Button()
                {
                    Width = RoomDAO.RoomWidth,
                    Height = RoomDAO.RoomHeight
                };
                btn.Text = item.Roomname + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightCyan;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpRoom.Controls.Add(btn);
            }

        }

        void ShowOrder(int id)
        {
            listBill.Items.Clear();
            List<Menu> listOrderDetail = MenuDAO.Instance.GetListMenuByRoom(id);
            double totalPrice = 0;
            foreach (Menu item in listOrderDetail)
            {
                ListViewItem lsvItem = new ListViewItem(item.Servicename.ToString());
                lsvItem.SubItems.Add(item.Serviceprice.ToString());
                lsvItem.SubItems.Add(item.Roomname.ToString());
                lsvItem.SubItems.Add(item.Roomprice.ToString());
                totalPrice += item.Serviceprice + item.Roomprice;
                listBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotal.Text = totalPrice.ToString("c1", culture);

        }
        #endregion
        void btn_Click(object? sender, EventArgs e)
        {
            int roomID = ((sender as Button).Tag as Room).Roomid;
            listBill.Tag = (sender as Button).Tag;
            ShowOrder(roomID);

        }
        #region Events 

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountProfile f = new frmAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender,AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.loginAccount = loginAccount;
            f.InsertService += f_InsertService;
            f.DeletetService += f_DeletetService;
            f.UpdateService += f_UpdateService;


            f.InsertCategory += f_InsertCategory;
            f.DeleteCategory += f_DeleteCategory;
            f.UpdateCategory += f_UpdateCategory;

            f.InsertRoom += f_InsertRoom;
            f.DeleteRoom += f_DeleteRoom;
            f.UpdateRoom += f_UpdateRoom;

            f.ShowDialog();
        }

        private void f_UpdateRoom(object? sender, EventArgs e)
        {
            LoadRoom();

            LoadRoomByCategoryID((cbCategory.SelectedItem as Category).CategoryID);
            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if (listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        private void f_DeleteRoom(object? sender, EventArgs e)
        {
            LoadRoom();
            LoadRoomByCategoryID((cbCategory.SelectedItem as Category).CategoryID);

            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if (listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        private void f_InsertRoom(object? sender, EventArgs e)
        {
            LoadRoom();
            LoadRoomByCategoryID((cbCategory.SelectedItem as Category).CategoryID);

            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if (listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        private void f_UpdateCategory(object? sender, EventArgs e)
        {
            LoadRoom();
            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if(listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        private void f_DeleteCategory(object? sender, EventArgs e)
        {
            LoadRoom();
            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if (listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        private void f_InsertCategory(object? sender, EventArgs e)
        {
            LoadRoom();
            LoadCategory();
            LoadService();
            LoadComboboxRoom(cbSwitchTable);
            if (listBill.Tag != null)
            {
                ShowOrder((listBill.Tag as Room).Roomid);
            }
        }

        void f_UpdateService(object? sender, EventArgs e)
        {
            
        }

        private void f_DeletetService(object? sender, EventArgs e)
        {
        }

        void f_InsertService(object sender, EventArgs e)
        {

        }
        #endregion
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            int id = 0;
            
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category selected = cb.SelectedItem as Category;
            id = selected.CategoryID;
            LoadRoomByCategoryID(id);
        }

        private void btnAddServices_Click(object sender, EventArgs e)
        {

            Room room = listBill.Tag as Room;
            int idOrder = OrderDAO.Instance.GetUncheckBillIDByRoomID(room.Roomid);
            int serviceid = (cbService.SelectedItem as Service).ServiceID;
            if (idOrder == -1)
            {
                OrderDAO.Instance.InsertOrder(room.Roomid);
                OrderDetailDAO.Instance.InsertOrderDetail(OrderDAO.Instance.GetMaxIDOrder(), serviceid);
            }
            else
            {
                OrderDetailDAO.Instance.InsertOrderDetail(idOrder, serviceid);
            }
            ShowOrder(room.Roomid);
            LoadRoom();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {

        }

        private void flpRoom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Room room = listBill.Tag as Room;
            int roomid = OrderDAO.Instance.GetUncheckBillIDByRoomID(room.Roomid);
            if (roomid != -1)
            {
                int discount = (int)numDiscount.Value;
                string price = txtTotal.Text.Split(",")[0];
                string[] price2 = price.Split(".");
                string price3 = "";
                for (int i = 0; i <= price2.Length - 1; i++)
                {
                    price3 += price2[i];
                }
                double totalPrice = Convert.ToDouble(price3);
                double finalPrice = Convert.ToDouble(totalPrice - ((totalPrice / 100) * discount));
                NumberFormatInfo numberFormatInfo = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                numberFormatInfo.NumberDecimalSeparator = ",";
                numberFormatInfo.NumberGroupSeparator = ".";
                string text = string.Format(numberFormatInfo, "{0:n}", finalPrice);
                {
                    if (listBill.Items.Count == 0)
                    {
                        MessageBox.Show("eo co cai gi de thanh toan ca");
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn thanh toán cho  {0}\n Tổng tiền (Đã bao gồm giảm giá)= {0}đ" +
                            room.Roomname, text), "Thông báo", MessageBoxButtons.OKCancel
                            ) == DialogResult.OK) ;
                        {
                            OrderDAO.Instance.CheckOut(roomid, discount, (float)finalPrice);
                            ShowOrder(room.Roomid);
                            LoadRoom();
                        }
                    }

                }
            }
        }

        private void listBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSwitchRoom_Click(object sender, EventArgs e)
        {

            int id1 = (listBill.Tag as Room).Roomid;
            int id2 = (cbSwitchTable.SelectedItem as Room).Roomid;
            if (MessageBox.Show(String.Format("Bạn có thực sự muốn chuyển {0} qua  {1} không ?",
                (listBill.Tag as Room).Roomname, (cbSwitchTable.SelectedItem as Room).Roomname),
                "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            RoomDAO.Instance.SwitchRoom(id1, id2);
            LoadRoom();
        }
        void LoadComboboxRoom(ComboBox cb)
        {
            cb.DataSource = RoomDAO.Instance.LoadRoomList();
            cb.DisplayMember = "roomname";
        }

        #region Room

        #endregion

        #region Category

        #endregion

    }
}
