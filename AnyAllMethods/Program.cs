using DataAccess.Context;

namespace AnyAllMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();

            bool result = context.Products.Any();

            bool result2 = context.Products.Any(x=>x.Name == "Product1");

            bool result3 = context.Products.All(x => x.Name.Contains("P"));

            bool result4 = context.Products.All(x => x.Name == "Product1");
            Console.WriteLine("Hello, World!");
        }
    }
}