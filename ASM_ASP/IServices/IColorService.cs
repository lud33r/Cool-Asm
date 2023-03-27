using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IColorService
    {
        public bool CreateColor(Color c);
        public bool UpdateColor(Color c);
        public bool DeleteColor(Guid id);
        public List<Color> GetAllColors();
        public Color GetColorById(Guid id);
        public List<Color> GetColorByName(string name);

    }
}
