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
        private XElement element;

        public string Value
        {
            get
            {
                return element.IsNull() ? string.Empty : element.Value;
            }
        }
        public string this[string attr]
        {
            get
            {
                return element.IsNull() ? string.Empty : element.Attribute(attr).Value;
            }
        }


        public DanzorDynamicXml()
        {
            this.element = null;
        }

        public DanzorDynamicXml(string filename)
        {
            this.element = XElement.Load(filename);
        }

        public DanzorDynamicXml(XElement element)
        {
            this.element = element;
        }


        public double ToDouble()
        {
            return this.element.ToDouble();
        }

        public DateTime? ToDateTime()
        {
            return this.element.ToDateTime();
        }

        public DanzorDynamicXml First()
        {
            var node = this.element.Elements().First();

            if (node == null) return null;
            else return new DanzorDynamicXml(node);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = PrepareGetMembeResult(binder, GetElements(binder.Name));
            return true;
        }

        private object PrepareGetMembeResult(GetMemberBinder binder, IEnumerable<XElement> nodes)
        {
            var collections = new string[] { "det", "dup" };
            object result;

            if (nodes.IsEmpty())
                result = new DanzorDynamicXml();
            else if (collections.Contains(binder.Name))
                result = nodes.Select(n => new DanzorDynamicXml(n)).ToList();
            else
                result = new DanzorDynamicXml(nodes.First());

            return result;
        }

        private IEnumerable<XElement> GetElements(string name)
        {
            if (this.element.IsNull()) return null;

            XNamespace xnameSpace = "http://www.portalfiscal.inf.br/nfe";
            return this.element.Elements(xnameSpace + name);
        }
    }
}
