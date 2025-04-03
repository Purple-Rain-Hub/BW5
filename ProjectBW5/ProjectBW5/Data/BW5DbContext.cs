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
        public DbSet<StrayHospital> StrayHospitals { get; set; }

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
        
            modelBuilder.Entity<Examination>().HasOne(e => e.Animal).WithMany(a=> a.Examinations).HasForeignKey(e=> e.AnimalId);

            modelBuilder.Entity<Examination>().HasOne(e => e.User).WithMany(u => u.Examinations).HasForeignKey(e => e.VetId);

            modelBuilder.Entity<Hospitalization>().HasOne(h => h.Animal).WithMany(a => a.Hospitalizations).HasForeignKey(h => h.AnimalId);

            modelBuilder.Entity<Hospitalization>().HasOne(h => h.User).WithMany(u => u.Hospitalizations).HasForeignKey(h => h.VetId);

            modelBuilder.Entity<Animal>().Property(p => p.RegistrationDate).HasDefaultValueSql("GETDATE()").IsRequired(true);

            modelBuilder.Entity<Animal>().HasIndex(a => a.MicrochipNumber).IsUnique();

            modelBuilder.Entity<StrayHospital>().HasOne(s => s.User).WithMany(u => u.StrayHospitals).HasForeignKey(s => s.VetId);

            modelBuilder.Entity<StrayHospital>().HasOne(s => s.Animal).WithOne(a => a.StrayHospital).HasForeignKey<StrayHospital>(s=> s.AnimalId);
        }
    }
}
