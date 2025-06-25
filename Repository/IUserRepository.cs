using PasswordResetAPI.Model;

namespace PasswordResetAPI.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetByEmail(string email);
        public Task<User> GetByResetToken(string token);
        public Task<bool> SaveChanges();
    }
}
