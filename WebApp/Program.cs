using Microsoft.AspNetCore;
using Microsoft.AspNetCore.DataProtection.Infrastructure;

var builder = WebHost.CreateDefaultBuilder()
    .UseStartup<Startup>();
var app = builder.Build();

app.Run();


public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDataProtection();
    }
    
    public void Configure(IApplicationDiscriminator discriminator)
    {
        Console.WriteLine("App Discriminator: " + discriminator.Discriminator);
    }
}
