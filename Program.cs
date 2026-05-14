using System;

namespace DsnFarms
{
    class Program
    {
        static void Main()
        {
            // Create Seller
            Seller seller = new Seller
            {
                Name = "Ramesh",
                Location = "Andhra Pradesh"
            };

            // Create Hens Product
            Product hens = new Product
            {
                Name = "Hens"
            };

            hens.Variants.Add(new ProductVariant
            {
                VariantName = "Broiler",
                Price = 200,
                Quantity = 50
            });

            hens.Variants.Add(new ProductVariant
            {
                VariantName = "Country Chicken",
                Price = 350,
                Quantity = 30
            });

            // Create Vegetables Product
            Product vegetables = new Product
            {
                Name = "Vegetables"
            };

            vegetables.Variants.Add(new ProductVariant
            {
                VariantName = "Tomato",
                Price = 20,
                Quantity = 100
            });

            vegetables.Variants.Add(new ProductVariant
            {
                VariantName = "Potato",
                Price = 25,
                Quantity = 80
            });

            // Add products to seller
            seller.Products.Add(hens);
            seller.Products.Add(vegetables);

            // Print Output
            PrintSellerData(seller);
        }

        static void PrintSellerData(Seller seller)
        {
            Console.WriteLine($"Seller: {seller.Name}\n");

            foreach (var product in seller.Products)
            {
                Console.WriteLine($"Product: {product.Name}");

                foreach (var variant in product.Variants)
                {
                    Console.WriteLine($" - {variant.VariantName} → ₹{variant.Price} ({variant.Quantity} qty)");
                }

                Console.WriteLine();
            }
        }
    }
}