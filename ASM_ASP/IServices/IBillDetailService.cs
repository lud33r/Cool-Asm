using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IBillDetailService
    {
        public bool Create(BillDetail c);
        public bool Update(BillDetail c);
        public bool Delete(Guid id);
        public List<BillDetail> GetAll();
        public BillDetail GetById(Guid id);
        

    }
}
