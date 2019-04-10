using Jakoben.FileReader.Abstraction;

namespace Jakoben.FileReader.Validations
{
    public class DecimalValidation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            decimal value = 0;
            return decimal.TryParse(data, out value);
        }
    }
}
