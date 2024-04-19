using Microsoft.EntityFrameworkCore;
using Models;

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
    }
}