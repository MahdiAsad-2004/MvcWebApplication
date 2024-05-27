using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;

namespace OrganicShop.DAL.Repositories
{
    public class DeliveryRepository : CrudRepository<Delivery, byte>, IDeliveryRepository
    {
        public DeliveryRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
