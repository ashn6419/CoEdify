using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Qualification 
    {
        public Qualification()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; } 
    }
}
