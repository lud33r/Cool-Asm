using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IBillService
    {
        public bool Create(Bill c);
        public bool Update(Bill c);
        public bool Delete(Guid id);
        public List<Bill> GetAll();
        public Bill GetById(Guid id);
    }
}
