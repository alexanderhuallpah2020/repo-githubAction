using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("SGP")]
    public class SplitGoodsPlacement
    {
        [EdiElement, EdiPath("SGP/0")]
        public EquipmentIdentification__ EquipmentIdentification { get; set; }

        [EdiValue("9(8)", Path = "SGP/1/0")]
        public int? NumberOfPackages { get; set; }
    }

    [EdiElement, EdiPath("SGP/0")]
    public class EquipmentIdentification__
    {
        [EdiValue("X(17)", Path = "SGP/0/0")]
        public string EquipmentIdentificationNumber { get; set; }

        [EdiValue("X(3)", Path = "SGP/0/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "SGP/0/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(3)", Path = "SGP/0/3")]
        public string CountryCoded { get; set; }
    }

}
