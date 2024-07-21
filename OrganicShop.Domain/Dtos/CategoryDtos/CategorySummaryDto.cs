using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class CategorySummaryDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string IconClass { get; set; }
        public string IconColor { get; set; }
        public string Type { get; set; }
        public string ImageName { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public int? ParentId { get; set; }
        public int ProductsCount { get; set; }
        public int ArticlesCount { get; set; }

        //public string? ParentTitle { get; set; }


    }




}
