using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class ItemDesconsolidacion
    {
        public Guid Id { get; set; } = new Guid();
        public int SeguimientoCodigo { get; set; }
        public string TipoCarga { get; set; }
        public string Carga { get; set; }
        public string Embalaje { get; set; }
        public int Cantidad { get; set; }
        public int Items { get; set; }
    }
}
