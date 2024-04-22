using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("عملیات")]
    public class Operation 
    {
        public long Id { get; set; }
        public OperationType Type { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
        public string EntityTitle { get; set; }
        public string? EntityOldData { get; set; }
        public string? EntityNewData { get; set; }
        public string? Description { get; set; }



        public User User { get; set; }
    }
}
