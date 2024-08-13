using OrganicShop.Domain.Dtos.Base;
using System.Text.Json;

namespace OrganicShop.Domain.Dtos.UserDtos
{
    public class VerifyEmailToken : BaseDto
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public DateTime ExpireDate { get; set; }




        public static VerifyEmailToken? GetVerifyEmailToken(string? serializedToken)
        {
            VerifyEmailToken? token = null;
            try
            {
                token = JsonSerializer.Deserialize<VerifyEmailToken>(serializedToken);
            }
            catch (Exception ex)
            {
                return null;
            }
            return token;
        }


    }





}
