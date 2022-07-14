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
        public void SwitchRoom(int id1,int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchRoom1 @@id1 , @@id2", new object[] { id1, id2 });
        }
        private static RoomDAO instance;
        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set { instance = value; }
        }
        private RoomDAO() {
        }
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
        public List<Room> GetRoomByID(int id)
        {
            List<Room> list = new List<Room>();
            string query = "select * from Room where categoryid = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }
            return list;
        }

        public static int RoomWidth = 80;
        public static int RoomHeight = 80;
    }
}
