using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("TDT")]
    public class DetailsOfTransport
    {
        [EdiValue("X(3)", Path = "TDT/0")]
        public string TransportStageQualifier { get; set; }

        [EdiValue("X(17)", Path = "TDT/1", Mandatory = false)]
        public string ConveyanceReferenceNumber { get; set; }

        [EdiElement, EdiPath("TDT/2")]
        public ModeOfTransport ModeOfTransport { get; set; }

        [EdiElement, EdiPath("TDT/3")]
        public TransportMeans TransportMeans { get; set; }

        [EdiElement, EdiPath("TDT/4")]
        public Carrier Carrier { get; set; }

        [EdiValue("X(3)", Path = "TDT/5", Mandatory = false)]
        public string TransitDirectionCoded { get; set; }

        [EdiElement, EdiPath("TDT/6")]
        public ExcessTransportationInformation ExcessTransportationInformation { get; set; }

        [EdiElement, EdiPath("TDT/7")]
        public TransportIdentification TransportIdentification { get; set; }

        [EdiValue("X(3)", Path = "TDT/8", Mandatory = false)]
        public string TransportOwnershipCoded { get; set; }
    }

    [EdiElement, EdiPath("TDT/2")]
    public class ModeOfTransport
    {
        [EdiValue("X(3)", Path = "TDT/2/0", Mandatory = false)]
        public string ModeOfTransportCoded { get; set; }

        [EdiValue("X(17)", Path = "TDT/2/1", Mandatory = false)]
        public string ModeOfTransportName { get; set; }
    }

    [EdiElement, EdiPath("TDT/3")]
    public class TransportMeans
    {
        [EdiValue("X(8)", Path = "TDT/3/0", Mandatory = false)]
        public string TypeOfMeansOfTransportIdentification { get; set; }

        [EdiValue("X(17)", Path = "TDT/3/1", Mandatory = false)]
        public string TypeOfMeansOfTransport { get; set; }
    }

    [EdiElement, EdiPath("TDT/4")]
    public class Carrier
    {
        [EdiValue("X(17)", Path = "TDT/4/0", Mandatory = false)]
        public string CarrierIdentification { get; set; }

        [EdiValue("X(3)", Path = "TDT/4/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TDT/4/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "TDT/4/3", Mandatory = false)]
        public string CarrierName { get; set; }
    }

    [EdiElement, EdiPath("TDT/6")]
    public class ExcessTransportationInformation
    {
        [EdiValue("X(3)", Path = "TDT/6/0")]
        public string ExcessTransportationReasonCoded { get; set; }

        [EdiValue("X(3)", Path = "TDT/6/1")]
        public string ExcessTransportationResponsibilityCoded { get; set; }

        [EdiValue("X(17)", Path = "TDT/6/2", Mandatory = false)]
        public string CustomerAuthorizationNumber { get; set; }
    }

    [EdiElement, EdiPath("TDT/7")]
    public class TransportIdentification
    {
        [EdiValue("X(9)", Path = "TDT/7/0")]
        public string IdOfMeansOfTransportIdentification { get; set; }

        [EdiValue("X(3)", Path = "TDT/7/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TDT/7/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "TDT/7/3")]
        public string IdOfTheMeansOfTransport { get; set; }

        [EdiValue("X(3)", Path = "TDT/7/4")]
        public string NationalityOfMeansOfTransportCoded { get; set; }
    }

}
