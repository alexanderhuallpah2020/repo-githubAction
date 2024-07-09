using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegmentGroup("TDT", "RFF", "LOC", "DTM")]
    public class SG1 : DetailsOfTransport
    {
        public List<Reference> References  { get; set; } = new List<Reference>();
        public List<LocationIdentification> Locations { get; set; } = new List<LocationIdentification>();
        public List<DateTimePeriod> DateTimePeriods { get; set; } = new List<DateTimePeriod>();

    }
}
