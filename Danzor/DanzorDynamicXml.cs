using Danzor.Extensions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace Danzor
{
    public class DanzorDynamicXml : DynamicObject
    {
        private XElement Element { get; set; }
        public string this[string attr]
        {
            get
            {
                return Element.IsNull() ? string.Empty : Element.Attribute(attr).Value;
            }
        }
        public string Value
        {
            get
            {
                return Element.IsNull() ? string.Empty : Element.Value;
            }
        }

        public DanzorDynamicXml(string filename)
        {
            this.Element = XElement.Load(filename);
        }

        public DanzorDynamicXml(XElement el)
        {
            this.Element = el;
        }

        public double ToDouble()
        {
            return this.Element.ToDouble();
        }

        public DateTime? ToDateTime()
        {
            return this.Element.ToDateTime();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = PrepareGetMembeResult(binder, GetElements(binder.Name));
            return true;
        }

        private object PrepareGetMembeResult(GetMemberBinder binder, IEnumerable<XElement> nodes)
        {
            object result;

            if (nodes.IsEmpty())
                result = null;

            else if (binder.Name == "det")
                result = nodes.Select(n => new DanzorDynamicXml(n)).ToList();

            else
                result = new DanzorDynamicXml(nodes.First());

            return result;
        }

        private IEnumerable<XElement> GetElements(string name)
        {
            if (this.Element.IsNull()) return null;

            XNamespace xnameSpace = "http://www.portalfiscal.inf.br/nfe";
            return this.Element.Elements(xnameSpace + name);
        }
    }
}
