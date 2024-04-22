using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Base
{
    public class BaseListDto<TKey> : BaseDto where TKey : struct 
    {
        public TKey Id { get; set; }
    }
}
