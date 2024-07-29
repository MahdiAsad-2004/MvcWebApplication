using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.WishItemDtos;
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
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.BLL.Services
{
    public class WishItemService : Service<WishItem>, IWishItemService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IWishItemRepository _WishItemRepository;

        public WishItemService(IApplicationUserProvider provider, IMapper mapper, IWishItemRepository WishItemRepository) : base(provider)
        {
            _Mapper = mapper;
            _WishItemRepository = WishItemRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<WishItem, WishItemListDto, long>>> GetAll(FilterWishItemDto? filter = null, PagingDto? paging = null)
        {
            var query = _WishItemRepository.GetQueryable();

            if (filter == null) filter = new FilterWishItemDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.UserId != null)
                query = query.Where(q => q.UserId.Equals(filter.UserId.Value));

            if (filter.ProductId != null)
                query = query.Where(q => q.UserId.Equals(filter.ProductId.Value));

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<WishItem, WishItemListDto, long> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<WishItemListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<WishItem, WishItemListDto, long>>(ResponseResult.Success, pageDto);
        }


        public async Task<ServiceResponse<Empty>> Create(CreateWishItemDto create)
        {
            if (_AppUserProvider.User.Id < 1)
                return new ServiceResponse<Empty>(ResponseResult.NoAccess, _Message.NoAccess());

            WishItem WishItem = _Mapper.Map<WishItem>(create);

            if (await _WishItemRepository.GetQueryable().AnyAsync(a => a.UserId == _AppUserProvider.User.Id && a.ProductId == create.ProductId) == true)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "محصول در علاقه مندی ها وجود دارد");

            await _WishItemRepository.Add(WishItem, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }


        //public async Task<ServiceResponse<Empty>> Delete(long delete)
        //{
        //    WishItem? WishItem = await _WishItemRepository.GetAsTracking(delete);

        //    if (WishItem == null)
        //        return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

        //    await _WishItemRepository.SoftDelete(WishItem, _AppUserProvider.User.Id);
        //    return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        //}


        public async Task<ServiceResponse<Empty>> Delete(long productId)
        {
            if (_AppUserProvider.User.Id < 1)
                return new ServiceResponse<Empty>(ResponseResult.NoAccess , _Message.NoAccess());

            WishItem? WishItem = await _WishItemRepository.GetQueryableTracking()
                .FirstOrDefaultAsync(a => a.ProductId == productId && a.UserId == _AppUserProvider.User.Id);

            if (WishItem == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _WishItemRepository.SoftDelete(WishItem, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }


        public async Task<ServiceResponse<long[]>> GetUserWishProductIds()
        {
            long[] productIds = new long[0];

            if (_AppUserProvider.User.Id > 0)
            {
                productIds = await _WishItemRepository.GetQueryable()
                .Where(a => a.UserId == _AppUserProvider.User.Id)
                .Select(a => a.ProductId)
                .ToArrayAsync();
            }

            return new ServiceResponse<long[]>(ResponseResult.Success, productIds);
        }





        public async Task<ServiceResponse<Empty>> ToggleProduct(long productId)
        {
            if (productId < 1)
                return new ServiceResponse<Empty>(ResponseResult.Failed, "محصول یافت نشد");

            if (_AppUserProvider.User.Id < 1)
                return new ServiceResponse<Empty>(ResponseResult.Failed, _Message.NoAccess());

            WishItem? WishItem = await _WishItemRepository.GetQueryable()
                .FirstOrDefaultAsync(a => a.ProductId == productId && a.UserId == _AppUserProvider.User.Id);

            if (WishItem == null)
            {
                WishItem = new WishItem
                {
                    ProductId = productId,
                    UserId = _AppUserProvider.User.Id
                };
                await _WishItemRepository.Add(WishItem, _AppUserProvider.User.Id);
                return new ServiceResponse<Empty>(ResponseResult.Success, "محصول به علاقه مندی ها افزوده شد");
            }
            else
            {
                await _WishItemRepository.SoftDelete(WishItem, _AppUserProvider.User.Id);
                return new ServiceResponse<Empty>(ResponseResult.Success, "محصول از علاقه مندی ها حذف سد");
            }
        }



    }
}
