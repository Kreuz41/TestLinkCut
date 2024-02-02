using LinkCutter.Database;
using Microsoft.EntityFrameworkCore;

namespace LinkCutter.Project.Extension;

public static class WebApplicationExtensions
{

    public static async Task<IApplicationBuilder> SetupDatabaseAsync(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var conn = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            await conn.Database.MigrateAsync();
            
            return app;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cannot setup database: {e.Message}");
            throw;
        }
    }
}