using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor
{
    public class DanzorHeader
    {
        public dynamic ide { get; set; }
        public dynamic emit { get; set; }

        public DanzorHeader(dynamic nfe)
        {
            this.ide = nfe.infNFe.ide;
            this.emit = nfe.infNFe.emit;
        }
    }
}
