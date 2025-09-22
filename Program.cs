using Anana_Restaurant.Models;
using Anana_Restaurant.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var mongoDBSettings = builder.Configuration.GetSection("Anana_MongoDBSetting").Get<Anana_MongoDBSetting>();
builder.Services.Configure<Anana_MongoDBSetting>(builder.Configuration.GetSection("Anana_MongoDBSetting"));

builder.Services.AddDbContext<Anana_RestaurantReservationDbContext>(options =>
options.UseMongoDB(mongoDBSettings.AtlasURI ?? "", mongoDBSettings.DatabaseName ?? ""));

builder.Services.AddScoped<RestaurantService, RestaurantService>();
builder.Services.AddScoped<ReservationService, ReservationService>();


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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Anana_Restaurant}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
