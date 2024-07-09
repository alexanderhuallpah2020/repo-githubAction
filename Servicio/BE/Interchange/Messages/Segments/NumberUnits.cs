using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("EQN")]
    public class NumberOfUnits
    {
        [EdiElement, EdiPath("EQN/0")]
        public NumberOfUnitDetails NumberOfUnitDetails { get; set; }
    }

    [EdiElement, EdiPath("EQN/0")]
    public class NumberOfUnitDetails
    {
        [EdiValue("9(15)", Path = "EQN/0/0")]
        public int NumberOfUnits { get; set; }

        [EdiValue("X(3)", Path = "EQN/0/1")]
        public string NumberOfUnitsQualifier { get; set; }
    }

}
