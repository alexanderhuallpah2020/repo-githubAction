using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("BGM")]
    public class BeginningOfMessage
    {
        [EdiElement, EdiPath("BGM/0")]
        public DocumentMessageName DocumentMessageName { get; set; }

        [EdiValue("X(35)", Path = "BGM/1", Mandatory = false)]
        public string DocumentMessageNumber { get; set; }

        [EdiValue("X(3)", Path = "BGM/2", Mandatory = false)]
        public MessageFunctionCode MessageFunctionCoded { get; set; }

        [EdiValue("X(3)", Path = "BGM/3", Mandatory = false)]
        public string ResponseTypeCoded { get; set; }
    }

    [EdiElement, EdiPath("BGM/0")]
    public class DocumentMessageName
    {
        [EdiValue("X(3)", Path = "BGM/0/0")]
        public string DocumentMessageNameCoded { get; set; }

        [EdiValue("X(3)", Path = "BGM/0/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "BGM/0/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "BGM/0/3", Mandatory = false)]
        public string DocumentMessageNameText { get; set; }
    }
}
