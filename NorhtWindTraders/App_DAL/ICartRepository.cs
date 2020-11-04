using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorhtWindTraders.App_DAL
{
    interface ICartRepository
    {
        IEnumerable<Cart> GetCartItems();
        Product GetProduct(int productId);
        Cart GetCartProduct(int productId);
        bool InsertProductToCart(Cart product);
        bool DeleteProductFromCart(int productId);
        bool Save();
    }
}
