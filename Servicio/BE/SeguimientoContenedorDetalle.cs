using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class SeguimientoContenedorDetalle
    {
        public string EmpresaId { get; set; }
        public int SeguimientoId { get; set; }
        public int SeguimientoDetalleId { get; set; }
        public DateTime FechaOperacion { get; set; }
        public int? ConsolidacionId { get; set; }
        public int? InspeccionId { get; set; }
        public int? InspeccionSeguridadId { get; set; } //??
        public int? AsignacionId { get; set; }
        public short? UbicacionId { get; set; }
        public int? MovimientoId { get; set; }
        public int? MovimientoDetalleId { get; set; }
        public int? DesconsolidacionId { get; set; }
        public int? AperturaId { get; set; }
        public string Audi_Usuario { get; set; }
    }
}
