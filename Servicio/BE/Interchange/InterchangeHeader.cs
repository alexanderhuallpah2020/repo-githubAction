using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange
{

    [EdiSegment, EdiPath("UNB")]
    public class InterchangeHeader
    {
        [EdiElement, EdiPath("UNB/0")]
        public SyntaxIdentifier SyntaxIdentifier { get; set; }

        [EdiElement, EdiPath("UNB/1")]
        public InterchangeSender InterchangeSender { get; set; }

        [EdiElement, EdiPath("UNB/2")]
        public InterchangeRecipient InterchangeRecipient { get; set; }

        [EdiElement, EdiPath("UNB/3")]
        public DateTimeOfPreparation DateTimeOfPreparation { get; set; }

        [EdiValue("X(14)", Path = "UNB/4")]
        public string InterchangeControlReference { get; set; }

        [EdiElement, EdiPath("UNB/5")]
        public RecipientsReferencePassword RecipientsReferencePassword { get; set; }

        [EdiValue("X(14)", Path = "UNB/6", Mandatory = false)]
        public string ApplicationReference { get; set; }

        [EdiValue("X(1)", Path = "UNB/7", Mandatory = false)]
        public string ProcessingPriorityCode { get; set; }

        [EdiValue("9(1)", Path = "UNB/8", Mandatory = false)]
        public string AcknowledgementRequest { get; set; }

        [EdiValue("X(35)", Path = "UNB/9", Mandatory = false)]
        public string CommunicationsAgreementId { get; set; }

        [EdiValue("9(1)", Path = "UNB/10", Mandatory = false)]
        public string TestIndicator { get; set; }
    }

    [EdiElement, EdiPath("UNB/0")]
    public class SyntaxIdentifier
    {
        [EdiValue("X(4)", Path = "UNB/0/0")]
        public string Identifier { get; set; }

        [EdiValue("9(1)", Path = "UNB/0/1")]
        public int VersionNumber { get; set; }
    }

    [EdiElement, EdiPath("UNB/1")]
    public class InterchangeSender
    {
        [EdiValue("X(35)", Path = "UNB/1/0")]
        public string SenderIdentification { get; set; }

        [EdiValue("X(4)", Path = "UNB/1/1")]
        public string PartnerIDCodeQualifier { get; set; }

        [EdiValue("X(14)", Path = "UNB/1/2")]
        public string ReverseRoutingAddress { get; set; }
    }

    [EdiElement, EdiPath("UNB/2")]
    public class InterchangeRecipient
    {
        [EdiValue("X(35)", Path = "UNB/2/0")]
        public string RecipientIdentification { get; set; }

        [EdiValue("X(4)", Path = "UNB/2/1")]
        public string PartnerIDCodeQualifier { get; set; }

        [EdiValue("X(14)", Path = "UNB/2/2")]
        public string RoutingAddress { get; set; }
    }

    [EdiElement, EdiPath("UNB/3")]
    public class DateTimeOfPreparation
    {
        [EdiValue("9(6)", Path = "UNB/3/0")]
        public string Date { get; set; }

        [EdiValue("9(4)", Path = "UNB/3/1")]
        public string Time { get; set; }
    }

    [EdiElement, EdiPath("UNB/5")]
    public class RecipientsReferencePassword
    {
        [EdiValue("X(14)", Path = "UNB/5/0")]
        public string ReferencePassword { get; set; }

        [EdiValue("X(2)", Path = "UNB/5/1")]
        public string ReferencePasswordQualifier { get; set; }
    }
}
