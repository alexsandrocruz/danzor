using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using System.Dynamic;

namespace Danzor
{
    internal class DanzorSerializer
    {
        public static dynamic DeserializerNFe(string path)
        {
            return null;
        }

        public static dynamic DeserializerProtNFe(string path)
        {
            return null;
        }

        public static dynamic GetExpandoFromXml(string file)
        {
            var doc = XDocument.Load(file);
            var nodes = doc.Elements().Elements().First();
            dynamic person = new DanzorDynamicXml();

            dynamic x = FillElement(nodes.Descendants(), person);


            return person;
        }

        private static dynamic FillElement(IEnumerable<XElement> nodes, dynamic person)
        {
            var collections = new string[] { "det", "dup" };

            dynamic o = new object { };
            foreach (var child in nodes)
            {
                if (child.HasElements)
                    if (collections.Contains(child.Name.LocalName))
                        person.Add(child.Name.LocalName, new List<dynamic>() { FillElement(child.Descendants(), person) });
                    else
                    {
                        var value = FillElement(child.Descendants(), person);
                        person.Add(child.Name.LocalName, value);
                    }
                else
                {
                    person.Add(child.Name.LocalName, child.Value.Trim());
                }
            }
            return o;
        }
    }
}
