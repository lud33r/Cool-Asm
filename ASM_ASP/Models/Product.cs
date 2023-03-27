namespace ASM_ASP.Models
{
    public class Product
    {
        public Guid Id { get; set; } 
        public Guid? IdColor { get; set; }
        public Guid? IdMaterial { get; set; }
        public Guid? IdSize { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual Material Material { get; set; }
        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }      
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
