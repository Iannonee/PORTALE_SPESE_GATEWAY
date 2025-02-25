using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi il file di configurazione di Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Registra Ocelot
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

// Usa Ocelot come middleware
await app.UseOcelot();

app.Run();