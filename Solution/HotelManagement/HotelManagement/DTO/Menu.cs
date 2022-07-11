using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Menu
    {
        private string servicename;
        private double price;
        private double totalprice;
        private DateTime? date;

        public string Servicename { get => servicename; set => servicename = value; }
        public double Price { get => price; set => price = value; }
        public double Totalprice { get => totalprice; set => totalprice = value; }
        public DateTime? Date { get => date; set => date = value; }

        public Menu(string servicename, double price, double totalprice, DateTime? date)
        {
            this.servicename = servicename;
            this.price = price;
            this.totalprice = totalprice;
            this.date = date;
        }
    }
}
