using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegmentGroup("EQD", "RFF", "EQN", "TMD", "DTM", "TSR", "LOC", "MEA", "DIM", "TMP", "RNG", "SEL", "FTX", "DGS", "MOA", "GOR", "EQA", "DAM", "COD", "TDT", "LOC", "DTM", "NAD", "DTM", "CTA", "COM")]
    public class SG7 : EquipmentDetails
    {
        public List<Reference> References { get; set; } = new List<Reference>();
        public NumberOfUnits NumberOfUnits { get; set; }
        public List<TransportMovementDetails> TransportMovementDetails { get; set; } = new List<TransportMovementDetails>();
        public List<DateTimePeriod> DateTimePeriods { get; set; } = new List<DateTimePeriod>();
        public List<TransportServiceRequirements> TransportServiceRequirements { get; set; } = new List<TransportServiceRequirements>();
        public List<LocationIdentification> Locations { get; set; } = new List<LocationIdentification>();
        public List<Measurement> Measurements { get; set; } = new List<Measurement>();
        public List<Dimensions> Dimensions { get; set; } = new List<Dimensions>();
        public List<Temperature> Temperatures { get; set; } = new List<Temperature>();
        public List<RangeDetails> RangeDetails { get; set; } = new List<RangeDetails>();
        public List<SealNumber> SealNumber { get; set; } = new List<SealNumber>();
        public List<FreeText> FreeText { get; set; } = new List<FreeText>();
        public DangerousGoods Dangerous { get; set; }
        public List<MonetaryAmount> MonetaryAmounts { get; set; } = new List<MonetaryAmount>();
        public List<GovernmentalRequirements> GovernmentalRequirements { get; set; } = new List<GovernmentalRequirements>();
        public AttachedEquipment AttachedEquipment { get; set; }
        public List<SG8> SegmentN8 { get; set; } = new List<SG8>();
        public List<SG9> SegmentN9 { get; set; } = new List<SG9>();
        public List<SG10> SegmentN10 { get; set; } = new List<SG10>();

    }

    [EdiSegmentGroup("DAM", "COD")]
    public class SG8 : Damage
    {
        public ComponentDetails COD  { get; set; }
    }

    [EdiSegmentGroup("TDT", "LOC", "DTM")]
    public class SG9 : DetailsOfTransport
    {
        public List<LocationIdentification> Locations { get; set; } = new List<LocationIdentification>();
        public List<DateTimePeriod> DateTimePeriods { get; set; } = new List<DateTimePeriod>();

    }


    [EdiSegmentGroup("NAD", "DTM", "CTA", "COM")]
    public class SG10 : NameAddress
    {
        public DateTimePeriod DateTimePeriod { get; set; }
        public ContactInformation ContactInformation { get; set; }
        public CommunicationContact CommunicationContact { get; set; }
    }
    
}
