namespace ASM_ASP.Models
{
    public class BillDetail
    {
        public Guid Id { get; set; }
        public Guid? IdProduct { get; set; }
        public Guid? IdBill { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
