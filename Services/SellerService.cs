using System;
using System.Collections.Generic;

namespace DsnFarms
{
    public class SellerService
    {
        public Seller CreateSeller(string name, string location)
        {
            return new Seller
            {
                Name = name,
                Location = location
            };
        }

        public void AddProduct(Seller seller, Product product)
        {
            seller.Products.Add(product);
        }

        public void AddVariant(Product product, string variantName, double price, int quantity)
        {
            product.Variants.Add(new ProductVariant
            {
                VariantName = variantName,
                Price = price,
                Quantity = quantity
            });
        }

        public void PrintSellerData(Seller seller)
        {
            Console.WriteLine($"Seller: {seller.Name} ({seller.Location})");
            Console.WriteLine($"Total Inventory Value: ₹{CalculateInventoryValue(seller):F2}\n");

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

        public double CalculateInventoryValue(Seller seller)
        {
            double total = 0;
            foreach (var product in seller.Products)
            {
                foreach (var variant in product.Variants)
                {
                    total += variant.Price * variant.Quantity;
                }
            }
            return total;
        }

        public Product? FindProductByName(Seller seller, string productName)
        {
            return seller.Products.Find(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveVariant(Product product, string variantName)
        {
            var variant = product.Variants.Find(v => v.VariantName.Equals(variantName, StringComparison.OrdinalIgnoreCase));
            if (variant != null)
            {
                product.Variants.Remove(variant);
            }
        }
    }
}