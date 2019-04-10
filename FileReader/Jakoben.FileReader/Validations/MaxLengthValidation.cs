using Jakoben.FileReader.Abstraction;
using System;

namespace Jakoben.FileReader.Validations
{
    public class MaxLengthValidation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            return !String.IsNullOrEmpty(data) && data.Length <= (int)parameter;
        }
    }
}
