using Xibix.Services;

namespace Xibix;

/// <summary>
/// The Main function can be used to run the ASP.NET Core application locally using the Kestrel webserver.
/// </summary>
public class LocalEntryPoint
{
    public static void Main(string[] args)
    {
        if(args.Length >= 2 && args.Any(arg => arg.Contains(".json"))) {
            var jsonPath = args[0];
            var amountOfSpots = int.Parse(args[1]);
            PathFinder.WritePathToConsole(jsonPath, amountOfSpots);
        }
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}