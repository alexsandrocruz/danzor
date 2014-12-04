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
            this.dest = page.Equals(1) ? this.nfe.infNFe.dest : null;
            this.total = page.Equals(1) ? this.nfe.infNFe.total : null;
            this.transp = page.Equals(1) ? this.nfe.infNFe.transp : null;
            this.cobr = page.Equals(1) ? this.nfe.infNFe.cobr : null;
            this.protNFe = protNFe;

            this.det = ((List<DanzorDynamicXml>)this.nfe.infNFe.det).Skip(page - 1).Take(10);
        }
    }
}
