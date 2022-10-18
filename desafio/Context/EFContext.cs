
using Microsoft.EntityFrameworkCore;
using desafio.Entity;

namespace desafio.Context
{
    public class EFContext : DbContext
    {
        public DbSet<EmployeeEntity> Employees { get; set; }
        
        public DbSet<MemberEntity> Members { get; set; }
        
        public DbSet<ProjectEntity> Projects { get; set; }

        public EFContext(DbContextOptions<EFContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}