using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.CategoryDtos
{
    public class CategoryListDto : BaseListDto<int>
    {
        public string Title { get; set; }
        public string IconClass { get; set; }
        public string IconColor { get; set; }
        public string Type { get; set; }
        public string ImageName { get; set; }
        public PersianDateTime CreateDate { get; set; }
        public string? ParentTitle { get; set; }
    }




}
