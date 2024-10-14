namespace ExampleStore.src.Infra.EntityFramework.Configuration;

public static class DbSeederExtension
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ProductDb>();
            DbSeeder.Seed(context);
        }
        catch (Exception e)
        {
            Console.WriteLine("Seed error: " + e);
        }
        
        return app;
    }
}