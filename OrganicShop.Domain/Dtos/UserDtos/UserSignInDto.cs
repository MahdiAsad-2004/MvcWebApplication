
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UserSignInDto : BaseDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public long Id { get; set; }


    }


}
