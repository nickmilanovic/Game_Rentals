using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using assignment1.Data;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<assignment1Context>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("assignment1Context") ?? throw new InvalidOperationException("Connection string 'assignment1Context' not found.")));
builder.Services.AddDbContext<assignment1Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("assignment1Context") ?? throw new InvalidOperationException("Connection string 'assignment1Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePages();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/CustomNotFound";
        await next();
    }
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
