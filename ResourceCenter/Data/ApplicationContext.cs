using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ResourceCenter.Models;

namespace ResourceCenter.Data
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Resident> Residents { get; set; } = null!;
        public DbSet<ResidentAccount> ResidentAccounts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasAlternateKey(account => account.Number);
            modelBuilder.Entity<Resident>().HasAlternateKey(resident => new { resident.FullName, resident.Number });
            modelBuilder
            .Entity<Account>()
            .HasMany(account => account.Residents)
            .WithMany(resident => resident.Accounts)
            .UsingEntity<ResidentAccount>();
            /*.UsingEntity(
            "ResidentAccount",
            l => l.HasOne(typeof(Resident)).WithMany().HasForeignKey("ResidentId").HasPrincipalKey(nameof(Resident.Id)),
            r => r.HasOne(typeof(Account)).WithMany().HasForeignKey("AccountId").HasPrincipalKey(nameof(Account.Id)),
            j => j.HasKey("ResidentId", "AccountId"));*/
        }
    }
}
