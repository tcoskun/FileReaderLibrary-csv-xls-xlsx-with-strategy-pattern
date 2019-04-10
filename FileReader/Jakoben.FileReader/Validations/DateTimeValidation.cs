using Jakoben.FileReader.Abstraction;
using System;

namespace Jakoben.FileReader.Validations
{
    public class DateTimeValidation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            DateTime value = DateTime.MinValue;
            return DateTime.TryParse(data, out value);
        }
    }
}
