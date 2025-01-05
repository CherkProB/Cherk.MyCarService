using Microsoft.AspNetCore;

namespace Cherk.MyCarService;

public static class Program
{
    public static void Main(string[] args) =>
        CreateWebHostBuilder(args)
            .Build()
            .Run();

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseKestrel();

}