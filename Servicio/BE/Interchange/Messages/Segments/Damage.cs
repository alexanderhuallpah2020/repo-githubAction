using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{
    using indice.Edi.Serialization;

    [EdiSegment, EdiPath("DAM")]
    public class Damage
    {
        [EdiValue("X(3)", Path = "DAM/0")]
        public string DamageDetailsQualifier { get; set; }

        [EdiElement, EdiPath("DAM/1")]
        public TypeOfDamage TypeOfDamage { get; set; }

        [EdiElement, EdiPath("DAM/2")]
        public DamageArea DamageArea { get; set; }

        [EdiElement, EdiPath("DAM/3")]
        public DamageSeverity DamageSeverity { get; set; }

        [EdiElement, EdiPath("DAM/4")]
        public Action Action { get; set; }
    }

    [EdiElement, EdiPath("DAM/1")]
    public class TypeOfDamage
    {
        [EdiValue("X(3)", Path = "DAM/1/0")]
        public string TypeOfDamageCoded { get; set; }

        [EdiValue("X(3)", Path = "DAM/1/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "DAM/1/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "DAM/1/3")]
        public string TypeOfDamageText { get; set; }
    }

    [EdiElement, EdiPath("DAM/2")]
    public class DamageArea
    {
        [EdiValue("X(4)", Path = "DAM/2/0")]
        public string DamageAreaIdentification { get; set; }

        [EdiValue("X(3)", Path = "DAM/2/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "DAM/2/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "DAM/2/3")]
        public string DamageAreaText { get; set; }
    }

    [EdiElement, EdiPath("DAM/3")]
    public class DamageSeverity
    {
        [EdiValue("X(3)", Path = "DAM/3/0")]
        public string DamageSeverityCoded { get; set; }

        [EdiValue("X(3)", Path = "DAM/3/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "DAM/3/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "DAM/3/3")]
        public string DamageSeverityText { get; set; }
    }

    [EdiElement, EdiPath("DAM/4")]
    public class Action
    {
        [EdiValue("X(3)", Path = "DAM/4/0")]
        public string ActionRequestNotificationCoded { get; set; }

        [EdiValue("X(3)", Path = "DAM/4/1")]
        public string CodeListQualifier { get; set; }

        [EdiValue("X(3)", Path = "DAM/4/2")]
        public string CodeListResponsibleAgencyCoded { get; set; }

        [EdiValue("X(35)", Path = "DAM/4/3")]
        public string ActionRequestNotificationText { get; set; }
    }


}
