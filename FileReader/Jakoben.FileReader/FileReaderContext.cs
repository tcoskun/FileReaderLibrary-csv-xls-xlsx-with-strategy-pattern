using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Jakoben.FileReader
{
    public class FileReaderContext
    {
        private static UnityContainer container = new UnityContainer();
        //Register managers as singleton
        public static void InitializeContext()
        {
            container.RegisterType<IFileReaderManager, FileReaderManager>();
            container.RegisterType<IValidationManager, ValidationManager>();
            container.RegisterType<IFormatManager, FormatManager>();
        }
        public static T Get<T>()
        {
            return container.Resolve<T>();
        }
    }
}
