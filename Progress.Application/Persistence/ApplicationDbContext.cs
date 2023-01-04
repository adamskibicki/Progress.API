using Microsoft.EntityFrameworkCore;
using Progress.Application.Persistence.Entities;

namespace Progress.Application.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tree> Trees { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public DbSet<Quest> Quests { get; set; }
    }
}
