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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmAdmin : Form
    {
        BindingSource roomlist = new BindingSource();
        BindingSource serviceList = new BindingSource();
        BindingSource accountList = new BindingSource();
        BindingSource categoryList = new BindingSource();
        public Account loginAccount;
        public frmAdmin()
        {
            InitializeComponent();

            Load();
        }
        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        #region methods

        void Load()
        {
            dtgServices.DataSource = serviceList;
            dtgAccount.DataSource = accountList;
            dtgRoom.DataSource = roomlist;
            LoadDateTimePickerOrder();
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListService();
            AddServiceBinding();
            LoadListRoom();
            LoadAccount();
            AddRoomBinding();
            AddAccountBinding();
            loadListCategory();
            LoadCategoryIntoCombobox(cbRoomCategory);
        }
        #region Account
        void AddAccountBinding()
        {
            txtUsername.DataBindings.Add(new Binding("Text", dtgAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmTypeAcc.DataBindings.Add(new Binding("Value", dtgAccount.DataSource, "type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void AddAccount(string userName, string disPlayname, int type)
        {
            bool containsLetter = Regex.IsMatch(userName.Trim(), @"^[a-zA-Z1-9 ]+$");
            if (String.IsNullOrEmpty(userName.Trim()))
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return;
            }
            if (String.IsNullOrEmpty(disPlayname.Trim()))
            {
                MessageBox.Show("Tên hiển thị không được để trống");
                return;
            }
            if (!containsLetter)
            {
                MessageBox.Show("Định dạng 'Tên tài khoản' không hợp lệ");
                return;
            }
            if (AccountDAO.Instance.checkAccountExist(txtUsername.Text) == 1)
            {
                MessageBox.Show("Không thể thêm tài khoản đã tồn tại");
                return;
            }
            if (AccountDAO.Instance.InsertAccount(userName, disPlayname, type))
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
            if (String.IsNullOrEmpty(userName.Trim()))
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
                return;
            }
            if (String.IsNullOrEmpty(disPlayname.Trim()))
            {
                MessageBox.Show("Tên hiển thị không được để trống");
                return;
            }
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
                MessageBox.Show("Không thể xóa tài khoản đang được đăng nhập");
                return;
            }
            if (MessageBox.Show(string.Format("Bạn có muốn sửa xóa tài khoản '{0}'", userName), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Xóa tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Xóa nhật khoản thất bại!");
                }
            }
            //if (loginAccount.UserName.Equals(userName))
            //{
            //    MessageBox.Show("Đừng xóa chính bạn :))))");
            //    return;
            //}
            //if (AccountDAO.Instance.DeleteAccount(userName))
            //{
            //    MessageBox.Show("Delete tài khoản thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Delete tài khoản thất bại");

            //}
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

        #region Category
        void loadCategoryToComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "categoryname";
            cb.Refresh();
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {

            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "categoryname";
        }
        void loadListCategory()
        {
            dtgCategories.DataSource = CategoryDAO.instance.GetListCategory();
            categoryList.DataSource = CategoryDAO.instance.GetListCategory();
            txtCategoryID.DataBindings.Clear();
            txtCategoryName.DataBindings.Clear();
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgCategories.DataSource, "categoryid", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgCategories.DataSource, "categoryname", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region Room
        void LoadListRoom()
        {
            roomlist.DataSource = RoomDAO.Instance.GetListRoom();

        }
        void AddRoomBinding()
        {
            txtroomname.DataBindings.Add(new Binding("Text", dtgRoom.DataSource, "roomname", true, DataSourceUpdateMode.Never));
            txtroomid.DataBindings.Add(new Binding("Text", dtgRoom.DataSource, "roomid", true, DataSourceUpdateMode.Never));
            numRoomPrice.DataBindings.Add(new Binding("Value", dtgRoom.DataSource, "roomprice", true, DataSourceUpdateMode.Never));
        }

        #endregion

        #region Service
        List<Service> SearchServiceByName(string name)
        {
            List<Service> listService = ServiceDAO.Instance.SerachServiceByName(name);

            return listService;
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

        #region Order
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
        #endregion

        #region events

        #region Account
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
        #endregion

        #region Category
        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            string name = Regex.Replace(txtCategoryName.Text.Trim(), " {2,}", " ");
            bool containsLetter = Regex.IsMatch(convertToUnSign(name).ToLower(), @"^[a-zA-Z1-9 ]+$");
            if (String.IsNullOrEmpty(name.Trim()))
            {
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (!containsLetter)
            {
                MessageBox.Show("Định dạng tên không hợp lệ");
                return;
            }
           
            if (MessageBox.Show(string.Format("Bạn có thực sự muốn thêm danh mục '{0}'", name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (CategoryDAO.Instance.InsertCategory(name))
                {
                    MessageBox.Show("Thêm thành công");
                    loadListCategory();
                    if (insertCategory != null)
                    {
                        insertCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm");
                }
                loadCategoryToComboBox(cbRoomCategory);
            }

        }


        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = Regex.Replace(txtCategoryName.Text.Trim(), " {2,}", " ");
            bool containsLetter = Regex.IsMatch(convertToUnSign(name).ToLower(), @"^[a-zA-Z1-9 ]+$");
            int categoryId = int.Parse(txtCategoryID.Text);
            if (String.IsNullOrEmpty(name.Trim()))
            {
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (!containsLetter)
            {
                MessageBox.Show("Định dạng tên không hợp lệ");
                return;
            }
            
            if (MessageBox.Show(string.Format("Bạn có thực sự muốn sửa tên danh mục thành '{0}'", name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int idCategory = Convert.ToInt32(txtCategoryID.Text);
                if (CategoryDAO.Instance.UpdateCategory(name, idCategory))
                {
                    MessageBox.Show("Sửa thành công");
                    loadListCategory();
                    if (updateCategory != null)
                    {
                        updateCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi Sửa");
                }
            }
            loadCategoryToComboBox(cbRoomCategory);

        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            string name = Regex.Replace(txtCategoryName.Text.Trim(), " {2,}", " ");

            if (MessageBox.Show(string.Format("Bạn có thực sự muốn xóa danh mục '{0}'", name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int idCategory = Convert.ToInt32(txtCategoryID.Text);
                if (CategoryDAO.Instance.DeleteCategory(idCategory))
                {
                    MessageBox.Show("Xóa thành công");
                    loadListCategory();
                    if (deleteCategory != null)
                    {
                        deleteCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa");
                }
            }
            LoadListRoom();
            loadCategoryToComboBox(cbRoomCategory);

        }

        #endregion

        #region Room
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string name = Regex.Replace(txtroomname.Text.Trim(), " {2,}", " ");
            int cateid = (cbRoomCategory.SelectedItem as Category).CategoryID;
            float price = (float)numRoomPrice.Value;
            bool containsLetter = Regex.IsMatch(convertToUnSign(name).ToLower(), @"^[a-zA-Z1-9 ]+$");
            if (!containsLetter)
            {
                MessageBox.Show("Định dạng tên không hợp lệ");
                return;
            }
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Tên không được để trống");
                return;
            }
            if (RoomDAO.Instance.checkRoomExsit(name) == 1)
            {
                MessageBox.Show("Không thể thêm phòng đã tồn tại");
                return;
            }
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
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            LoadListRoom();
            int roomid = Convert.ToInt32(txtroomid.Text);
            if (RoomDAO.Instance.DeleteRoom(roomid))
            {
                MessageBox.Show("Delete  thành công");
                LoadListRoom();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Delete rồi đần ");

            }
        }
        #endregion

        #region Service
        private void btnSearchServices_Click(object sender, EventArgs e)
        {
            serviceList.DataSource = SearchServiceByName(txtServicesSearchName.Text);
        }
        private void btnViewServices_Click(object sender, EventArgs e)
        {
            LoadListService();
        }
        private void btnAddServices_Click(object sender, EventArgs e)
        {
            string name = txtServicesName.Text;
            float price = (float)numServicePrice.Value;

            if (ServiceDAO.Instance.checkServiceExsit(name) == 1)
            {
                MessageBox.Show("Không thể thêm dịch vụ đã tồn tại");
                return;
            }
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
        #endregion

        #region Order
        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            LoadListOrderByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        #region EventHandle
        #region Account
        #endregion

        #region Category
        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        #endregion

        #region Room
        private event EventHandler insertRoom;
        public event EventHandler InsertRoom
        {
            add { insertRoom += value; }
            remove { insertRoom -= value; }
        }

        private event EventHandler deleteRoom;
        public event EventHandler DeleteRoom
        {
            add { deleteRoom += value; }
            remove { deleteRoom -= value; }
        }

        private event EventHandler updateRoom;
        public event EventHandler UpdateRoom
        {
            add { updateRoom += value; }
            remove { updateRoom -= value; }
        }
        #endregion

        #region Service
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

        #region Order
        #endregion
        #endregion

        #endregion





        private void txtroomid_TextChanged(object sender, EventArgs e)
        {
            if (dtgRoom.SelectedCells.Count > 0)
            {
                int id = (int)dtgRoom.SelectedCells[0].OwningRow.Cells["categoryid"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);

                cbRoomCategory.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cbRoomCategory.Items)
                {
                    if (item.CategoryID + 1 == category.CategoryID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbRoomCategory.SelectedIndex = index;

            }
        }
    }
}
