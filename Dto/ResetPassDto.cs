namespace PasswordResetAPI.DTOs
{
    public class ResetPassDto
    {
        public string Token { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
