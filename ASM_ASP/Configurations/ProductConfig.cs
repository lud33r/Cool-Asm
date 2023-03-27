using ASM_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_ASP.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.ImageDirection).HasColumnName("varchar(500)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");

        }
    }
}
