using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Danzor
{
    public class DanzorDynamicXml : DynamicObject
    {
        private const XNamespace XNAME_SPACE = "http://www.portalfiscal.inf.br/nfe";

        public string Value
        {
            get
            {
                return element == null ? string.Empty : element.Value;
            }
        }
        public string this[string attr]
        {
            get
            {
                return element == null ? string.Empty : element.Attribute(attr).Value;
            }
        }
        public XElement Element { get; private set; }


        #region CONSTRUCTORS

        public DanzorDynamicXml(string filename)
        {
            this.Element = XElement.Load(filename);
        }

        public DanzorDynamicXml(string text)
        {
            this.Element = XElement.Parse(text);
        }

        public DanzorDynamicXml(XElement el)
        {
            this.Element = el;
        }

        #endregion

        #region METHODS

        public double ToDouble()
        {
            return this.Element == null ? 0 : (double)this.Element;
        }

        public DateTime? ToDateTime()
        {
            return this.Element == null ? null : (DateTime?)this.Element;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (this.Element == null) return false;

            var node = this.Element.Element(XNAME_SPACE + binder.Name);
            var nodes = this.Element.Elements(XNAME_SPACE + binder.Name);

            if (nodes.Count() > 1 || binder.Name == "det")
            {
                result = nodes.Select(n => new DanzorDynamicXml(n)).ToList();
                return true;
            }

            if (node == null) result = null;
            else result = new DanzorDynamicXml(node);
            return true;
        }

        #endregion
    }
}
