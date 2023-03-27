using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ASM_ASP.Models;

namespace ASM_ASP.Configurations
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(p => new { p.Id });
            builder.HasOne(p => p.User).WithMany(p => p.Bills).HasForeignKey(p => p.UserId);
        }
    }
}
