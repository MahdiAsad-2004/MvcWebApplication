using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class CommentListDto : BaseListDto<long>
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public PersianDateTime Date { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
    }




}
