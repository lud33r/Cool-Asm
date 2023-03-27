using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IBillService
    {
        public bool CreateBill(Bill c);
        public bool UpdateBill(Bill c);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
    }
}
