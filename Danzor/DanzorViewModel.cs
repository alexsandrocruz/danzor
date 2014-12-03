using System.Xml.Linq;

namespace Danzor
{
    public class DanzorViewModel
    {
        public dynamic NFe { get; set; }
        public dynamic ProtNFe { get; set; }

        public DanzorViewModel(string path)
        {
            var deserializer = new DanzorDeserializer();
            this.NFe = deserializer.NFe(path);
            this.ProtNFe = deserializer.ProtNFe(path);
        }

        public DanzorViewModel(XElement element)
        {
            var deserializer = new DanzorDeserializer();
            this.NFe = deserializer.NFe(element);
            this.ProtNFe = deserializer.ProtNFe(element);
        }
    }
}
