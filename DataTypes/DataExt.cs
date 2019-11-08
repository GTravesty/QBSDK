using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class DataExt : IQBXML
        {
            #region // PROPERTIES ///////////////////////////////////////////
            public string OwnerID { get; set; }
            public string DataExtName { get; set; }
            public string DataExtValue { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public DataExt() : this(null) { }
            public DataExt(XElement xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                OwnerID = (string)xElement.Element(nameof(OwnerID));
                DataExtName = (string)xElement.Element(nameof(DataExtName));
                DataExtValue = (string)xElement.Element(nameof(DataExtValue));
            }

            public static explicit operator DataExt(XElement xElement)
            {
                if(xElement == null)
                {
                    return null;
                }
                return new DataExt(xElement);
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(OwnerID.ToQBXML(nameof(OwnerID)));
                xElement.Add(DataExtName.ToQBXML(nameof(DataExtName)));
                xElement.Add(DataExtValue.ToQBXML(nameof(DataExtValue)));
                return xElement;
            }
            #endregion
        }
    }
}