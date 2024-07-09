using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("CTA")]
    public class ContactInformation
    {
        [EdiValue("X(3)", Path = "CTA/0", Mandatory = false)]
        public string ContactFunctionCoded { get; set; }

        [EdiElement, EdiPath("CTA/0")]
        public DepartmentOrEmployeeDetails DepartmentOrEmployeeDetails { get; set; }

    }

    [EdiElement, EdiPath("CTA/0")]
    public class DepartmentOrEmployeeDetails
    {
        [EdiValue("X(17)", Path = "CTA/0/0", Mandatory = false)]
        public string DepartmentOrEmployeeIdentification { get; set; }

        [EdiValue("X(35)", Path = "CTA/0/1", Mandatory = false)]
        public string DepartmentOrEmployee { get; set; }
    }

}
