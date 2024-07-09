using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;
using System.Collections.Generic;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("FTX")]
    public class FreeText
    {
        [EdiValue("X(3)", Path = "FTX/0", Mandatory = true)]
        public string TextSubjectQualifier { get; set; }

        [EdiValue("X(3)", Path = "FTX/1", Mandatory = false)]
        public string TextFunctionCoded { get; set; }

        [EdiElement, EdiPath("FTX/2")]
        public TextReference TextReference { get; set; }

        [EdiElement, EdiPath("FTX/3")]
        public TextLiteral TextLiterals { get; set; }

        [EdiValue("X(3)", Path = "FTX/4", Mandatory = false)]
        public string LanguageCoded { get; set; }
    }

    [EdiElement, EdiPath("FTX/2")]
    public class TextReference
    {
        [EdiValue("X(3)", Path = "FTX/2/0", Mandatory = true)]
        public string FreeTextCoded { get; set; }

        [EdiValue("X(3)", Path = "FTX/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "FTX/2/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

    [EdiElement, EdiPath("FTX/3")]
    public class TextLiteral
    {
        [EdiValue("X(70)", Path = "FTX/3/0", Mandatory = true)]
        public string FreeText1 { get; set; }

        [EdiValue("X(70)", Path = "FTX/3/1", Mandatory = true)]
        public string FreeText2 { get; set; }

        [EdiValue("X(70)", Path = "FTX/3/2", Mandatory = true)]
        public string FreeText3 { get; set; }

        [EdiValue("X(70)", Path = "FTX/3/3", Mandatory = true)]
        public string FreeText4 { get; set; }

        [EdiValue("X(70)", Path = "FTX/3/4", Mandatory = true)]
        public string FreeText5 { get; set; }
    }

}
