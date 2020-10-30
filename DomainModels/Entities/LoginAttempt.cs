using System;

namespace DomainModels.Entities
{
    public class LoginAttempt
    {
        public LoginAttempt()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int LoginAttemptId { get; set; } 
        public DateTime? LastLoginTimeStamp { get; set; }
        public int UserId { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsActive { get; set; }
        public string IP_Address { get; set; }
        public bool IsSuccess { get; set; }
    }
}
