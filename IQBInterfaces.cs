using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public interface IAddRq
        {
            XElement GenerateAddRq();
        }

        public interface IModRq
        {
            XElement GenerateModRq();
        }

        public interface IDelRq
        {
            XElement GenerateDelRq();
        }

        public interface IQueryRq
        {
            XElement GenerateQueryRq();
        }

        public interface IQBXML
        {
            XElement ToQBXML(string name);
        }
    }
}