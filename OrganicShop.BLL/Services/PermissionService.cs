using Microsoft.EntityFrameworkCore;
using OrganicShop.BLL.Mappers;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.PermissionDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using OrganicShop.Domain.IServices;
using OrganicShop.Domain.Enums.Response;
using OrganicShop.Domain.Response;
using OrganicShop.Domain.Dtos.Combo;
using AutoMapper;
using OrganicShop.Domain.Dtos.AddressDtos;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Enums;

namespace OrganicShop.BLL.Services
{
    public class PermissionService : Service<Permission>, IPermissionService
    {
        #region ctor

        private readonly IMapper _Mapper;
        private readonly IPermissionRepository _PermissionRepository;
        private readonly IPermissionUsersRepository _PermissionUsersRepository;

        public PermissionService(IApplicationUserProvider provider,IMapper mapper,IPermissionRepository permissionRepository,
            IPermissionUsersRepository permissionUsersRepository) : base(provider)
        {
            _Mapper = mapper;
            _PermissionRepository = permissionRepository;
            _PermissionUsersRepository = permissionUsersRepository;
        }

        #endregion



        public async Task<ServiceResponse<PageDto<Permission,PermissionListDto,byte>>> GetAll(FilterPermissionDto? filter = null,PagingDto? paging = null)
        {
            var query = _PermissionRepository.GetQueryable();

            if (filter == null) filter = new FilterPermissionDto();
            if (paging == null) paging = new PagingDto();

            #region filter

            query = filter.ApplyBaseFilters(query);

            if (filter.ParentId != null)
                query = query.Where(q => q.ParentId == filter.ParentId);


            if (filter.UserId != null)
            {
                IQueryable<User> query1 = _PermissionUsersRepository.GetQueryable().Where(q => q.UserId == filter.UserId).Select(a => a.User).AsQueryable();
                query = query.IntersectBy(query1.Select(a => a.Id), b => b.Id);

            }

            #endregion

            #region sort

            query = filter.ApplySortType(query);

            #endregion

            PageDto<Permission, PermissionListDto, byte> pageDto = new();
            pageDto.List = pageDto.SetPaging(query, paging).Select(a => _Mapper.Map<PermissionListDto>(a)).ToList();
            pageDto.Pager = pageDto.SetPager(query, paging);

            return new ServiceResponse<PageDto<Permission, PermissionListDto, byte>>(ResponseResult.Success,pageDto);
        }



        public async Task<ServiceResponse<Empty>> Create(CreatePermissionDto create)
        {
            Permission Permission = _Mapper.Map<Permission>(create);

            #region relations

            if (create.ParentId != null)
            {
                if (_PermissionRepository.GetQueryable().Any(a => a.Id == create.ParentId) == false)
                    return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());
                Permission.ParentId = create.ParentId;
            }

            #endregion

            await _PermissionRepository.Add(Permission, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessCreate());
        }



        public async Task<ServiceResponse<Empty>> Update(UpdatePermissionDto update)
        {
            Permission? Permission = await _PermissionRepository.GetAsTracking(update.Id);

            if (Permission == null)
                return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());

            #region relation

            if (update.ParentId != null)
            {
                if (_PermissionRepository.GetQueryable().Any(a => a.Id == update.ParentId) == false)
                    return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());
            }

            #endregion

            await _PermissionRepository.Update(_Mapper.Map<Permission>(update), _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessUpdate());
        }



        public async Task<ServiceResponse<Empty>> Delete(byte delete)
        {

            Permission? Permission = await _PermissionRepository.GetAsTracking(delete);

            if (Permission == null)
                return new ServiceResponse<Empty>(ResponseResult.NotFound, _Message.NotFound());

            await _PermissionRepository.SoftDelete(Permission, _AppUserProvider.User.Id);
            return new ServiceResponse<Empty>(ResponseResult.Success, _Message.SuccessDelete());
        }




        public async Task<ServiceResponse<List<ComboDto<Permission>>>> GetCombos()
        {
            var comboDtos = _PermissionRepository
            .GetQueryable()
            .Select(a => _Mapper.Map<ComboDto<Permission>>(a))
            .ToList();
            return new ServiceResponse<List<ComboDto<Permission>>>(ResponseResult.Success,comboDtos);
        }


    }
}
