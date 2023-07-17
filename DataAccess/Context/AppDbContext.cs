﻿using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

//sealed başka bir class'a inherit edilmesini engelliyor
public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=BATUHAN;Initial Catalog=TipsForNetDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
    public DbSet<Product> Products { get; set; }
}
