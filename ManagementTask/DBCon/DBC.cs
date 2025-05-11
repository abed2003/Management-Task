using ManagementTask.Entity;
using Microsoft.EntityFrameworkCore;

namespace ManagementTask.DBCon
{
    public class DBC : DbContext
    {
        public DBC(DbContextOptions<DBC> options) : base(options) { }
        public DbSet<Users> User {  get; set; } 
        public DbSet<UserTask> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<UserTask>()
               .HasOne(w => w.User)
               .WithMany(f => f.Tasks)
               .HasForeignKey(w => w.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        }
        }
}
