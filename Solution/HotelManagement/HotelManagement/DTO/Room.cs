using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Room
    {

        public Room(int roomid, string roomname, int categoryid, string status, double roomprice)
        {
            this.Roomid = roomid;
            this.Roomname = roomname;   
            this.Categoryid = categoryid;
            this.Status = status;
            this.Roomprice = roomprice;
        }
        private int roomid;
        private string roomname;
        private int categoryid;
        private string status;
        private double roomprice;

        
        public string Status { get => status; set => status = value; }
        public int Categoryid { get => categoryid; set => categoryid = value; }
        public double Roomprice { get => roomprice; set => roomprice = value; }
        public int Roomid { get => roomid; set => roomid = value; }
        public string Roomname { get => roomname; set => roomname = value; }

        public Room(DataRow row)
        {
            this.Roomid = (int)row["roomid"];
            this.Roomname = row["roomname"].ToString();
            this.Categoryid = (int)row["categoryid"];
            this.Status = row["status"].ToString();
            this.Roomprice = (double)row["roomprice"];
        }
    }
}
