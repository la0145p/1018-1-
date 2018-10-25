using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.Model;
using System.Xml;

namespace XMLFunction
{
    public class XMLFunction
    {
        public static XmlDocument LoadData(XmlDocument doc, string url)
        {
            doc.Load(url);
            return doc;
        }

        public static string getALLXML(XmlDocument doc)
        {
            var xml = doc.InnerText;
            return xml;
        }

        public static List<XmlElement> getAllElement(XmlDocument doc)
        {
            List<XmlElement> elementList = new List<XmlElement>();
            foreach (XmlElement element in doc.DocumentElement)
            {
                elementList.Add(element);
            }
            return elementList;
        }


        public static string getAttribute(XmlDocument doc)
        {
            var xml = doc.InnerText;
            return xml;
        }

        public static XmlNodeList getChildnodeList(XmlElement element)
        {
            XmlNodeList nodeList = element.ChildNodes;
            return nodeList;
        }

        public static XmlNode getChildnode(XmlNodeList nodeList, int index)
        {
            XmlNode node = nodeList.Item(index);
            return node;
        }

        public static string getNodeValue(XmlNode node)
        {
            string value = node.InnerText;
            return value;
        }

        public static XmlAttributeCollection getAttributeCollection(XmlNodeList nodeList, int index)
        {
            XmlAttributeCollection attributeCollection = nodeList[index].Attributes;
            return attributeCollection;
        }

        public static string getAttribute(XmlAttributeCollection attributeCollection, int index)
        {
            string attribute = attributeCollection[index].Value;
            return attribute;
        }
    }
}
