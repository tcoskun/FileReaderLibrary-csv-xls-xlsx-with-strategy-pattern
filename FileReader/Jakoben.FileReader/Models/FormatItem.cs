
namespace Jakoben.FileReader.Models
{
    public class FormatItem
    {
        public string Data { get; }
        public string Extension { get; }

        public FormatItem(string data, string extension)
        {
            Data = data;
            Extension = extension;
        }
    }
}
