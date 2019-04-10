
namespace Jakoben.FileReader.Models
{
    public class ValidationError
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string Data { get; set; }
        public string ValidationMessage { get; set; }
    }
}
