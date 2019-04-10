using Jakoben.FileReader.Models;

namespace Jakoben.FileReader.Abstraction
{
    public interface IFormatManager
    {
        FormatItem FormatData(IFormat formatType, BaseFile file, string itemName = "");
    }
}
