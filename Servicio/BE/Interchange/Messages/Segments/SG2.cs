using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegmentGroup("NAD","CTA", "RFF", "DTM")]
    public class SG2 : NameAddress
    { 
        public List<ContactInformation> Contacts  { get; set; }
        public List<Reference> References { get; set; } = new List<Reference>();
        public List<DateTimePeriod> DateTimePeriods { get; set; } = new List<DateTimePeriod>();
    }
}
