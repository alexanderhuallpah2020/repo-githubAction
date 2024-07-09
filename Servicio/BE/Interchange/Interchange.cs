using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRV_EdiFileService.Servicio.BE.Interchange.Message;

namespace SRV_EdiFileService.Servicio.BE.Interchange
{
    public class Interchange
    {
        public InterchangeHeader InterchangeHeader { get; set; }

        public List<CoparnMessage> CoparnMessages { get; set;}

        public InterchangeTrailer InterchangeTrailer { get; set; }
    }
}
