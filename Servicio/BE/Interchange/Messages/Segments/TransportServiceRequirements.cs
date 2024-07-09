using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("TSR")]
    public class TransportServiceRequirements
    {
        [EdiElement, EdiPath("TSR/0")]
        public ContractAndCarriageCondition ContractAndCarriageCondition { get; set; }

        [EdiElement, EdiPath("TSR/1")]
        public ServiceRequirement ServiceRequirement { get; set; }

        [EdiElement, EdiPath("TSR/2")]
        public TransportPriority TransportPriority { get; set; }

        [EdiElement, EdiPath("TSR/3")]
        public NatureOfCargo NatureOfCargo { get; set; }
    }

    [EdiElement, EdiPath("TSR/0")]
    public class ContractAndCarriageCondition
    {
        [EdiValue("X(3)", Path = "TSR/0/0", Mandatory = true)]
        public string ConditionCoded { get; set; }

        [EdiValue("X(3)", Path = "TSR/0/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TSR/0/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

    [EdiElement, EdiPath("TSR/1")]
    public class ServiceRequirement
    {
        [EdiValue("X(3)", Path = "TSR/1/0", Mandatory = true)]
        public string ServiceRequirementCoded { get; set; }

        [EdiValue("X(3)", Path = "TSR/1/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TSR/1/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

    [EdiElement, EdiPath("TSR/2")]
    public class TransportPriority
    {
        [EdiValue("X(3)", Path = "TSR/2/0", Mandatory = true)]
        public string PriorityCoded { get; set; }

        [EdiValue("X(3)", Path = "TSR/2/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TSR/2/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

    [EdiElement, EdiPath("TSR/3")]
    public class NatureOfCargo
    {
        [EdiValue("X(3)", Path = "TSR/3/0", Mandatory = true)]
        public string NatureOfCargoCoded { get; set; }

        [EdiValue("X(3)", Path = "TSR/3/1", Mandatory = false)]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "TSR/3/2", Mandatory = false)]
        public string CodeListResponsibleAgencyCoded { get; set; }
    }

}
