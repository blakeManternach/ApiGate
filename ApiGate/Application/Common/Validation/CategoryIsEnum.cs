using ApiGate.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGate.Application.Common.Validation
{
    public class CategoryIsEnum : ValidationAttribute
    {
        public CategoryIsEnum()
        {
        }
        public string GetErrorMessage() =>
            "Category must be one of the following: ARTS_AND_ENTERTAINMENT, JOURNALISM_AND_ACADEMICS, POLITICS, SPORTS, TECHNOLOGY, FILM_AND_TELEVISION, OR OTHER";
    


        protected override ValidationResult 
                IsValid(object value, ValidationContext validationContext)
        {   
            try
            {
                var correctlyFormattedValue = value.ToString().Trim(' ').Replace(' ', '_');
                var result = (GateCategory)Enum.Parse(typeof(GateCategory), correctlyFormattedValue, true);
            } catch (Exception e)
            {
                return new ValidationResult(e.GetType() + ": " + GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
