using ASM_ASP.IServices;
using ASM_ASP.Models;

namespace ASM_ASP.Services
{
    public class UserService : IUserService
    {
        ShopDBContext shopDBContext;
        public UserService()
        {
            shopDBContext = new ShopDBContext();
        }
        public bool Create(User c)
        {
            try
            {
                shopDBContext.Users.Add(c);
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
                dynamic shoe = shopDBContext.Users.Find(id);
                shopDBContext.Users.Remove(shoe);
                shopDBContext.SaveChanges();
                return true;
        }
            catch (Exception)
            {

                return false;
            }
        }

        public List<User> GetAll()
        => shopDBContext.Users.ToList();

        public List<User> GetAll(Guid roleId)
        => shopDBContext.Users.Where(c => c.RoleId == roleId).ToList();
        public User GetById(Guid id)
        => shopDBContext.Users.FirstOrDefault(c => c.Id == id);

        public List<User> GetByName(string userName)
        => shopDBContext.Users.Where(c => c.Name.Contains(userName)).ToList();

        public User GetByEmail(string email) => shopDBContext.Users.FirstOrDefault(c => c.Email == email);
        
        public bool Update(User c)
        {
            try
            {// Find(id) chỉ dùng được khi id là khóa chính
                var shoe = shopDBContext.Users.Find(c.Id);
                shoe.Name = c.Name;
                shoe.RoleId = c.RoleId;
                shoe.Password = c.Password;
                shoe.Status = c.Status;
                shopDBContext.Users.Update(shoe);
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
