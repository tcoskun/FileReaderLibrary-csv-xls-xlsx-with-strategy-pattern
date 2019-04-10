
using Jakoben.FileReader.Abstraction;

namespace Jakoben.FileReader.Managers
{
    public class FileReaderManager : IFileReaderManager
    {
        /// <summary>
        /// The ReadFile method reads any file derived from BaseFile
        /// </summary>
        /// <param name="file"></param>
        public void ReadFile(BaseFile file)
        {
            file.Read();
        }
    }
}
