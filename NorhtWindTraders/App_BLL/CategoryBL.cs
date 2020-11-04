using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_BLL
{
    public class CategoryBL
    {
        CategoryRepository repo;
        public CategoryBL()
        {
            repo = new CategoryRepository();
        }

        public IEnumerable<Category> GetCategories()
        {
            return repo.GetCategories();
        }
    }
}