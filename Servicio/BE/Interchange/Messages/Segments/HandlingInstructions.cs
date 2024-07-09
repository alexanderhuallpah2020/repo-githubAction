using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("HAN")]
    public class HandlingInstructions
    {
        [EdiElement, EdiPath("HAN/0")]
        public HandlingInformation HandlingInformation { get; set; }

        [EdiElement, EdiPath("HAN/1")]
        public HazardousMaterial HazardousMaterial { get; set; }
    }

    [EdiElement, EdiPath("HAN/0")]
    public class HandlingInformation
    {
        [EdiValue("X(3)", Path = "HAN/0/0")]
        public string HandlingInstructionsCoded { get; set; }

        [EdiValue("X(3)", Path = "HAN/0/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "HAN/0/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(70)", Path = "HAN/0/3")]
        public string HandlingInstructions { get; set; }
    }

    [EdiElement, EdiPath("HAN/1")]
    public class HazardousMaterial
    {
        [EdiValue("X(4)", Path = "HAN/1/0")]
        public string HazardousMaterialClassCodeIdentification { get; set; }

        [EdiValue("X(3)", Path = "HAN/1/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "HAN/1/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

}
