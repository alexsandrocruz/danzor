using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor
{
    public class DanzorPage
    {
        public int page { get; set; }
        public int size { get; set; }

        public dynamic nfe { get; set; }
        public dynamic ide { get; set; }
        public dynamic emit { get; set; }
        public dynamic dest { get; set; }
        public dynamic det { get; set; }
        public dynamic total { get; set; }
        public dynamic transp { get; set; }
        public dynamic cobr { get; set; }
        public dynamic protNFe { get; set; }

        public DanzorPage(dynamic nfe, dynamic protNFe, int page, int size)
        {
            this.page = page;
            this.size = size;

            this.nfe = nfe;
            this.ide = this.nfe.infNFe.ide;
            this.emit = this.nfe.infNFe.emit;
            this.dest = this.nfe.infNFe.dest;
            this.total = this.nfe.infNFe.total;
            this.transp = this.nfe.infNFe.transp;
            this.cobr = this.nfe.infNFe.cobr;
            this.protNFe = protNFe;

            this.det = ((List<DanzorDynamicXml>)this.nfe.infNFe.det).Skip(page - 1).Take(10);
        }
    }
}
