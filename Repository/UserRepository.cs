using Microsoft.EntityFrameworkCore;
using PasswordResetAPI.Data;
using PasswordResetAPI.Model;


namespace PasswordResetAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PasswordContext db;
        public UserRepository(PasswordContext db)
        {
            this.db = db;
        }
        public async Task<User> GetByEmail(string email)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetByResetToken(string token)
        {
            return await db.Users.FirstOrDefaultAsync(u =>
            u.PasswordResetToken == token &&
            u.ResetTokenExpires > DateTime.UtcNow);
        }

        public async Task<bool> SaveChanges()
        {
            return await db.SaveChangesAsync() > 0;
        }
    }
}