using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public string Description { get; set; }

        public DateTime Due_date { get; set; }

        public bool IsComplete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool IsActive { get; set; }
    }

    public class TaskItem : Tasks
    {
        public int TaskItemId { get; set; }
        public string Item { get; set; }
        public new bool IsComplete { get; set; }

        public new DateTime CreatedDate { get; set; }
        public new DateTime ModifiedDate { get; set; }

        public new bool IsActive { get; set; }
    }
}
