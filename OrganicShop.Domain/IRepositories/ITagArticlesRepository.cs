using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IRepositories
{
    public interface ITagArticlesRepository : IRepository,
        IReadRepository<TagArticles, int>,
        IWriteRepository<TagArticles, int>
    {
      
    }
}
