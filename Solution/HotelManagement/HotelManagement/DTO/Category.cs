using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DTO
{
    internal class Category
    {   
        public Category(int id, string name)
        {
            CategoryID = id;
            CategoryName = name;
        }
        public Category(DataRow row)
        {
            this.CategoryID = (int)row["categoryid"];
            this.CategoryName = row["categoryname"].ToString();
        }
        private int _categoryID;

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        private string _categoryNamee;

        public string CategoryName
        {
            get { return _categoryNamee; }
            set { _categoryNamee = value; }
        }

    }
}
