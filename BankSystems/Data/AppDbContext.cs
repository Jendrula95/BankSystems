using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Customer> Customers { get; set; } = default;
       
        public DbSet<Account> Accounts { get; set; } = default;
        public DbSet<Transaction> Transactions { get; set; } = default;
        public DbSet<Currency> Currencies { get; set; } = default;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Currency>().ToTable("Currency");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
           
            modelBuilder.Entity<Account>().ToTable("Account");
            //modelBuilder.Entity<Models.Account>().HasMany(c => c.Customer).WithOne(s => s.Account).HasForeignKey(s => s.CustomerID);
            //modelBuilder.Entity<Models.Account>().HasOne(c => c.Currency).WithMany(s => s.Account).HasForeignKey(s => s.CurrencyID);
        }
        public DbSet<BankSystem.Models.Cards> Cards { get; set; }
       

    }
}
