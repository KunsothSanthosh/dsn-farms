using System;


public class Product
{
    public string Name { get; set; }
    public double PricePerKg { get; set; }
    public double Quantity { get; set; }

    public Product(string name, double pricePerKg, double quantity)
    {
        Name = name;
        PricePerKg = pricePerKg;
        Quantity = quantity;
    }

    public double CalculateTotal()
    {
        double total = PricePerKg * Quantity;
        if (total > 500)
        {
            total -= total * 0.1; // Apply 10% discount
        }
        return total;
    }

    public double CalculateGST()
    {
        return CalculateTotal() * 0.05; // GST is 5%
    }

    public double CalculateFinalAmount()
    {
        return CalculateTotal() + CalculateGST();
    }



}