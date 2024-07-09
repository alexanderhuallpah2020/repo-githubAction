using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("DTM")]
    public class DateTimePeriod
    {
        [EdiElement, EdiPath("DTM/0")]
        public DateTimePeriodDetails DateTimePeriodDetails { get; set; }
    }

    [EdiElement, EdiPath("DTM/0")]
    public class DateTimePeriodDetails
    {
        [EdiValue("X(3)", Path = "DTM/0/0", Mandatory = true)]
        public string DateTimePeriodQualifier { get; set; }

        [EdiValue("X(35)", Path = "DTM/0/1", Format = "yyyyMMddHHmm")]
        public DateTime DateTimePeriod { get; set; }

        [EdiValue("X(3)", Path = "DTM/0/2", Mandatory = false)]
        public string DateTimePeriodFormatQualifier { get; set; }
    }
}
