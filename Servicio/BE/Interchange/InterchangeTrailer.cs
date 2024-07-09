using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange
{

    [EdiSegment, EdiPath("UNZ")]
    public class InterchangeTrailer
    {
        [EdiValue("9(1)", Path = "UNZ/0", Description = "Interchange Control Count")]
        public string InterchangeControlCount { get; set; }

        [EdiValue("X(14)", Path = "UNZ/1", Description = "Interchange Control Reference")]
        public string InterchangeControlReference { get; set; }
    }
}
