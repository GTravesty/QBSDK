using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class BarCode : IQBXML
        {
            public string BarCodeValue { get; set; }
            public bool? AssignEvenIfUsed { get; set; }
            public bool? AllowOverride { get; set; }

            public XElement ToQBXML(string name)
            {
                if (BarCodeValue == null && AssignEvenIfUsed == null && AllowOverride == null)
                {
                    return null;
                }
                XElement xElement = new XElement(name);
                xElement.Add(BarCodeValue.ToQBXML(nameof(BarCodeValue)));
                xElement.Add(AssignEvenIfUsed?.ToQBXML(nameof(AssignEvenIfUsed)));
                xElement.Add(AllowOverride?.ToQBXML(nameof(AllowOverride)));
                return xElement;
            }
        }
    }
}