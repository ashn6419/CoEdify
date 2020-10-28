using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Entities
{
    public class User : UserLogin
    {
        public User()
        {
            this.CreateDate = DateTime.Now;
        }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your name!")]
        public string UserName { get; set; }
        public string Address { get; set; }
        public DateTime? Date_Of_Birth { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [RegularExpression(@"^[6,7,8,9]\d{9}$", ErrorMessage = "Please Enter Correct Contact")]
        public Int64 ContactNo { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select qualification.")]
        public int QualificationId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModificationDate { get; set; }


    }
}
