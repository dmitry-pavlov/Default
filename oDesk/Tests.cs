using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpTest
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestMaxSum()
        {
            MaxSum(new[] {2, -3, 2, 2, -1, 2, -2, 1});
        }

        [TestMethod]
        public void TestSearchProducts()
        {
            var products = new[] {"boat", "bike", "phone"};
            var queries = new[] {"b", "bk", "PHo", "bO"};
            SearchProducts(products, queries);
        }

        public void SearchProducts(string[] products, string[] queries)
        {
            const string notFound = "-1";
            Array.Sort(products);

            queries
                .Select(query => products.FirstOrDefault(product => product.StartsWith(query, true, null)))
                .Select(matchedProduct => matchedProduct ?? notFound)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        public void MaxSum(int[] numbers)
        {
            var maxSoFar = numbers[0];
            var maxEndingHere = numbers[0];

            for (var i = 1; i < numbers.Length; i++)
            {
                var number = numbers[i];

                maxEndingHere = maxEndingHere >= 0
                    ? maxEndingHere + number
                    : number;

                if (maxEndingHere < maxSoFar) continue;

                maxSoFar = maxEndingHere;
            }

            Console.WriteLine(maxSoFar);
        }
    }
}