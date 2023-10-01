using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_butik
{
    internal class CartItem
    {

        public int Quantity { get; set; }
        public  Product Product { get; set; }
        public CartItem(int quantity, Product typeProduct) 
        {
            Quantity = quantity;
            Product = typeProduct;
        }
    }
}
