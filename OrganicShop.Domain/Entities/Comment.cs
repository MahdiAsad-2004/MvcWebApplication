using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("نظر")]
    public class Comment: EntityId<long>
    {
        public int Rate { get; set; }
        public string Text { get; set; }
        public CommentStatus Status { get; set; }
        public long UserId { get; set; }
        public long ProductId { get; set; }



        public User User { get; set; }
        public Product Product { get; set; }



    }
}
