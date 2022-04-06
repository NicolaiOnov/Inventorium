using System.Text.Json.Serialization;
using Inventorium.Server.Database;
using Inventorium.Server.Services.DbInitializer;
using Microsoft.EntityFrameworkCore;

namespace Inventorium.Server;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder.WithOrigins("http://localhost:4200");
                });
        });

        builder.Services.AddMvc().AddJsonOptions(options =>
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        // Application-specific services
        builder.Services.AddDbContext<InventoriumDbContext>(options =>
            options.UseSqlServer("Server=LAPTOP-7EB7I4FT\\SQLEXPRESS;Database=InventoriumDb;Trusted_Connection=True;"));
        builder.Services.AddScoped<IDbInitializerService, DbInitializerService>();
        
        var app = builder.Build();

        if (args.Length > 0)
            RecreateDbAndSeed(app, bool.Parse(args[0]));

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

        static void RecreateDbAndSeed(IHost host, bool recreateDb)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var dbInitializer = services.GetRequiredService<IDbInitializerService>();
                dbInitializer.Initialize(recreateDb);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }
    }

}