using DataAccess.Context;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace EagerLazyLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();
            //Lazy Loading 
            //IList<Product> products = context.Products.ToList();

            //Eager Loading
            IList<Product> products = context.Products.Include(x=>x.Category).ToList(); 

            Console.WriteLine("Hello, World!");
        }
    }
}