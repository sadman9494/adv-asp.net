using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using validation_labtask.Customvalidation;

namespace validation_labtask.Models
{
    public class student
    {
        [Required ]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should contain 3 to 30 characters")]
        [RegularExpression(@"^[a-zA-Z-. ]*$", ErrorMessage = "can not contain any digit and special charecter")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d\d-\d\d\d\d\d-\d{1,3}", ErrorMessage = "id must be  xx-xxxxx-x")]

        public string ID { get; set; }

        [Required]
        
        [RegularExpression(@"^\d\d-\d\d\d\d\d-\d{1,3}@student\.aiub\.edu$", ErrorMessage = "email must contain @student.aiub.edu")]
        [Custom_Validation ( ErrorMessage ="your email must contain your id " )]
        public string Email { get; set; }

        [Required]
        public string Dob { get; set; }

        [Required]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])", ErrorMessage ="Password must contain atleast one upper, lower case , digit and special charecter")]
        public string Password { get; set; }

        public string Gender { get; set; }

        [Compare("Password")]
        public string ConfPassword { get; set; }


    }
}