using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorhtWindTraders.App_DAL
{
    public class CartRepository:ICartRepository,IDisposable
    {
        private NWContext db;

        public CartRepository()
        {
            db = new NWContext();
        }
        
        public IEnumerable<Cart> GetCartItems()
        {
            return db.Carts.ToList();
        }

        public Product GetProduct(int productId)
        {
            return db.Products.Where(p => p.ProductID == productId).ToList().First();
        }

        public Cart GetCartProduct(int productId)
        {
            return db.Carts.Where(p => p.ProductID == productId).ToList().First();
        }


        public void MoveToOrderDetails(Cart items)
        {
            Order_Detail o = new Order_Detail();
            o.ProductID = Convert.ToInt32(items.ProductID);
            o.UnitPrice = Convert.ToDecimal(items.UnitPrice);
            o.Quantity = Convert.ToInt16(items.ProductQuantity);

            db.Order_Details.Add(o);
        }

        public bool InsertProductToCart(Cart product)
        {
            db.Carts.Add(product);
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public bool DeleteProductFromCart(int productId)
        {
            var prod = db.Carts.Find(productId);
            db.Carts.Remove(prod);
            if (db.SaveChanges() > 0)
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
            db.Dispose();
        }


        
    }
}