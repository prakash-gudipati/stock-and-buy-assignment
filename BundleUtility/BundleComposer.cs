using System;
using System.Collections.Generic;

namespace BundleUtility
{
    public class BundleComposer
    {
        private Dictionary<Part, int> memo;

        public int CalculateMaxBundles(Part root)
        {
            memo = new Dictionary<Part, int>();
            return CalculateMaxBundlesHelper(root);
        }

        private int CalculateMaxBundlesHelper(Part root)
        {
            if (root == null)
                return 0;

            if (memo.ContainsKey(root))
                return memo[root];

            if (root.SubParts.Count == 0)
            {
                int maxStockForPart = GetMaxStockForPart(root);
                memo[root] = maxStockForPart;
                return maxStockForPart;
            }

            int minSubPartBundles = int.MaxValue;
            foreach (var subPart in root.SubParts)
            {
                if (subPart.Stock == int.MaxValue)
                {
                    int subPartBundles = CalculateMaxBundlesHelper(subPart) / subPart.Quantity;
                    minSubPartBundles = GetMinimum(minSubPartBundles, subPartBundles);
                }
                else
                {
                    int maxStockForSubPart = GetMaxStockForPart(subPart);
                    minSubPartBundles = GetMinimum(minSubPartBundles, maxStockForSubPart);
                }
            }
            memo[root] = minSubPartBundles;
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
