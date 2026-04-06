using System;
using System.Collections.Generic;
using System.Linq;

namespace G_Net_40_LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Seafood Category
            Console.WriteLine("\n--- 1. Seafood Products ---");
            var seafoodProducts = ListGenerator.ProductList.Where(p => p.Category == "Seafood");

            foreach (var p in seafoodProducts)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }
            #endregion

            #region 2. Product Names Only
            Console.WriteLine("\n--- 2. Product Names Only ---");
            var productNames = ListGenerator.ProductList.Select(p => p.ProductName);

            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region 3. Sort by Price (Ascending)
            Console.WriteLine("\n--- 3. Sorted by Price (Ascending) ---");
            var sortedByPrice = ListGenerator.ProductList.OrderBy(p => p.UnitPrice);

            foreach (var p in sortedByPrice)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }
            #endregion

            #region 4. Price Between 10 and 30
            Console.WriteLine("\n--- 4. Price Between 10 and 30 ---");
            var priceRange = ListGenerator.ProductList.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);

            foreach (var p in priceRange)
            {
                Console.WriteLine($"Name: {p.ProductName}, Price: {p.UnitPrice}");
            }
            #endregion

            #region 5. In Stock & Condiments
            Console.WriteLine("\n--- 5. In Stock Condiments ---");
            var stockCondiments = ListGenerator.ProductList.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            foreach (var p in stockCondiments)
            {
                Console.WriteLine($"Name: {p.ProductName}, Stock: {p.UnitsInStock}");
            }
            #endregion

            #region 6. Anonymous Type (Name, Price, Status)
            Console.WriteLine("\n--- 6. Product Status Report ---");
            var productStatus = ListGenerator.ProductList.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var p in productStatus)
            {
                Console.WriteLine($"{p.Name} | {p.Price} | {p.StockStatus}");
            }
            #endregion

            #region 7. Position and Name (1-based)
            Console.WriteLine("\n--- 7. Indexed Product Names ---");
            var indexedList = ListGenerator.ProductList.Select((p, i) => $"{i + 1}. {p.ProductName}");

            foreach (var item in indexedList)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 8. Multi-Level Sorting
            Console.WriteLine("\n--- 8. Sort by Category then Price ---");
            var multiSorted = ListGenerator.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var p in multiSorted)
            {
                Console.WriteLine($"[{p.Category}] {p.ProductName}: {p.UnitPrice}");
            }
            #endregion

            #region 9. Beverages by Stock (Descending)
            Console.WriteLine("\n--- 9. Beverages Stock Levels ---");
            var beverages = ListGenerator.ProductList
                .Where(p => p.Category == "Beverages")
                .OrderByDescending(p => p.UnitsInStock);

            foreach (var p in beverages)
            {
                Console.WriteLine($"{p.ProductName}: {p.UnitsInStock}");
            }
            #endregion

            #region 10. Query Syntax (Orders >= 1997)
            Console.WriteLine("\n--- 10. Orders from 1997 onwards ---");
            var orders = from c in ListGenerator.CustomerList
                         from o in c.Orders
                         where o.OrderDate.Year >= 1997
                         select new { c.CustomerID, o.OrderDate };

            foreach (var item in orders)
            {
                Console.WriteLine($"ID: {item.CustomerID}, Date: {item.OrderDate.ToShortDateString()}");
            }
            #endregion

            #region 11. Product Position
            Console.WriteLine("\n--- 11. Names with Positions ---");
            var namePositions = ListGenerator.ProductList.Select((p, i) => new { Pos = i + 1, Name = p.ProductName });

            foreach (var item in namePositions)
            {
                Console.WriteLine($"{item.Pos}. {item.Name}");
            }
            #endregion

            #region 12. String Array Sorting
            Console.WriteLine("\n--- 12. Sorting Words by Length ---");
            string[] wordsArr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = wordsArr
                .OrderBy(w => w.Length)
                .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
            {
                Console.WriteLine(word);
            }
            #endregion

            #region 13. Reversed Digits
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var filteredDigits = digits
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();

            foreach (var d in filteredDigits)
            {
                Console.WriteLine(d);
            }
            #endregion
        }
    }
}