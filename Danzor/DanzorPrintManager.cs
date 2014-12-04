using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor
{
    internal class DanzorPrintManager
    {
        private DanzorDeserializer Deserializer { get; set; }

        public DanzorPrintManager(DanzorDeserializer deserializer)
        {
            this.Deserializer = deserializer;
        }

        public List<DanzorPage> GeneratePages()
        {
            return ApportionPages().ToList();
        }

        public DanzorFooter GenerateFooter()
        {
            return new DanzorFooter(this.Deserializer.nfe);
        }

        public DanzorHeader GenerateHeader()
        {
            return new DanzorHeader(this.Deserializer.nfe);
        }

        private IEnumerable<DanzorPage> ApportionPages()
        {
            var totalPages = CalculateTotalPageSize();
            var protNFe = this.Deserializer.protNFe;
            var nfe = this.Deserializer.nfe;

            for (int i = 1; i <= totalPages; i++)
                yield return new DanzorPage(nfe, protNFe, i, totalPages);

        }

        private int CalculateTotalPageSize()
        {
            int rating = this.Deserializer.nfe.infNFe.det.Count / 10;
            return rating < 1 ? 1 : rating;
        }
    }
}
