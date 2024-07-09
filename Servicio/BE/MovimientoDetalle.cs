using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class MovimientoDetalle
    {
        public string EmpresaId { get; set; }
        public int MovimientoCabeceraCodigo { get; set; }
        public int MovimientoDetalleCodigo { get; set; }
        [Required]
        public string ZonaId { get; set; }

        public string ZonaOrigen { get; set; }
        [Required]
        public string ZonaControlSiguiente { get; set; }
        public string ZonaDestino { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? FechaControl { get; set; } = DateTime.Now;
        public int TiempoEstimado { get; set; }
        public int TiempoReal { get; set; }
        public string CamionPlaca { get; set; }
        public int? EirCodigo { get; set; }
        public string ObservacionesDetalle { get; set; }
        public bool RegistroEstado { get; set; }
        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; } = DateTime.Now;
        public int TotalRows { get; set; }
        public int ContenedorNumero { get; set; }
        public string ContenedorCodigo { get; set; }
        public int SeguimientoCodigo { get; set; }
        public int TipoMovimientoCodigo { get; set; }

    }

}
