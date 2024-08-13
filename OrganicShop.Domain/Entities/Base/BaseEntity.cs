
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicShop.Domain.Entities.Base
{
    [ComplexType]
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? DeleteDate { get; set; }

        public BaseEntity()
        {
                
        }

        public BaseEntity(bool newEntity)
        {
            CreateDate = DateTime.Now;
            LastModified = DateTime.Now;
            IsActive = true;
            IsDelete = false;
            DeleteDate = null;
        }  
        
        public BaseEntity(DateTime createDate)
        {
            CreateDate = createDate;
            LastModified = createDate;
            IsActive = true;
            IsDelete = false;
            DeleteDate = null;
        }

        public BaseEntity UpdateOperation(BaseEntity baseEntity)
        {
            baseEntity.LastModified = DateTime.Now;
            return baseEntity;
        }

        public BaseEntity SoftDeleteOperation(BaseEntity baseEntity)
        {
            baseEntity.IsDelete = true;
            baseEntity.DeleteDate = DateTime.Now;
            return baseEntity;
        }

    }
}
