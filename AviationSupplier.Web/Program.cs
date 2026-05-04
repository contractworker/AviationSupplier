using AviationSupplier.Web.Data.Dapper;
using AviationSupplier.Web.Data.Repositories;
using AviationSupplier.Web.Services;
using AviationSupplier.Web.ViewModel.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CustomerProfile>();
});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CustomerAddressProfile>();
});

builder.Services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ILookupRepository, LookupRepository>();

builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

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
