using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using validation_labtask.Models;

namespace validation_labtask.Customvalidation
{
    public class Custom_Validation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext  )
        {
            if (value != null)
            {
                string id = value.ToString();
                if (id.Contains("20-43435-1"))
                {
                    return ValidationResult.Success;
                }
                else
                    return new ValidationResult(ErrorMessage = "your email must contain your id");


            }
            return  new ValidationResult(ErrorMessage = "provide a valid email");
        }
    }
}