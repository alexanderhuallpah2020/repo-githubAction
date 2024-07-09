using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("TMD")]
    public class TransportMovementDetails
    {
        [EdiElement, EdiPath("TMD/0")]
        public MovementType MovementType { get; set; }

        [EdiValue("X(26)", Path = "TMD/1", Mandatory = false)]
        public string EquipmentPlan { get; set; }

        [EdiValue("X(3)", Path = "TMD/2", Mandatory = false)]
        public string HaulageArrangementsCoded { get; set; }
    }

    [EdiElement, EdiPath("TMD/0")]
    public class MovementType
    {
        [EdiValue("X(3)", Path = "TMD/0/0", Mandatory = false)]
        public string MovementTypeCoded { get; set; }

        [EdiValue("X(35)", Path = "TMD/0/1", Mandatory = false)]
        public string MovementTypeText { get; set; }
    }

}
