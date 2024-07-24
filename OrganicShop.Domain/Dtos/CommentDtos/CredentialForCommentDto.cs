using MD.PersianDateTime;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;

namespace OrganicShop.Domain.Dtos.CommentDtos
{
    public class CredentialForCommentDto : BaseDto
    {
        public string AuthorName { get; set; }

        public string Email { get; set; }
    
    }


}
