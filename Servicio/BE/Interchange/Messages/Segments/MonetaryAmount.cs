using indice.Edi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using indice.Edi.Serialization;

namespace SRV_EdiFileService.Servicio.BE.Interchange.Messages.Segments
{

    [EdiSegment, EdiPath("MOA")]
    public class MonetaryAmount
    {
        [EdiElement, EdiPath("MOA/0")]
        public MonetaryAmountDetails MonetaryAmountDetails { get; set; }
    }

    [EdiElement, EdiPath("MOA/0")]
    public class MonetaryAmountDetails
    {
        [EdiValue("X(3)", Path = "MOA/0/0")]
        public string MonetaryAmountTypeQualifier { get; set; }

        [EdiValue("9(18)", Path = "MOA/0/1")]
        public decimal? MonetaryAmount { get; set; }

        [EdiValue("X(3)", Path = "MOA/0/2")]
        public string CurrencyCoded { get; set; }

        [EdiValue("X(3)", Path = "MOA/0/3")]
        public string CurrencyQualifier { get; set; }

        [EdiValue("X(3)", Path = "MOA/0/4")]
        public string StatusCoded { get; set; }
    }

}
