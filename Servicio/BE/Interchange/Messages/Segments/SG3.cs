using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegmentGroup("GID", "HAN", "FTX", "RFF", "PIA", "NAD", "DTM", "RFF", "MEA", "DIM", "DOC", "SGP", "MEA", "DGS", "FTX", "MEA")]
    public class SG3 : GoodsItemDetails
    {
        public List<HandlingInstructions> HandlingInstructions { get; set; } = new List<HandlingInstructions>();
        public List<FreeText> FreeText { get; set; } = new List<FreeText>();
        public List<Reference> References { get; set; } = new List<Reference>();

        public List<AdditionalProductID> AdditionalProductIDs { get; set; } = new List<AdditionalProductID>();

        public List<SG4> ItemAddresses { get; set; } = new List<SG4>();
        public List<SG5> ItemDistribution { get; set; } = new List<SG5>();
        public List<SG6> ItemDangerousDetails { get; set; } = new List<SG6>();
    }

    [EdiSegmentGroup("NAD", "DTM", "RFF", "MEA", "DIM", "DOC")]
    public class SG4 : NameAddress
    {
        public List<DateTimePeriod> DateTimePeriods { get; set; } = new List<DateTimePeriod>();
        public List<Reference> References { get; set; } = new List<Reference>();
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public List<Dimensions> Dimensions { get; set; } = new List<Dimensions>();
        public List<DocumentMessageDetails> DocumentMessageDetails { get; set; } = new List<DocumentMessageDetails>();
    }

    [EdiSegmentGroup("SGP", "MEA")]
    public class SG5 : SplitGoodsPlacement
    {
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
    }

    [EdiSegmentGroup("DGS", "FTX", "MEA")]
    public class SG6 : DangerousGoods
    {
        public List<FreeText> FreeText { get; set; } = new List<FreeText>();
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
    }

}
