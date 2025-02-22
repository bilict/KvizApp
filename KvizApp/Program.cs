using KvizApp.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Build the application.
var app = builder.Build();

//cookies
builder.Services.AddAuthentication("Cookies")
    .AddCookie();
    

// Configure middleware.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // Keep HSTS for security
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();


// Configure endpoints in the proper order.
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        endpoints.MapControllers();
        endpoints.MapRazorPages();

        // For Blazor Components
        endpoints.MapRazorComponents<KvizApp.Components.App>()

            .AddInteractiveServerRenderMode();
    });

app.Run();