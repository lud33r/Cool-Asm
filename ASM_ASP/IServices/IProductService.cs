using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IProductService
    {
        public bool Create(Product c); 
        public bool Update(Product c);
        public bool Delete(Guid id); 
        public List<Product> GetAll(); 
        public Product GetById(Guid id);
        public List<Product> GetByName(string name);
    }
}
