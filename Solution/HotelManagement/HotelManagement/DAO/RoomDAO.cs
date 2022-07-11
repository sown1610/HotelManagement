using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class RoomDAO
    {
        private static RoomDAO instance;
        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set { instance = value; }
        }
        private RoomDAO() { }
        public List<Room> LoadRoomList()
        {
            List<Room> roomList = new List<Room>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetRoomList");
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                roomList.Add(room);
            }
            return roomList;
        }
        public static int RoomWidth = 80;
        public static int RoomHeight = 80;
    }
}
