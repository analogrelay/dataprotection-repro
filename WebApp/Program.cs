var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var env = app.Services.GetRequiredService<IHostEnvironment>();
Console.WriteLine($"The Content Root is: {env.ContentRootPath}");

app.MapGet("/", () => "Hello World!");

app.Run();
