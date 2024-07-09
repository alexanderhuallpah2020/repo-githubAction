using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("GOR")]
    public class GovernmentalRequirements
    {
        [EdiValue("X(3)", Path = "GOR/0/0")]
        public string TransportMovementCoded { get; set; }

        [EdiElement, EdiPath("GOR/1")]
        public List<GovernmentAction> GovernmentActions { get; set; } = new List<GovernmentAction>();
    }

    [EdiElement, EdiPath("GOR/1")]
    public class GovernmentAction
    {
        [EdiValue("X(3)", Path = "GOR/1/0")]
        public string GovernmentAgencyCoded { get; set; }

        [EdiValue("X(3)", Path = "GOR/1/1")]
        public string GovernmentInvolvementCoded { get; set; }

        [EdiValue("X(3)", Path = "GOR/1/2")]
        public string GovernmentActionCode { get; set; }

        [EdiValue("X(3)", Path = "GOR/1/3")]
        public string GovernmentProcedureCoded { get; set; }
    }


}
