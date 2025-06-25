using Microsoft.EntityFrameworkCore;
using PasswordResetAPI.Model;


namespace PasswordResetAPI.Data
{
    public class PasswordContext : DbContext
    {
        public PasswordContext(DbContextOptions<PasswordContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}