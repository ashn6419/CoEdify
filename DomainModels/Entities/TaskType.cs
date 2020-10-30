using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class TaskType
    {
        public TaskType()
        {
            this.CreatedDate = DateTime.Now;
            this.IsActive = true;
        }
        public int TaskTypeId { get; set; }
        public int TaskTypeName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
