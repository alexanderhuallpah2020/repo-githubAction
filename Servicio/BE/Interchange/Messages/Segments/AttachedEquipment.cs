using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("EQA")]

    public class AttachedEquipment
    {
        [EdiValue("X(3)", Path = "EQA/0", Mandatory = true)]
        public string EquipmentQualifier { get; set; }

        [EdiElement, EdiPath("EQA/1")]
        public EquipmentIdentification EquipmentIdentification { get; set; }
    }

    [EdiElement, EdiPath("EQA/1")]
    public class EquipmentIdentification
    {
        [EdiValue("X(17)", Path = "EQA/1/0", Mandatory = false)]
        public string EquipmentIdentificationNumber { get; set; }

        [EdiValue("X(3)", Path = "EQA/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "EQA/1/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(3)", Path = "EQA/1/3", Mandatory = false)]
        public string CountryCoded { get; set; }
    }
}
