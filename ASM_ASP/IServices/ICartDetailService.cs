using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface ICartDetailService
    {
        public bool CreateCartDetail(CartDetail c);
        public bool UpdateCartDetail(CartDetail c);
        public bool DeleteCartDetail(Guid id);
        public List<CartDetail> GetAllCartDetails();
        public CartDetail GetCartDetailById(Guid id);
    }
}
