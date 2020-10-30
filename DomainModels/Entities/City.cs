using System;

namespace DomainModels.Entities
{
    public class City
    {
        public City()
        {
            this.CreateDate = DateTime.Now;
        }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
