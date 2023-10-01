using System.Text;

namespace Labb_2_butik
{
    internal class Program
    {
        private static List<Customer> customers = new List<Customer>();
        public static List<Product> Products = new List<Product>();
        private static Customer loggedInCustomer;
        static void Main(string[] args)
        {
            Products.Add(new Product("Carlsberg", 1));
            Products.Add(new Product("Pistonhead", 1));
            Products.Add(new Product("Heineken", 2));
            Products.Add(new Product("Poppels", 4));
            Products.Add(new Product("Plastic Bag", 0.5));

            customers.Add(new Customer("Johan", "1234"));
            customers.Add(new Customer("Knatte", "123"));
            customers.Add(new Customer("Fnatte", "321"));
            customers.Add(new Customer("Tjatte", "213"));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-------------------------");
            Console.WriteLine("Welcome to the BeerMarket!");
            Console.WriteLine();

            Console.WriteLine("Do you want to (login) or create a (new) account?");
            string loginOrCreate = Console.ReadLine().ToLower();

            if (loginOrCreate == "login")
            {
                Console.Clear();
                Console.Write("Enter your username: ");
                string usernameInput = Console.ReadLine();
                Console.Write("Enter your password: ");
                string userpasswordInput = Console.ReadLine();

                Customer customer = FindCustomerByUsername(usernameInput);

                if (customer != null && customer.CheckPassword(userpasswordInput))
                {
                    Console.WriteLine();
                    loggedInCustomer = customer;
                    // Perform actions for a logged-in customer
                }
                else
                {
                    Console.WriteLine("Customer not found or password is incorrect.");
                    Console.WriteLine("Do you want to create a new account? (yes/no)");
                    string createAccountChoice = Console.ReadLine().ToLower();

                    if (createAccountChoice == "yes")
                    {
                        Console.WriteLine("Enter a new username:");
                        string newUsername = Console.ReadLine();
                        Console.WriteLine("Enter a new password:");
                        string newPassword = Console.ReadLine();

                        Customer newCustomer = new Customer(newUsername, newPassword);
                        customers.Add(newCustomer);

                        Console.WriteLine("Account created successfully. You are now logged in.");
                    }
                }
            }

            else if (loginOrCreate == "new")
            {
                Console.Clear();
                Console.Write("Enter a new username: ");
                string newUsername = Console.ReadLine();
                Console.Write("Enter a new password: ");
                string newPassword = Console.ReadLine();
                Customer newCustomer = new Customer(newUsername, newPassword);
                customers.Add(newCustomer);
                loggedInCustomer = newCustomer;
                Console.WriteLine("----------------------");
                Console.WriteLine("Account created successfully. You are now logged in.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1 for login or 2 for creating a new account.");
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {loggedInCustomer.Name}!");

                Console.WriteLine("Press 1: Go to shop.");
                Console.WriteLine("Press 2: Show cart.");
                Console.WriteLine("Press 3: Check out.");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Store();
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine(loggedInCustomer);
                    loggedInCustomer.TotalCartPrice();
                    Console.WriteLine("Press any key to return to menu");
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    if (CheckOut())
                    {
                        break;
                    }
                }
            }


        }
        static void Store()
        {
            while (true)
            {

                int index = 1;
                StringBuilder storeBuilder = new StringBuilder();

                Console.Clear();
                storeBuilder.AppendLine($"These are our beers:");
                Console.WriteLine("---------------------------");

                foreach (Product product in Products)
                {
                    storeBuilder.AppendLine($"({index}) - {product.Name} - ${product.Price}");
                    index++;
                }
                storeBuilder.AppendLine("Choose the product you want to buy:");
                Console.WriteLine(storeBuilder.ToString());


                int option = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many would you like?");
                int amount = Convert.ToInt32(Console.ReadLine());
                if (option >= 1 && option <= Products.Count)
                {
                    // Pass the product name and price to AddToCart method
                    Product selectedProduct = Products[option - 1];
                    CartItem? itemFound = loggedInCustomer.Cart.FirstOrDefault(c => c.Product.Name == selectedProduct.Name);
                    if (itemFound == null)
                    {
                        CartItem newItem = new CartItem(amount, selectedProduct);
                        loggedInCustomer.AddToCart(newItem);

                    }
                    else
                    {
                        itemFound.Quantity += amount;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid beer option");
                }


                Console.WriteLine("Would you like to continue shopping? (yes/no)");
                string continueShopping = Console.ReadLine();

                if (continueShopping == "no")
                {
                    break;
                }

            }

        }

        public static bool CheckOut()
        {
            Console.WriteLine("Would you like to pay? (yes/no)");
            string payOrnot = Console.ReadLine();

            if (payOrnot == "yes")
            {
                Console.WriteLine("Thank you for shopping! Welcome back any time!");
                return true;
            }
            return false;
        }
        private static Customer FindCustomerByUsername(string username)
        {
            return customers.Find(c => c.Name == username);
        }
    }
}






































