using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("ارتباط با ما")]
    public class ContactUs : EntityId<byte>
    {
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Email1 { get; set; }
        public string? Email2 { get; set; }
        public string Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public string PhoneNumber1 { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? PhoneNumber3 { get; set; }
        public string Office1 { get; set; }
        public string? Office2 { get; set; }
        public string? Office3 { get; set; }
    }
}
