using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASM_ASP.Models;


namespace ASM_ASP.Configurations
{
    public class BillDetailConfig : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdBill).HasConstraintName("FK_Bill");
            builder.HasOne(p => p.Product).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.IdProduct).HasConstraintName("FK_Product");
        }
    }
}
    