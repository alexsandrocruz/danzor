using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor
{
    public class DanzorDeserializer
    {
        public dynamic NFe(string path)
        {
            try
            {
                dynamic nfeProc = new NFeDynamicXml(path);
                return nfeProc.NFe;
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
                dynamic nfeProc = new NFeDynamicXml(path);
                return nfeProc.protNFe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
