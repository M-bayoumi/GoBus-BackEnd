namespace GoBye.BLL.Dtos.ApplicationUserDtos
{
    public class LoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
