using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("UNT")]
    public class MessageTrailer
    {
        [EdiValue("9(6)", Path = "UNT/0", Description = "Number of Segments in the Message", Mandatory = true)]
        public int NumberOfSegments { get; set; }

        [EdiValue("X(14)", Path = "UNT/1", Description = "Message Reference Number", Mandatory = true)]
        public string MessageReferenceNumber { get; set; }
    }
}
