using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine("🌾 Welcome to DSN Farms");

        Product product = GetProductInput();

        double finalAmount = product.CalculateFinalAmount();

        PrintBill(product, finalAmount);
    }

    static Product GetProductInput()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter Price per Kg: ");
        double price = Convert.ToDouble(Console.ReadLine() ?? "0");

        Console.Write("Enter Quantity (Kg): ");
        double quantity = Convert.ToDouble(Console.ReadLine() ?? "0");

        return new Product(name, price, quantity);
    }

    static void PrintBill(Product product, double total)
    {
        Console.WriteLine("\n🧾 Bill Summary:");
        Console.WriteLine($"Product: {product.Name}");
        Console.WriteLine($"Quantity: {product.Quantity} Kg");
        Console.WriteLine($"Final Price (incl. GST): ₹{total}");
    }
}