using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Validations
{
    public sealed class ValidCreatedDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? DefaultErrorMessage);
            }

            var created = Convert.ToDateTime(value);
            return created > DateTime.Today ? new ValidationResult(ErrorMessage ?? DefaultErrorMessage) : ValidationResult.Success;
        }

        private const string DefaultErrorMessage = "Must equal or greater than tody";
    }
}