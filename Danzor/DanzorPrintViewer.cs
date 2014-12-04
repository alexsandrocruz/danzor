using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Danzor
{
    public class DanzorPrintViewer
    {
        public DanzorHeader Header { get; set; }
        public List<DanzorPage> Pages { get; set; }
        public DanzorFooter Footer { get; set; }

        public DanzorPrintViewer(string path)
        {
            var deserializer = new DanzorDeserializer(path);
            var manager = new DanzorPrintManager(deserializer);

            this.Header = manager.GenerateHeader();
            this.Pages = manager.GeneratePages();
            this.Footer = manager.GenerateFooter();
        }
    }
}
