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
    public partial class frmManager : Form
    {
        public frmManager()
        {
            InitializeComponent();
            LoadRoom();
        }
        #region Method
        void LoadRoom()
        {
            List<Room> roomList = RoomDAO.Instance.LoadRoomList();
            foreach (Room item in roomList)
            {
                Button btn = new Button()
                {
                    Width = RoomDAO.RoomWidth,
                    Height = RoomDAO.RoomHeight
                };
                btn.Text = item.Roomname +Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag= item;
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

        void ShowBill(int id)
        {

        }
        #endregion
         void btn_Click(object? sender, EventArgs e)
        {
            int roomID =(sender as Room).Roomid;
            ShowBill(roomID);
        }
        #region Events 

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccountProfile f = new frmAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin f = new frmAdmin();
            f.ShowDialog();
        }
        #endregion
    }
}
