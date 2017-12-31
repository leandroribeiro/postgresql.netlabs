using System.Data.Entity;
using Postgre.Domain.Entities;
using Postgre.Persistence.NETFull70.EF62.Mappings;

namespace Postgre.Persistence.NETFull70.EF62
{
    public partial class MainContext : DbContext
    {
        public MainContext()
            : base("name=MainContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
        }
    }
}
