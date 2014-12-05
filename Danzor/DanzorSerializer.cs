using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Dynamic;

namespace Danzor
{
    internal class DanzorSerializer
    {
        public static dynamic DeserializerNFe(string path)
        {
            dynamic result = new DanzorDynamicXml(path);
            return result.NFe;
        }

        public static dynamic DeserializerProtNFe(string path)
        {
            dynamic result = new DanzorDynamicXml(path);
            return result.protNFe;
        }
    }
}
