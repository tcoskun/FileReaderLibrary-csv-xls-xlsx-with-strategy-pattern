
namespace Jakoben.FileReader.Models
{
    public class ValidationItem
    {
        public string PropertyName { get; }
        public string ValidationName { get; }
        public object Parameter { get; }
        public string ValidationMessage { get; }

        public ValidationItem(string propertyName, string validationName, string validationMessage, object parameter = null)
        {
            PropertyName = propertyName;
            ValidationName = validationName;
            Parameter = parameter;
            ValidationMessage = validationMessage;
        }
    }
}
