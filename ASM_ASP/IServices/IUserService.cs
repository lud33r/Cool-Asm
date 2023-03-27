using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IUserService
    {
        public bool Create(User p);
        public bool Update(User p);
        public bool Delete(Guid id);
        public List<User> GetAll();
        public User GetById(Guid id);
        public List<User> GetByName(string name);
        public User GetByEmail(string email);
    }
}
