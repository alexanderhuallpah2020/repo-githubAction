using indice.Edi.Serialization;
using Renci.SshNet.Messages;
using SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Message
{

    [EdiMessage]
    public class CoparnMessage
    {
        public MessageHeader MessageHeader { get; set; }

        public BeginningOfMessage BeginningOfMessage { get; set; }

        public TransportMovementDetails TransportMovementDetails { get; set; }

        public TransportServiceRequirements TransportServiceRequirements { get; set; }

        [EdiCondition("BN", Path = "RFF/0/0")]
        public List<Reference> References { get; set; } = new List<Reference>();

        public List<SG1> ContainerMovementDetails { get; set; } = new List<SG1>();

        [EdiCondition("CZ", Path = "NAD/0/0")]
        public SG2 Sender { get; set; }

        [EdiCondition("CA", Path = "NAD/0/0")]
        public SG2 Carrier { get; set; }

        public List<SG3> ItemDetails { get; set; } = new List<SG3>();   

        public List<SG7> ContainerDetails { get; set; } = new List<SG7>();   

        public ControlTotal ControlTotal { get; set; }  
        public MessageTrailer MessageTrailer { get; set; }
    }
}
