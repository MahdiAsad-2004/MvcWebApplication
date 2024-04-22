using OrganicShop.BLL.Extensions;
using OrganicShop.DAL;
using OrganicShop.Domain.Dtos.BankCardDtos;
using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.IProviders;


namespace OrganicShop.BLL.Providers
{
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        public ApplicationUser User { get; private set; }


        public void SetCurrentUser(ApplicationUser currentUser)
        {
            User = currentUser;
        }

    }
}
