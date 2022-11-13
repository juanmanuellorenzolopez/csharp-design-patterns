using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class XmlToJsonAdapter : IXmlToJson
    {
        private readonly XmlConverter _xmlConverter;

        public XmlToJsonAdapter(XmlConverter xmlConverter)
        {
            _xmlConverter = xmlConverter;
        }

        public void ConvertXmlToJson()
        {
            var manufacturers = _xmlConverter.GetXML()
                    .Element("Manufacturers")
                    .Elements("Manufacturer")
                    .Select(m => new Manufacturer
                                 {
                                    City = m.Element("City").Value,
                                    Name = m.Element("Name").Value,
                                    Year = Convert.ToInt32(m.Element("Year").Value)
                                 });

            new JsonConverter(manufacturers)
                .ConvertToJson();
        }
    }
}
