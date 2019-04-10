using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakoben.FileReader.Abstraction
{
    public interface IValidation
    {
        bool Validate(string data, object parameter = null);
    }
}
