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

        public List<Service> SerachServiceByName(string name)
        {

            List<Service> list = new List<Service>();
            string query =string.Format ("SELECT * FROM Service WHERE [dbo].[fuConvertToUnsign1](servicename) LIKE N'%'+[dbo].[fuConvertToUnsign1](N'{0}') +N'%'",name );
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
            string query =string.Format("INSERT INTO dbo.Service(servicename,serviceprice)VALUES (N'{0}',{1})", name,price) ;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateService(int idService,string name, float price)
        {
            string query = string.Format("update Service set  servicename = N'{0}',serviceprice = {1} where serviceid ={2}", name, price,idService);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteService(int idService)
        {
            OrderDetailDAO.Instance.DeleteOderDetailByServiceId(idService);
            string query = string.Format("Delete Service where serviceid = {0} ",idService);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

    }
}
