using DataAccess.Context;
using HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Data Source=BATUHAN;Initial Catalog=TipsForNetDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

builder.Services.AddHealthChecks()
    .AddSqlServer(
    connectionString: connectionString,
    healthQuery: "Select 1",
    name: "Sql Server",
    failureStatus: HealthStatus.Unhealthy,
    tags: new String[] { "database" });



builder.Services.AddHostedService<DatabaseHealthChecksService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,//control derecelendirme-> her þeyi kontrol et.
    //Predicate = check => check.Tags.Contains("database")//bire bir spesifik þeyleri kontrol eder.
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();

