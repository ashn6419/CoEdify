using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Tasks : TaskType
    {
        public int TaskId { get; set; }
        public new string Description { get; set; }
        public DateTime Due_date { get; set; }
        public bool IsComplete { get; set; }
        public bool? IsParent { get; set; }
        public new DateTime CreatedDate { get; set; }
        public new DateTime ModifiedDate { get; set; }
        public int UserId { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsReminder { get; set; }
        public new bool IsActive { get; set; }
    }  
}
