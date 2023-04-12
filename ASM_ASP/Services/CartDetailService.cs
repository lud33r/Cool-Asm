using ASM_ASP.IServices;
using ASM_ASP.Models;
using Microsoft.CodeAnalysis;

namespace ASM_ASP.Services
{
    public class CartDetailService : ICartDetailService
    {
        ShopDBContext shopDBContext;
        public CartDetailService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool Create(CartDetail c)
        {
            try
            {
                shopDBContext.CartDetails.Add(c);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Guid productId, Guid userId)
        {
            try
            {
                var list = shopDBContext.CartDetails.ToList();
                var obj = list.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

                shopDBContext.Remove(obj);
                shopDBContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetail> GetAll() => shopDBContext.CartDetails.ToList();


        public CartDetail GetById(Guid productId, Guid userId)
        {
            var list = shopDBContext.CartDetails.ToList();
            var obj = list.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
            if (obj == null)
        {
                return new CartDetail();
            }
            return obj;
        }

        public bool Update(Guid productId, Guid userId, CartDetail obj)
        {
            try
        {
                var listObj = shopDBContext.CartDetails.ToList();
                var objForUpdate = listObj.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);

                objForUpdate.Quantity = obj.Quantity;
                objForUpdate.Status = obj.Status;

                shopDBContext.CartDetails.Update(objForUpdate);
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
