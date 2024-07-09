using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class BultoDetalle
    {
        public string EmpresaId { get; set; }
        public int TarjaCodigo { get; set; }
        public int ConsolidacionNumero { get; set; }
        public int BultoITem { get; set; }
        public short FilaNumero { get; set; }
        public int BultoCantidad { get; set; }
        public int BultoCantidadNivel { get; set; }
        public int BultoCantidadAdicional { get; set; }
        public int BultoCantidadTotal { get; set; }
        public bool EsParaCompletar { get; set; }
        public short CondItem { get; set; } //p
        public int Total { get; set; }
        public int TotalRows { get; set; }
        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; } = DateTime.Now;
    }

}
