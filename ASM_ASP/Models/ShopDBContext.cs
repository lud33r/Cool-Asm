using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;

namespace ASM_ASP.Models
{
    public class ShopDBContext:DbContext
    {
        public ShopDBContext() { }
        public ShopDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LEMINHHIEU\SQLEXPRESS;Initial Catalog=ShoesShop;Persist Security Info=True;User ID=lmaohieu;Password=1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
