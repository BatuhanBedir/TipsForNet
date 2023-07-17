using DataAccess.Context;
using Entity;
using System.Net.Http.Headers;

namespace IQueryable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();
            
            IQueryable<Product> products = context.Products.AsQueryable(); //şuanlık sonuç vermiyor
            //products.ToList();
            IList<Product> productsList = products.Where(x => x.Id > 663853).ToList();


            Console.WriteLine("Hello, World!");
        }
    }
}