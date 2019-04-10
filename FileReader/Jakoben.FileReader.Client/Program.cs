using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Jakoben.FileReader;
using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Concretes;
using Jakoben.FileReader.Constants;
using Jakoben.FileReader.Models;

namespace Jakoben.FileReader.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading file starts.");

            FileReaderContext.InitializeContext();
            var fileReaderManager = FileReaderContext.Get<IFileReaderManager>();
            var formatManager = FileReaderContext.Get<IFormatManager>();

            //we can set validation list which we want validate any area 
            var validationList = new List<ValidationItem>();
            validationList.Add(new ValidationItem("name", ValidationNameConstants.UTF8Validation, "Name value must be UTF8 format."));
            validationList.Add(new ValidationItem("uri", ValidationNameConstants.URLValidation, "Uri value must be url format."));
            validationList.Add(new ValidationItem("stars", ValidationNameConstants.IntegerValidation, "Starts value must be integer."));
            validationList.Add(new ValidationItem("name", ValidationNameConstants.MaxLengthValidation, "Name value max length must be 5.", 5));

            Console.WriteLine("Reading CSV file");

            //csv file operations
            var csvFile = new CsvFile("Data\\hotels.csv", validationList);
            fileReaderManager.ReadFile(csvFile);
            var csvValueList = csvFile.GetValueList<ExcelData>();
            var csvErrorList = csvFile.GetErrorList();

            Console.WriteLine("Reading XLS file");

            //excel file operations(xls)
            var xlsExcelFile = new ExcelFile("Data\\hotels.xlsx", validationList, "hotels");
            fileReaderManager.ReadFile(xlsExcelFile);
            var xlsExcelValueList = csvFile.GetValueList<ExcelData>();
            var xlsExcelErrorList = csvFile.GetErrorList();

            Console.WriteLine("Reading XLSX file");

            //excel file operations(xlsx)
            var xlsxExcelFile = new ExcelFile("Data\\hotels.xls", validationList, "hotels");
            fileReaderManager.ReadFile(xlsxExcelFile);
            var xlsxExcelValueList = csvFile.GetValueList<ExcelData>();
            var xlsxExcelErrorList = csvFile.GetErrorList();

            //convert csv file to XML
            Console.WriteLine("Translating data into xml format.");

            var xmlFormat = formatManager.FormatData(new XMLFormat(), csvFile, "Hotel");
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xmlFormat.Data);
            var xmlName = string.Concat("Data\\hotels.", xmlFormat.Extension);
            var xmlPath = GetPath(xmlName);
            xdoc.Save(xmlPath);

            //convert xls excel file to XML
            Console.WriteLine("Translating data into json format.");

            var jsonFormat = formatManager.FormatData(new JSONFormat(), xlsExcelFile);
            var jsonName = string.Concat("Data\\hotels.", jsonFormat.Extension);
            var jsonPath = GetPath(jsonName);
            File.WriteAllText(jsonPath, jsonFormat.Data);


            Console.WriteLine("Process is finished. Check 'Data' folder in project for outputs.");
            Console.ReadKey();
        }
        private static string GetPath(string path)
        {
            var directoryPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            return String.Format("{0}\\{1}", directoryPath, path);
        }
    }
    public class ExcelData
    {
        public string name { get; set; }
        public string address { get; set; }
        public int stars { get; set; }
        public string contact { get; set; }
        public string phone { get; set; }
        public string uri { get; set; }
    }
}
