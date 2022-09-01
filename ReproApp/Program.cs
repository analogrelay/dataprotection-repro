using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var keysDirectory = Path.Combine(Directory.GetCurrentDirectory(), ".keys");
Directory.CreateDirectory(keysDirectory);
var builder = new HostBuilder();
builder.ConfigureServices(services =>
{
    services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(keysDirectory));
});

using var host = builder.Build();

await host.StartAsync();

var protectionProvider = host.Services.GetRequiredService<IDataProtectionProvider>();
var protector = protectionProvider.CreateProtector("nonsense");

if(args[0] == "protect")
{
    var protectedPayload = protector.Protect(args[1]);
    Console.WriteLine(protectedPayload);
}
else if(args[0] == "unprotect")
{
    var unprotectedPayload = protector.Unprotect(args[1]);
    Console.WriteLine(unprotectedPayload);
}