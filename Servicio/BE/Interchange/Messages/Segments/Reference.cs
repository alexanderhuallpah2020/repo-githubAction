using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("RFF")]
    public class Reference
    {
        [EdiElement, EdiPath("RFF/0")]
        public ReferenceInformation ReferenceInformation { get; set; }
    }

    [EdiElement, EdiPath("RFF/0")]
    public class ReferenceInformation
    {
        [EdiValue("X(3)", Path = "RFF/0/0", Mandatory = true)]
        public string ReferenceQualifier { get; set; }

        [EdiValue("X(35)", Path = "RFF/0/1", Mandatory = false)]
        public string ReferenceNumber { get; set; }

        [EdiValue("X(6)", Path = "RFF/0/2", Mandatory = false)]
        public string LineNumber { get; set; }

        [EdiValue("X(35)", Path = "RFF/0/3", Mandatory = false)]
        public string ReferenceVersionNumber { get; set; }
    }
}
