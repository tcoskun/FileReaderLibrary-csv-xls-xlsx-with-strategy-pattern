using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Constants;
using Jakoben.FileReader.Models;
using Newtonsoft.Json;

namespace Jakoben.FileReader.Concretes
{
    public class JSONFormat : IFormat
    {
        public FormatItem Format(dynamic value, string itemName)
        {
            //Get formatted json from string
            var data = JsonConvert.SerializeObject(value, Formatting.Indented);
            return new FormatItem(data, ExtensionConstants.JSONExtension);
        }
    }
}
