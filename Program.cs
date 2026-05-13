using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("🌾 Welcome to DSN Farms");

        Console.Write("Enter Product Name: ");
        string productName = Console.ReadLine()?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(productName))
        {
            productName = "Unknown Product";
        }

        double pricePerKg = ReadDouble("Enter Price per Kg: ");
        double quantity = ReadDouble("Enter Quantity (Kg): ");

        double total = pricePerKg * quantity;
        if (total > 500)
        {
            total -= total * 0.1; // Apply 10% discount
        }

        double gst = total * 0.05;
        double finalAmount = total + gst;

        Console.WriteLine("\n🧾 Bill Summary:");
        Console.WriteLine($"Product: {productName}");
        Console.WriteLine($"Total Price: ₹{finalAmount:F2}");
    }

    private static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, NumberStyles.Number, CultureInfo.CurrentCulture, out double result))
            {
                return result;
            }

            Console.WriteLine("Invalid number. Please enter a valid numeric value.");
        }
    }
}
