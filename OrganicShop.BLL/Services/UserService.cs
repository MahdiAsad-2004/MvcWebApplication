using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using OrganicShop.BLL.Extensions;
using OrganicShop.Domain.Dtos.TagDtos;
using OrganicShop.Domain.Dtos.WishItemDtos;

namespace OrganicShop.BLL.Services
{
    public class UserService : Service<User>, IUserService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _ProductRepository;
        public UserService(IApplicationUserProvider provider, IMapper mapper, IUserRepository userRepository,IProductRepository productRepository) : base(provider)
        {
            _Mapper = mapper;
            _userRepository = userRepository;
            _ProductRepository = productRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<User, UserListDto, long>>> GetAll(FilterUserDto? filter = null,PagingDto? paging = null)
        {
            var query = _userRepository.GetQueryable()
                .Include(a => a.Picture)
                .AsQueryable();

            if (filter == null) filter = new FilterUserDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Name != null)
                query = query.Where(a => EF.Functions.Like(a.Name, $"%{filter.Name}%"));

            if (filter.PhoneNumber != null)
                query = query.Where(a => EF.Functions.Like(a.PhoneNumber, $"%{filter.PhoneNumber}%"));

            if (filter.Email != null)
                query = query.Where(a => EF.Functions.Like(a.Email, $"%{filter.Email}%"));

            if(filter.Role != null)
                query = query.Where(a => a.Role == filter.Role);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<User, UserListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<UserListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            await Console.Out.WriteLineAsync($"************** {_AppUserProvider.User.Id}  {_AppUserProvider.User.UserName} ***************");

            return new ServiceResponse<PageDto<User, UserListDto, long>>(ResponseResult.Success,pageDto);
        }


        public async Task<UserListDto?> Get(long id)
        {
            var user = await _userRepository.GetAsNoTracking(id);
            UserListDto? userListDto = null;
            if(user != null)
            {
                userListDto = _Mapper.Map<UserListDto>(user);
            }
            return userListDto;
        }



        public async Task<ServiceResponse<Empty>> Create(CreateUserDto create)
        {
            if (await _userRepository.GetQueryable().AnyAsync(a => a.PhoneNumber == create.PhoneNumber))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create,a => nameof(a.PhoneNumber)));

            if (await _userRepository.GetQueryable().AnyAsync(a => a.Email == create.Email))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Email)));

            User user = _Mapper.Map<User>(create);
            
            if(HasPermission(a => a.Giving_Permission))
            {
                foreach (var permissionId in create.Permissions)
                {
                    user.PermissionUsers.Add(new PermissionUsers() { PermissionId = (byte)permissionId , BaseEntity = new BaseEntity(true) });
                }
            }

            user.Picture = create.ProfileImage != null ? await create.ProfileImage.SavePictureAsync(PathKey.UserImages , PictureType.User) : null;

            await _userRepository.Add(user,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateUserDto update)
        {
            //if (await _userRepository.GetQueryable().AnyAsync(a => a.Id != update.Id && a.Email == update.Email))
            //    return new ServiceResponse<Empty>(ResponseResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Email)));

            User? user = await _userRepository.GetAsTracking(update.Id);
            
            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if(update.ProfileImage != null) 
            {
                if(user.Picture != null)
                    user.Picture =  await update.ProfileImage.SavePictureAsync(user.Picture,PathKey.UserImages );
                else 
                    user.Picture =  await update.ProfileImage.SavePictureAsync(PathKey.UserImages ,PictureType.User);
            }
            await _userRepository.Update(_Mapper.Map<User>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            if(delete < 1)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            User? user = await _userRepository.GetAsTracking(delete);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _userRepository.SoftDelete(user, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<Empty>> ChangePassword(ChangePasswordDto changePassword)
        {
            User? user = await _userRepository.GetAsNoTracking(changePassword.Id);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (user.Password != changePassword.Password)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "رمز عبور نادرست است");

            user = await _userRepository.GetAsTracking(changePassword.Id);
            user!.Password = changePassword.NewPassword;
            await _userRepository.Update(user, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, "رمز عبور با موفقیت تغییر یافت");
        }



        public Task<bool> IsEmailExist(string email)
        {
            email = email.Trim().ToLower();
            return Task.FromResult(_userRepository.GetQueryable().Any(a => a.Email == email));
        }



        public Task<bool> IsPhoneNumberExist(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim().ToLower();
            return Task.FromResult(_userRepository.GetQueryable().Any(a => a.PhoneNumber == phoneNumber));
        }



        


      

    }


}
