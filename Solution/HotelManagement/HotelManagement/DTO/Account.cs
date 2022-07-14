using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    public class Account
    {


        private int type;
        private string password;
        private string displayName;
        private string userName;
        public string UserName { get; set; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public Account(int type, string password = null, string displayName, string userName)
        {
            this.Type = type;
            this.Password = password;
            this.DisplayName = displayName;
            this.UserName = userName;
            
        }
        public Account(DataRow row)
        {
            this.Type = type;
            this.Password = password;
            this.DisplayName = displayName;
            this.UserName = userName;
        }
    }
}
