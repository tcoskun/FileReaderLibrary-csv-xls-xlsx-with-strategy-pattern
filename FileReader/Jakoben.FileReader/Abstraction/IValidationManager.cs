using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakoben.FileReader.Abstraction
{
    public interface IValidationManager
    {
        bool ValidateData(string validationName, string data, object parameter = null);
    }
}
