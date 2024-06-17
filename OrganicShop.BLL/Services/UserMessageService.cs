using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserMessageDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;
using OrganicShop.DAL.Repositories;
using OrganicShop.Domain.Dtos.Combo;
using FluentValidation;

namespace OrganicShop.BLL.Services
{
    public class UserMessageService : Service<UserMessage>, IUserMessageService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IUserMessageRepository _UserMessageRepository;
        private readonly IValidator<CreateUserMessageDto> _ValidatorCreateUserMessage;

        public UserMessageService(IApplicationUserProvider provider, IMapper mapper, IUserMessageRepository UserMessageRepository,
            IValidator<CreateUserMessageDto> validatorCreateUserMessage) : base(provider)
        {
            _Mapper = mapper;
            _UserMessageRepository = UserMessageRepository;
            _ValidatorCreateUserMessage = validatorCreateUserMessage;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<UserMessage, UserMessageListDto, int>>> GetAll(FilterUserMessageDto? filter = null,PagingDto? paging = null)
        {
            var query = _UserMessageRepository.GetQueryable()
                .Include(a => a.User)
                .AsQueryable();

            if (filter == null) filter = new FilterUserMessageDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Text != null)
                query = query.Where(q => EF.Functions.Like(q.Text, $"%{filter.Text}%"));

            if (filter.Email != null)
                query = query.Where(q => EF.Functions.Like(q.Email ?? q.User!.Email, $"%{filter.Email}%"));

            if (filter.PhoneNumber != null)
                query = query.Where(q => EF.Functions.Like(q.PhoneNumber ?? q.User!.PhoneNumber, $"%{filter.Text}%"));

            if (filter.Email != null)
                query = query.Where(q => EF.Functions.Like(q.Name ?? q.User!.Name, $"%{filter.UserName}%"));

            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);


            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<UserMessage, UserMessageListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<UserMessageListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<UserMessage, UserMessageListDto, int>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateUserMessageDto create)
        {
            var validationResult = await _ValidatorCreateUserMessage.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            UserMessage UserMessage = _Mapper.Map<UserMessage>(create);

            if(create.UserId > 0)
            {
                UserMessage.Email = null;
                UserMessage.PhoneNumber = null;
                UserMessage.Name = null;
            }

            await _UserMessageRepository.Add(UserMessage,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, "پیام شما با موفقیت ارسال شد");
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            UserMessage? UserMessage = await _UserMessageRepository.GetAsTracking(delete);

            if (UserMessage == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _UserMessageRepository.SoftDelete(UserMessage, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



    }
}
