﻿using OrganicShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface IPictureRepository : IRepository,
        IReadRepository<Picture, long>,
        IWriteRepository<Picture, long>,
        IDeleteRepository<Picture, long>
    {

    }
}
