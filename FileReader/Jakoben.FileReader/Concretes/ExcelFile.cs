using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Constants;
using Jakoben.FileReader.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace Jakoben.FileReader.Concretes
{
    public class ExcelFile : BaseFile
    {
        private const string XLSConnectionFormat = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'";
        private const string XLSXConnectionFormat = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
        private const string OleDBQueryFormat = "SELECT * FROM [{0}$]";
        private const string TemporaryTableName = "ExcelTable";
        public ExcelFile(string path, List<ValidationItem> validationList, string sheetName) : base(path, validationList, sheetName) { }

        public override void Read()
        {
            var extension = System.IO.Path.GetExtension(Path);
            if (extension != ExtensionConstants.XLSExtension && extension != ExtensionConstants.XLSXExtension)
            {
                throw new FormatException();
            }
            var connectionFormat = extension == ExtensionConstants.XLSExtension ? XLSConnectionFormat : XLSXConnectionFormat;
            var connection = String.Format(connectionFormat, Path);
            var adapter = new OleDbDataAdapter(String.Format(OleDBQueryFormat, SheetName), connection);

            var ds = new DataSet();
            adapter.Fill(ds, TemporaryTableName);

            DataTable data = ds.Tables[TemporaryTableName];
            var columns = data.Columns.Cast<dynamic>().Select(item => item.ColumnName).Cast<string>().ToArray();

            for (int index = 0; index < data.Rows.Count; index++)
            {
                //Create field list
                var fields = data.Rows[index].ItemArray.Select(r => r.ToString()).ToArray();
                //Create a dynamic object and add to list
                AddValueList(fields, columns, index + 1);
            }
        }
    }
}
