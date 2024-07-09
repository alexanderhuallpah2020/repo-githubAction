using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("EQD")]
    public class EquipmentDetails
    {
        [EdiValue("X(3)", Path = "EQD/0/0")]
        public string EquipmentQualifier { get; set; }

        [EdiElement, EdiPath("EQD/1")]
        public EquipmentIdentification_ EquipmentIdentification { get; set; }

        [EdiElement, EdiPath("EQD/2")]
        public EquipmentSizeAndType EquipmentSizeAndType { get; set; }

        [EdiValue("X(3)", Path = "EQD/3/0")]
        public string EquipmentSupplierCoded { get; set; }

        [EdiValue("X(3)", Path = "EQD/4/0")]
        public string EquipmentStatusCoded { get; set; }

        [EdiValue("X(3)", Path = "EQD/5/0")]
        public string FullEmptyIndicatorCoded { get; set; }
    }


    [EdiElement, EdiPath("EQD/1")]
    public class EquipmentIdentification_
    {
        [EdiValue("X(17)", Path = "EQD/1/0")]
        public string EquipmentIdentificationNumber { get; set; }

        [EdiValue("X(3)", Path = "EQD/1/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "EQD/1/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(3)", Path = "EQD/1/3")]
        public string CountryCoded { get; set; }
    }

    [EdiElement, EdiPath("EQD/2")]
    public class EquipmentSizeAndType
    {
        [EdiValue("X(10)", Path = "EQD/2/0")]
        public string EquipmentSizeAndTypeIdentification { get; set; }

        [EdiValue("X(3)", Path = "EQD/2/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "EQD/2/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "EQD/2/3")]
        public string EquipmentSizeAndTypeText { get; set; }
    }

}
