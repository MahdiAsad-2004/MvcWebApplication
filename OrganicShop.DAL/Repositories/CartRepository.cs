﻿using OrganicShop.DAL.Context;
using OrganicShop.DAL.Repositories.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public class CartRepository : CrudRepository<Cart, long>, ICartRepository
    {
        public CartRepository(OrganicShopDbContext organicShopDbContext) : base(organicShopDbContext)
        {
        }
    }


}
