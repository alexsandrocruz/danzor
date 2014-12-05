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
        private Dictionary<string, object> dictionary;

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
            this.dictionary = dictionary ?? new Dictionary<string, object>();
        }

        public DanzorDynamicXml(string filename)
        {
            this.element = XElement.Load(filename);
            this.dictionary = dictionary ?? new Dictionary<string, object>();
        }

        public DanzorDynamicXml(XElement element)
        {
            this.element = element;
            this.dictionary = dictionary ?? new Dictionary<string, object>();
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
            if (dictionary.Keys.Contains(binder.Name))
            {
                result = dictionary[binder.Name];
            }
            else
            {
                var nodes = GetElements(binder.Name);
                result = PrepareGetMembeResult(binder, nodes);
                dictionary.Add(binder.Name, result);
            }
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
