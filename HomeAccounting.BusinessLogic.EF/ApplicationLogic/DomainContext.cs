using HomeAccounting.BusinessLogic.EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinessLogic.EF.ApplicationLogic
{
    public class DomainContext : DbContext
    {
        private readonly string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=HomeAccounting;Integrated Security=true;MultipleActiveResultSets=True;";


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Cash> Cashes { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Property> Propertes { get; set; }
        public DbSet<PropertyPriceChange> PricesChanges { get; set; }

        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Bank>();
            modelBuilder.Entity<Cash>().ToTable("Cashes");
            modelBuilder.Entity<Deposit>().ToTable("Deposits");
            modelBuilder.Entity<Operation>().HasMany<Account>(x => x.Accounts); 
            modelBuilder.Entity<Property>().ToTable("Propertes").HasMany<PropertyPriceChange>(x => x.PropertyPriceChanges);
            modelBuilder.Entity<PropertyPriceChange>();
        }
    }
}
