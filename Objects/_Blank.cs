using System;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Blank : QBList
        {
            #region // PROPERTIES ///////////////////////////////////////////
            
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Blank() : this(null) { }
            public Blank(XElement xElement) : base(xElement)
            {
                if(xElement == null)
                {
                    return;
                }
            }
            #endregion

            #region // METHODS //////////////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                throw new NotImplementedException();
            }

            public override XElement GenerateModRq()
            {
                throw new NotImplementedException();
            }

            public override XElement GenerateDelRq()
            {
                throw new NotImplementedException();
            }
            #endregion
        }
    }
}