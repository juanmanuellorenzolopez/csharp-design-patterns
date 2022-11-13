using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AdapterPattern
{
    public class XmlConverter
    {
        public XDocument GetXML()
        {
            var xDocument = new XDocument();
            var xElement = new XElement("Manufacturers");
            var xAttributes = ManufacturerDataProvider.GetData()
                .Select(m => new XElement("Manufacturer", 
                                    new XElement("City", m.City),
                                    new XElement("Name", m.Name),
                                    new XElement("Year", m.Year)));

            xElement.Add(xAttributes);
            xDocument.Add(xElement);

            Console.WriteLine(xDocument);

            return xDocument;
        }
    }
}
