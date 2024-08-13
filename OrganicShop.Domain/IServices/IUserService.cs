
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IUserService : IService<User>
    {
        Task<ServiceResponse<PageDto<User, UserListDto, long>>> GetAll(FilterUserDto? filter = null,PagingDto? paging = null);
        
        Task<UserListDto> Get(long id);

        Task<ServiceResponse<UpdateUserDto>> GetUpdate(long Id);

        Task<ServiceResponse<UserProfileDto>> GetProfile();

        Task<ServiceResponse<long>> Create(CreateUserDto create);

        Task<ServiceResponse<Empty>> Update(UpdateUserDto update);

        Task<ServiceResponse<Empty>> UpdatePrivacy(UpdateUserPrivacyDto updatePrivacy);

        Task<ServiceResponse<Empty>> UpdateProfileImage(UpdateProfileImageDto updateImage);

        Task<ServiceResponse<Empty>> Delete(long Id);

        Task<ServiceResponse<Empty>> ChangePassword(ChangePasswordDto changePassword);

        Task<bool> IsEmailExist(string email);

        Task<bool> IsPhoneNumberExist(string email);

        Task<ServiceResponse<UserSignInDto>> SignIn(SignInUserDto signInUser);

        Task<ServiceResponse<Empty>> SendEmailVerification();
        
        Task<ServiceResponse<EmailVerificationDto>> VeifyEmail(string cryptedToken);





    }
}
