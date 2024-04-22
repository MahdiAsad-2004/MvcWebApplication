using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IProviders;
using OrganicShop.Domain.Models;
using OrganicShop.Domain.Response.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IServices
{
    public interface IService<Entity> where Entity : IAggregateRoot
    {
        Message<Entity> _Message { get; } 
        IApplicationUserProvider _AppUserProvider { get; } 
    }

}
