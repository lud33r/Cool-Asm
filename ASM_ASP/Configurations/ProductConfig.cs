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
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Description).HasColumnType("nvarchar(100)");
            builder.HasOne(p => p.Color).WithMany(p => p.Products).HasForeignKey(p => p.IdColor).HasConstraintName("FK_Color");
            builder.HasOne(p => p.Size).WithMany(p => p.Products).HasForeignKey(p => p.IdSize).HasConstraintName("FK_Size");
            builder.HasOne(p => p.Material).WithMany(p => p.Products).HasForeignKey(p => p.IdMaterial).HasConstraintName("FK_Material");
        }
    }
}
