namespace QuizSystemWeb.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using QuizSystemWeb.Data.Entities;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        // public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
