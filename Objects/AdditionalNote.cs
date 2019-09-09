using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class AdditionalNote : IQBXML
        {
            public int? NoteID { get; set; }
            public DateTime? Date { get; set; }
            public string Note { get; set; }

            public XElement ToQBXML(string name)
            {
                XElement xElement = new XElement(name);
                xElement.Add(NoteID.ToQBXML(nameof(NoteID)));
                xElement.Add(Date.ToQBXML(nameof(Date)));
                xElement.Add(Note.ToQBXML(nameof(Note)));
                return xElement;
            }
        }

    }
}
