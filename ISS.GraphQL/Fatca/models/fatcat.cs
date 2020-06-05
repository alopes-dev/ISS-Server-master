/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Xml2CSharp
{
	[XmlRoot(ElementName = "AccountBalance", Namespace = "urn:oecd:ties:fatca:v2")]
	public class AccountBalance
	{
		[XmlAttribute(AttributeName = "currCode")]
		public string CurrCode { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "AccountHolder", Namespace = "urn:oecd:ties:fatca:v2")]
	public class AccountHolder
	{
		[XmlElement(ElementName = "AcctHolderType", Namespace = "urn:oecd:ties:fatca:v2")]
		public string AcctHolderType { get; set; }
		[XmlElement(ElementName = "Individual", Namespace = "urn:oecd:ties:fatca:v2")]
		public Individual Individual { get; set; }
		[XmlElement(ElementName = "Organisation", Namespace = "urn:oecd:ties:fatca:v2")]
		public Organisation Organisation { get; set; }
	}

	[XmlRoot(ElementName = "AccountReport", Namespace = "urn:oecd:ties:fatca:v2")]
	public class AccountReport
	{
		[XmlElement(ElementName = "AccountBalance", Namespace = "urn:oecd:ties:fatca:v2")]
		public AccountBalance AccountBalance { get; set; }
		[XmlElement(ElementName = "AccountClosed", Namespace = "urn:oecd:ties:fatca:v2")]
		public string AccountClosed { get; set; }
		[XmlElement(ElementName = "AccountHolder", Namespace = "urn:oecd:ties:fatca:v2")]
		public AccountHolder AccountHolder { get; set; }
		[XmlElement(ElementName = "AccountNumber", Namespace = "urn:oecd:ties:fatca:v2")]
		public string AccountNumber { get; set; }
		[XmlElement(ElementName = "AdditionalData", Namespace = "urn:oecd:ties:fatca:v2")]
		public AdditionalData AdditionalData { get; set; }
		[XmlElement(ElementName = "DocSpec", Namespace = "urn:oecd:ties:fatca:v2")]
		public DocSpec DocSpec { get; set; }
		[XmlElement(ElementName = "Payment", Namespace = "urn:oecd:ties:fatca:v2")]
		public Payment Payment { get; set; }
		[XmlElement(ElementName = "SubstantialOwner", Namespace = "urn:oecd:ties:fatca:v2")]
		public SubstantialOwner SubstantialOwner { get; set; }
	}

	[XmlRoot(ElementName = "AdditionalData", Namespace = "urn:oecd:ties:fatca:v2")]
	public class AdditionalData
	{
		[XmlElement(ElementName = "AdditionalItem", Namespace = "urn:oecd:ties:fatca:v2")]
		public AdditionalItem AdditionalItem { get; set; }
	}

	[XmlRoot(ElementName = "AdditionalItem", Namespace = "urn:oecd:ties:fatca:v2")]
	public class AdditionalItem
	{
		[XmlElement(ElementName = "ItemContent", Namespace = "urn:oecd:ties:fatca:v2")]
		public string ItemContent { get; set; }
		[XmlElement(ElementName = "ItemName", Namespace = "urn:oecd:ties:fatca:v2")]
		public string ItemName { get; set; }
	}

	[XmlRoot(ElementName = "Address", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
	public class Address
	{
		[XmlElement(ElementName = "AddressFree", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string AddressFree { get; set; }
		[XmlElement(ElementName = "CountryCode", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string CountryCode { get; set; }
	}

	[XmlRoot(ElementName = "BirthInfo", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
	public class BirthInfo
	{
		[XmlElement(ElementName = "BirthDate", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string BirthDate { get; set; }
		[XmlElement(ElementName = "City", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string City { get; set; }
		[XmlElement(ElementName = "CitySubentity", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string CitySubentity { get; set; }
		[XmlElement(ElementName = "CountryInfo", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public CountryInfo CountryInfo { get; set; }
	}

	[XmlRoot(ElementName = "CountryInfo", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
	public class CountryInfo
	{
		[XmlElement(ElementName = "CountryCode", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string CountryCode { get; set; }
	}

	[XmlRoot(ElementName = "DocSpec", Namespace = "urn:oecd:ties:fatca:v2")]
	public class DocSpec
	{
		[XmlElement(ElementName = "CorrDocRefId", Namespace = "urn:oecd:ties:fatca:v2")]
		public string CorrDocRefId { get; set; }
		[XmlElement(ElementName = "CorrMessageRefId", Namespace = "urn:oecd:ties:fatca:v2")]
		public string CorrMessageRefId { get; set; }
		[XmlElement(ElementName = "DocRefId", Namespace = "urn:oecd:ties:fatca:v2")]
		public string DocRefId { get; set; }
		[XmlElement(ElementName = "DocTypeIndic", Namespace = "urn:oecd:ties:fatca:v2")]
		public string DocTypeIndic { get; set; }
	}

	[XmlRoot(ElementName = "FATCA", Namespace = "urn:oecd:ties:fatca:v2")]
	public class FATCA
	{
		[XmlElement(ElementName = "ReportingFI", Namespace = "urn:oecd:ties:fatca:v2")]
		public ReportingFI ReportingFI { get; set; }
		[XmlElement(ElementName = "ReportingGroup", Namespace = "urn:oecd:ties:fatca:v2")]
		public ReportingGroup ReportingGroup { get; set; }
	}

	[XmlRoot(ElementName = "FATCA_OECD", Namespace = "urn:oecd:ties:fatca:v2")]
	public class FATCA_OECD
	{
		[XmlElement(ElementName = "FATCA", Namespace = "urn:oecd:ties:fatca:v2")]
		public FATCA FATCA { get; set; }
		[XmlAttribute(AttributeName = "ftc", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Ftc { get; set; }
		[XmlAttribute(AttributeName = "iso", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Iso { get; set; }
		[XmlElement(ElementName = "MessageSpec", Namespace = "urn:oecd:ties:fatca:v2")]
		public MessageSpec MessageSpec { get; set; }
		[XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
		[XmlAttribute(AttributeName = "sfa", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Sfa { get; set; }
		[XmlAttribute(AttributeName = "stf", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Stf { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
		[XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
	}

	[XmlRoot(ElementName = "Individual", Namespace = "urn:oecd:ties:fatca:v2")]
	public class Individual
	{
		[XmlElement(ElementName = "Address", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public Address Address { get; set; }
		[XmlElement(ElementName = "BirthInfo", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public BirthInfo BirthInfo { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public Name Name { get; set; }
		[XmlElement(ElementName = "Nationality", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Nationality { get; set; }
		[XmlElement(ElementName = "ResCountryCode", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string ResCountryCode { get; set; }
		[XmlElement(ElementName = "TIN", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public TIN TIN { get; set; }
	}

	[XmlRoot(ElementName = "MessageSpec", Namespace = "urn:oecd:ties:fatca:v2")]
	public class MessageSpec
	{
		[XmlElement(ElementName = "MessageRefId", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string MessageRefId { get; set; }
		[XmlElement(ElementName = "MessageType", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string MessageType { get; set; }
		[XmlElement(ElementName = "ReceivingCountry", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string ReceivingCountry { get; set; }
		[XmlElement(ElementName = "ReportingPeriod", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string ReportingPeriod { get; set; }
		[XmlElement(ElementName = "SendingCompanyIN", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string SendingCompanyIN { get; set; }
		[XmlElement(ElementName = "Timestamp", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Timestamp { get; set; }
		[XmlElement(ElementName = "TransmittingCountry", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string TransmittingCountry { get; set; }
	}

	[XmlRoot(ElementName = "Name", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
	public class Name
	{
		[XmlElement(ElementName = "FirstName", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string FirstName { get; set; }
		[XmlElement(ElementName = "GeneralSuffix", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string GeneralSuffix { get; set; }
		[XmlElement(ElementName = "GenerationIdentifier", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string GenerationIdentifier { get; set; }
		[XmlElement(ElementName = "LastName", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string LastName { get; set; }
		[XmlElement(ElementName = "MiddleName", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string MiddleName { get; set; }
		[XmlElement(ElementName = "NamePrefix", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string NamePrefix { get; set; }
		[XmlElement(ElementName = "PrecedingTitle", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string PrecedingTitle { get; set; }
		[XmlElement(ElementName = "Suffix", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Suffix { get; set; }
		[XmlElement(ElementName = "Title", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Title { get; set; }
	}

	[XmlRoot(ElementName = "Organisation", Namespace = "urn:oecd:ties:fatca:v2")]
	public class Organisation
	{
		[XmlElement(ElementName = "Address", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public Address Address { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Name { get; set; }
		[XmlElement(ElementName = "TIN", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string TIN { get; set; }
	}

	[XmlRoot(ElementName = "Payment", Namespace = "urn:oecd:ties:fatca:v2")]
	public class Payment
	{
		[XmlElement(ElementName = "PaymentAmnt", Namespace = "urn:oecd:ties:fatca:v2")]
		public PaymentAmnt PaymentAmnt { get; set; }
		[XmlElement(ElementName = "Type", Namespace = "urn:oecd:ties:fatca:v2")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "PaymentAmnt", Namespace = "urn:oecd:ties:fatca:v2")]
	public class PaymentAmnt
	{
		[XmlAttribute(AttributeName = "currCode")]
		public string CurrCode { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "ReportingFI", Namespace = "urn:oecd:ties:fatca:v2")]
	public class ReportingFI
	{
		[XmlElement(ElementName = "Address", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public Address Address { get; set; }
		[XmlElement(ElementName = "DocSpec", Namespace = "urn:oecd:ties:fatca:v2")]
		public DocSpec DocSpec { get; set; }
		[XmlElement(ElementName = "FilerCategory", Namespace = "urn:oecd:ties:fatca:v2")]
		public string FilerCategory { get; set; }
		[XmlElement(ElementName = "Name", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string Name { get; set; }
		[XmlElement(ElementName = "ResCountryCode", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string ResCountryCode { get; set; }
		[XmlElement(ElementName = "TIN", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
		public string TIN { get; set; }
	}

	[XmlRoot(ElementName = "ReportingGroup", Namespace = "urn:oecd:ties:fatca:v2")]
	public class ReportingGroup
	{
		[XmlElement(ElementName = "AccountReport", Namespace = "urn:oecd:ties:fatca:v2")]
		public List<AccountReport> AccountReport { get; set; }
	}

	[XmlRoot(ElementName = "SubstantialOwner", Namespace = "urn:oecd:ties:fatca:v2")]
	public class SubstantialOwner
	{
		[XmlElement(ElementName = "Individual", Namespace = "urn:oecd:ties:fatca:v2")]
		public Individual Individual { get; set; }
	}

	[XmlRoot(ElementName = "TIN", Namespace = "urn:oecd:ties:stffatcatypes:v2")]
	public class TIN
	{
		[XmlAttribute(AttributeName = "issuedBy")]
		public string IssuedBy { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

}
