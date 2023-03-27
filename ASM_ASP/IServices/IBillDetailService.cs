using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IBillDetailervice
    {
        public bool CreateBillDetail(BillDetail c);
        public bool UpdateBillDetail(BillDetail c);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);
        

    }
}
