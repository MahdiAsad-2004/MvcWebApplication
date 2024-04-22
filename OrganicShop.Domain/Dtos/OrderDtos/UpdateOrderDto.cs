using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.OrderDtos
{
    public class UpdateOrderDto : BaseListDto<long>
    {
        public OrderStatus OrderStatus { get; set; }
        public DateTime DeliveryDatePredicate { get; set; }

    }




}
