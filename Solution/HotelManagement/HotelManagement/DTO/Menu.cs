using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Menu
    {
        private string servicename;
        private double serviceprice;
        private double totalprice;
        private string roomname;
        private double roomprice;

        public string Servicename { get => servicename; set => servicename = value; }
        public double Totalprice { get => totalprice; set => totalprice = value; }
        public double Serviceprice { get => serviceprice; set => serviceprice = value; }
        public double Roomprice { get => roomprice; set => roomprice = value; }
        public string Roomname { get => roomname; set => roomname = value; }

        public Menu(string servicename, double price, double totalprice, double serviceprice, double roomprice, string roomname)
        {
            this.servicename = servicename;
            this.totalprice = totalprice;
            this.serviceprice = serviceprice;
            this.roomname = roomname;
            this.roomprice = roomprice;
        }
        public Menu(DataRow row)
        {
            this.servicename = row["servicename"].ToString();
            this.serviceprice = (double)row["serviceprice"];
            this.roomname = (string)row["roomname"];
            this.roomprice = (double)row["roomprice"];
        }
    }
}
