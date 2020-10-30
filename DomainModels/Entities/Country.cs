using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DomainModels.Entities
{
    public class Country
    {
        public Country()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
