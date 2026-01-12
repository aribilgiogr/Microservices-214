using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin()
                                                .AllowAnyMethod()
                                                .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

await app.UseOcelot();

app.Run();
