using System;

namespace DsnFarms
{
    class Program
    {
        static void Main()
        {
            SellerService service = new SellerService();

            // Create seller
            Seller seller = service.CreateSeller("Ramesh", "Andhra Pradesh");

            // Create products
            Product hens = new Product { Name = "Hens" };
            Product vegetables = new Product { Name = "Vegetables" };

            // Add variants
            service.AddVariant(hens, "Broiler", 200, 50);
            service.AddVariant(hens, "Country Chicken", 350, 30);

            service.AddVariant(vegetables, "Tomato", 20, 100);
            service.AddVariant(vegetables, "Potato", 25, 80);

            // Add products to seller
            service.AddProduct(seller, hens);
            service.AddProduct(seller, vegetables);

            // Print data
            service.PrintSellerData(seller);
        }
    }
}