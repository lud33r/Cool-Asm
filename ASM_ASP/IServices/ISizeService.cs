using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface ISizeService
    {
        public bool CreateSize(Size c);
        public bool UpdateSize(Size c);
        public bool DeleteSize(Guid id);
        public List<Size> GetAllSizes();
        public Size GetSizeById(Guid id);
    }
}
