using Jakoben.FileReader.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakoben.FileReader.Validations
{
    public class IntegerValidation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            int value = 0;
            return Int32.TryParse(data, out value);
        }
    }
}
