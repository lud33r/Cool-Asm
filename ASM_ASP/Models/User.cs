using System.Data;

namespace ASM_ASP.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
