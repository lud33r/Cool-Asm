using ASM_ASP.IServices;
using ASM_ASP.Models;
using System.Data;

namespace ASM_ASP.Services
{
    public class RoleService : IRoleService
    {
        ShopDBContext shopDBContext;
        public RoleService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool Create(Role p)
        {
            try
            {
                shopDBContext.Roles.Add(p);
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
                var shoe = shopDBContext.Roles.Find(id);
                shopDBContext.Roles.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAll()
        =>shopDBContext.Roles.ToList();

        public Role GetById(Guid id)
        =>shopDBContext.Roles.FirstOrDefault(x => x.Id == id);

        public List<Role> GetByName(string name)
        => shopDBContext.Roles.Where(x=>x.Name.Contains(name)).ToList();

        public bool Update(Role p)
        {
            try
            {
                var shoe = shopDBContext.Roles.Find(p.Id);
                shoe.Name = p.Name;
                shoe.Description = p.Description;
                shoe.Status = p.Status;
                // Có thể sửa thêm thuộc tính
                shopDBContext.Roles.Update(shoe);
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
