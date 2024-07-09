using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    using indice.Edi.Serialization;

    [EdiSegment, EdiPath("DOC")]
    public class DocumentMessageDetails
    {
        [EdiElement, EdiPath("DOC/0")]
        public DocumentMessageNameData DocumentMessageName { get; set; }

        [EdiElement, EdiPath("DOC/1")]
        public DocumentMessageIdentification DocumentMessageIdentification { get; set; }

        [EdiValue("X(3)", Path = "DOC/2/0")]
        public string CommunicationChannelIdentifier { get; set; }

        [EdiValue("9(2)", Path = "DOC/3/0")]
        public int NumberOfCopiesOfDocumentRequired { get; set; }

        [EdiValue("9(2)", Path = "DOC/4/0")]
        public int NumberOfOriginalsOfDocumentRequired { get; set; }
    }

    [EdiElement, EdiPath("DOC/0")]
    public class DocumentMessageNameData
    {
        [EdiValue("X(3)", Path = "DOC/0/0")]
        public string DocumentMessageNameCoded { get; set; }

        [EdiValue("X(3)", Path = "DOC/0/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "DOC/0/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "DOC/0/3")]
        public string DocumentMessageName { get; set; }
    }

    [EdiElement, EdiPath("DOC/1")]
    public class DocumentMessageIdentification
    {
        [EdiValue("X(35)", Path = "DOC/1/0")]
        public string DocumentIdentifier { get; set; }

        [EdiValue("X(3)", Path = "DOC/1/1")]
        public string DocumentStatus { get; set; }

        [EdiValue("X(3)", Path = "DOC/1/2")]
        public string DocumentSource { get; set; }

        [EdiValue("X(3)", Path = "DOC/1/3")]
        public string LanguageCoded { get; set; }
    }

}
