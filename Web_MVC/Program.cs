using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Web_MVC.Converters;
using Web_MVC.Models;
using Web_MVC.Services;
using Web_MVC.Services.Impl;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddJsonOptions(option =>
{
	option.JsonSerializerOptions.Converters.Add(new DateConverter());
}); ;
var connectString = builder.Configuration["Connection:DefaultString"];
builder.Services.AddDbContext<DatabaseContext>(option=> option.UseLazyLoadingProxies().UseSqlServer(connectString));
//builder.Services.AddControllers().AddJsonOptions(option =>
//{
//    option.JsonSerializerOptions.Converters.Add(new DateConverter());
//});

builder.Services.AddSession();
builder.Services.AddScoped<CategoryService, CategoryImpl>();
builder.Services.AddScoped<SupplierService, SupplierImpl>();
builder.Services.AddScoped<DiscountService, DiscountImpl>();
builder.Services.AddScoped<RoleService, RoleImpl>();
var app = builder.Build();
app.UseSession();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");
app.MapControllerRoute(name: "MyArea",pattern: "{area:exists}/{controller}/{action}/{id?}");
app.UseHttpsRedirection();
app.Run();
