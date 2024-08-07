﻿using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Dtos.OrderDtos;
using MD.PersianDateTime;
using OrganicShop.Domain.Entities.ComplexTypes;


namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class UserProfileDto : BaseListDto<long>
    {
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public Gender? Gender { get; set; }
        //public PersianDateTime? BirthDate { get; set; }
        
        //public string Password { get; set; }
        //public string PhoneNumber { get; set; }
        //public bool IsEmailVerified { get; set; } 
        //public PersianDateTime RegisterDate { get; set; }


        public UpdateUserPrivacyDto UpdatePrivacy { get; set; }
        public UpdateUserDto UpdateUser { get; set; }

        public Role Role { get; set; }
        public string ProfileImage { get; set; }
        public AddressListDto[] Addresses { get; set; }
        public BankCardListDto[] BankCards { get; set; }
        public OrderListDto[] Orders { get; set; }

  
    
    
    
    
    }





}
