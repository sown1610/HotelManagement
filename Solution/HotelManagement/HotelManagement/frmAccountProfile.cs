using HotelManagement.DAO;
using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class frmAccountProfile : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public frmAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            txtUser.Text = loginAccount.UserName;
            txtName.Text = loginAccount.DisplayName;

        }
        void UpdateAccountInfor()
        {
            string displayName = txtName.Text;
            string password = txtPass.Text;
            string newpass = txtNewPass.Text;
            string reenterpass = txtReNewPass.Text;
            string userName = txtUser.Text;

            if (String.IsNullOrEmpty(password.Trim()))
            {
                MessageBox.Show("Hãy nhập mật khẩu để xác nhận thao tác!");
                return;
            }
            if (String.IsNullOrEmpty(displayName.Trim()))
            {
                MessageBox.Show("Tên hiển thị không được để trống");
                return;
            }
            if (!newpass.Equals(reenterpass))
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp!");
            }
            else
            {
                if (MessageBox.Show(string.Format("Bạn có thực sự muốn cập nhật các thông tin trên?"), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (AccountDAO.Instance.UpdateAccount(userName,displayName,password,newpass))
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                    else
                    {
                        MessageBox.Show("Hãy điền đúng thông tin");
                    }
                    ChangeAccount(LoginAccount);
                    txtPass.Clear();
                    txtNewPass.Clear();
                    txtReNewPass.Clear();
                }

            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfor();
        }

        private void frmAccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }
        public AccountEvent(Account acc) 
        { 
            this.Acc = acc; 
        }    

    }
}
