using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Benchmark.ConsoleApp;

public class BenchmarkService
{   //ShortRunJob -> kısa ve performanslı çalışmasını sağlıyor
    [ShortRunJob,Config(typeof(Config))]
    private class Config : ManualConfig
    {
        //değerlendirdiğim methodlarda veya yöntemlerde perf farkını yüzdelik olarak görmek için
        public Config()
        {
            SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default.WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
        }
    }
    [Benchmark(Baseline = true)] //ana method olduğunu belirtme
    public void GetAll()
    {
        AppDbContext context = new();
        context.Products.ToList();
    }
    [Benchmark]
    public void GetAllSqlRaw()
    {
        AppDbContext context = new();
        context.Products.FromSqlRaw("Select * From Products").ToList();
    }
}
