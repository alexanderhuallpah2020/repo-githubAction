using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using indice.Edi.Serialization;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("PIA")]
    public class AdditionalProductID
    {
        [EdiValue("X(3)", Path = "PIA/0", Mandatory = true)]
        public string ProductIDFunctionQualifier { get; set; }

        public List<ItemNumberIdentification> ItemNumberIdentifications { get; set; } = new List<ItemNumberIdentification>();
    }

    [EdiElement, EdiPath("PIA/1..*")]
    public class ItemNumberIdentification
    {
        [EdiValue("X(35)", Path = "PIA/*/0", Mandatory = false)]
        public string ItemNumber { get; set; }

        [EdiValue("X(3)", Path = "PIA/*/1", Mandatory = false)]
        public string ItemNumberTypeCoded { get; set; }

        [EdiValue("X(3)", Path = "PIA/*/2", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "PIA/*/3", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }
}
