
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UserSignInDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }


    }


}
