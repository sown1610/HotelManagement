using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    public class ServiceDAO
    {
        private static ServiceDAO instance;
        public static ServiceDAO Instance
        {
            get { if (instance == null) instance = new ServiceDAO(); return instance; }
            private set { instance = value; }
        }
        private ServiceDAO() { }
        public List<Service> GetServicesByID(int id)
        {
            List<Service> servicesList = new List<Service>();
            string query = "";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Service service = new Service(item);
                servicesList.Add(service);
            }
            return servicesList;
        }
        public int GetServiceIDByOrdDetail(int detailid)
        {   
            string query = String.Format("SELECT serviceid FROM dbo.OrderDetail WHERE detailid = {0} ",detailid);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }
        public List<Service> GetListService()
        {
            List<Service> list = new List<Service>();
            string query = "SELECT * FROM dbo.Service ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Service service = new Service(item);
                list.Add(service);
            }
            return list;
        }

        public bool InsertService(string name,float price)
        {
            string query =string.Format("INSERT INTO dbo.Service(name,price)VALUES (N'{0}',{2})", name,price) ;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
