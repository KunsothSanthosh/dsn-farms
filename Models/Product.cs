using System.Collections.Generic;

namespace DsnFarms
{
    public class Product
    {
        public string Name { get; set; } // Hens / Vegetables

        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}