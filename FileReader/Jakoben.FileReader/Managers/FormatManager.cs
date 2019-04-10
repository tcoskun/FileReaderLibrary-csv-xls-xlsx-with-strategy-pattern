using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Models;
using System;

namespace Jakoben.FileReader.Managers
{
    public class FormatManager : IFormatManager
    {
        /// <summary>
        /// The FormatData method is used to convert a file into a format that users want
        /// </summary>
        /// <param name="formatType"></param>
        /// <param name="file"></param>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public FormatItem FormatData(IFormat formatType, BaseFile file, string itemName = "")
        {
            return formatType.Format(file.GetValueList(), itemName);
        }
    }
}
