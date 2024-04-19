using Microsoft.EntityFrameworkCore;
using Models;
using System.Reflection.Metadata;

namespace DAL
{
    public class UczelniaContext : DbContext
    {
        public DbSet<Student>? Studenci { get; set; }
        public DbSet<Grupa>? Grupy { get; set; }
        public DbSet<Historia>? Historia { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KolokwiumUczelniaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .ToTable(tb => tb.HasTrigger("Trigger_EdycjaStudenta"));
            modelBuilder.Entity<Student>()
                .ToTable(tb => tb.HasTrigger("Trigger_UsuwanieStudenta"));
        }
    }
}