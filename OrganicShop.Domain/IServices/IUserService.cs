
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

        Task<ServiceResponse<Empty>> Create(CreateUserDto create);

        Task<ServiceResponse<Empty>> Update(UpdateUserDto update);
        
        Task<ServiceResponse<Empty>> Delete(long Id);

        Task<ServiceResponse<Empty>> ChangePassword(ChangePasswordDto changePassword);

        Task<bool> IsEmailExist(string email);

        Task<bool> IsPhoneNumberExist(string email);




    }
}
