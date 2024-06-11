using OrganicShop.Domain.Enums;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using OrganicShop.Domain.Entities.Relations;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("دسته بندی")]
    public class Category : EntityId<int>
    {
        public string Title { get; set; }
        public string? IconClass { get; set; }
        public string? IconColor { get; set; }
        public CategoryType Type { get; set; }
        public int? ParentId { get; set; }




        public Picture? Picture { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Subs { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<CouponCategories> CouponCategories { get; set; }





        public List<Category> GetWithAllParents()
        {
            var category = this;
            var list = new List<Category>() { category};
            while (category.Parent != null)
            {
                list.Add(category.Parent);
                category = category.Parent;
            }
            return list;
        }



    }
}
