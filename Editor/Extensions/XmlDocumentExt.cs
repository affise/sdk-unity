using System.Xml;

namespace AffiseAttributionLib.Editor.Extensions
{
    internal static class XmlDocumentExt
    {
        internal static XmlNamespaceManager Namespace(this XmlDocument xml)
        {
            var ns = new XmlNamespaceManager(xml.NameTable);
            ns.AddNamespace("android", "http://schemas.android.com/apk/res/android");
            return ns;
        }

        internal static XmlElement AddAttribute(this XmlElement node, XmlDocument xml, string key, string value)
        {
            var androidSchemeAttribute = xml.CreateAttribute("android", key, "http://schemas.android.com/apk/res/android");
            androidSchemeAttribute.InnerText = value;
            node.SetAttributeNode(androidSchemeAttribute);
            return node;
        }

        internal static XmlElement AppendTo(this XmlElement child, XmlNode root)
        {
            root.AppendChild(child);
            return child;
        }
    }
}