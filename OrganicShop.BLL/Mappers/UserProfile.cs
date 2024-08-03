using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Dtos.UserDtos;
using AutoMapper;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.BLL.Extensions;
using DryIoc;
using OrganicShop.Domain.Entities.ComplexTypes;
using MD.PersianDateTime;

namespace OrganicShop.BLL.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {

            CreateMap<User, UserListDto>()
                //.ForMember(m => m.Addresses, a => a.MapFrom(b => b.Addresses != null ? b.Addresses : new List<Address>()))
                .ForMember(m => m.ProfileImage, a => a.MapFrom(b => b.Picture != null ? b.Picture.Name : "user.png"));


            CreateMap<User, UserProfileDto>()
                .ForMember(m => m.UpdateUser, a => a.MapFrom(b => b.ToUpdateDto()))
                .ForMember(m => m.UpdatePrivacy, a => a.MapFrom(b => b.ToUpdatePrivacyDto()))
                .ForMember(m => m.Addresses, a => a.MapFrom(b => b.Addresses.Select(a => a.ToListDto()).ToArray()))
                .ForMember(m => m.BankCards, a => a.MapFrom(b => b.BankCards.Select(a => a.ToListDto()).ToArray()))
                .ForMember(m => m.Orders, a => a.MapFrom(b => b.Orders.Select(a => a.ToListDto()).ToArray()))
                .ForMember(m => m.ProfileImage, a => a.MapFrom(b => b.Picture != null ? b.Picture.Name : PathExtensions.UserDefaultImage));


            CreateMap<CreateUserDto, User>()
                .ForMember(m => m.Email, a => a.AddTransform(b => b.ToLower()));


            CreateMap<UpdateUserDto, User>()
                .ForMember(m => m.BirthDate, a => a.MapFrom(b => b.BirthDate != null ? new PersianDateTime(b.BirthDate.Value.Year,b.BirthDate.Value.Month,b.BirthDate.Value.Day).ToDateTime() : default(DateTime?)))
                .ForMember(m => m.Email, a => a.AddTransform(b => b.ToLower()));
            
            
            CreateMap<User,UpdateUserDto>()
                .ForMember(m => m.RegisterDate_readonly, a => a.MapFrom(b => b.BaseEntity.CreateDate))
                .ForMember(m => m.PhoneNumber_readonly, a => a.MapFrom(b => b.PhoneNumber))
                .ForMember(m => m.IsEmailVerified_readonly, a => a.MapFrom(b => b.IsEmailVerified));


            CreateMap<UpdateUserPrivacyDto, User>()
             .ForPath(m => m.Privacy.DeleteAccountAfterLogOut, a => a.MapFrom(b => b.DeleteAccountAfterLogOut))
             .ForPath(m => m.Privacy.IsEmailVisible, a => a.MapFrom(b => b.IsEmailVisible))
             .ForPath(m => m.Privacy.IsProfileImageVisible, a => a.MapFrom(b => b.IsProfileImageVisible));

        }


    }

    public static class UserMappers
    {
        public static UpdateUserDto ToUpdateDto(this User user)
        {
            return new UpdateUserDto
            {
                BirthDate = user.BirthDate != null ? user.BirthDate.Value.ToPersianDate() : null,
                Email = user.Email,
                Gender = user.Gender,
                Id = user.Id,
                Name = user.Name,

               IsEmailVerified_readonly = user.IsEmailVerified,
                PhoneNumber_readonly = user.PhoneNumber,
                RegisterDate_readonly = user.BaseEntity.CreateDate.ToPersianDate(),

            };
        }
        public static UpdateUserPrivacyDto ToUpdatePrivacyDto(this User user)
        {
            return new UpdateUserPrivacyDto
            {
                UserId = user.Id,
                IsEmailVisible = user.Privacy.IsEmailVisible,
                IsProfileImageVisible = user.Privacy.IsProfileImageVisible,
                DeleteAccountAfterLogOut = user.Privacy.DeleteAccountAfterLogOut,
            };
        }


    }
}
