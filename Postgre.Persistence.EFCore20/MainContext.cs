using Microsoft.EntityFrameworkCore;
using Postgre.Domain.Entities;
using Postgre.Persistence.EFCore20.Mappings;

namespace Postgre.Persistence.EFCore20
{
    public partial class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfiguration(new CustomerMap());

        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
