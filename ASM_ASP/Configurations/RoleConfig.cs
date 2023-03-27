using ASM_ASP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_ASP.Configurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("varchar(100)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");
        }
    }
}
