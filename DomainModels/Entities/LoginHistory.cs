using System;

namespace DomainModels.Entities
{
    public class LoginHistory
    {
        public LoginHistory()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int LoginHistoryId { get; set; }
        public DateTime? LastLoginTimeStamp { get; set; }
        public int UserLoginId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public string IP_Address { get; set; }
        public bool IsSuccess { get; set; }
    }
}
