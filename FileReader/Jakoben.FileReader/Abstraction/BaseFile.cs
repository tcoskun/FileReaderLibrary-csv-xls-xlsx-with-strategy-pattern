using Jakoben.FileReader.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
namespace Jakoben.FileReader.Abstraction
{
    public abstract class BaseFile
    {
        private const string FilePathNotExist = "File path is not exist!";
        private const string DefaultSheetName = "Sheet1";
        protected string Path { get; set; }
        protected List<dynamic> ValueList { get; }
        protected List<ValidationItem> ValidationList { get; set; }
        protected List<ValidationError> ErrorList { get; }
        protected string SheetName { get; }
        protected BaseFile(string path, List<ValidationItem> validationList, string sheetName = DefaultSheetName)
        {
            var directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Path = String.Format("{0}\\{1}", directoryPath, path);
            if (!File.Exists(Path))
            {
                throw new Exception(FilePathNotExist);
            }

            ValidationList = validationList;
            SheetName = sheetName;
            ValueList = new List<dynamic>();
            ErrorList = new List<ValidationError>();
        }
        protected void AddValueList(string[] fields, string[] columns, int rowIndex)
        {
            dynamic expandoObject = new ExpandoObject();
            var validationManager = FileReaderContext.Get<IValidationManager>();
            var isValid = true;
            //for loop is used for each column name
            for (var index = 0; index < columns.Length; index++)
            {
                //find column from fields index
                var column = columns[index];
                //find data from fields index
                var data = fields[index];
                //create expando object
                var validationItems = ValidationList.Where(i => i.PropertyName == column).ToArray();
                //if exist a validation for the property
                if (validationItems != null && validationItems.Length > 0)
                {
                    foreach (var validationItem in validationItems)
                    {
                        isValid = validationManager.ValidateData(validationItem.ValidationName, data, validationItem.Parameter);

                        if (!isValid)
                        {
                            var validationError = new ValidationError();
                            validationError.RowNumber = rowIndex;
                            validationError.ColumnName = column;
                            validationError.Data = data;
                            validationError.ValidationMessage = validationItem.ValidationMessage;
                            ErrorList.Add(validationError);
                            expandoObject = null;
                            return;
                        }
                    }
                }
                ((IDictionary<string, object>)expandoObject).Add(column, data);
            }
            ValueList.Add(expandoObject);
            expandoObject = null;
        }
        public abstract void Read();

        public List<dynamic> GetValueList()
        {
            return ValueList;
        }
        public List<T> GetValueList<T>()
        {
            var json = JsonConvert.SerializeObject(ValueList);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
        public List<ValidationError> GetErrorList()
        {
            return ErrorList;
        }
    }
}
