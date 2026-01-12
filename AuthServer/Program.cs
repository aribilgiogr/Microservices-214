using AuthServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer()
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddDeveloperSigningCredential();

var app = builder.Build();

// IdentityServer Middleware'ini çalıştırma.
app.UseIdentityServer();

app.MapGet("/", () => "Hello World!");

app.Run();
