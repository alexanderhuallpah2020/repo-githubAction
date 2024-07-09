using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("LOC")]
    public class LocationIdentification
    {
        [EdiValue("X(3)", Path = "LOC/0/0")]
        public string LocationQualifier { get; set; }

        [EdiElement, EdiPath("LOC/1")]
        public LocationDetails LocationDetails { get; set; }

        [EdiElement, EdiPath("LOC/2")]
        public RelatedLocationOneIdentification RelatedLocationOneDetails { get; set; }

        [EdiElement, EdiPath("LOC/3")]
        public RelatedLocationTwoIdentification RelatedLocationTwoDetails { get; set; }

        [EdiValue("X(3)", Path = "LOC/4/0")]
        public string RelationCoded { get; set; }
    }

    [EdiElement, EdiPath("LOC/1")]
    public class LocationDetails
    {
        [EdiValue("X(25)", Path = "LOC/1/0")]
        public string PlaceLocationIdentificationBase { get; set; }

        public string PlaceLocationIdentification => PlaceLocationIdentificationBase.Substring(0, 2) + '-' + PlaceLocationIdentificationBase.Substring(2);

        [EdiValue("X(3)", Path = "LOC/1/1")]
        public string CodeListQualifier { get; set; }

            [EdiValue("X(3)", Path = "LOC/1/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(17)", Path = "LOC/1/3")]
        public string PlaceLocation { get; set; }

        
    }

    [EdiElement, EdiPath("LOC/2")]
    public class RelatedLocationOneIdentification
    {
        [EdiValue("X(25)", Path = "LOC/2/0")]
        public string RelatedPlaceLocationOneIdentification { get; set; }

        [EdiValue("X(3)", Path = "LOC/2/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "LOC/2/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(70)", Path = "LOC/2/3")]
        public string RelatedPlaceLocationOne { get; set; }
    }

    [EdiElement, EdiPath("LOC/3")]
    public class RelatedLocationTwoIdentification
    {
        [EdiValue("X(25)", Path = "LOC/3/0")]
        public string RelatedPlaceLocationTwoIdentification { get; set; }

        [EdiValue("X(3)", Path = "LOC/3/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "LOC/3/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(70)", Path = "LOC/3/3")]
        public string RelatedPlaceLocationTwo { get; set; }
    }
}
