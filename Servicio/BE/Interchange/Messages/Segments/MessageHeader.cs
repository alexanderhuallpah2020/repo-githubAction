using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("UNH")]
    public class MessageHeader
    {
        [EdiValue("X(14)", Path = "UNH/0")]
        public string MessageReferenceNumber { get; set; }

        [EdiElement, EdiPath("UNH/1")]
        public MessageIdentifier MessageIdentifier { get; set; }

        [EdiValue("X(35)", Path = "UNH/2", Mandatory = false)]
        public string CommonAccessReference { get; set; }

        [EdiElement, EdiPath("UNH/3")]
        public StatusOfTheTransfer StatusOfTheTransfer { get; set; }
    }

    [EdiElement, EdiPath("UNH/1")]
    public class MessageIdentifier
    {
        [EdiValue("X(6)", Path = "UNH/1/0")]
        public string MessageType { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/1")]
        public string MessageVersionNumber { get; set; }

        [EdiValue("X(3)", Path = "UNH/1/2")]
        public string MessageReleaseNumber { get; set; }

        [EdiValue("X(2)", Path = "UNH/1/3")]
        public string ControllingAgency { get; set; }

        [EdiValue("X(6)", Path = "UNH/1/4", Mandatory = false)]
        public string AssociationAssignedCode { get; set; }
    }

    [EdiElement, EdiPath("UNH/3")]
    public class StatusOfTheTransfer
    {
        [EdiValue("9(2)", Path = "UNH/3/0")]
        public int SequenceOfTransfers { get; set; }

        [EdiValue("X(1)", Path = "UNH/3/1", Mandatory = false)]
        public string FirstAndLastTransfer { get; set; }
    }


}
