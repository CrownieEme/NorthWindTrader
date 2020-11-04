using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWindTraders.App_BLL
{
    interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int categoryid);
        bool InsertCategory(Category category);
        bool DeleteCategory(int categoryID);
        bool UpdateCategory(Category category);
        bool Save();
    }
}
