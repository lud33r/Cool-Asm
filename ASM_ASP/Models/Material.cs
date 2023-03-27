﻿namespace ASM_ASP.Models
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual ICollection<Product> Products{ get; set; }
    }
}
