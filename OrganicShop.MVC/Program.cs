//using StructureMap.TypeRules;
using OrganicShop.Domain;
using DryIoc;
using DryIoc.Microsoft.DependencyInjection;
using OrganicShop.Ioc;
using OrganicShop.BLL.Services;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Mvc.Middlewares;
using OrganicShop.BLL.Providers;
using OrganicShop.Domain.IProviders;
using OrganicShop.Mvc.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using OrganicShop.DAL.Context;
using Microsoft.Extensions.Configuration;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SqlServer;
using OrganicShop.BLL.Services.BackgroundServices;
using System.Configuration;
using OrganicShop.BLL.Utils;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using OrganicShop.DAL.SeedDatas;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System.Diagnostics;
using OrganicShop.BLL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<ITestServ, TestServ>();

builder.Services.AddSingleton<IApplicationUserProvider, ApplicationUserProvider>();

builder.Services.Configure<AesKeys>(builder.Configuration.GetSection("AesKeys"));
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));

//builder.Services.AddHangfire(c => c.UseMemoryStorage(new MemoryStorageOptions { }));
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("OrganicShopConnectionString")));
builder.Services.AddHangfireServer();

builder.Services.AddHostedService<NewsLetterSenderServiceBackground>();

RegisterServices(builder.Services);


#region config DbContex

builder.Services.AddDbContext<OrganicShopDbContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("OrganicShopConnectionString"),
    //options.UseSqlServer(connectionString: "Server=.;Database=OrganicShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    //options.UseSqlServer(connectionString: "Server=.;Database=OrganicShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True",
    sqlServerOptions => sqlServerOptions.CommandTimeout(6000));

    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion

//builder.Services.AddValidatorsFromAssemblyContaining<>()


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var dbContext = app.Services.GetRequiredService<OrganicShopDbContext>();
Console.WriteLine($"Database Can Connect: {dbContext.Database.CanConnect()}");
if (dbContext.Database.CanConnect() == false)
{
    Console.WriteLine("migrating database");
    await dbContext.Database.MigrateAsync();
}
var productTableRowCount = await dbContext.Products.LongCountAsync();
var categoryTableRowCount = await dbContext.Categories.CountAsync();
var UserTableCustomerRowCount = await dbContext.Users.CountAsync(a => (int)a.Role == (int)Role.Customer);
Console.WriteLine($"Category Table Row Count: {categoryTableRowCount}");
Console.WriteLine($"Product Table Row Count: {productTableRowCount}");
Console.WriteLine($"User(Customer) Table Row Count: {UserTableCustomerRowCount}");
if (categoryTableRowCount < 1)
{
    Console.WriteLine("seedign categories with products");
    await dbContext.Categories.AddRangeAsync(CategorySeed.Categories);
    await dbContext.SaveChangesAsync();
}
if(UserTableCustomerRowCount < 1)
{
    Console.WriteLine("seedign users(customers)");
    await dbContext.Users.AddRangeAsync(UserSeed.RandomUsers());
    await dbContext.SaveChangesAsync();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ApplicationUserProviderMiddleware>(app);



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



#region add Ioc

void RegisterServices(IServiceCollection services)
{
    builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory(InversionOfControl.GetContainer()))
         .ConfigureContainer<Container>(builder => { });
}


//void RegisterServices(IServiceCollection services)
//{
//    builder.Host.UseServiceProviderFactory(new DryIocServiceProviderFactory(DryIocAdapter.WithDependencyInjectionAdapter(InversionOfControl.GetContainer())))
//         .ConfigureContainer<Container>(builder => { });
//}


#endregion



app.Run();

