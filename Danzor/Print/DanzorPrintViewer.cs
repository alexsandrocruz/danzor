using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Danzor.Print;

namespace Danzor.Print
{
    public class DanzorPrintViewer
    {
        public List<DanzorPage> Pages { get; set; }

        public DanzorPrintViewer(string path)
        {
            var manager = new DanzorPrintManager(path);

            this.Pages = manager.GeneratePages();
        }
    }
}
