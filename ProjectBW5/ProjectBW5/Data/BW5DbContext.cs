using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjectBW5.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectBW5.Data
{
    public class BW5DbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public BW5DbContext(DbContextOptions<BW5DbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRoles).HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(r => r.ApplicationUserRoles).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);
        
            modelBuilder.Entity<Examination>().HasOne(e => e.Animal).WithMany(a=> a.Examinations).HasForeignKey(e=> e.AnimalId);

            modelBuilder.Entity<Examination>().HasOne(e => e.User).WithMany(u => u.Examinations).HasForeignKey(e => e.VetId);

            modelBuilder.Entity<Hospitalization>().HasOne(h => h.Animal).WithMany(a => a.Hospitalizations).HasForeignKey(h => h.AnimalId);

            modelBuilder.Entity<Hospitalization>().HasOne(h => h.User).WithMany(u => u.Hospitalizations).HasForeignKey(h => h.VetId);

            modelBuilder.Entity<Animal>().Property(p => p.RegistrationDate).HasDefaultValueSql("GETDATE()").IsRequired(true);
        }
    }
}
