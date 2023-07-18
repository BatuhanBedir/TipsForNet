using DataAccess.Context;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PerformanceLogWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        AppDbContext context = new();

        IList<PerformanceLog> performanceLogs = 
            await context.PerformanceLogs
            .OrderByDescending(x=>x.Id)
            .ToListAsync();

        return Ok(performanceLogs);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        AppDbContext context = new();
        IList<Product> products = 
            await context.Products
            .ToListAsync(cancellationToken);
        return Ok(products.Take(10));

    }
}
