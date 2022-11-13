using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AppWebMvcSales.Data;
using AppWebMvcSales.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppWebMvcSalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppWebMvcSalesContext") ?? throw new InvalidOperationException("Connection string 'AppWebMvcSalesContext' not found.")));

builder.Services.AddScoped<DepartamentService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<SelesRecordService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

