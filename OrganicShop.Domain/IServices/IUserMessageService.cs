using OrganicShop.Domain.Dtos.Combo;
using OrganicShop.Domain.Dtos.Page;
using OrganicShop.Domain.Dtos.UserMessageDtos;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Response;

namespace OrganicShop.Domain.IServices
{
    public interface IUserMessageService : IService<UserMessage>
    {
        Task<ServiceResponse<PageDto<UserMessage, UserMessageListDto, int>>> GetAll(FilterUserMessageDto? filter = null,PagingDto? paging = null);

        Task<ServiceResponse<Empty>> Create(CreateUserMessageDto create);

        
        Task<ServiceResponse<Empty>> Delete(int delete);


    }
}
