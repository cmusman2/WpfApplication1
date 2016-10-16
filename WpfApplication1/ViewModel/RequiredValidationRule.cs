using System;
using System.Windows.Controls;
namespace WpfApplication1.ViewModel
{
    public class RequiredValidationRule : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            if (value == null || object.ReferenceEquals(value, DBNull.Value))
            {
                result = new ValidationResult(false, "Required!");
            }
            return result; 
        }
    }
}