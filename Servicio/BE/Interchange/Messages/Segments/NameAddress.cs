using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("NAD")]
    public class NameAddress
    {
        [EdiValue("X(3)", Path = "NAD/0", Mandatory = true)]
        public string PartyQualifier { get; set; }

        [EdiElement, EdiPath("NAD/1")]
        public PartyIdentificationDetails PartyIdentification { get; set; }

        public List<NameAndAddressLine> NameAndAddressLines { get; set; }

        //public PartyName PartyName { get; set; }

        public List<Street> Street { get; set; }

        [EdiValue("X(35)", Path = "NAD/5", Mandatory = false)]
        public string CityName { get; set; }

        [EdiValue("X(9)", Path = "NAD/6", Mandatory = false)]
        public string CountrySubEntityIdentification { get; set; }

        [EdiValue("X(9)", Path = "NAD/7", Mandatory = false)]
        public string PostcodeIdentification { get; set; }

        [EdiValue("X(3)", Path = "NAD/8", Mandatory = false)]
        public string CountryCoded { get; set; }
    }

    [EdiElement, EdiPath("NAD/1")]
    public class PartyIdentificationDetails
    {
        [EdiValue("X(35)", Path = "NAD/1/0", Mandatory = true)]
        public string PartyIdIdentification { get; set; }

        [EdiValue("X(3)", Path = "NAD/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "NAD/1/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

    [EdiElement, EdiPath("NAD/2..*")]
    public class NameAndAddressLine
    {
        [EdiValue("X(35)", Path = "NAD/*/0", Mandatory = true)]
        public string Line { get; set; }
    }

    [EdiElement, EdiPath("NAD/3..*")]
    public class PartyName
    {
        [EdiValue("X(35)", Path = "NAD/*/0", Mandatory = true)]
        public List<string> PartyNameLines { get; set; } = new List<string>();

        [EdiValue("X(3)", Path = "NAD/3/1", Mandatory = false)]
        public string PartyNameFormatCoded { get; set; }
    }

    [EdiElement, EdiPath("NAD/4..*")]
    public class Street
    {
        [EdiValue("X(35)", Path = "NAD/*/0", Mandatory = true)]
        public string StreetAndNumber { get; set; }
    }
}
