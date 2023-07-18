using DataAccess.Context;
using Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.AccessControl;
using System;

namespace AsReadOnly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new ();
            IReadOnlyList<Product> products = context.Products.ToList().AsReadOnly();
            products[0].Name = "Deneme";  //Değiştirmeye etkisi olmuyor. sadece eklemeye.

            //            Product product = new()
            //            {
            //                Name = "Deneme2"
            //            };
            //            products.Add(product);
            //            'IReadOnlyList<Product>' does not contain a definition for 'Add' and no accessible extension method 'Add' accepting a first argument of type 'IReadOnlyList<Product>' could be found(are you missing a using directive or an assembly reference ?)	 hatası 


            Console.WriteLine(products[0].Name);
        }
    }
}