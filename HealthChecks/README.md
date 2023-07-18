```
builder.Services.AddHealthChecks()
    .AddSqlServer(
    connectionString: connectionString,
    healthQuery: "Select 1",
    name: "Sql Server",
    failureStatus: HealthStatus.Unhealthy,
    tags: new String[] { "database" });

    -AddSqlServer() y�ntemiyle bir SQL Server sa�l�k denetimi yap�land�rmas� eklenmektedir.

    healthQuery: Sa�l�k durumu sorgusu olarak kullan�lacak SQL sorgusunu belirtir. Bu �rnekte "Select 1" sorgusu kullan�l�yor, yani SQL 
    Server'a ba�lant� sa�land���nda "1" de�eri d�nd�r�l�yor.

    name: Sa�l�k denetimi ad�n� belirtir. "Sql Server" olarak adland�r�ld�.

    failureStatus: Sa�l�k durumu ba�ar�s�z oldu�unda d�nd�r�lecek durumu belirtir. HealthStatus.Unhealthy kullan�l�yor, yani
    sa�l�k durumu ba�ar�s�z oldu�unda "Unhealthy" durumu d�nd�r�lmesi gerekiyor
    .
    tags: Sa�l�k denetimi i�in etiketleri belirtir. Bu �rnekte "database" etiketi kullan�l�yor.


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

    -while (!stoppingToken.IsCancellationRequested) d�ng�s�, g�revin iptal edilmedi�i s�rece �al���r. stoppingToken parametresi, g�revin
    iptal edilmesini sa�layan bir i�aretleyicidir.

    using (var scope = _scopeFactory.CreateScope()) ifadesi, yeni bir hizmet kapsam� olu�turur. Bu kapsam, ba��ml�l�klara eri�imi ve bellek
    s�z�nt�lar�n� �nlemek i�in kullan�l�r.

    var healtCheckService = scope.ServiceProvider.GetRequiredService<HealthCheckService>(), sa�l�k denetimi hizmetine eri�mek i�in
    HealthCheckService'i ��z�mleyen bir hizmet sa�lay�c�s� kullan�r.

    var result = await healtCheckService.CheckHealthAsync(cancellationToken: stoppingToken);, sa�l�k denetimlerini ger�ekle�tirir ve
    sonucunu result de�i�kenine atar.

    var healtCheckResult = new Entity.HealthCheckResult sat�r�, sa�l�k denetimi sonu�lar�n� HealthCheckResult adl� bir varl�k s�n�f�na 
    aktar�r. 

    await Task.Delay(_interval, stoppingToken); sat�r�, belirli bir s�re boyunca beklemek i�in kullan�l�r. _interval de�i�keni, beklemek
    i�in kullan�lan s�reyi belirtir.
```