using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

//sealed başka bir class'a inherit edilmesini engelliyor
public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=TipsForNetDb;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True");
    }
    DbSet<Product> Products { get; set; }
}
