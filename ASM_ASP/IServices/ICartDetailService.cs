using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface ICartDetailService
    {
        public bool Create(CartDetail c);
        public bool Update(Guid productId, Guid userId, CartDetail obj);
        public bool Delete(Guid productId, Guid userId);
        public List<CartDetail> GetAll();
        public CartDetail GetById(Guid productId, Guid userId);
    }
}
