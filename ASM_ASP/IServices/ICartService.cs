using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface ICartService
    {
        public bool CreateCart(Cart c);
        public bool UpdateCart(Cart c);
        public bool DeleteCart(Guid id);
        public List<Cart> GetAllCarts();
        public Cart GetCartById(Guid id);
    }

}
