using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private NWContext db;

        public  CategoryRepository()
        {
            db = new NWContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }


        public Category GetCategoryById(int categoryid)
        {
            throw new NotImplementedException();
        }

        public bool InsertCategory(Category category)
        {
            db.Categories.Add(category);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool DeleteCategory(int categoryID)
        {
            var cat = db.Categories.Find(categoryID);
            db.Categories.Remove(cat);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCategory(Category category)
        {

            db.Categories.Attach(category);
            db.Entry(category).State = EntityState.Modified;
            if(db.SaveChanges()>0)
                return true;
            else
                return false;
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}