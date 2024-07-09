//using System.Text.RegularExpressions;
//using indice.Edi.Serialization;
//using SRV_EdiFileService.Servicio.BE;

//namespace SRV_EdiFileService.Servicio.BE
//{
//    [EdiSegment, EdiPath("UNB")]
//    public class InterchangeHeader
//    {
//        [EdiValue("X(4)", Path = "UNB/0/0")]
//        public string SyntaxIdentifier { get; set; }

//        [EdiValue("X(1)", Path = "UNB/0/1")]
//        public string SyntaxVersionNumber { get; set; }

//        [EdiValue("X(35)", Path = "UNB/1/0")]
//        public string SenderId { get; set; }

//        [EdiValue("X(35)", Path = "UNB/2/0")]
//        public string RecipientId { get; set; }

//        [EdiValue("X(6)", Path = "UNB/3/0")]
//        public string Date { get; set; }

//        [EdiValue("X(4)", Path = "UNB/3/1")]
//        public string Time { get; set; }

//        [EdiValue("X(14)", Path = "UNB/4")]
//        public string InterchangeControlReference { get; set; }
//    }

//    [EdiSegment, EdiPath("UNH")]
//    public class MessageHeader
//    {
//        [EdiValue("X(14)", Path = "UNH/0/0")]
//        public string MessageReferenceNumber { get; set; }

//        [EdiValue("X(6)", Path = "UNH/1/0")]
//        public string MessageType { get; set; }

//        [EdiValue("X(3)", Path = "UNH/1/1")]
//        public string MessageVersionNumber { get; set; }

//        [EdiValue("X(3)", Path = "UNH/1/2")]
//        public string MessageReleaseNumber { get; set; }

//        [EdiValue("X(2)", Path = "UNH/1/3")]
//        public string ControllingAgencyCode { get; set; }

//        [EdiValue("X(6)", Path = "UNH/1/4")]
//        public string AssociationAssignedCode { get; set; }
//    }

//    [EdiSegment, EdiPath("BGM")]
//    public class BeginningOfMessage
//    {
//        [EdiValue("X(3)", Path = "BGM/0/0")]
//        public string DocumentMessageName { get; set; }

//        [EdiValue("X(35)", Path = "BGM/1/0")]
//        public string DocumentMessageNumber { get; set; }

//        [EdiValue("X(3)", Path = "BGM/2/0")]
//        public MessageFunctionCode MessageFunctionCode { get; set; }
//    }

//    [EdiSegment, EdiPath("RFF")]
//    public class Reference
//    {
//        [EdiValue("X(3)", Path = "RFF/0/0")]
//        public string ReferenceQualifier { get; set; }

//        [EdiValue("X(70)", Path = "RFF/0/1")]
//        public string ReferenceNumber { get; set; }
//    }

//    [EdiSegment, EdiPath("TDT")]
//    public class DetailsOfTransport
//    {
//        [EdiValue("X(3)", Path = "TDT/0/0")]
//        public string TransportStageQualifier { get; set; }

//        [EdiValue("X(17)", Path = "TDT/1/0")]
//        public string ConveyanceReferenceNumber { get; set; }

//        [EdiValue("X(1)", Path = "TDT/2/0")]
//        public string ModeOfTransport { get; set; }

//        [EdiValue("X(3)", Path = "TDT/3/0")]
//        public string TransportMeans { get; set; }

//        [EdiValue("X(35)", Path = "TDT/3/1")]
//        public string CarrierIdentifier { get; set; }

//        [EdiValue("X(3)", Path = "TDT/3/2")]
//        public string CarrierCode { get; set; }

//        [EdiValue("X(9)", Path = "TDT/4/0")]
//        public string VesselID { get; set; }

//        [EdiValue("X(17)", Path = "TDT/4/1")]
//        public string VesselName { get; set; }

//        [EdiValue("X(4)", Path = "TDT/4/2")]
//        public string VesselCountryCode { get; set; }
//    }

//    [EdiSegment, EdiPath("LOC")]
//    public class Location
//    {
//        [EdiValue("X(3)", Path = "LOC/0/0")]
//        public string LocationQualifier { get; set; }

//        [EdiValue("X(25)", Path = "LOC/1/0")]
//        public string LocationIdentifier { get; set; }

//        [EdiValue("X(3)", Path = "LOC/1/1")]
//        public string LocationCodeQualifier { get; set; }

//        [EdiValue("X(70)", Path = "LOC/1/2")]
//        public string LocationName { get; set; }

//        [EdiValue("X(17)", Path = "LOC/1/3")]
//        public string PlaceLocation { get; set; }
//    }

//    [EdiSegment, EdiPath("DTM")]
//    public class DateTimePeriod
//    {
//        [EdiValue("X(3)", Path = "DTM/0/0")]
//        public string DateTimePeriodQualifier { get; set; }

//        [EdiValue("X(12)", Path = "DTM/0/1")]
//        public string DateTimePeriodo { get; set; }

//        [EdiValue("X(3)", Path = "DTM/0/2")]
//        public string DateTimePeriodFormatQualifier { get; set; }
//    }

//    [EdiSegment, EdiPath("NAD")]
//    public class NameAndAddress
//    {
//        [EdiValue("X(3)", Path = "NAD/0/0")]
//        public string PartyQualifier { get; set; }

//        [EdiValue("X(35)", Path = "NAD/1/0")]
//        public string PartyIdentifier { get; set; }

//        [EdiValue("X(3)", Path = "NAD/1/1")]
//        public string CodeListQualifier { get; set; }

//        [EdiValue("X(3)", Path = "NAD/1/2")]
//        public string CodeListResponsibleAgency { get; set; }
//    }

//    [EdiSegment, EdiPath("GID")]
//    public class GoodsItemDetails
//    {
//        [EdiValue("X(4)", Path = "GID/0/0")]
//        public string LineItemNumber { get; set; }
//    }

//    [EdiSegment, EdiPath("FTX")]
//    public class FreeText
//    {
//        [EdiValue("X(3)", Path = "FTX/0/0")]
//        public string TextSubjectQualifier { get; set; }

//        [EdiValue("X(3)", Path = "FTX/1/0")]
//        public string TextFunctionCode { get; set; }

//        [EdiValue("X(512)", Path = "FTX/2/0")]
//        public string TextReference { get; set; }

//        [EdiValue("X(512)", Path = "FTX/3/0")]
//        public string TextLiteral { get; set; }
//    }

//    [EdiSegment, EdiPath("PIA")]
//    public class AdditionalProductId
//    {
//        [EdiValue("X(3)", Path = "PIA/0/0")]
//        public string ProductIdFunctionQualifier { get; set; }

//        [EdiValue("X(35)", Path = "PIA/1/0")]
//        public string ItemNumberIdentification { get; set; }

//        [EdiValue("X(3)", Path = "PIA/1/1")]
//        public string ItemNumberType { get; set; }
//    }

//    [EdiSegment, EdiPath("EQD")]
//    public class EquipmentDetails
//    {
//        [EdiValue("X(3)", Path = "EQD/0/0")]
//        public string EquipmentTypeCodeQualifier { get; set; }

//        [EdiValue("X(17)", Path = "EQD/1/0")]
//        public string EquipmentIdentification { get; set; }

//        [EdiValue("X(4)", Path = "EQD/2/0")]
//        public string EquipmentSizeAndType { get; set; }

//        [EdiValue("X(3)", Path = "EQD/3/0")]
//        public string EquipmentSupplierCode { get; set; }

//        [EdiValue("X(3)", Path = "EQD/4/0")]
//        public string EquipmentStatusCode { get; set; }
//    }

//    [EdiSegment, EdiPath("EQN")]
//    public class NumberOfUnits
//    {
//        [EdiValue("X(15)", Path = "EQN/0/0")]
//        public string NumberOfUnitsQualifier { get; set; }
//    }

//    [EdiSegment, EdiPath("TMD")]
//    public class TransportMovementDetails
//    {
//        [EdiValue("X(3)", Path = "TMD/0/0")]
//        public string MovementType { get; set; }
//    }

//    [EdiSegment, EdiPath("MEA")]
//    public class Measurements
//    {
//        [EdiValue("X(3)", Path = "MEA/0/0")]
//        public string MeasurementPurposeQualifier { get; set; }

//        [EdiValue("X(3)", Path = "MEA/1/0")]
//        public string MeasurementTypeCode { get; set; }

//        [EdiValue("X(3)", Path = "MEA/2/0")]
//        public string MeasurementUnitCode { get; set; }

//        [EdiValue("X(18)", Path = "MEA/2/1")]
//        public string MeasurementValue { get; set; }
//    }

//    [EdiSegment, EdiPath("SEL")]
//    public class SealNumber
//    {
//        [EdiValue("X(35)", Path = "SEL/0/0")]
//        public string SealIdentifier { get; set; }

//        [EdiValue("X(3)", Path = "SEL/1/0")]
//        public string SealIssuer { get; set; }
//    }

//    [EdiSegment, EdiPath("CNT")]
//    public class Control
//    {
//        [EdiValue("X(3)", Path = "CNT/0/0")]
//        public string ControlQualifier { get; set; }

//        [EdiValue("X(15)", Path = "CNT/0/1")]
//        public string ControlValue { get; set; }
//    }

//    [EdiSegment, EdiPath("UNT")]
//    public class MessageTrailer
//    {
//        [EdiValue("X(6)", Path = "UNT/0/0")]
//        public string SegmentCount { get; set; }

//        [EdiValue("X(14)", Path = "UNT/1/0")]
//        public string MessageReferenceNumber { get; set; }
//    }

//    [EdiSegment, EdiPath("UNZ")]
//    public class InterchangeTrailer
//    {
//        [EdiValue("X(6)", Path = "UNZ/0/0")]
//        public string InterchangeControlCount { get; set; }

//        [EdiValue("X(14)", Path = "UNZ/1/0")]
//        public string InterchangeControlReference { get; set; }
//    }


//    [EdiSegmentGroup("TDT", "RFF", "LOC", "DTM")]
//    public class TransportDetails : DetailsOfTransport
//    {
//        public List<Reference>? References { get; set; }
//        public List<Location> Locations { get; set; }
//        public List<DateTimePeriod> DateTimePeriods { get; set; }
//    }

//    [EdiSegmentGroup("NAD", "CTA", "RFF", "DTM")]
//    public class ContactDetails : NameAndAddress
//    {
//        public List<Reference> References { get; set; }
//        public List<DateTimePeriod> DateTimePeriods { get; set; }
//    }

//    [EdiMessage]
//    public class Message
//    {
//        public MessageHeader messageHeader { get; set; }
//        public BeginningOfMessage beginningOfMessage { get; set; }
//        public List<Reference> references { get; set; }
//        public List<TransportDetails> transportDetails { get; set; }
//        public List<ContactDetails> contactDetails { get; set; }
//    }



//}

