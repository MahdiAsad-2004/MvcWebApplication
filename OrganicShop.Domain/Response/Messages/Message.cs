using OrganicShop.Domain.Dtos.Base;
using OrganicShop.Domain.Entities.Base;
using OrganicShop.Domain.Enums.Response;
using System.ComponentModel;
using System.Reflection;

namespace OrganicShop.Domain.Response.Messages
{
    public class Message<Entity> where Entity : IAggregateRoot
    {
        private static string _EntityName;

        private static readonly string NotFoundMessage = "{x} Not Found";
        private static readonly string NoAccessMessage = "You haven't access to entity";
        private static readonly string SuccessCreateMessage = "{x} successfully create";
        private static readonly string SuccessUpdateMessage = "{x} successfully update";
        private static readonly string SuccessDeleteMessage = "{x} successfully delete";
        private static readonly string MaxCreateMessage = "The maximum number of {x} is {y}";
        private static readonly string EntityExistMessage = "{x} with {y} '{z}' already exist";
        //private static void SetEntityName(T? entity)
        //{
        //    if(entity == null)
        //    {
        //        _EntityName = nameof(entity);
        //    }
        //    else if(entity is string)
        //    {
        //        _EntityName = entity.ToString();
        //    }
        //    else if(entity is Type)
        //    {
        //        var type = (Type)entity;
        //        _EntityName = type.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        //    }
        //    else if(entity is IAggregateRoot)
        //    {
        //        var type = entity.GetType();
        //        _EntityName = type.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        //    }
        //    else
        //    {
        //        _EntityName = entity.GetType().Name;
        //    }

        //}





        public Message()
        {
            var type = typeof(Entity);
            _EntityName = type.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        }




        public string NotFound()
        {
            //return $"{_EntityName} Not Found";
            return $"{_EntityName} مورد نظر یافت نشد !";
        }
        public string NotFound(Type? type)
        {
            var displayAttribute = type.GetCustomAttribute<DisplayNameAttribute>();
            string entityName = _EntityName = displayAttribute != null ? displayAttribute.DisplayName : type.Name;
            return $"{entityName} مورد نظر یافت نشد !";
        }
        public string NoAccess()
        {
            return $"شما به این {_EntityName} ندارید";
        }

        public string SuccessUpdate()
        {
            return $"{_EntityName} با موفقیت ویرایش شد";
        }

        public string SuccessCreate()
        {
            return $"{_EntityName} با موفقیت ایجاد شد";
        }

        public string SuccessDelete()
        {
            return $"{_EntityName} با موفقیت حذف شد";
        }

        public string MaxCreate(int count)
        {
            //return $"The maximum number of {_EntityName} is {count}";
            return $"حداکثر تعداد {_EntityName} , {count} است";
        }

        //public static string EntityExist(object? entity, )
        //{
        //    SetEntityName(entity);
        //    //return $"{_EntityName} with {propertyName} '{propertyValue}' already exist";
        //    return $"{_EntityName} با {propertyName} '{propertyValue}' در حال حاضر وجود دارد";
        //}

        public string EntityExist<TDto>(TDto dto, Func<TDto, string> nameofProperty) where TDto : BaseDto
        {
            var entityType = typeof(Entity);
            var dtoType = typeof(TDto);
            var propertyStr = nameofProperty.Invoke(dto);
            var displayAttribute = dtoType.GetProperty(propertyStr).GetCustomAttribute<DisplayNameAttribute>();
            string propertyName = displayAttribute != null ? displayAttribute.DisplayName : dtoType.GetProperty(propertyStr).Name;
            string propertyValue = dtoType.GetProperty(propertyStr).GetValue(dto).ToString();
            return $"{_EntityName} با {propertyName} ' {propertyValue} ' در حال حاضر وجود دارد";
        }


















        //public static string NotFound(Type? entity)
        //{
        //    SetEntityName(entity);
        //    //return $"{_EntityName} Not Found";
        //    return $"{_EntityName} مورد نظر یافت نشد !";
        //}

        //public static string NoAccess()
        //{
        //    return $"شما به این بخش دسترسی ندارید";
        //}

        //public static string SuccessUpdate(Type? entity)
        //{
        //    SetEntityName(entity);
        //    return $"{_EntityName} با موفقیت ویرایش شد";
        //}

        //public static string SuccessCreate(Type? entity)
        //{
        //    SetEntityName(entity);
        //    return $"{_EntityName} با موفقیت ایجاد شد";
        //}

        //public static string SuccessDelete(Type? entity)
        //{
        //    SetEntityName(entity);
        //    return $"{_EntityName} با موفقیت حذف شد";
        //}

        //public static string MaxCreate(Type? entity , int count)
        //{
        //    SetEntityName(entity);
        //    //return $"The maximum number of {_EntityName} is {count}";
        //    return $"حداکثر تعداد {_EntityName} , {count} است";
        //}

        ////public static string EntityExist(object? entity, )
        ////{
        ////    SetEntityName(entity);
        ////    //return $"{_EntityName} with {propertyName} '{propertyValue}' already exist";
        ////    return $"{_EntityName} با {propertyName} '{propertyValue}' در حال حاضر وجود دارد";
        ////}

        //public static string EntityExist<TDto>(TDto dto, Type? entity  ,Func<TDto, string> nameofProperty) where TDto : BaseDto
        //{
        //    SetEntityName(entity);
        //    var propertyStr = nameofProperty.Invoke(dto);
        //    string propertyName = entity.GetType().GetProperty(propertyStr).GetCustomAttribute<DisplayNameAttribute>().DisplayName;
        //    string propertyValue = entity.GetType().GetProperty(propertyStr).GetValue(dto).ToString();
        //    return $"{_EntityName} با {propertyName} '{propertyValue}' در حال حاضر وجود دارد";
        //}





    }


}
