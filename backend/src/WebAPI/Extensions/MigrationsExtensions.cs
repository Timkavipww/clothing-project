namespace WebAPI.Extensions;

public static class MigrationsExtensions
{
    public static async Task<IApplicationBuilder> ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using ClothingDbContext dbContext = 
            scope.ServiceProvider.GetRequiredService<ClothingDbContext>();

        await dbContext.Database.MigrateAsync();

        return app;     
    }
}
