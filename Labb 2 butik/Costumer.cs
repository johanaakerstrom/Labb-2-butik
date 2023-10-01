using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2_butik
{
    internal class Customer
    
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        private List<CartItem> _cart;
        public List<CartItem> Cart { get { return _cart; } }
        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            _cart = new List<CartItem>();
        }
       
        public void AddToCart(CartItem cartItem)
        {
            
            _cart.Add(cartItem);
            Console.WriteLine($"{cartItem.Quantity} {cartItem.Product.Name} has been added to {Name}'s cart.");
        }
        public void TotalCartPrice()

        {
            double totalPrice = 0;
            foreach (CartItem cartItem in _cart)
            {
                totalPrice += cartItem.Product.Price * cartItem.Quantity;
            }

            Console.WriteLine($"The total is {totalPrice} $");
        }
        public override string ToString()
        {
            StringBuilder cartBuilder = new StringBuilder();
            cartBuilder.AppendLine($"Customer name: {Name} - Customer password: {Password}");
            cartBuilder.AppendLine($"Shopping cart:");
            foreach (CartItem cartItem in _cart)
            {
                cartBuilder.AppendLine($" - {cartItem.Quantity} {cartItem.Product.Name} (${cartItem.Product.Price}) {cartItem.Quantity * cartItem.Product.Price}");

            }

            return cartBuilder.ToString();
        }
        public bool CheckPassword(string password)
        {
            return Password == password;

        }

    }

}
                    










































































