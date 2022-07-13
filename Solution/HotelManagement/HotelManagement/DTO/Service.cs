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

        private float _servicePrice;

        public float ServicePrice
        {
            get { return _servicePrice; }
            set { _servicePrice = value; }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public Service(int id, string name, float price,string date)
        {
            ServiceID = id;
            ServiceName = name;
            Date = date;
            ServicePrice = price;
        }
        public Service(DataRow row)
        {
            this.ServiceID = (int)row["id"];
            this.ServiceName = row["name"].ToString();          
            this.Date = row["date"].ToString();
            this.ServicePrice = (float)Convert.ToDouble(row["price"].ToString());
        }
    }
}
