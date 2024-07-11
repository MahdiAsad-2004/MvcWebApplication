using FluentValidation;
using OrganicShop.Domain.Dtos.OrderDtos;
using OrganicShop.Domain.Validation.Validators.Base;

namespace OrganicShop.Domain.Validation.OrderValidators
{
    public class CreateOrderValidator : BaseValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {


        }
    }


    public class UpdateOrderValidator : BaseValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
         

        }
    }



}
