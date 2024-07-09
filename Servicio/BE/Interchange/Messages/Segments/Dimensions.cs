using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("DIM")]
    public class Dimensions
    {
        [EdiValue("X(3)", Path = "DIM/0")]
        public string DimensionQualifier { get; set; }

        [EdiElement, EdiPath("DIM/1")]
        public DimensionDetails DimensionDetails { get; set; }
    }

    [EdiElement, EdiPath("DIM/1")]
    public class DimensionDetails
    {
        [EdiValue("X(3)", Path = "DIM/1/0")]
        public string MeasureUnitQualifier { get; set; }

        [EdiValue("9(15)", Path = "DIM/1/1", Mandatory = false)]
        public decimal? LengthDimension { get; set; }

        [EdiValue("9(15)", Path = "DIM/1/2", Mandatory = false)]
        public decimal? WidthDimension { get; set; }

        [EdiValue("9(15)", Path = "DIM/1/3", Mandatory = false)]
        public decimal? HeightDimension { get; set; }
    }

}
