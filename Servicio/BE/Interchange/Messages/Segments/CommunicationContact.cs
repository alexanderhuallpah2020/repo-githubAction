using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("COM")]
    public class CommunicationContact
    {
        [EdiElement, EdiPath("COM/0")]
        public CommunicationDetails CommunicationDetails { get; set; }
    }

    [EdiElement, EdiPath("COM/0")]
    public class CommunicationDetails
    {
        [EdiValue("X(25)", Path = "COM/0/0", Mandatory = true)]
        public string CommunicationNumber { get; set; }

        [EdiValue("X(3)", Path = "COM/0/1", Mandatory = true)]
        public string CommunicationChannelQualifier { get; set; }
    }
}
