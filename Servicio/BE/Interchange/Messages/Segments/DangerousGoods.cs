using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("DGS")]
    public class DangerousGoods
    {
        [EdiValue("X(3)", Path = "DGS/0")]
        public string DangerousGoodsRegulationsCoded { get; set; }

        [EdiElement, EdiPath("DGS/1")]
        public HazardCode HazardCode { get; set; }

        [EdiElement, EdiPath("DGS/2")]
        public UNDGInformation UndgInformation { get; set; }

        [EdiElement, EdiPath("DGS/3")]
        public DangerousGoodsShipmentFlashpoint DangerousGoodsShipmentFlashpoint { get; set; }

        [EdiValue("X(3)", Path = "DGS/4")]
        public string PackingGroupCoded { get; set; }

        [EdiValue("X(6)", Path = "DGS/5")]
        public string EMSNumber { get; set; }

        [EdiValue("X(4)", Path = "DGS/6")]
        public string MFAG { get; set; }

        [EdiValue("X(10)", Path = "DGS/7")]
        public string TremCardNumber { get; set; }

        [EdiElement, EdiPath("DGS/8")]
        public HazardIdentification HazardIdentification { get; set; }

        [EdiElement, EdiPath("DGS/9")]
        public DangerousGoodsLabel DangerousGoodsLabel { get; set; }

        [EdiValue("X(3)", Path = "DGS/10")]
        public string PackingInstructionCoded { get; set; }

        [EdiValue("X(3)", Path = "DGS/11")]
        public string CategoryOfMeansOfTransportCoded { get; set; }

        [EdiValue("X(3)", Path = "DGS/12")]
        public string PermissionForTransportCoded { get; set; }
    }

    [EdiElement, EdiPath("DGS/1")]
    public class HazardCode
    {
        [EdiValue("X(7)", Path = "DGS/1/0")]
        public string HazardCodeIdentification { get; set; }

        [EdiValue("X(7)", Path = "DGS/1/1")]
        public string HazardSubstanceItemPageNumber { get; set; }

        [EdiValue("X(10)", Path = "DGS/1/2")]
        public string HazardCodeVersionNumber { get; set; }
    }

    [EdiElement, EdiPath("DGS/2")]
    public class UNDGInformation
    {
        [EdiValue("9(4)", Path = "DGS/2/0")]
        public string UNDGNumber { get; set; }

        [EdiValue("X(8)", Path = "DGS/2/1")]
        public string DangerousGoodsFlashpoint { get; set; }
    }

    [EdiElement, EdiPath("DGS/3")]
    public class DangerousGoodsShipmentFlashpoint
    {
        [EdiValue("9(3)", Path = "DGS/3/0")]
        public decimal ShipmentFlashpoint { get; set; }

        [EdiValue("X(3)", Path = "DGS/3/1")]
        public string MeasureUnitQualifier { get; set; }
    }

    [EdiElement, EdiPath("DGS/8")]
    public class HazardIdentification
    {
        [EdiValue("X(4)", Path = "DGS/8/0")]
        public string HazardIdentificationNumberUpperPart { get; set; }

        [EdiValue("X(4)", Path = "DGS/8/1")]
        public string SubstanceIdentificationNumberLowerPart { get; set; }
    }

    [EdiElement, EdiPath("DGS/9")]
    public class DangerousGoodsLabel
    {
        [EdiValue("X(4)", Path = "DGS/9/0")]
        public string DangerousGoodsLabelMarking { get; set; }
    }

}
