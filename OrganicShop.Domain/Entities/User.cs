﻿using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Entities.Relations;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("کاربر")]
    public class User : EntityId<long>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }



        #region relations

        public Picture? Picture { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<BankCard> BankCards { get; set; }
        public Cart Cart { get; set; }
        public Cart NextCart { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Operation> Operations { get; set; }
        //public ICollection<Cart> Carts { get; set; }
        public ICollection<PermissionUsers> PermissionUsers { get; set; }

        #endregion


    }

}
