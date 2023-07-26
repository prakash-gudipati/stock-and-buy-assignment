using System;

namespace BundleUtility
{
    public class BundleComposer
    {
        public int CalculateMaxBundles(Part root, int h = 0)
        {
            if (root == null)
                return 0;

            if (h == 0 && root.SubParts.Count == 0)
            {
                return int.MinValue;
            }

            if (root.SubParts.Count == 0)
            {
                return GetMaxStockForPart(root);
            }

            int minSubPartBundles = int.MaxValue;
            foreach (var subPart in root.SubParts)
            {
                if (subPart.Stock == int.MaxValue)
                {
                    minSubPartBundles = GetMinimum(minSubPartBundles, (CalculateMaxBundles(subPart, h + 1) / subPart.Quantity));
                }
                else
                {
                    minSubPartBundles = GetMinimum(minSubPartBundles, GetMaxStockForPart(subPart));
                }
            }
            return minSubPartBundles;
        }

        private int GetMinimum(int a, int b)
        {
            return Math.Min(a, b);
        }

        private int GetMaxStockForPart(Part part)
        {
            return (part.Stock / part.Quantity);
        }
    }
}
