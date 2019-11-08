using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QBSDK_Helper
{
    public static partial class QBSDK
    {
        public class Customer : List
        {
            #region // PROPERTIES ///////////////////////////////////////////
            private ListType ListDelType = ListType.Customer;
            public BaseRef ClassRef { get; set; }
            public string CompanyName { get; set; }
            public string Salutation { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string JobTitle { get; set; }
            public Address BillAddress { get; set; }
            public Address ShipAddress { get; set; }
            public List<Address> ShipToAddress { get; set; }
            public string Phone { get; set; }
            public string AltPhone { get; set; }
            public string Fax { get; set; }
            public string Email { get; set; }
            public string Cc { get; set; }
            public string Contact { get; set; }
            public string AltContact { get; set; }
            public List<ContactRef> AdditionalContactRef { get; set; }
            public List<Contacts> Contacts { get; set; }
            public BaseRef CustomerTypeRef { get; set; }
            public BaseRef TermsRef { get; set; }
            public BaseRef SalesRepRef { get; set; }
            public decimal? Balance { get; set; }
            public decimal? OpenBalance
            {
                get { return Balance; }
                set { Balance = value; }
            }
            public DateTime? OpenBalanceDate { get; set; }
            public BaseRef SalesTaxCodeRef { get; set; }
            public BaseRef ItemSalesTaxRef { get; set; }
            public string ResaleNumber { get; set; }
            public string AccountNumber { get; set; }
            public decimal? CreditLimit { get; set; }
            public BaseRef PreferredPaymentMethodRef { get; set; }
            public CreditCard CreditCardInfo { get; set; }
            public JobStatus? JobStatus { get; set; }
            public DateTime? JobStartDate { get; set; }
            public DateTime? JobProjectedEndDate { get; set; }
            public DateTime? JobEndDate { get; set; }
            public string JobDesc { get; set; }
            public BaseRef JobTypeRef { get; set; }
            public string Notes { get; set; }
            public List<AdditionalNote> AdditionalNotes { get; set; }
            public PreferredDeliveryMethod? PreferredDeliveryMethod { get; set; }
            public BaseRef PriceLevelRef { get; set; }
            public string ExternalGUID { get; set; }
            public BaseRef CurrencyRef { get; set; }
            #endregion

            #region // CONSTRUCTORS /////////////////////////////////////////
            public Customer() : this(null) { }
            public Customer(XElement xElement) : base(xElement)
            {
                if(xElement == null)
                {
                    return;
                }
                ClassRef = (BaseRef)xElement.Element(nameof(ClassRef));
                CompanyName = (string)xElement.Element(nameof(CompanyName));
                Salutation = (string)xElement.Element(nameof(Salutation));
                FirstName = (string)xElement.Element(nameof(FirstName));
                MiddleName = (string)xElement.Element(nameof(MiddleName));
                LastName = (string)xElement.Element(nameof(LastName));
                JobTitle = (string)xElement.Element(nameof(JobTitle));
                BillAddress = (Address)xElement.Element(nameof(BillAddress));
                ShipAddress = (Address)xElement.Element(nameof(ShipAddress));
                ShipToAddress = (List<Address>)xElement.Elements(nameof(ShipToAddress));
                Phone = (string)xElement.Element(nameof(Phone));
                AltPhone = (string)xElement.Element(nameof(AltPhone));
                Fax = (string)xElement.Element(nameof(Fax));
                Email = (string)xElement.Element(nameof(Email));
                Cc = (string)xElement.Element(nameof(Cc));
                Contact = (string)xElement.Element(nameof(Contact));
                AltContact = (string)xElement.Element(nameof(AltContact));
                AdditionalContactRef = (List<ContactRef>)xElement.Elements(nameof(AdditionalContactRef));
                Contacts = (List<Contacts>)xElement.Elements(nameof(Contacts));
                CustomerTypeRef = (BaseRef)xElement.Elements(nameof(CustomerTypeRef));
                TermsRef = (BaseRef)xElement.Element(nameof(TermsRef));
                SalesRepRef = (BaseRef)xElement.Element(nameof(SalesRepRef));
                Balance = (decimal?)xElement.Element(nameof(Balance));
                OpenBalance = (decimal?)xElement.Element(nameof(OpenBalance));
                OpenBalanceDate = (DateTime?)xElement.Element(nameof(OpenBalanceDate));
                SalesTaxCodeRef = (BaseRef)xElement.Element(nameof(SalesTaxCodeRef));
                ItemSalesTaxRef = (BaseRef)xElement.Element(nameof(ItemSalesTaxRef));
                ResaleNumber = (string)xElement.Element(nameof(ResaleNumber));
                AccountNumber = (string)xElement.Element(nameof(AccountNumber));
                CreditLimit = (decimal?)xElement.Element(nameof(CreditLimit));
                PreferredPaymentMethodRef = (BaseRef)xElement.Element(nameof(PreferredPaymentMethodRef));
                CreditCardInfo = (CreditCard)xElement.Element(nameof(CreditCardInfo));
                JobStatus = (JobStatus?)xElement.Parse<JobStatus>();
                JobStartDate = (DateTime?)xElement.Element(nameof(JobStartDate));
                JobProjectedEndDate = (DateTime?)xElement.Element(nameof(JobProjectedEndDate));
                JobEndDate = (DateTime?)xElement.Element(nameof(JobEndDate));
                JobDesc = (string)xElement.Element(nameof(JobDesc));
                JobTypeRef = (BaseRef)xElement.Element(nameof(JobTypeRef));
                Notes = (string)xElement.Element(nameof(Notes));
                AdditionalNotes = (List<AdditionalNote>)xElement.Elements(nameof(AdditionalNotes));
                PreferredDeliveryMethod = (PreferredDeliveryMethod?)xElement.Parse<PreferredDeliveryMethod>();
                PriceLevelRef = (BaseRef)xElement.Element(nameof(PriceLevelRef));
                ExternalGUID = (string)xElement.Element(nameof(ExternalGUID));
                CurrencyRef = (BaseRef)xElement.Element(nameof(CurrencyRef));

            }
            #endregion

            #region // METHODS ///////////////////////////////////////
            public override XElement GenerateAddRq()
            {
                XElement Add = new XElement("CustomerAdd");
                Add.Add(Name?.ToQBXML(nameof(Name)));
                Add.Add(IsActive.ToQBXML(nameof(IsActive)));
                Add.Add(ClassRef?.ToQBXML(nameof(ClassRef)));
                Add.Add(ParentRef?.ToQBXML(nameof(ParentRef)));
                Add.Add(CompanyName?.ToQBXML(nameof(CompanyName)));
                Add.Add(Salutation?.ToQBXML(nameof(Salutation)));
                Add.Add(FirstName?.ToQBXML(nameof(FirstName)));
                Add.Add(MiddleName?.ToQBXML(nameof(MiddleName)));
                Add.Add(LastName?.ToQBXML(nameof(LastName)));
                Add.Add(JobTitle?.ToQBXML(nameof(JobTitle)));
                Add.Add(BillAddress?.ToQBXML(nameof(BillAddress)));
                Add.Add(ShipAddress?.ToQBXML(nameof(ShipAddress)));
                Add.Add(ShipToAddress?.ToQBXML(nameof(ShipToAddress)));
                Add.Add(Phone?.ToQBXML(nameof(Phone)));
                Add.Add(AltPhone?.ToQBXML(nameof(AltPhone)));
                Add.Add(Fax?.ToQBXML(nameof(Fax)));
                Add.Add(Email?.ToQBXML(nameof(Email)));
                Add.Add(Cc?.ToQBXML(nameof(Cc)));
                Add.Add(Contact?.ToQBXML(nameof(Contact)));
                Add.Add(AltContact?.ToQBXML(nameof(AltContact)));
                Add.Add(AdditionalContactRef?.ToQBXML(nameof(AdditionalContactRef)));
                Add.Add(Contacts?.ToQBXML<Contacts>(nameof(Contacts)));
                Add.Add(CustomerTypeRef?.ToQBXML(nameof(CustomerTypeRef)));
                Add.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                Add.Add(SalesRepRef?.ToQBXML(nameof(SalesRepRef)));
                Add.Add(OpenBalance?.ToQBXML(nameof(OpenBalance)));
                Add.Add(OpenBalanceDate?.ToQBXML(nameof(OpenBalanceDate)));
                Add.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                Add.Add(ItemSalesTaxRef?.ToQBXML(nameof(ItemSalesTaxRef)));
                Add.Add(ResaleNumber?.ToQBXML(nameof(ResaleNumber)));
                Add.Add(AccountNumber?.ToQBXML(nameof(AccountNumber)));
                Add.Add(CreditLimit?.ToQBXML(nameof(CreditLimit)));
                Add.Add(PreferredPaymentMethodRef?.ToQBXML(nameof(PreferredPaymentMethodRef)));
                Add.Add(CreditCardInfo?.ToQBXML(nameof(CreditCardInfo)));
                Add.Add(JobStatus.ToQBXML(nameof(JobStatus)));
                Add.Add(JobStartDate?.ToQBXML(nameof(JobStartDate)));
                Add.Add(JobProjectedEndDate?.ToQBXML(nameof(JobProjectedEndDate)));
                Add.Add(JobEndDate?.ToQBXML(nameof(JobEndDate)));
                Add.Add(JobDesc?.ToQBXML(nameof(JobDesc)));
                Add.Add(JobTypeRef?.ToQBXML(nameof(JobTypeRef)));
                Add.Add(Notes?.ToQBXML(nameof(Notes)));
                Add.Add(AdditionalNotes?.ToQBXML(nameof(AdditionalNotes)));
                Add.Add(PreferredDeliveryMethod.ToQBXML(nameof(PreferredDeliveryMethod)));
                Add.Add(PriceLevelRef?.ToQBXML(nameof(PriceLevelRef)));
                Add.Add(ExternalGUID?.ToQBXML(nameof(ExternalGUID)));
                Add.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));

                XElement AddRq = new XElement("CustomerAddRq");
                AddRq.Add(Add);
                AddRq.Add(IncludeRetElement?.ToQBXML(nameof(IncludeRetElement)));

                return AddRq;
            }
            public override XElement GenerateDelRq()
            {
                XElement Del = new XElement("ListDelRq");
                Del.Add(ListDelType.ToQBXML(nameof(ListDelType)));
                Del.Add(ListID.ToQBXML(nameof(ListID)));
                return Del;
            }
            public override XElement GenerateModRq()
            {
                XElement Mod = new XElement("CustomerMod");
                Mod.Add(ListID?.ToQBXML(nameof(ListID)));
                Mod.Add(EditSequence?.ToQBXML(nameof(EditSequence)));
                Mod.Add(Name?.ToQBXML(nameof(Name)));
                Mod.Add(IsActive.ToQBXML(nameof(IsActive)));
                Mod.Add(ClassRef?.ToQBXML(nameof(ClassRef)));
                Mod.Add(ParentRef?.ToQBXML(nameof(ParentRef)));
                Mod.Add(CompanyName?.ToQBXML(nameof(CompanyName)));
                Mod.Add(Salutation?.ToQBXML(nameof(Salutation)));
                Mod.Add(FirstName?.ToQBXML(nameof(FirstName)));
                Mod.Add(MiddleName?.ToQBXML(nameof(MiddleName)));
                Mod.Add(LastName?.ToQBXML(nameof(LastName)));
                Mod.Add(JobTitle?.ToQBXML(nameof(JobTitle)));
                Mod.Add(BillAddress?.ToQBXML(nameof(BillAddress)));
                Mod.Add(ShipAddress?.ToQBXML(nameof(ShipAddress)));
                Mod.Add(ShipToAddress?.ToQBXML(nameof(ShipToAddress)));
                Mod.Add(Phone?.ToQBXML(nameof(Phone)));
                Mod.Add(AltPhone?.ToQBXML(nameof(AltPhone)));
                Mod.Add(Fax?.ToQBXML(nameof(Fax)));
                Mod.Add(Email?.ToQBXML(nameof(Email)));
                Mod.Add(Cc?.ToQBXML(nameof(Cc)));
                Mod.Add(Contact?.ToQBXML(nameof(Contact)));
                Mod.Add(AltContact?.ToQBXML(nameof(AltContact)));
                Mod.Add(AdditionalContactRef?.ToQBXML(nameof(AdditionalContactRef)));
                // TODO: ContactsMod
                Mod.Add(CustomerTypeRef?.ToQBXML(nameof(CustomerTypeRef)));
                Mod.Add(TermsRef?.ToQBXML(nameof(TermsRef)));
                Mod.Add(SalesRepRef?.ToQBXML(nameof(SalesRepRef)));
                Mod.Add(SalesTaxCodeRef?.ToQBXML(nameof(SalesTaxCodeRef)));
                Mod.Add(ItemSalesTaxRef?.ToQBXML(nameof(ItemSalesTaxRef)));
                Mod.Add(ResaleNumber?.ToQBXML(nameof(ResaleNumber)));
                Mod.Add(AccountNumber?.ToQBXML(nameof(AccountNumber)));
                Mod.Add(CreditLimit?.ToQBXML(nameof(CreditLimit)));
                Mod.Add(PreferredPaymentMethodRef?.ToQBXML(nameof(PreferredPaymentMethodRef)));
                Mod.Add(CreditCardInfo?.ToQBXML(nameof(CreditCardInfo)));
                Mod.Add(JobStatus.ToQBXML(nameof(JobStatus)));
                Mod.Add(JobStartDate?.ToQBXML(nameof(JobStartDate)));
                Mod.Add(JobProjectedEndDate?.ToQBXML(nameof(JobProjectedEndDate)));
                Mod.Add(JobEndDate?.ToQBXML(nameof(JobEndDate)));
                Mod.Add(JobDesc?.ToQBXML(nameof(JobDesc)));
                Mod.Add(JobTypeRef?.ToQBXML(nameof(JobTypeRef)));
                Mod.Add(Notes?.ToQBXML(nameof(Notes)));
                // TODO: AdditionalNotesMod
                Mod.Add(PreferredDeliveryMethod.ToQBXML(nameof(PreferredDeliveryMethod)));
                Mod.Add(PriceLevelRef?.ToQBXML(nameof(PriceLevelRef)));
                Mod.Add(CurrencyRef?.ToQBXML(nameof(CurrencyRef)));

                XElement ModRq = new XElement("CustomerModRq");
                ModRq.Add(Mod);
                ModRq.Add(IncludeRetElement?.ToQBXML(nameof(IncludeRetElement)));

                return ModRq;

            }
            #endregion
        }
    }
}