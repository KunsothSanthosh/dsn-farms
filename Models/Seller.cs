using System.Collections.Generic;

namespace DsnFarms
{
    public class Seller
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public double GetTotalValue()
        {
            double total = 0;
            foreach (var product in Products)
            {
                foreach (var variant in product.Variants)
                {
                    total += variant.Price * variant.Quantity;
                }
            }
            return total;
        }
    }
}