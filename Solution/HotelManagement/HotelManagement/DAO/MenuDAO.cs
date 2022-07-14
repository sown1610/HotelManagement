using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByRoom(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "select s.servicename, s.serviceprice, r.roomname, " +
                "r.roomprice from OrderDetail as od, [Order] as o, Service as s," +
                " Room as r where od.orderid = o.orderid and od.serviceid = s.serviceid" +
                " and r.roomid = o.idRoom and o.status = 0 and o.idRoom =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
