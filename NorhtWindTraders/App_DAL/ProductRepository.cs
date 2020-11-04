using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class ProductRepository:IProductRepository,IDisposable
    {
        private NWContext db;

        public ProductRepository()
        {
            db = new NWContext();
        }
        //*************  Get all Products *****************
        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }
        //*************  Get a quantity of Products *****************
        public IEnumerable<Product> GetProducts(int prodqty)
        {
            return db.Products.ToList().Take(prodqty);
        }

        //*************  Get a quantity of Products with the lowest price *****************
     

        //*************  Get all Products based on the Category *****************
        public IEnumerable<Product> GetProductByCategoryID(int categoryId)
        {
            return db.Products.Where(a => a.CategoryID == categoryId).ToList();
        }
        public IEnumerable<Product> GetProductDeals(int prodqty)
        {
            return db.Products.ToList().OrderBy(p => p.UnitPrice).Take(prodqty);
        }
        //*************  Get a Products by its name *****************
        public Product GetProduct(string prodName)
        {
            return db.Products.Where(p => p.ProductName == prodName).ToList().First();
        }

        //*************  Get a Product by its Id *****************
        public Product GetProduct(int productId)
        {
            return db.Products.Where(p => p.ProductID == productId).ToList().First();
        }

        //*************  Add one product to the database *****************
        public bool InsertProduct(Product product)
        {
            db.Products.Add(product);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        //*************  Delete a spacefic Product to the database *****************
        public bool DeleteProduct(int productId)
        {
            var prod = db.Products.Find(productId);
            db.Products.Remove(prod);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        //*************  Update one product to the database *****************
        public bool UpdateProduct(Product product)
        {
            db.Products.Attach(product);
            db.Entry(product).State = EntityState.Modified;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        //*************  Save any changes to the database *****************
        public bool Save()
        {
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}