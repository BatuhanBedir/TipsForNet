using DataAccess.Context;
using Entity;

namespace SingleOrUnique;

internal class Program
{
    static void Main(string[] args)
    {
        AppDbContext context = new();
        //Product product = new()
        //{
        //    Name = "Product0"
        //};
        //context.Products.Add(product);
        //context.SaveChanges();
        //SqlException: Cannot insert duplicate key row in object 'dbo.Products' with unique index 'IX_Products_Name'. The duplicate key value is (Product0).

        //Product? product = context.Products.Where(x => x.Name == "Product0").SingleOrDefault();
        //System.InvalidOperationException: 'Sequence contains more than one element'

        //Console.WriteLine(product?.Name);
    }
}