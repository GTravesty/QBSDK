using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public static DateTime QBMinDate = new DateTime(1901, 01, 01, 0, 0, 0);
        public static DateTime QBMaxDate = new DateTime(2999, 12, 31, 12, 59, 59);

        public static XElement ToQBXML(this string value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return new XElement(name, value);
        }

        public static XElement ToQBXML(this int value, string name)
        {
            return new XElement(name, value);
        }
        public static XElement ToQBXML(this int? value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return ((int)value).ToQBXML(name);
        }

        public static XElement ToQBXML(this bool value, string name)
        {
            if (value)
            {
                return new XElement(name, "1");
            }
            else
            {
                return new XElement(name, "0");
            }
        }
        public static XElement ToQBXML(this bool? value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return ((bool)value).ToQBXML(name);
        }

        public static XElement ToQBXML(this decimal value, string name, int decimalPlaces = 2)
        {
            string formating = new string('#', decimalPlaces);
            return new XElement(name, value.ToString("0." + formating));
        }
        public static XElement ToQBXML(this decimal? value, string name, int decimalPlaces = 2)
        {
            if (value == null)
            {
                return null;
            }
            return ((decimal)value).ToQBXML(name, decimalPlaces);
        }

        public static XElement ToQBXML(this float value, string name, int decimalPlaces = 2)
        {
            string formating = new string('#', decimalPlaces);
            return new XElement(name, value.ToString("0." + formating));
        }
        public static XElement ToQBXML(this float? value, string name, int decimalPlaces = 2)
        {
            if (value == null)
            {
                return null;
            }
            return ((float)value).ToQBXML(name, decimalPlaces);
        }

        public static XElement ToQBXML(this DateTime value, string name)
        {
            return new XElement(name, value.ToString("yyyy-MM-dd"));
        }
        public static XElement ToQBXML(this DateTime? value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return ((DateTime)value).ToQBXML(name);
        }

        public static XElement ToQBXML(this Enum value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return new XElement(name, value);
        }

        public static List<XElement> ToQBXML(this List<string> values, string name)
        {
            if (values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach (string value in values)
            {
                xElements.Add(value.ToQBXML(name));
            }
            return xElements;
        }
        public static List<XElement> ToQBXML(this List<Address> values, string name)
        {
            if (values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach (Address value in values)
            {
                xElements.Add(value.ToQBXML(name));
            }
            return xElements;
        }
        public static List<XElement> ToQBXML(this List<ContactRef> values, string name)
        {
            if (values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach (var value in values)
            {
                xElements.Add(value.ToQBXML(name));
            }
            return xElements;
        }
        public static List<XElement> ToQBXML(this List<AdditionalNote> values, string name)
        {
            if (values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach (var value in values)
            {
                xElements.Add(value.ToQBXML(name));
            }
            return xElements;
        }
        public static List<XElement> ToQBXML<T>(this List<T> values, string name) where T : IQBXML
        {
            if(values == null)
            {
                return null;
            }
            List<XElement> xElements = new List<XElement>();
            foreach(T value in values)
            {
                xElements.Add(value.ToQBXML(name));
            }
            return xElements;
        }
                

        public static XElement ToQBXML(this BaseRef value, string name)
        {
            if (value == null)
            {
                return null;
            }
            return value.ToQBXML(name);
        }
    }
}