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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IApplicationUserProvider,ApplicationUserProvider>();

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

