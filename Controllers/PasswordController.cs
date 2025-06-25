using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PasswordResetAPI.Services;

namespace PasswordResetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly UserService userService;
        private readonly EmailService emailService;
        public PasswordController(UserService userService, EmailService emailService)
        {
            this.userService = userService;
            this.emailService = emailService;
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await userService.GettingByEmail(request.Email);
            if (user == null)
                return Ok(new { message = "If your email exists, a reset link will be sent." });

            var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            var expires = DateTime.UtcNow.AddHours(1);

            var updated = await userService.SetResetToken(user, token, expires);

            if (!updated)
                return StatusCode(500, new { message = "Error generating reset token." });

            var resetLink = $"https://localhost:7207/api/Password/reset-password?token={token}";
            await emailService.SendEmail(user.Email, resetLink);

            return Ok(new { message = "If your email exists, a reset link will be sent......." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            var success = await userService.ResetPassword(request.ResetCode, request.NewPassword);

            if (!success)
                return BadRequest(new { message = "Invalid or expired token." });

            return Ok(new { message = "Password has been reset successfully." });
        }
    }
}