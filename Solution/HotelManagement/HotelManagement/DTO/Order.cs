using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Order
    {
        private int orderid;
        private DateTime? datecheckin;
        private DateTime? datecheckout;
        private int idRoom;
        private int status;

        public Order(int orderid, DateTime? datecheckin, DateTime? datecheckout, int idRoom, int status)
        {
            this.Orderid = orderid;
            this.Datecheckin = datecheckin;
            this.Datecheckout = datecheckout;
            this.IdRoom = idRoom;
            this.Status = status;
         
        }
        public Order(DataRow row)
        {
            this.Orderid = (int)row["orderid"];
            this.Datecheckin = (DateTime?)row["datecheckin"];
            this.Datecheckout = (DateTime?)row["datecheckout"]; ;
            this.IdRoom = (int)row["idRoom"];
            this.Status = (int)row["status"];

        }

        public int Orderid { get => orderid; set => orderid = value; }
        public DateTime? Datecheckin { get => datecheckin; set => datecheckin = value; }
        public DateTime? Datecheckout { get => datecheckout; set => datecheckout = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
        public int Status { get => status; set => status = value; }
    }
}
