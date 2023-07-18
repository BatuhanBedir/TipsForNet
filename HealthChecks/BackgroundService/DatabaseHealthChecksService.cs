using DataAccess.Context;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks;

public class DatabaseHealthChecksService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);

    public DatabaseHealthChecksService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var healtCheckService = scope.ServiceProvider.GetRequiredService<HealthCheckService>();
                var context = new AppDbContext();

                var result = await healtCheckService.CheckHealthAsync(cancellationToken: stoppingToken);

                var healtCheckResult = new Entity.HealthCheckResult
                {
                    Timestamp = DateTime.Now,
                    Status = result.Status.ToString(),
                    Description = result.Entries["Sql Server"].Description
                };

                await context.HealthCheckResults.AddAsync(healtCheckResult);
                await context.SaveChangesAsync(stoppingToken);
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}
