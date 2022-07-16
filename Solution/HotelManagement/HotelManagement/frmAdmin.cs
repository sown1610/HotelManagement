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
        BindingSource roomlist = new BindingSource();
        BindingSource serviceList = new BindingSource();
        BindingSource accountList = new BindingSource();
        public Account loginAccount;
        public frmAdmin()
        {
            InitializeComponent();

            Load();
        }

        #region methods
        List<Service> SearchServiceByName(string name)
        {
            List<Service> listService = ServiceDAO.Instance.SerachServiceByName(name);

            return listService;
        }
        void Load()
        {
            dtgServices.DataSource = serviceList;
            dtgAccount.DataSource = accountList;

            LoadDateTimePickerOrder();
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListService();
            AddServiceBinding();
            LoadListRoom();
            LoadAccount();
            addRoomBinding();
            AddAccountBinding();
            LoadCategoryIntoCombobox(cbRoomCategory);
        }
        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dtgAccount.DataSource, "UserName",true,DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAcc.DataBindings.Add(new Binding("Value", dtgAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
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
        void AddAccount(string userName,string disPlayname,int type)
        {
           if(AccountDAO.Instance.InsertAccount(userName,disPlayname,type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");

            }
            LoadAccount();
        }
        void EditAccount(string userName, string disPlayname, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, disPlayname, type))
            {
                MessageBox.Show("Update tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Update tài khoản thất bại");

            }
            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Đừng xóa chính bạn :))))");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Delete tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Delete tài khoản thất bại");

            }
            LoadAccount();
        }
        void ResetPass(string username)
        {
            if (AccountDAO.Instance.ResetPassword(username))
            {
                MessageBox.Show("Reset tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Reset tài khoản thất bại");

            }
        }

        #endregion
        #region events
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string disPlayName = txtDisplayName.Text;
            int type = (int)nmTypeAcc.Value;
            AddAccount(userName, disPlayName, type);
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string disPlayName = txtDisplayName.Text;
            int type = (int)nmTypeAcc.Value;
            EditAccount(userName, disPlayName, type);
        }
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;

            ResetPass(userName);
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
           
            DeleteAccount(userName);
        }

        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void btnSearchServices_Click(object sender, EventArgs e)
        {
            serviceList.DataSource = SearchServiceByName(txtServicesSearchName.Text);
        }

        private void btnViewServices_Click(object sender, EventArgs e)
        {
            LoadListService();
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        private void txtServiceID_TextChange(object sender, EventArgs e)
        {
            try
            {
                if (dtgServices.SelectedCells.Count > 0)
                {
                    int id = (int)dtgServices.SelectedCells[0].OwningRow.Cells["RoomId"].Value;

                    Room room = RoomDAO.Instance.GetRoomById(id);

                    cbRoomCategory.SelectedItem = room;
                    int index = -1;
                    int i = 0;
                    foreach (Room item in cbRoomCategory.Items)
                    {
                        if (item.Categoryid == room.Roomid)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbRoomCategory.SelectedIndex = index;
                }
            }
            catch { }

            }
        private void btnAddServices_Click(object sender, EventArgs e)
            {
                string name = txtServicesName.Text;

                float price = (float)numServicePrice.Value;

                if (ServiceDAO.Instance.InsertService(name, price))
                {
                    MessageBox.Show("Thêm Service thành công");
                    LoadListService();
                    if (insertService != null)
                    {
                        insertService(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm");
                }
            }
            private void btnUpdateServices_Click(object sender, EventArgs e)
            {
                string name = txtServicesName.Text;
                //int cateid = (cbRoomCategory.SelectedItem as Category).CategoryID;
                float price = (float)numServicePrice.Value;
                int serviceid = Convert.ToInt32(txtServicesID.Text);
                if (ServiceDAO.Instance.UpdateService(serviceid, name, price))
                {
                    MessageBox.Show("Sửa  thành công");
                    LoadListService();
                    if (updateService != null)
                    {
                        updateService(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm rồi đần ");
                }

            }
            private void btnDeleteServices_Click(object sender, EventArgs e)
            {
                int serviceid = Convert.ToInt32(txtServicesID.Text);
                MessageBox.Show("Bạn có muốn xóa");
                if (ServiceDAO.Instance.DeleteService(serviceid))
                {
                    MessageBox.Show("Xóa  thành công");
                    LoadListService();
                    if (deleteService != null)
                    {
                        deleteService(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa rồi đần ");
                }
            }

        private event EventHandler insertService;
        public event EventHandler InsertService
        {
            add { insertService += value; }
            remove { insertService -= value; }
        }

        private event EventHandler deleteService;
        public event EventHandler DeletetService
        {
            add { deleteService += value; }
            remove { deleteService -= value; }
        }

        private event EventHandler updateService;
        public event EventHandler UpdateService
        {
            add { updateService += value; }
            remove { updateService -= value; }
        }



        #endregion

        void loadCategoryToComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "categoryname";
            cb.Refresh();
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

            if (RoomDAO.Instance.InsertRoom(name, cateid, price))
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
            if (RoomDAO.Instance.UpdateRoom(roomid, name, cateid, price))
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
