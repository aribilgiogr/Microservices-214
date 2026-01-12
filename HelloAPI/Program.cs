var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Anonim nesne dönüşü yapılıyor.
app.MapGet("/", () => new { message = "Hello World!" });

app.Run();
