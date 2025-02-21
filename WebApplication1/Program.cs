using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Data;
using Portfolio.Models;
using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EmailService>();

// Dynamically choose which connection string to use
var connectionStringName = Environment.GetEnvironmentVariable("USE_BACKUP_DB") ?? "DefaultConnection";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString(connectionStringName))
);

var app = builder.Build();

// Ensure database migrations are applied on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    // Log the connection string to ensure you're connecting to the right database
    var connectionString = context.Database.GetDbConnection().ConnectionString;
    Console.WriteLine($"Connecting to database: {connectionString}");

    // Apply migrations at startup
    context.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
