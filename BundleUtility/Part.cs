using System.Collections.Generic;

namespace BundleUtility
{
    public class Part
    {
        public string PartName { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
        public List<Part> SubParts { get; set; }

        public Part(string partName, int quantity, int stock)
        {
            PartName = partName;
            Quantity = quantity;
            Stock = stock;
            SubParts = new List<Part>();
        }
    }
}
