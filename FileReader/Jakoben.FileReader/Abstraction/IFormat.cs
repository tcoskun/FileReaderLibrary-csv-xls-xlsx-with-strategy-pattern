using Jakoben.FileReader.Models;

namespace Jakoben.FileReader.Abstraction
{
    public interface IFormat
    {
        FormatItem Format(dynamic value, string itemName);
    }
}
