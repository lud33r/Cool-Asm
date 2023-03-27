using ASM_ASP.Models;

namespace ASM_ASP.IServices
{
    public interface IMaterialService
    {
        public bool CreateMaterial(Material c);
        public bool UpdateMaterial(Material c);
        public bool DeleteMaterial(Guid id);
        public List<Material> GetAllMaterials();
        public Material GetMaterialById(Guid id);
        public List<Material> GetMaterialByName(string name);

    }
}


