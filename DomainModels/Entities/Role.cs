using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Role
    {
        public Role()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Descritption { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
