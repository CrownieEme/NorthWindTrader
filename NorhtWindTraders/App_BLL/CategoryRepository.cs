using NorhtWindTraders.App_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_BLL
{
    public class CategoryRepository:ICategoryRepository, IDisposable
    {
        private NorthWindDB db;
        public CategoryRepository()
        {
             db = new NorthWindDB(ConfigurationManager.ConnectionStrings["NWContext"].ConnectionString);
        }

        public IEnumerable<Category> GetCategories()
        {
            DataTable dt = db.GetDataSet("Category_GetAll");
            List<Category> category = new List<Category>();
            foreach(DataRow row in dt.Rows)
            {
                category.Add(new Category{
                    CategoryID = Convert.ToInt16(row["CategoryID"]),
                    CategoryName = row["CategoryName"].ToString(),
                    Description = row["Description"].ToString()
                });
            }
            return category.ToList();
        }

        public Category GetCategoryById(int categoryid)
        {
            throw new NotImplementedException();
        }

        public bool InsertCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCategory(int categoryID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}