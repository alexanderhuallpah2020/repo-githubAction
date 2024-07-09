using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("COD")]
    public class ComponentDetails
    {
        [EdiElement, EdiPath("COD/0")]
        public TypeOfUnitComponent TypeOfUnitComponent { get; set; }

        [EdiElement, EdiPath("COD/1")]
        public ComponentMaterial ComponentMaterial { get; set; }
    }

    [EdiElement, EdiPath("COD/0")]
    public class TypeOfUnitComponent
    {
        [EdiValue("X(3)", Path = "COD/0/0", Mandatory = false)]
        public string TypeOfUnitComponentCoded { get; set; }

        [EdiValue("X(3)", Path = "COD/0/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "COD/0/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "COD/0/3", Mandatory = false)]
        public string TypeOfUnitComponentText { get; set; }
    }

    [EdiElement, EdiPath("COD/1")]
    public class ComponentMaterial
    {
        [EdiValue("X(3)", Path = "COD/1/0", Mandatory = false)]
        public string ComponentMaterialCoded { get; set; }

        [EdiValue("X(3)", Path = "COD/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "COD/1/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "COD/1/3", Mandatory = false)]
        public string ComponentMaterialText { get; set; }
    }

}
