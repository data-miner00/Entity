namespace Entity.Blazor;

using Entity.Blazor.Services;
using Entity.Console.Data;
using Entity.Console.Repositories;

/// <summary>
/// The main program.
/// </summary>
public static class Program
{
    /// <summary>
    /// The starting point.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddScoped<UserRepository>();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapBlazorHub();
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
