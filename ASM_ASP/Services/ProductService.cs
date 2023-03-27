using ASM_ASP.IServices;
using ASM_ASP.Models;

namespace ASM_ASP.Services
{
    public class ProductService : IProductService
    {
        ShopDBContext shopDBContext;
        public ProductService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool CreateProduct(Product c)
        {
            try
            {
                shopDBContext.Products.Add(c);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                dynamic shoe = shopDBContext.Products.Find(id);
                shopDBContext.Products.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return shopDBContext.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return shopDBContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return shopDBContext.Products.Where(p => p.Name.Contains(name)).ToList();    
        }

        public bool UpdateProduct(Product c)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.Products.Find(c.Id);
                shoe.Name = c.Name;
                shoe.Description = c.Description;
                shoe.Stock = c.Stock;
                shoe.Price = c.Price;
                shoe.Status = c.Status;               
                shopDBContext.Products.Update(shoe);
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
