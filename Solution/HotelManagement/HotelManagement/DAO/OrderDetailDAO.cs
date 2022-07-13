using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        public static OrderDetailDAO Instance
        {
            get { if (instance == null) instance = new OrderDetailDAO(); return instance; }
            private set { instance = value; }
        }
        private OrderDetailDAO() { }
        public List<OrderDetail> GetListOrderDetail(int id)
        {
            List<OrderDetail> listOrderDetail = new List<OrderDetail>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from OrderDetail where orderid ="+id);
            foreach (DataRow item in data.Rows)
            {
                OrderDetail OrderDetail = new OrderDetail(item);
                listOrderDetail.Add(OrderDetail);
            }
            return listOrderDetail;
        }
       
        public void InsertOrderDetail(int orderid,int serviceid)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertOrderDetail @orderid , @serviceid  ", 
                new object[] { orderid, serviceid });
        }
        public int GetDetailIDByOrder(int orderid)
        {
            string query = String.Format("SELECT detailid FROM dbo.OrderDetail WHERE orderid = {0}", orderid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }
    }
}
