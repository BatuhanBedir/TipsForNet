using DataAccess.Context;
using Entity;

namespace StartConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new();

            IList<Category> categories = new List<Category>();
            for (int i = 1; i <= 9; i++)
            {
                Category category = new Category
                {
                    Name = "Category " + i
                };
                categories.Add(category);
            }

            IList<Product> products = new List<Product>();
            for (int i = 0; i < 1000000; i++)
            {
                Random random = new Random();
                Product product = new()
                {
                    Name = "Product" + i.ToString(),
                    CategoryId = random.Next(1,9)
                };
                products.Add(product);
            }
            context.Categories.AddRange(categories);
            context.Products.AddRange(products);

            context.SaveChanges();

            Console.WriteLine("Hello, World!");
        }
    }
}