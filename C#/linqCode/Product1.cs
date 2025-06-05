using System;
using System.Linq;

namespace LinqCodeTemplate
{
    internal class MainLinq
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();

            Console.WriteLine("1. Products with category FMCG");
            var q1 = products.Where(p => p.ProCategory == "FMCG");
            foreach (var item in q1)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            Console.WriteLine("\n2. Products with category Grain");
            var q2 = products.Where(p => p.ProCategory == "Grain");
            foreach (var item in q2)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");

            Console.WriteLine("\n3. Sorted by Product Code");
            var q3 = products.OrderBy(p => p.ProCode);
            foreach (var item in q3)
                Console.WriteLine($"{item.ProCode}\t{item.ProName}");

            Console.WriteLine("\n4. Sorted by Product Category");
            var q4 = products.OrderBy(p => p.ProCategory);
            foreach (var item in q4)
                Console.WriteLine($"{item.ProCategory}\t{item.ProName}");

            Console.WriteLine("\n5. Sorted by Mrp Ascending");
            var q5 = products.OrderBy(p => p.ProMrp);
            foreach (var item in q5)
                Console.WriteLine($"{item.ProMrp}\t{item.ProName}");

            Console.WriteLine("\n6. Sorted by Mrp Descending");
            var q6 = products.OrderByDescending(p => p.ProMrp);
            foreach (var item in q6)
                Console.WriteLine($"{item.ProMrp}\t{item.ProName}");

            Console.WriteLine("\n7. Grouped by Product Category");
            var q7 = products.GroupBy(p => p.ProCategory);
            foreach (var group in q7)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }

            Console.WriteLine("\n8. Grouped by Mrp");
            var q8 = products.GroupBy(p => p.ProMrp);
            foreach (var group in q8)
            {
                Console.WriteLine($"MRP: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProCategory}");
            }

            Console.WriteLine("\n9. Product with Highest Price in FMCG");
            var q9 = products.Where(p => p.ProCategory == "FMCG").OrderByDescending(p => p.ProMrp).FirstOrDefault();
            if (q9 != null)
                Console.WriteLine($"{q9.ProCode}\t{q9.ProName}\t{q9.ProMrp}");

            Console.WriteLine("\n10. Count of Total Products");
            Console.WriteLine(products.Count());

            Console.WriteLine("\n11. Count of FMCG Products");
            Console.WriteLine(products.Count(p => p.ProCategory == "FMCG"));

            Console.WriteLine("\n12. Max Price");
            Console.WriteLine(products.Max(p => p.ProMrp));

            Console.WriteLine("\n13. Min Price");
            Console.WriteLine(products.Min(p => p.ProMrp));

            Console.WriteLine("\n14. Are all products below Rs.30?");
            Console.WriteLine(products.All(p => p.ProMrp < 30));

            Console.WriteLine("\n15. Are any products below Rs.30?");
            Console.WriteLine(products.Any(p => p.ProMrp < 30));

            Console.ReadLine();
        }
    }
}
