using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Mango.Web.Utility
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailAddressAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "The {0} field is not a valid e-mail address.";

        public EmailAddressAttribute() : base(DefaultErrorMessage) { }

        public override bool IsValid(object value)
        {
            if (value == null || !(value is string email))
            {
                return true; // 
            }

            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
