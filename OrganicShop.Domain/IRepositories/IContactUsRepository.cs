using OrganicShop.Domain.Entities;
using OrganicShop.Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface IContactUsRepository : IRepository,
        IReadRepository<ContactUs,byte>,
        IWriteRepository<ContactUs,byte>
    {

    }
}
