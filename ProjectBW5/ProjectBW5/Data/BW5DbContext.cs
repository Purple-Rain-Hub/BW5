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

        // DbSet Farmacia
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.User).WithMany(u => u.ApplicationUserRoles).HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<ApplicationUserRole>().HasOne(ur => ur.Role).WithMany(r => r.ApplicationUserRoles).HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().Property(p => p.Date).HasDefaultValueSql("GETDATE()").IsRequired(true);

            // Molti a Molti: Farmacia
            modelBuilder.Entity<Receipt>().HasKey(r => new { r.MedicineId, r.SaleId });

            modelBuilder.Entity<Receipt>().HasOne(r => r.Medicine).WithMany(m => m.Receipts).HasForeignKey(r => r.MedicineId);

            modelBuilder.Entity<Receipt>().HasOne(r => r.Sale).WithMany(s => s.Receipts).HasForeignKey(r => r.SaleId);

            modelBuilder.Entity<Receipt>().Property(r => r.Timestamp).HasDefaultValueSql("GETDATE()").IsRequired();

            modelBuilder.Entity<Sale>().Property(s => s.SaleDate).HasDefaultValueSql("GETDATE()").IsRequired();
        }
    }
}
