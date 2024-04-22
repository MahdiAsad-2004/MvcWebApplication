using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class PermissionListDto : BaseListDto<byte>
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public string? ParentTitle { get; set; }
    }


}
