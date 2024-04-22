using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.BankCardDtos
{
    public class UpdateBankCardDto : BaseListDto<long>
    {
        public string Cvv2 { get; set; }
        public string Number { get; set; }
        public DateTime ExpireDate { get; set; }
        public string OwnerName { get; set; }
        public long UserId { get; set; }
    }



}
