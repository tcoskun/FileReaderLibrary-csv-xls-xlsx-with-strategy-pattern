using Jakoben.FileReader.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Jakoben.FileReader.Validations
{
    public class URLValidation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            if (String.IsNullOrEmpty(data))
            {
                return false;
            }
            else
            {
                var isWellFormedUriString = Uri.IsWellFormedUriString(data, UriKind.Absolute);
                return isWellFormedUriString;
            }
        }
    }
}
