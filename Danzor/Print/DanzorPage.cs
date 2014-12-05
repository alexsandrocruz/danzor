using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danzor.Print
{
    public class DanzorPage
    {
        public int page { get; set; }
        public int size { get; set; }
        public DanzorHeader Header { get; set; }
        public DanzorBody Body { get; set; }
        public DanzorFooter Footer { get; set; }
        public bool IsFirstPage
        {
            get
            {
                return this.page.Equals(1);
            }
        }
        public bool IsLastPage
        {
            get
            {
                return this.page.Equals(size);
            }
        }

        public DanzorPage(dynamic nfe, dynamic protNFe, int page, int size)
        {
            this.page = page;
            this.size = size;

            this.Header = new DanzorHeader(nfe);
            this.Body = new DanzorBody(nfe, protNFe, page, size);
            this.Footer = new DanzorFooter(nfe);
        }
    }
}
