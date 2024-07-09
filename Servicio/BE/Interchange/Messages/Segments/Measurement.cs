using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("MEA")]
    public class Measurement
    {
        [EdiValue("X(3)", Path = "MEA/0/0")]
        public string MeasurementApplicationQualifier { get; set; }

        [EdiElement, EdiPath("MEA/1")]
        public MeasurementDetails MeasurementDetails { get; set; }

        [EdiElement, EdiPath("MEA/2")]
        public ValueRange ValueRange { get; set; }

        [EdiValue("X(3)", Path = "MEA/3/0")]
        public string SurfaceLayerIndicatorCoded { get; set; }
    }

    [EdiElement, EdiPath("MEA/1")]
    public class MeasurementDetails
    {
        [EdiValue("X(3)", Path = "MEA/1/0")]
        public string MeasurementDimensionCoded { get; set; }

        [EdiValue("X(3)", Path = "MEA/1/1")]
        public string MeasurementSignificanceCoded { get; set; }

        [EdiValue("X(3)", Path = "MEA/1/2")]
        public string MeasurementAttributeCoded { get; set; }

        [EdiValue("X(70)", Path = "MEA/1/3")]
        public string MeasurementAttribute { get; set; }
    }

    [EdiElement, EdiPath("MEA/2")]
    public class ValueRange
    {
        [EdiValue("X(3)", Path = "MEA/2/0")]
        public string MeasureUnitQualifier { get; set; }

        [EdiValue("9(18)", Path = "MEA/2/1")]
        public decimal? MeasurementValue { get; set; }

        [EdiValue("9(18)", Path = "MEA/2/2")]
        public decimal? RangeMinimum { get; set; }

        [EdiValue("9(18)", Path = "MEA/2/3")]
        public decimal? RangeMaximum { get; set; }

        [EdiValue("9(2)", Path = "MEA/2/4")]
        public int? SignificantDigits { get; set; }
    }
}
