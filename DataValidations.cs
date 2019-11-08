using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {

       
        public static class Validator
        {
            public static string CountryCode = "US";
            public static QBEdition QBEdition = QBEdition.Enterprise;
            public static int QBXMLMajorVersion = 13;
            public static int QBXMLMinorVersion = 0;

            public static List<ValidationResult> Validate(object o)
            {
                Dictionary<object, object> versionContext = new Dictionary<object, object>
                {
                    { "CountryCode", CountryCode },
                    {"QBEdition", QBEdition},
                    {"MajorVersion", QBXMLMajorVersion},
                    {"MinorVersion", QBXMLMinorVersion}
                };
                ValidationContext context = new ValidationContext(o, versionContext);
                List<ValidationResult> results = new List<ValidationResult>();
                System.ComponentModel.DataAnnotations.Validator.TryValidateObject(o, context, results, true);
                return results;
            }

            public static bool IsValid(object o)
            {
                List<ValidationResult> results = Validate(o);
                if(results == null || results.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

         [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
        public class MaxLengthAttribute : ValidationAttribute
        {
            private int _maxLength;
            private string _countryCode;

            public MaxLengthAttribute(int MaxLength) : this(MaxLength, "US")
            {

            }
            public MaxLengthAttribute(int MaxLength, string CountryCode)
            {
                _maxLength = MaxLength;
                _countryCode = CountryCode;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                string v = value as string;

                if (!String.IsNullOrWhiteSpace(v))
                {
                    // Do we have a validation context for what country code to use
                    if (validationContext != null)
                    {
                        object cc = "US";
                        validationContext.Items.TryGetValue("CountryCode", out cc);
                        if (cc.Equals(_countryCode))
                        {
                            // Check if the length of our string is longer than allowed
                            if (v.Length > _maxLength)
                            {
                                return new ValidationResult("Maximum length of this field is " + _maxLength);
                            }
                        }
                    }
                }

                return ValidationResult.Success;
            }
        }

    }
}