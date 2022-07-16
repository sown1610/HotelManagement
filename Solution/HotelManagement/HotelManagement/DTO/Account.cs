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
        private string displayName;
        private string userName;
        private string password;
        private int type;

        public string UserName{get => userName; set => userName = value;}
        public string DisplayName { get => displayName; set => displayName = value; }
        public int Type { get => type; set => type = value; }
        public string Password { get => password; set => password = value; }
        public Account(string displayName, string userName, string password, int type)
        {
            DisplayName = displayName;
            UserName = userName;
            Password = password;
            Type = type;
            
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.Type = (int)row["type"];
            this.Password = row["password"].ToString();
        }
    }
}
