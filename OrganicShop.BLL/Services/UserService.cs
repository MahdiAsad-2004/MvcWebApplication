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
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using OrganicShop.Domain.Dtos.PictureDtos;
using Microsoft.AspNetCore.Identity;
using OrganicShop.BLL.Utils;
using OrganicShop.BLL.Providers;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace OrganicShop.BLL.Services
{
    public class UserService : Service<User>, IUserService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IUserRepository _userRepository;
        private readonly AesKeys _AesKeys;
        private readonly IEmailSenderService _EmailSenderService;
        private readonly IPictureRepository _PictureRepository;
        private readonly IValidator<CreateUserDto> _ValidatorCreateUser;
        private readonly IValidator<UpdateUserDto> _ValidatorUpdateUser;
        private readonly IValidator<ChangePasswordDto> _ValidatorChangePassword;
        public UserService(IApplicationUserProvider provider, IMapper mapper, IUserRepository userRepository,
            IValidator<CreateUserDto> validator1CreateUser, IValidator<UpdateUserDto> validator1UpdateUser, IOptions<AesKeys> aesKeys,
            IValidator<ChangePasswordDto> validatorChangePassword, IPictureRepository pictureRepository, IEmailSenderService emailSenderService) : base(provider)
        {
            _Mapper = mapper;
            _userRepository = userRepository;
            _ValidatorCreateUser = validator1CreateUser;
            _ValidatorUpdateUser = validator1UpdateUser;
            _ValidatorChangePassword = validatorChangePassword;
            _PictureRepository = pictureRepository;
            _EmailSenderService = emailSenderService;
            _AesKeys = aesKeys.Value;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<User, UserListDto, long>>> GetAll(FilterUserDto? filter = null, PagingDto? paging = null)
        {
            var query = _userRepository.GetQueryable()
                .Include(a => a.Picture)
                .AsQueryable();

            if (filter == null) filter = new FilterUserDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Name != null)
                query = query.Where(a => EF.Functions.Like(a.Name, $"%{filter.Name}%"));

            if (filter.PhoneNumber != null)
                query = query.Where(a => EF.Functions.Like(a.PhoneNumber, $"%{filter.PhoneNumber}%"));

            if (filter.Email != null)
                query = query.Where(a => EF.Functions.Like(a.Email, $"%{filter.Email}%"));

            if (filter.Role != null)
                query = query.Where(a => a.Role == filter.Role);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<User, UserListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<UserListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            await Console.Out.WriteLineAsync($"************** {_AppUserProvider.User.Id}  {_AppUserProvider.User.UserName} ***************");

            return new ServiceResponse<PageDto<User, UserListDto, long>>(ResponseResult.Success, pageDto);
        }


        public async Task<UserListDto?> Get(long id)
        {
            var user = await _userRepository.GetAsNoTracking(id);
            UserListDto? userListDto = null;
            if (user != null)
            {
                userListDto = _Mapper.Map<UserListDto>(user);
            }
            return userListDto;
        }


        public async Task<ServiceResponse<UpdateUserDto>> GetUpdate(long Id)
        {
            var user = await _userRepository.GetQueryable()
                .FirstOrDefaultAsync(a => a.Id == Id);

            if (user == null)
                return new ServiceResponse<UpdateUserDto>(ResponseResult.NotFound, " کاربری مورد نظر یافت نشد");

            return new ServiceResponse<UpdateUserDto>(ResponseResult.Success, _Mapper.Map<UpdateUserDto>(user));
        }


        public async Task<ServiceResponse<UserProfileDto>> GetProfile()
        {
            var user = await _userRepository.GetQueryable()
                .Include(a => a.Addresses)
                .Include(a => a.BankCards)
                .Include(a => a.Orders)
                .Include(a => a.Picture)
                .FirstOrDefaultAsync(a => a.Id == _AppUserProvider.User.Id);

            if (user == null)
                return new ServiceResponse<UserProfileDto>(ResponseResult.NotFound, "پروفایل کاربری شما یافت نشد");

            return new ServiceResponse<UserProfileDto>(ResponseResult.Success, _Mapper.Map<UserProfileDto>(user));
        }



        public async Task<ServiceResponse<long>> Create(CreateUserDto create)
        {
            var validationResult = await _ValidatorCreateUser.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<long>(create, validationResult);

            if (await _userRepository.GetQueryable().AnyAsync(a => a.PhoneNumber == create.PhoneNumber))
                return new ServiceResponse<long>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.PhoneNumber)));

            if (await _userRepository.GetQueryable().AnyAsync(a => a.Email == create.Email))
                return new ServiceResponse<long>(ResponseResult.Failed, _Message.EntityExist(create, a => nameof(a.Email)));

            User user = _Mapper.Map<User>(create);

            if (HasPermission(a => a.Giving_Permission))
            {
                foreach (var permissionId in create.Permissions)
                {
                    user.PermissionUsers.Add(new PermissionUsers() { PermissionId = (byte)permissionId, BaseEntity = new BaseEntity(true) });
                }
            }

            user.Picture = create.ProfileImage != null ? await create.ProfileImage.SavePictureAsync(PathKey.UserImages, PictureType.User) : null;
            user.Password = create.Password.ToSha256String();

            var userId = await _userRepository.Add(user, _AppUserProvider.User.Id);
            return new ServiceResponse<long>(ResponseResult.Success, _Message.SuccessCreate(), data: userId);
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateUserDto update)
        {
            var validationResult = await _ValidatorUpdateUser.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            //if (await _userRepository.GetQueryable().AnyAsync(a => a.Id != update.Id && a.Email == update.Email))
            //    return new ServiceResponse<Empty>(ResponseResult.EntityExist, _Message.EntityExist(update, a => nameof(a.Email)));

            User? user = await _userRepository.GetAsTracking(update.Id);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            var x = _Mapper.Map(update, user);

            await _userRepository.Update(_Mapper.Map(update, user), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }

        public async Task<ServiceResponse<Empty>> UpdateProfileImage(UpdateProfileImageDto updateImage)
        {
            // validate object

            var oldPicture = await _PictureRepository.GetQueryableTracking()
                .FirstOrDefaultAsync(a => a.UserId == updateImage.UserId);

            if (oldPicture != null)
            {
                oldPicture.UserId = null;
                await _PictureRepository.Update(oldPicture, _AppUserProvider.User.Id);
            }

            var newPicture = await updateImage.ImageFile.SavePictureAsync(PathKey.UserImages, PictureType.User);
            newPicture.UserId = updateImage.UserId;
            await _PictureRepository.Add(newPicture, _AppUserProvider.User.Id);

            return new ServiceResponse<Empty>(ResponseResult.Success, "تصویر پروفایل شما با موفقیت ویرایش شد");
        }


        public async Task<ServiceResponse<Empty>> UpdatePrivacy(UpdateUserPrivacyDto updatePrivacy)
        {
            if (updatePrivacy.UserId != _AppUserProvider.User.Id)
                return new ServiceResponse<Empty>(ResponseResult.NoAccess);

            User? user = await _userRepository.GetAsTracking(updatePrivacy.UserId);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _userRepository.Update(_Mapper.Map<User>(updatePrivacy), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(long delete)
        {
            if (delete < 1)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            User? user = await _userRepository.GetAsTracking(delete);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _userRepository.SoftDelete(user, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<Empty>> ChangePassword(ChangePasswordDto changePassword)
        {
            //if (changePassword.UserId != _AppUserProvider.User.Id)
            //    return new ServiceResponse<Empty>(ResponseResult.NoAccess);

            var validationResult = await _ValidatorChangePassword.ValidateAsync(changePassword);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(changePassword, validationResult);

            User? user = await _userRepository.GetAsTracking(changePassword.UserId);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (user.Password != changePassword.Password.ToSha256String())
                return new ServiceResponse<Empty>(ResponseResult.Failed, "رمز عبور نادرست است");

            user!.Password = changePassword.NewPassword.ToSha256String();
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





        public async Task<ServiceResponse<UserSignInDto>> SignIn(SignInUserDto signInUser)
        {
            User? user = null;
            bool isSignInWithEmail = false;

            if (signInUser.PhoneNumberOrEmail.Contains('@') || signInUser.PhoneNumberOrEmail.Contains('.'))
            {
                isSignInWithEmail = true;
                user = await _userRepository.GetQueryable()
                    .FirstOrDefaultAsync(a => a.Email == signInUser.PhoneNumberOrEmail && a.Password == signInUser.Password.ToSha256String());
            }
            else
            {
                user = await _userRepository.GetQueryable()
                    .FirstOrDefaultAsync(a => a.PhoneNumber == signInUser.PhoneNumberOrEmail && a.Password == signInUser.Password.ToSha256String());
            }


            if (user == null)
            {
                if (isSignInWithEmail)
                    return new ServiceResponse<UserSignInDto>(ResponseResult.Failed, "ایمیل یا رمز عبور وارد شده نادرست است");

                return new ServiceResponse<UserSignInDto>(ResponseResult.Failed, "شماره همراه یا رمز عبور وارد شده نادرست است");
            }

            return new ServiceResponse<UserSignInDto>(ResponseResult.Success, "شما با موفقیت وارد شدید",
                new UserSignInDto
                {
                    Email = user.Email,
                    Id = user.Id,
                    Role = user.Role,
                    Name = user.Name,
                    PhoneNumber = user.PhoneNumber,

                });

        }












        public async Task<ServiceResponse<Empty>> SendEmailVerification()
        {
            User? user = await _userRepository.GetAsTracking(_AppUserProvider.User.Id);

            if (user == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, "حساب کاربری شما یافت نشد");

            if (user.IsEmailVerified)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "ایمیل شما قبلا تایید شده است");

            if (user.EmailVerificationSendDate != null)
            {
                int minutesPassedFromLastSend = (DateTime.Now - user.EmailVerificationSendDate.Value).Minutes;
                minutesPassedFromLastSend = minutesPassedFromLastSend == 0 ? 1 : minutesPassedFromLastSend;
                if (minutesPassedFromLastSend < 30 && minutesPassedFromLastSend > 0)
                    return new ServiceResponse<Empty>(ResponseResult.Failed, $"ایمیل فعالسازی {minutesPassedFromLastSend} دقیقه قبل برای شما ارسال شده است");
            }

            VerifyEmailToken verifyEmailToken = new VerifyEmailToken
            {
                UserId = user.Id,
                Email = user.Email,
                ExpireDate = DateTime.Now.AddMinutes(30),
            };

            var token = AesOperation.Encrypt(JsonSerializer.Serialize(verifyEmailToken), _AesKeys.VerficationEmail);

            string url = $"https://localhost:7196/user/email-verification?Token={TextExtensions.EncodeUrlString(token)}";

            var x = VerifyEmailToken.GetVerifyEmailToken(AesOperation.Decrypt(token, _AesKeys.VerficationEmail));
            
            VerifyEmailTemplate verifyEmailTemplate = new VerifyEmailTemplate(user.Name, url);
            string htmlBody = await verifyEmailTemplate.GetHtml();

            if (await _EmailSenderService.Send(user.Email, "ارگانیک شاپ : تایید ایمیل", htmlBody))
            {
                user.EmailVerificationSendDate = DateTime.Now;
                await _userRepository.Update(user, _AppUserProvider.User.Id);
                return new ServiceResponse<Empty>(ResponseResult.Success , "ایمیل فعالسازی با موفقیت برای شما ارسال شد");
            }

            return new ServiceResponse<Empty>(ResponseResult.Failed, "ارسال ایمیل با مشکل مواجه شد");
        }





        public async Task<ServiceResponse<EmailVerificationDto>> VeifyEmail(string cryptedToken)
        {
            //cryptedToken = TextExtensions.DecodeUrlString(cryptedToken);
            VerifyEmailToken? verifyEmailToken = VerifyEmailToken.GetVerifyEmailToken(AesOperation.Decrypt(cryptedToken, _AesKeys.VerficationEmail));

            if (verifyEmailToken == null)
                return new ServiceResponse<EmailVerificationDto>(ResponseResult.Failed, new EmailVerificationDto(false, "توکن ارسال شده نادرست است"));

            if (verifyEmailToken.ExpireDate < DateTime.Now)
                return new ServiceResponse<EmailVerificationDto>(ResponseResult.Failed, new EmailVerificationDto(false, "انقضای توکن به پایان رسیده است"));

            User? user = await _userRepository.GetAsTracking(verifyEmailToken.UserId);

            if (user == null)
                return new ServiceResponse<EmailVerificationDto>(ResponseResult.Failed, new EmailVerificationDto(false, "حساب کاربری شما یافت نشد"));

            if (user.Email != verifyEmailToken.Email)
                return new ServiceResponse<EmailVerificationDto>(ResponseResult.Failed, new EmailVerificationDto(false, "ایمیل شما نامعتبر است"));

            user.IsEmailVerified = true;
            await _userRepository.Update(user, _AppUserProvider.User.Id);

            return new ServiceResponse<EmailVerificationDto>(ResponseResult.Success, new EmailVerificationDto(true, "ایمیل شما با موفقیت تایید شد"));
        }







    }


}
