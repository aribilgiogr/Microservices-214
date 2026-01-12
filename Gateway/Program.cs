using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddJwtBearer("IdentityApiKey", opt =>
    {
        // AuthServer Adresi
        opt.Authority = "https://localhost:4999";
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        opt.RequireHttpsMetadata = false; // Development ortamı için false verdik.
    });

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
