using Jakoben.FileReader.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jakoben.FileReader.Validations
{
    public class UTF8Validation : IValidation
    {
        public bool Validate(string data, object parameter = null)
        {
            if (String.IsNullOrEmpty(data))
            {
                return false;
            }
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(data);
                var encodedData = Encoding.UTF8.GetString(bytes);
                return data == encodedData;
            }
        }
    }
}
