using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.NewsLetterMemberDtos;
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
    public class NewsLetterMemberService : Service<NewsLetterMember>, INewsLetterMemberService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly INewsLetterMemberRepository _NewsLetterMemberRepository;
        private readonly IValidator<CreateNewsLetterMemberDto> _ValidatorCreateNewsLetterMember;
        private readonly IValidator<UpdateNewsLetterMemberDto> _ValidatorUpdateNewsLetterMember;

        public NewsLetterMemberService(IApplicationUserProvider provider, IMapper mapper, INewsLetterMemberRepository NewsLetterMemberRepository,
            IValidator<CreateNewsLetterMemberDto> validatorCreateNewsLetterMember, IValidator<UpdateNewsLetterMemberDto> validatorUpdateNewsLetterMember) : base(provider)
        {
            _Mapper = mapper;
            _NewsLetterMemberRepository = NewsLetterMemberRepository;
            _ValidatorCreateNewsLetterMember = validatorCreateNewsLetterMember;
            _ValidatorUpdateNewsLetterMember = validatorUpdateNewsLetterMember;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<NewsLetterMember, NewsLetterMemberListDto, int>>> GetAll(FilterNewsLetterMemberDto? filter = null,PagingDto? paging = null)
        {
            var query = _NewsLetterMemberRepository.GetQueryable();

            if (filter == null) filter = new FilterNewsLetterMemberDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Email != null)
                query = query.Where(q => EF.Functions.Like(q.Email, $"%{filter.Email}%"));
            
            if (filter.UserId != null)
                query = query.Where(q => q.UserId == filter.UserId);

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<NewsLetterMember, NewsLetterMemberListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<NewsLetterMemberListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<NewsLetterMember, NewsLetterMemberListDto, int>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreateNewsLetterMemberDto create)
        {
            var validationResult = await _ValidatorCreateNewsLetterMember.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            NewsLetterMember NewsLetterMember = _Mapper.Map<NewsLetterMember>(create);

            if (await _NewsLetterMemberRepository.GetQueryable().AnyAsync(a => a.UserId != null && a.UserId == _AppUserProvider.User.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, "قبلا عضو شده اید !");

            if (await _NewsLetterMemberRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Email , create.Email)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, "قبلا عضو شده اید !");

            if (_AppUserProvider.User.Id > 0)
                NewsLetterMember.UserId = _AppUserProvider.User.Id;

            await _NewsLetterMemberRepository.Add(NewsLetterMember,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, "عضویت در خبرنامه با موفقیت انجام شد");
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateNewsLetterMemberDto update)
        {
            var validationResult = await _ValidatorUpdateNewsLetterMember.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            NewsLetterMember? NewsLetterMember = await _NewsLetterMemberRepository.GetAsTracking(update.Id);
            
            if (NewsLetterMember == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _NewsLetterMemberRepository.Update(_Mapper.Map(update,NewsLetterMember), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            NewsLetterMember? NewsLetterMember = await _NewsLetterMemberRepository.GetAsTracking(delete);

            if (NewsLetterMember == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _NewsLetterMemberRepository.SoftDelete(NewsLetterMember, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }





    }
}
