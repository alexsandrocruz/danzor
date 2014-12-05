using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danzor.Print;

namespace Danzor.Print
{
    internal class DanzorPrintManager
    {
        private dynamic nfe;
        private dynamic protNFe;

        public DanzorPrintManager(string path)
        {
            this.nfe = DanzorSerializer.GetExpandoFromXml(path);
            this.protNFe = DanzorSerializer.DeserializerProtNFe(path);
        }

        public List<DanzorPage> GeneratePages()
        {
            return ApportionPages().ToList();
        }

        private IEnumerable<DanzorPage> ApportionPages()
        {
            var totalPages = TotalPageSize();
            for (int i = 1; i <= totalPages; i++)
                yield return new DanzorPage(this.nfe, this.protNFe, i, totalPages);
        }

        private int TotalPageSize()
        {
            var pages = Rating();
            return pages < 1 ? 1 : pages;
        }

        private int Rating()
        {
            return this.nfe.infNFe.det.Count / 10;
        }


    }
}
