using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Danzor
{
    internal class DanzorDeserializer
    {
        public dynamic nfe { get; private set; }
        public dynamic protNFe { get; private set; }

        public DanzorDeserializer(string path)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(path);
                this.nfe = result.NFe;
                this.protNFe = result.protNFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DanzorDeserializer(XElement element)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(element);
                this.nfe = result.NFe;
                this.protNFe = result.protNFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
