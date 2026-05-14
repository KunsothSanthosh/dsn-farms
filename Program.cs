using System;

namespace DsnFarms
{
    class Program
    {
        static void Main()
        {
            List<Seller> sellers = new List<Seller>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n🌾 DSN Farms Menu:");
                Console.WriteLine("1. Add Seller");
                Console.WriteLine("2. Add Product to Seller");
                Console.WriteLine("3. Add Variant to Product");
                Console.WriteLine("4. View All Sellers");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddSeller(sellers);
                        break;
                    case "2":
                        AddProductToSeller(sellers);
                        break;
                    case "3":
                        AddVariantToProduct(sellers);
                        break;
                    case "4":
                        ViewAllSellers(sellers);
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddSeller(List<Seller> sellers)
        {
            Console.Write("Enter Seller Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter Seller Location: ");
            string location = Console.ReadLine() ?? string.Empty;

            Seller seller = new Seller { Name = name, Location = location };
            sellers.Add(seller);
            Console.WriteLine("Seller added successfully!");
        }

        static void AddProductToSeller(List<Seller> sellers)
        {
            if (sellers.Count == 0)
            {
                Console.WriteLine("No sellers available. Add a seller first.");
                return;
            }

            Console.WriteLine("Select a seller:");
            for (int i = 0; i < sellers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sellers[i].Name} ({sellers[i].Location})");
            }
            Console.Write("Enter seller number: ");
            if (int.TryParse(Console.ReadLine(), out int sellerIndex) && sellerIndex >= 1 && sellerIndex <= sellers.Count)
            {
                Seller seller = sellers[sellerIndex - 1];
                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine() ?? string.Empty;
                Product product = new Product { Name = productName };
                seller.Products.Add(product);
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid seller selection.");
            }
        }

        static void AddVariantToProduct(List<Seller> sellers)
        {
            if (sellers.Count == 0)
            {
                Console.WriteLine("No sellers available.");
                return;
            }

            Console.WriteLine("Select a seller:");
            for (int i = 0; i < sellers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sellers[i].Name}");
            }
            Console.Write("Enter seller number: ");
            if (int.TryParse(Console.ReadLine(), out int sellerIndex) && sellerIndex >= 1 && sellerIndex <= sellers.Count)
            {
                Seller seller = sellers[sellerIndex - 1];
                if (seller.Products.Count == 0)
                {
                    Console.WriteLine("No products available for this seller.");
                    return;
                }

                Console.WriteLine("Select a product:");
                for (int i = 0; i < seller.Products.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {seller.Products[i].Name}");
                }
                Console.Write("Enter product number: ");
                if (int.TryParse(Console.ReadLine(), out int productIndex) && productIndex >= 1 && productIndex <= seller.Products.Count)
                {
                    Product product = seller.Products[productIndex - 1];
                    Console.Write("Enter Variant Name: ");
                    string variantName = Console.ReadLine() ?? string.Empty;
                    double price = ReadDouble("Enter Price: ");
                    int quantity = (int)ReadDouble("Enter Quantity: ");

                    ProductVariant variant = new ProductVariant
                    {
                        VariantName = variantName,
                        Price = price,
                        Quantity = quantity
                    };
                    product.Variants.Add(variant);
                    Console.WriteLine("Variant added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid product selection.");
                }
            }
            else
            {
                Console.WriteLine("Invalid seller selection.");
            }
        }

        static void ViewAllSellers(List<Seller> sellers)
        {
            if (sellers.Count == 0)
            {
                Console.WriteLine("No sellers to display.");
                return;
            }

            foreach (var seller in sellers)
            {
                Console.WriteLine($"Seller: {seller.Name} ({seller.Location})");
                Console.WriteLine($"Total Inventory Value: ₹{seller.GetTotalValue():F2}");

                foreach (var product in seller.Products)
                {
                    Console.WriteLine($"  Product: {product.Name}");

                    foreach (var variant in product.Variants)
                    {
                        Console.WriteLine($"    - {variant.VariantName} → ₹{variant.Price} ({variant.Quantity} qty)");
                    }
                }
                Console.WriteLine();
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (double.TryParse(input, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.CurrentCulture, out double result))
                {
                    return result;
                }
                Console.WriteLine("Invalid number. Please enter a valid numeric value.");
            }
        }
    }
}