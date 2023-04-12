using ASM_ASP.IServices;
using ASM_ASP.Models;

namespace ASM_ASP.Services
{
    public class CartService : ICartService
    {
        ShopDBContext shopDBContext;
        public CartService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool Create(Cart c)
        {
            try
            {
                shopDBContext.Carts.Add(c);
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
                var shoe = shopDBContext.Carts.Find(id);
                shopDBContext.Carts.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cart> GetAll()
        => shopDBContext.Carts.ToList();

        public Cart GetById(Guid id)
        => shopDBContext.Carts.FirstOrDefault(c=>c.UserId == id);

        public bool Update(Cart c)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.Carts.Find(c.UserId);
                shoe.Description = c.Description;


                shopDBContext.Carts.Update(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCart(Cart c)
        {
            throw new NotImplementedException();
        }
    }
}
