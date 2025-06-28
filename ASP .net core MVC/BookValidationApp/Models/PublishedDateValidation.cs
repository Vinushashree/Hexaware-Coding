using System;
using System.ComponentModel.DataAnnotations;

namespace BookValidationApp.Models
{
    public class PublishedDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Now;
            }
            return false;
        }
    }
}
