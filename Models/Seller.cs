using System.Collections.Generic;

namespace DsnFarms
{
    public class Seller
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}