using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Service
    {
        private int _serviceid;

        public int ServiceID
        {
            get { return _serviceid; }
            set { _serviceid = value; }
        }

        private string _serviceName;

        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }

        private double _servicePrice;

        public double ServicePrice
        {
            get { return _servicePrice; }
            set { _servicePrice = value; }
        }

        
        public Service(int id, string name, double price)
        {
            ServiceID = id;
            ServiceName = name;           
            ServicePrice = price;
        }
        public Service(DataRow row)
        {
            this.ServiceID = (int)row["serviceid"];
            this.ServiceName = row["servicename"].ToString();          
            this.ServicePrice = Convert.ToDouble(row["serviceprice"].ToString());
            
        }
    }
}
