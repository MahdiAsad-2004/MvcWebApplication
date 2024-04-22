using OrganicShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.IProviders
{
    public interface IApplicationUserProvider
    {
        public ApplicationUser User { get; }

        void SetCurrentUser(ApplicationUser currentUser);
    }
}
