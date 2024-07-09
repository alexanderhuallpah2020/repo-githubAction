using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("TMP")]
    public class Temperature
    {
        [EdiValue("X(3)", Path = "TMP/0/0")]
        public string TemperatureQualifier { get; set; }

        [EdiElement, EdiPath("TMP/1")]
        public TemperatureSetting TemperatureSetting { get; set; }
    }

    [EdiElement, EdiPath("TMP/1")]
    public class TemperatureSetting
    {
        [EdiValue("9(3)", Path = "TMP/1/0")]
        public decimal? Temperature { get; set; }

        [EdiValue("X(3)", Path = "TMP/1/1")]
        public string MeasureUnitQualifier { get; set; }
    }
}
