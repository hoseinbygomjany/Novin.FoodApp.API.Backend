namespace Novin.FoodApp.API.Security.DTOs
{
    public class LoginResultDto
    {
        public string? Masseage { get; set; }
        public bool Isok { get; set; }
        public string? Token { get; set; }
        public string Type { get; set; }
    }
}
