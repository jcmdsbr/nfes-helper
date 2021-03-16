using System.Collections.Generic;
using System.Xml;

namespace NfeToCsv
{
    public static class Helper
    {
        public static List<Nfe> ConverterXmlNode(XmlNodeList nodeList)
        {
            var nfes = new List<Nfe>();

            for (var i = 0; i < nodeList.Count; i++)
            {
                var properties = nodeList[i]?.ChildNodes;
                if (properties is null) continue;
                nfes.Add((Nfe) properties);
            }

            return nfes;
        }
    }
}