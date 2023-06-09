﻿namespace ASM_ASP.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateofCreation { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public virtual User User { get; set; }


    }
}
