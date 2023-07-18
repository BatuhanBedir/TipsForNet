```
builder.Services.AddHealthChecks()
    .AddSqlServer(
    connectionString: connectionString,
    healthQuery: "Select 1",
    name: "Sql Server",
    failureStatus: HealthStatus.Unhealthy,
    tags: new String[] { "database" });

    -AddSqlServer() yöntemiyle bir SQL Server saðlýk denetimi yapýlandýrmasý eklenmektedir.

    healthQuery: Saðlýk durumu sorgusu olarak kullanýlacak SQL sorgusunu belirtir. Bu örnekte "Select 1" sorgusu kullanýlýyor, yani SQL 
    Server'a baðlantý saðlandýðýnda "1" deðeri döndürülüyor.

    name: Saðlýk denetimi adýný belirtir. "Sql Server" olarak adlandýrýldý.

    failureStatus: Saðlýk durumu baþarýsýz olduðunda döndürülecek durumu belirtir. HealthStatus.Unhealthy kullanýlýyor, yani
    saðlýk durumu baþarýsýz olduðunda "Unhealthy" durumu döndürülmesi gerekiyor
    .
    tags: Saðlýk denetimi için etiketleri belirtir. Bu örnekte "database" etiketi kullanýlýyor.


-------------------------------------------------------------------------------------------------------------------

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

    -while (!stoppingToken.IsCancellationRequested) döngüsü, görevin iptal edilmediði sürece çalýþýr. stoppingToken parametresi, görevin
    iptal edilmesini saðlayan bir iþaretleyicidir.

    using (var scope = _scopeFactory.CreateScope()) ifadesi, yeni bir hizmet kapsamý oluþturur. Bu kapsam, baðýmlýlýklara eriþimi ve bellek
    sýzýntýlarýný önlemek için kullanýlýr.

    var healtCheckService = scope.ServiceProvider.GetRequiredService<HealthCheckService>(), saðlýk denetimi hizmetine eriþmek için
    HealthCheckService'i çözümleyen bir hizmet saðlayýcýsý kullanýr.

    var result = await healtCheckService.CheckHealthAsync(cancellationToken: stoppingToken);, saðlýk denetimlerini gerçekleþtirir ve
    sonucunu result deðiþkenine atar.

    var healtCheckResult = new Entity.HealthCheckResult satýrý, saðlýk denetimi sonuçlarýný HealthCheckResult adlý bir varlýk sýnýfýna 
    aktarýr. 

    await Task.Delay(_interval, stoppingToken); satýrý, belirli bir süre boyunca beklemek için kullanýlýr. _interval deðiþkeni, beklemek
    için kullanýlan süreyi belirtir.
```