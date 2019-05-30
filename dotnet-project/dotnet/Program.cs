using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace dotnet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(directory)
                .UseWebRoot(Path.Combine(directory, "public"))
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
