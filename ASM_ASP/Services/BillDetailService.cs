using ASM_ASP.IServices;
using ASM_ASP.Models;

namespace ASM_ASP.Services
{
    public class BillDetailService : IBillDetailService
    {
        ShopDBContext shopDBContext;
        public BillDetailService()
        {
            shopDBContext = new ShopDBContext(); 
        }
        public bool Create(BillDetail c)
        {
            try
            {
                shopDBContext.BillDetail.Add(c);
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
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.BillDetail.Find(id);
                shopDBContext.BillDetail.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
        {
                return false;
            }
        }

        public List<BillDetail> GetAll()
        {
            return shopDBContext.BillDetail.ToList();
        }

        public BillDetail GetById(Guid id)
        {
            return shopDBContext.BillDetail.FirstOrDefault(x => x.Id == id);
        }

        public bool Update(BillDetail c)
        {
            
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.BillDetail.Find(c.Id);
                shoe.ProductId = c.ProductId;
                shoe.Quantity = c.Quantity;
                shoe.Price = c.Price;
                shopDBContext.BillDetail.Update(shoe);
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
