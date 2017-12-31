using System.Data.Entity.ModelConfiguration;
using Postgre.Domain.Entities;

namespace Postgre.Persistence.NETFull70.EF62.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            this.ToTable("public.customer");

            this.HasKey<long>(a => a.Id);

            this.Property(x => x.Id)
                .HasColumnName("id");

            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("name");
        }
    }
}
