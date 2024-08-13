using OrganicShop.Domain.Dtos.Base;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class EmailVerificationDto : BaseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }


        public EmailVerificationDto()
        {
            
        }
        public EmailVerificationDto(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }


    }







}
