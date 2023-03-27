using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IProductService
    {
        public bool CreateProduct(Product c);
        public bool UpdateProduct(Product c);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
    }
}
