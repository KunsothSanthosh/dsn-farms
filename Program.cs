using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("🌾 Welcome to DSN Farms");

        List<Product> products = new List<Product>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Bill");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Product p = GetProductInput();
                    products.Add(p);
                    Console.WriteLine("Product added successfully!");
                    break;
                case "2":
                    PrintBill(products);
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static Product GetProductInput()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        double price = ReadDouble("Enter Price per Kg: ");
        double quantity = ReadDouble("Enter Quantity (Kg): ");

        return new Product(name, price, quantity);
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

    static void PrintBill(List<Product> products)
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products added yet.");
            return;
        }

        Console.WriteLine("\n🧾 Bill Summary:");
        double grandTotal = 0;
        foreach (var product in products)
        {
            double finalAmount = product.CalculateFinalAmount();
            grandTotal += finalAmount;
            Console.WriteLine($"Product: {product.Name}, Quantity: {product.Quantity} Kg, Final Price (incl. GST): ₹{finalAmount:F2}");
        }
        Console.WriteLine($"Grand Total: ₹{grandTotal:F2}");
    }
}