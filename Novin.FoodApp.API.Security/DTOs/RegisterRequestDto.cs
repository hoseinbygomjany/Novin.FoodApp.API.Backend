using Novin.FoodApp.Core.Enumes;

namespace Novin.FoodApp.API.Security.DTOs
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public ApplicationUserType Type { get; set; }

    }
}
