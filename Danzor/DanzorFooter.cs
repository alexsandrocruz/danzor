using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor
{
    public class DanzorFooter
    {
        public dynamic infAdic { get; set; }

        public DanzorFooter(dynamic nfe)
        {
            this.infAdic = nfe.infNFe.infAdic;
        }
    }

}
