using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("SEL")]
    public class SealNumber
    {
        [EdiValue("X(10)", Path = "SEL/0/0")]
        public string SealNumberValue { get; set; }

        [EdiElement, EdiPath("SEL/1")]
        public SealIssuer SealIssuer { get; set; }

        [EdiValue("X(3)", Path = "SEL/2/0")]
        public string SealConditionCoded { get; set; }
    }

    [EdiElement, EdiPath("SEL/1")]
    public class SealIssuer
    {
        [EdiValue("X(3)", Path = "SEL/1/0")]
        public string SealingPartyCoded { get; set; }

        [EdiValue("X(3)", Path = "SEL/1/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "SEL/1/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "SEL/1/3")]
        public string SealingParty { get; set; }
    }
}
