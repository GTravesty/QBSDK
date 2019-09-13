using System.Collections.Generic;
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

        public interface IVoidRq
        {
            XElement GenerateVoidRq();
        }
        

        public interface IQBXML
        {
            XElement ToQBXML(string name);
        }


        public static List<XElement> GenerateAddRq<T>(this List<T> values) where T : IAddRq
        {
            if(values == null)
            {
                return null;
            }

            List<XElement> xElements = new List<XElement>();
            foreach(T value in values)
            {
                xElements.Add(value.GenerateAddRq());
            }
            return xElements;
        }

        public static List<XElement> GenerateModRq<T>(this List<T> values) where T : IModRq
        {
            if(values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach(T value in values)
            {
                xElements.Add(value.GenerateModRq());
            }
            return xElements;
        }
    }
}