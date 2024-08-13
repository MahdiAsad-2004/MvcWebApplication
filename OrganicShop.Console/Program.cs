// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;

Console.WriteLine("Hello, World!");

DbContextOptions<OrganicShopDbContext> dbContextOptions = new DbContextOptions<OrganicShopDbContext>()
{
    
};



OrganicShopDbContext dbContext = new OrganicShopDbContext(dbContextOptions);



string query = """

    Select Distinct Products.Id As "ProdutcId",Products.Title As "ProductTitle",Products.Price As "ProductPrice",DiscountProducts.ProductId , DiscountProducts.DiscountId,
    	D.Price As "DiscountPrice",D.[Percent] As "DiscountPercent" ,D.[Priority] As "DiscountPriority",
    	dbo.CalculateDiscounterPrice(Products.Price , D.Price , D.[Percent]) As "CalcDiscountedPrice" 
    	From Products
    Left Join DiscountProducts On Products.Id = DiscountProducts.ProductId
    Left Join (Select * From GetValidDiscounts()) As D On DiscountProducts.DiscountId = D.Id
    Order By Products.Id , D.[Priority]    

    """;

string x = "Select [Produtcs].[Id] From Products";

//var queryable = dbContext.Products.FromSqlRaw(x);

Console.WriteLine(dbContext.Products.FromSqlRaw(x).ToQueryString());

Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");

Console.WriteLine(dbContext.Products.FromSqlRaw("Select * From Products").ToQueryString());

//var result = await queryable.ToListAsync();

Console.WriteLine("\n----------------------------------------------------------------------------------------------------\n");


string a = """

    SELECT [o].[Id], [o].[Barcode], [o].[Description], [o].[DiscountedPrice], [o].[Price], [o].[SellerId], [o].[ShortDescription],
    [o].[SoldCount], [o].[Stock], [o].[Title], [p].[Id], [p].[BaseEntity_CreateDate], [p].[BaseEntity_DeleteDate], [p].[BaseEntity_IsActive],
    [p].[BaseEntity_IsDelete], [p].[BaseEntity_LastModified]
    From [Products] as [o]

    """;


Console.WriteLine(dbContext.Database.SqlQueryRaw<Product>(a, new { })
    .Include(a => a.BaseEntity)
    .ToQueryString());


Console.WriteLine();

Console.WriteLine();

