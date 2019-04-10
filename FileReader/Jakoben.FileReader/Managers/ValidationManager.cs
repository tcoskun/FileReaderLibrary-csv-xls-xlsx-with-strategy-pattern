using Jakoben.FileReader.Abstraction;
using System;

namespace Jakoben.FileReader.Managers
{
    public class ValidationManager : IValidationManager
    {
        private readonly string typeNameFormat = "Jakoben.FileReader.Validations.{0},Jakoben.FileReader";

        /// <summary>
        /// The ValidateData method is used to call the validation method with the corresponding parameter
        /// </summary>
        /// <param name="validationName"></param>
        /// <param name="data"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool ValidateData(string validationName, string data, object parameter = null)
        {
            //Get class type from name
            var typeName = String.Format(typeNameFormat, validationName);
            Type type = Type.GetType(typeName);
            //Create object and call Validate method
            var validation = Activator.CreateInstance(type) as IValidation;
            return validation.Validate(data, parameter);
        }
    }
}
