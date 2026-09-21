using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PixelPion.Api.Data;
using PixelPion.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAbonneRepository, AbonneRepository>();
builder.Services.AddScoped<IJeuRepository, JeuRepository>();
builder.Services.AddScoped<IEmpruntRepository, EmpruntRepository>();

builder.Services.AddScoped<ICatalogueService, CatalogueService>();
builder.Services.AddScoped<IEmpruntService, EmpruntService>();
builder.Services.AddScoped<ICompteClientService, CompteClientService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    await DbSeeder.SeedAsync(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

public partial class Program
{
}
