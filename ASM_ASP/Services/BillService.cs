using ASM_ASP.IServices;
using ASM_ASP.Models;

namespace ASM_ASP.Services
{
    public class BillService : IBillService
    {
        ShopDBContext shopDBContext;
        public BillService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool Create(Bill c)
        {
            try
            {
                shopDBContext.Bills.Add(c);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(Guid id)
        {
            try
            {
                dynamic shoe = shopDBContext.Bills.Find(id);
                shopDBContext.Bills.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Bill> GetAll()
        => shopDBContext.Bills.ToList();

        public Bill GetById(Guid id)
        => shopDBContext.Bills.FirstOrDefault(b => b.Id == id);
        

        public bool Update(Bill c)
        {

            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.Bills.Find(c.Id);
                shoe.Status = c.Status;
                
                shopDBContext.Bills.Update(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
