using Jakoben.FileReader.Abstraction;
using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using Jakoben.FileReader.Models;

namespace Jakoben.FileReader.Concretes
{
    public class CsvFile : BaseFile
    {
        public CsvFile(string path, List<ValidationItem> validationList) : base(path, validationList) { }

        public override void Read()
        {
            using (TextFieldParser csvParser = new TextFieldParser(Path))
            {
                //csv file text formats
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Get column names
                var columnsStr = csvParser.ReadLine();
                var columns = !String.IsNullOrEmpty(columnsStr) ? columnsStr.Split(',') : new string[0];
                //read all fields from csv
                var index = 1;
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    //Create a dynamic object and add to list
                    AddValueList(fields, columns, index);
                    index++;
                }
            }
        }
    }
}
