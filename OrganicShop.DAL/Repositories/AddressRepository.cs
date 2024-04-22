﻿using OrganicShop.DAL.Context;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.DAL.Repositories
{
    public class AddressRepository : CrudRepository<Address, long> , IAddressRepository
    {

        public AddressRepository(OrganicShopDbContext organicShopDbContext):base(organicShopDbContext) 
        {
                
        }
    }

    
}
