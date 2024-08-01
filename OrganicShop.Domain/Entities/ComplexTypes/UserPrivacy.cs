using OrganicShop.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Domain.Entities.ComplexTypes
{
    [ComplexType]
    public class UserPrivacy
    {
        public bool IsProfileImageVisible { get; set; }
        public bool IsEmailVisible { get; set; }
        public bool DeleteAccountAfterLogOut { get; set; }


    }


}
