using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums
{
    public enum OrderStep
    {
        Processing = 1,

        Packing = 2,

        DeliveredToPost = 3,

        Transporting = 4,

        DeliveredToCustomer = 5,


    }
}
