using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text;

namespace DomainModels.Entities
{
    public class UserLogin : Role
    {
        public UserLogin()
        {
            this.CreatedDate = DateTime.Now;
        }
        public int UserLoginId { get; set; }

        [Required(ErrorMessage = "Plesae enter email!")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Valid Email !")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Plesae enter password!")]
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public new DateTime CreatedDate { get; set; }

        public new DateTime? ModifiedDate { get; set; }

    }
}
