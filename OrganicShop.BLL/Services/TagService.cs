using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.TagDtos;
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
    public class TagService : Service<Tag>, ITagService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly ITagRepository _TagRepository;
        private readonly IValidator<CreateTagDto> _ValidatorCreateTag;
        private readonly IValidator<UpdateTagDto> _ValidatorUpdateTag;

        public TagService(IApplicationUserProvider provider, IMapper mapper, ITagRepository TagRepository,
            IValidator<CreateTagDto> validatorCreateTag, IValidator<UpdateTagDto> validatorUpdateTag) : base(provider)
        {
            _Mapper = mapper;
            _TagRepository = TagRepository;
            this._ValidatorCreateTag = validatorCreateTag;
            _ValidatorUpdateTag = validatorUpdateTag;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Tag, TagListDto, int>>> GetAll(FilterTagDto? filter = null,PagingDto? paging = null)
        {
            var query = _TagRepository.GetQueryable();

            if (filter == null) filter = new FilterTagDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.Title != null)
                query = query.Where(q => EF.Functions.Like(q.Title, $"%{filter.Title}%"));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Tag, TagListDto,int> pageDto = new();
            pageDto.List = pageDto.SetPaging(query , paging).Select(a => _Mapper.Map<TagListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Tag, TagListDto, int>>(ResponseResult.Success,pageDto);
        }


        public async Task<ServiceResponse<UpdateTagDto>> Get(int Id)
        {
            if(Id < 1)
                return new ServiceResponse<UpdateTagDto>(ResponseResult.NotFound,null);
            
            var tag = await _TagRepository.GetAsNoTracking(Id);
            
            if(tag == null)
                return new ServiceResponse<UpdateTagDto>(ResponseResult.NotFound,null);

            return new ServiceResponse<UpdateTagDto>(ResponseResult.Success, _Mapper.Map<UpdateTagDto>(tag));
        }


        public async Task<ServiceResponse<Empty>> Create(CreateTagDto create)
        {
            var validationResult = await _ValidatorCreateTag.ValidateAsync(create);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(create, validationResult);

            Tag Tag = _Mapper.Map<Tag>(create);

            if (await _TagRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , create.Title)))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(create,a => nameof(a.Title)));

            await _TagRepository.Add(Tag,_AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdateTagDto update)
        {
            var validationResult = await _ValidatorUpdateTag.ValidateAsync(update);
            if (!validationResult.IsValid)
                return new ServiceResponse<Empty>(update, validationResult);

            Tag? Tag = await _TagRepository.GetAsTracking(update.Id);
            
            if (Tag == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            if (await _TagRepository.GetQueryable().AnyAsync(a => EF.Functions.Like(a.Title , update.Title) && a.Id != update.Id))
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.EntityExist(update, a => nameof(a.Title)));

            await _TagRepository.Update(_Mapper.Map(update,Tag), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(int delete)
        {
            Tag? Tag = await _TagRepository.GetAsTracking(delete);

            if (Tag == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _TagRepository.SoftDelete(Tag, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }



        public async Task<ServiceResponse<List<ComboDto<Tag>>>> GetCombos()
        {
            var comboDtos = _TagRepository
              .GetQueryable()
              .Select(a => _Mapper.Map<ComboDto<Tag>>(a))
              .ToList();
            return new ServiceResponse<List<ComboDto<Tag>>>(ResponseResult.Success, comboDtos);
        }



    }
}
