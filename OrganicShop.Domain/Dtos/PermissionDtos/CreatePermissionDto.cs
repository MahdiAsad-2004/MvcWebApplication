using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.PermissionDtos
{
    public class CreatePermissionDto : BaseDto
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public byte? ParentId { get; set; }
    }


}
