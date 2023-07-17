using BenchmarkDotNet.Running;

namespace Benchmark.ConsoleApp;

internal class Program
{
    //Debug -> Release
    //Debug tool-> Start Without Debugging

    //uygulamalarda performans ölçmemizi sağlayan bir yöntem. Derlenmiş bir uygulama değil; çalışabilir, canlıya alınabilecek bir uygulamada denemek gerekiyor
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        BenchmarkRunner.Run<BenchmarkService>();
    }
}