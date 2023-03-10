using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using RedisMvcApp.Configuration;
using RedisMvcApp.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddStackExchangeRedis(options =>
{
    options.Servers = "192.168.2.33";
});

builder.Services.AddDbContext<AppDbContext>(
    opt =>
    {
        opt.UseNpgsql(builder.Configuration.GetConnectionString("ProductContext"));
        opt.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();// add this line

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
