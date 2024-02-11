using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.DTOs;
using Presentation.Services;
using Infrastructure.Entities;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services => 
{ 
    services.AddDbContext<LocalDatabaseContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Datalagring\turnin-database-assignment\Infrastructure\Data\local_db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<CategoryRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<OrderRepository>();
    services.AddScoped<OrderRowRepository>();
    services.AddScoped<AddressRepository>();

    services.AddScoped<ProductService>();
    services.AddScoped<OrderService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<MenuService>();
    services.AddScoped<OrderRowService>();

}).Build();

builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<MenuService>();

menuService.NavigationMenu();


Console.ReadKey();

