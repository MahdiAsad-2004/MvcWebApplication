using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("واحد")]
    public class UnitValue : EntityId<long>
    {
        public UnitType UnitType { get; set; }
        public float Value { get; set; }
        public long ProductId { get; set; }



        public Product Product { get; set; }

    }
}
