using System;
using System.Collections.Generic;
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

        public int Detailid { get => detailid; set => detailid = value; }
        public int Roomid { get => roomid; set => roomid = value; }
        public int Orderid { get => orderid; set => orderid = value; }
    }
}
