using Microsoft.EntityFrameworkCore;
using WisdomDev.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WisdomDevDbContext>(options =>
    options.UseSqlServer("Server=DiegoRomero\\SQLEXPRESS;Database=WisdomDevDB;Integrated Security=True;Persist Security Info=False;TrustServerCertificate=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
