using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.AddressDtos;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UserProfileDto : BaseListDto<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsEmailVerified { get; set; }
        public Role Role { get; set; }
        public string ProfileImage { get; set; }
        public AddressListDto[] Addresses { get; set; }
        public BankCard[] BankCards { get; set; }


        public ICollection<Order> Orders { get; set; }


     
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    }





}
