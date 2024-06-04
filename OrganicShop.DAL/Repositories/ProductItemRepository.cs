using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;


namespace OrganicShop.DAL.Repositories
{
    public class ProductItemRepository : CrudRepository<ProductItem, long>, IProductItemRepository
    {
        public ProductItemRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {

        }



        public async Task SetOrdered(long cartId,long orderId)
        {
            //await _dbSet.Where(a => a.CartId == cartId).ExecuteUpdateAsync(a => a.SetProperty(p => p.IsOrdered, true));
            //await _dbSet.Where(a => a.CartId == cartId).ExecuteUpdateAsync(a => a.SetProperty(p => p.OrderId, orderId));
            //await _dbSet.Where(a => a.CartId == cartId).ExecuteUpdateAsync(a => a.SetProperty(p => p.CartId, default(long?)));

            //await _context.Database.ExecuteSqlInterpolatedAsync($"UPDATE ProductItems SET IsOrdred = true, CartId = NULL , OrderId = {orderId} WHERE CartId = {cartId};");

            string x = $"BEGIN TRANSACTION;" +
                    
                    $"UPDATE Products SET Products.Stock -= ProductItems.Count" +
                    $"FROM Products , ProductItems" +
                    $"WHERE ProductItems.ProductVarientId IS NULL AND ProductItems.ProductId = Products.Id AND ProductItems.CartId = ${cartId};" +

                    $"UPDATE ProductVarients SET ProductVarients.Stock -= ProductItems.Count" +
                    $"FROM ProductVarients , ProductItems" +
                    $"WHERE ProductItems.ProductVarientId IS NOT NULL AND ProductItems.ProductVarientId = ProductVarients.Id AND ProdutcItems.CartId = ${cartId};" +

                    $"UPDATE ProductItems SET IsOrdred = true, CartId = NULL , OrderId = {orderId}," +
                    $"WHERE CartId = {cartId};" +
                    
                    $"COMMIT;";

            await _context.Database.ExecuteSqlRawAsync(x);

            await _context.SaveChangesAsync();

        }






        public async Task TransferFromNextCartToCart(long nextCartId, long cartId)
        {
            string command = $"UPDATE ProductItems SET NextCartId = ${cartId}" +
                             $"WHERE NextCartId = ${nextCartId}";

            await _context.Database.ExecuteSqlRawAsync(command);
            await _context.SaveChangesAsync();
        }






    }


}
