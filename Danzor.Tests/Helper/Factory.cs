using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danzor.Print;

namespace Danzor.Tests.Helper
{
    public class Factory
    {
        public static dynamic NFe28090708060730000190550020000001762000007303
        {
            get
            {
                return new DanzorPrintViewer(GetFilePath()).Pages.First();
            }
        }

        private static string GetFilePath()
        {
            var path = @"Helper\NFe28090708060730000190550020000001762000007303procNFe.xml";
            return new FileInfo(path).FullName;
        }
    }
}
