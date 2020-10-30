using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ViewModels
{
    public class UserLoginModel
    {
        public int UserLoginId { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserId { get; set; }
    }
}
