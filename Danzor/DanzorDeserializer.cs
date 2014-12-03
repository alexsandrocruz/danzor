using System;
using System.Xml.Linq;

namespace Danzor
{
    public class DanzorDeserializer
    {
        public dynamic NFe(string path)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(path);
                return result.NFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic NFe(XElement element)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(element);
                return result.NFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public dynamic ProtNFe(string path)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(path);
                return result.protNFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic ProtNFe(XElement element)
        {
            try
            {
                dynamic result = new DanzorDynamicXml(element);
                return result.protNFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
