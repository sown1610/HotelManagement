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
        public int orderid;
        private DateTime? datecheckin;
        private DateTime? datecheckout;
        private int idRoom;
        private int status;
        private int discount;

        public Order(int orderid, DateTime? datecheckin, DateTime? datecheckout, int idRoom, int status, int discount = 0)
        {
            this.Orderid = orderid;
            this.Datecheckin = datecheckin;
            this.Datecheckout = datecheckout;
            this.IdRoom = idRoom;
            this.Status = status;
            this.discount = discount;
        }
        public Order(DataRow row)
        {
            this.Orderid = (int)row["orderid"];
            this.Datecheckin = (DateTime?)row["datecheckin"];
            var datecheckoutTemp = row["datecheckout"];
            if (datecheckoutTemp.ToString() != "")
            {
                this.datecheckout = (DateTime?)datecheckoutTemp;
            }
            this.IdRoom = (int)row["idRoom"];
            this.Status = (int)row["status"];
            if (row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
        }

        public int Orderid { get => orderid; set => orderid = value; }
        public DateTime? Datecheckin { get => datecheckin; set => datecheckin = value; }
        public DateTime? Datecheckout { get => datecheckout; set => datecheckout = value; }
        public int IdRoom { get => idRoom; set => idRoom = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }


}
