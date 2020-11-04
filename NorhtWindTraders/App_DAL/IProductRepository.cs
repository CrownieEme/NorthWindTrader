using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWindTraders.App_DAL
{
    interface IProductRepository:IDisposable
    {

        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(int prodqty);
        IEnumerable<Product> GetProductDeals(int prodqty);    
        IEnumerable<Product> GetProductByCategoryID(int categoryId);
        Product GetProduct(string prodName);
        Product GetProduct(int productId);
        bool InsertProduct(Product product);
        bool DeleteProduct(int productId);
        bool UpdateProduct(Product product);
        bool Save();
    }
}
