using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }
        private BillDAO() { }
        public int GetUncheckBillIDByRoomID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select orderid from [Order] where idRoom = " + id + " and status = 0");
            if(data.Rows.Count > 0)
            {
                Order order = new Order(data.Rows[0]);
                return order.Orderid;
            }
            return -1;
        }
    }
}
