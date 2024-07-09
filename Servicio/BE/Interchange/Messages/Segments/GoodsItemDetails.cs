using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    [EdiSegment, EdiPath("GID")]
    public class GoodsItemDetails
    {
        [EdiValue("X(5)", Path = "GID/0", Mandatory = true)]
        public string GoodsItemNumber { get; set; }

        [EdiElement, EdiPath("GID/1")]
        public List<PackageDetail> PackageDetails { get; set; } = new List<PackageDetail>();
    }

    [EdiElement, EdiPath("GID/1")]
    public class PackageDetail
    {
        [EdiValue("X(8)", Path = "GID/1/0", Mandatory = false)]
        public string NumberOfPackages { get; set; }

        [EdiValue("X(17)", Path = "GID/1/1", Mandatory = false)]
        public string TypeOfPackagesIdentification { get; set; }

        [EdiValue("X(3)", Path = "GID/1/2", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "GID/1/3", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "GID/1/4", Mandatory = false)]
        public string TypeOfPackages { get; set; }
    } 
}
