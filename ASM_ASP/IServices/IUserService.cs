using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IUserService
    {
        public bool CreateUser(User c);
        public bool UpdateUser(User c);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string userName);
    }
}
