using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.Entities
{
    public class State
    {
        public State()
        {
            this.CreatedDate = DateTime.Now;
            this.CountryId = 1;             // for India
        }
        public int StateId { get; set; } 
        public string StateName { get; set; }
        public int CountryId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
