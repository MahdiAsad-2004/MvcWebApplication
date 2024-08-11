using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Dtos.ProductItemDtos;
using OrganicShop.Domain.Entities;

namespace OrganicShop.Domain.Dtos.CartDtos
{
    public class CartDetailDto : BaseListDto<long>
    {
        public ProductItemListDto[] ProductItems { get; set; }
        public BillDto Bill { get; set; }
       

    }



}
