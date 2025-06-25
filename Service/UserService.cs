using PasswordResetAPI.Model;
using PasswordResetAPI.Repository;

namespace PasswordResetAPI.Services
{
    public class UserService
    {
        private readonly IUserRepository repo;
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }
        public async Task<User> GettingByEmail(string email)
        {
            return await repo.GetByEmail(email);
        }
        public async Task<bool> SetResetToken(User user, string token, DateTime expires)
        {
            user.PasswordResetToken = token;
            user.ResetTokenExpires = expires;
            return await repo.SaveChanges();
        }
        public async Task<bool> ResetPassword(string token, string newPass)
        {
            var exist = await repo.GetByResetToken(token);
            if (exist == null)
                return false;
            exist.Password = BCrypt.Net.BCrypt.HashPassword(newPass);
            exist.PasswordResetToken = null;
            exist.ResetTokenExpires = null;
            return await repo.SaveChanges();
        }
    }
}