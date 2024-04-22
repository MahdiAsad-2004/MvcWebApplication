﻿using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface IDiscountProductsRepository : IRepository,
        IReadRepository<DiscountProducts,int>,
        IWriteRepository<DiscountProducts,int>
    {
      
    }
}
