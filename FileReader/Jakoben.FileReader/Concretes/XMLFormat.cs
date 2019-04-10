using Jakoben.FileReader.Abstraction;
using Jakoben.FileReader.Constants;
using Jakoben.FileReader.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Jakoben.FileReader.Concretes
{
    public class XMLFormat : IFormat
    {
        private const string HeaderName = "Result";
        public FormatItem Format(dynamic value, string itemName)
        {
            //Directory xml object
            var result = new XElement(HeaderName);
            var list = value as List<object>;

            foreach (var item in list)
            {
                var listElement = new XElement(itemName);
                //Get members of dynamic object
                Dictionary<string, object> members = new Dictionary<string, object>(((IDictionary<String, Object>)item));
                foreach (var member in members)
                {
                    var element = new XElement(member.Key);
                    element.Value = member.Value.ToString();
                    //Add to xml object property from dynmaic object property
                    listElement.Add(element);
                }
                //Add item to directory xml object
                result.Add(listElement);
            }
            return new FormatItem(result.ToString(), ExtensionConstants.XMLExtension);
        }
    }
}
