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
        public void SwitchRoom(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchRoom1 @@id1 , @@id2", new object[] { id1, id2 });
        }
        private static RoomDAO instance;
        public static RoomDAO Instance
        {
            get { if (instance == null) instance = new RoomDAO(); return instance; }
            private set { instance = value; }
        }
        private RoomDAO()
        {
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
        public Room GetRoomById(int id)
        {
            Room room = null;
            string query = "select * from Room where categoryid = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                room = new Room(item);
                return room;
            }

            return room;
        }
        public List<Room> GetListRoom()
        {
            List<Room> list = new List<Room>();

            string query = "select * from Room";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }

            return list;
        }

        public Boolean InsertRoom(string roomname, int categoryid, float price)
        {
            string query = string.Format("INSERT dbo.Room(roomname,categoryid,roomprice)VALUES(N'{0}' , {1} , {2} )", roomname, categoryid, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public Boolean UpdateRoom(int roomid, string roomname, int categoryid, float price)
        {
            string query = string.Format("UPDATE dbo.Room SET roomname = N'{0}', categoryid = {1}, roomprice = {2} WHERE roomid = {3}", roomname, categoryid, price, roomid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public Boolean DeleteRoom(int roomid)
        {
            string query = string.Format("DELETE dbo.Room WHERE roomid = {0}", roomid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteRoomByCateID(int idCategory)
        {
            string query = string.Format("DELETE dbo.Room WHERE categoryid ={0}", idCategory);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int checkRoomExsit(string roomname)
        {
            string query = string.Format("SELECT COUNT(*) FROM dbo.Room WHERE roomname = N'{0}'", roomname);
            int result = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return result;
        }

        public static int RoomWidth = 80;
        public static int RoomHeight = 80;
    }
}
