using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class OrderDAO
    {
        private static OrderDAO instance;
        public static OrderDAO Instance
        {
            get { if (instance == null) instance = new OrderDAO(); return instance; }
            private set { instance = value; }
        }
        private OrderDAO() { }
        public int GetUncheckBillIDByRoomID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery
                ("select * from [Order] where idRoom = " + id + " and status = 0");
            if (data.Rows.Count > 0)
            {
                Order order = new Order(data.Rows[0]);
                return order.Orderid;
            }
            return -1;
        }
        public void CheckOut(int id, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.[Order] SET datecheckout = GETDATE(), status = 1," + "discount =" + discount + ", totalPrice = " + totalPrice + " WHERE orderid = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void InsertOrder(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertOrder @idRoom ", new object[] { id });
        }

        public DataTable GetOrderListByDate(DateTime checkIn, DateTime checkOut)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListOrderByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public int GetMaxIDOrder()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(orderid) FROM [Order]");
            }
            catch
            {
                return 1;
            }

        }
        public DataTable OrderCount()
        {

            return DataProvider.Instance.ExecuteQuery("select * from (SELECT count (*) as [SoLanBook], idRoom FROM [HotelManagement].[dbo].[Order] group by idRoom )t where [SoLanBook] = (select MIN(SoLanBook)FROM (SELECT  count (*) as SoLanBook, idRoom FROM [HotelManagement].[dbo].[Order] group by idRoom)t)");
        }
       

    }
}
