using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface ICartService
    {
        public bool Create(Cart c); 
        public bool Update(Cart c);
        public bool Delete(Guid id); 
        public List<Cart> GetAll(); 
        public Cart GetById(Guid id);
    }

}
