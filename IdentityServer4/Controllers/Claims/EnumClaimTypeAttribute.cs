using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCTS.IdentityServer4.Controllers.Claims
{

    

    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultClaimTypeAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "Default Claims Type Incorrect";

        //public ClaimTypeEnum EnumVal { get; private set; }

        //public EnumClaimTypeAttribute(ClaimTypeEnum enumVal)
        //    : base(DefaultErrorMessage)
        //{
        //    EnumVal = enumVal;
        //}

        //public override string FormatErrorMessage(string name)
        //{
        //    return string.Format(ErrorMessageString, name, EnumVal);
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ClaimTypeEnum enumValue;

            if (value != null)
            {
                if (!Enum.TryParse<ClaimTypeEnum>(value.ToString(), out enumValue))
                {
                    return new ValidationResult(DefaultErrorMessage);
                }

            }
            return ValidationResult.Success;
        }
    }
}
