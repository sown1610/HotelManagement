using HotelManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAO
{
    internal class CategoryDAO
    {
        public static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }    
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO()
        {

        }
        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select * from RoomCategory ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        public int GetCategoryIDByCategoryName(string name)
        {   
            
            string query = String.Format("SELECT categoryid FROM dbo.RoomCategory WHERE categoryname LIKE N'{0}' ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result;
        }

    }
}
