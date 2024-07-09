using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("RNG")]
    public class RangeDetails
    {
        [EdiValue("X(3)", Path = "RNG/0/0")]
        public string RangeTypeQualifier { get; set; }

        [EdiElement, EdiPath("RNG/1")]
        public Range Range { get; set; }
    }

    [EdiElement, EdiPath("RNG/1")]
    public class Range
    {
        [EdiValue("X(3)", Path = "RNG/1/0")]
        public string MeasureUnitQualifier { get; set; }

        [EdiValue("9(18)", Path = "RNG/1/1")]
        public decimal? RangeMinimum { get; set; }

        [EdiValue("9(18)", Path = "RNG/1/2")]
        public decimal? RangeMaximum { get; set; }
    }
}
