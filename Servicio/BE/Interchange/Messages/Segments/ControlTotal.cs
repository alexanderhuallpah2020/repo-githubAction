using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("CNT")]
    public class ControlTotal
    {
        [EdiElement, EdiPath("CNT/0")]
        public Control Control { get; set; }
    }

    [EdiElement, EdiPath("CNT/0")]
    public class Control
    {
        [EdiValue("X(3)", Path = "CNT/0/0", Mandatory = true)]
        public string ControlQualifier { get; set; }

        [EdiValue("9(18)", Path = "CNT/0/1", Mandatory = true)]
        public decimal ControlValue { get; set; }

        [EdiValue("X(3)", Path = "CNT/0/2", Mandatory = false)]
        public string MeasureUnitQualifier { get; set; }
    }
}
