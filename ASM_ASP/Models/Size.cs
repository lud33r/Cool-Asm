namespace ASM_ASP.Models
{
    public class Size
    {
        public Guid Id { get; set; }
        public int SizeOfShoe { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}
