﻿using System;
using System.Linq;
using System.ComponentModel;

using linqshared;

namespace linq_quantifiers
{
    class Program : ProgramBase
    {
        static void Main(string[] args)
        {
            Linq67();
//            Linq69();
//            Linq70();
//            Linq72();
        }

        [Category("Quantifiers")]
        [Description("This sample uses determines if Any of the words in the array contain the substring 'ei'.")]
        static void Linq67()
        {
            var words = new []{ "believe", "relief", "receipt", "field" };

            var iAfterE = words.Any(w => w.Contains("ei"));

            Console.WriteLine($"There is a word in the list that contains 'ei': {iAfterE}");
        }

        [Category("Quantifiers")]
        [Description("This sample determines if Any of the grouped a list of products only for categories that have at least one product that is out of stock.")]
        static void Linq69()
        {
            var products = GetProductList();

            var productGroups = products
                .GroupBy(prod => prod.Category)
                .Where(prodGroup => prodGroup.Any(p => p.UnitsInStock == 0))
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        Products = prodGroup
                    });

            ObjectDumper.Write(productGroups, 1);
        }

        [Category("Quantifiers")]
        [Description("This sample determines if All the elements in the array contain only odd numbers.")]
        static void Linq70()
        {
            var numbers = new [] { 1, 11, 3, 19, 41, 65, 19 };

            var onlyOdd = numbers.All(n => n % 2 == 1);

            Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
        }

        [Category("Quantifiers")]
        [Description("This sample determines if All elements in the grouped a list of products by categories, have all of their products in stock.")]
        static void Linq72()
        {
            var products = GetProductList();

            var productGroups = products
                .GroupBy(prod => prod.Category)
                .Where(prodGroup => prodGroup.All(p => p.UnitsInStock > 0))
                .Select(prodGroup => 
                    new
                    {
                        Category = prodGroup.Key, 
                        Products = prodGroup
                    });

            ObjectDumper.Write(productGroups, 1);
        }
    }
}
