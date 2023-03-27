using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASM_ASP.Models;


namespace ASM_ASP.Configurations
{
    public class BillDetailConfig : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => new { x.Id });
            builder.Property(p => p.Quantity).IsRequired().HasColumnType("int");
            builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).HasForeignKey(p => p.BillId);
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails).HasForeignKey(p => p.ProductId);
        }
    }
}
    