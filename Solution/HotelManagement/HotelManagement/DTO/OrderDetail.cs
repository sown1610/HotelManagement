using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class OrderDetail
    {
        private int detailid;
        private int roomid;
        private int orderid;
        private int serviceid;
        private double totalprice;

        

        public int Detailid { get => detailid; set => detailid = value; }
        public int Roomid { get => roomid; set => roomid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
        public int Serviceid { get => serviceid; set => serviceid = value; }
        public double Totalprice { get => totalprice; set => totalprice = value; }
        public OrderDetail(int detailid, int roomid, int orderid, int serviceid, double totalprice)
        {
            this.Detailid = detailid;
            this.Roomid = roomid;
            this.Orderid = orderid;
            this.Serviceid = serviceid;
            this.Totalprice = totalprice;
            
        }
        public OrderDetail(DataRow row)
        {
            this.Detailid = (int)row["detailid"];
            this.Roomid = (int)row["roomid"];
            this.Orderid = (int)row["orderid"];
            this.Serviceid = (int)row["serviceid"];
            this.Totalprice = (double)row["totalprice"];
        }
    }
}
