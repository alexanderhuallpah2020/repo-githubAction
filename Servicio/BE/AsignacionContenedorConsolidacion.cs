using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class AsignacionContenedorConsolidacion
    {
        public int AsignacionContenedorId { get; set; } = 0;
        public int AsignacionId { get; set; }
        public int ContenedorId { get; set; }
        public string ContenedorCodigo { get; set; }
        public int SeguimientoId { get; set; }
        public string Tipo { get; set; }
        public string Clase { get; set; }
        public string Dimension { get; set; }
        public int Cantidad { get; set; }

        public string BookingId { get; set; }

        public string Condicion { get; set; }
        public string Ubicacion { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public int? Z { get; set; }
        public decimal Payload { get; set; }
        public DateTime? Fabricacion { get; set; } = new DateTime(2000, 1, 1);
        public string DimensionCod { get; set; }
        public string TipoCod { get; set; }
        public string TipoCondicionCodigo { get; set; }

        public string EstadoContenedorBase { get; set; }

        public string EstadoContenedor
        {
            get
            {
                if (EstadoContenedorBase == "4")
                {
                    return "001";
                }
                else if (EstadoContenedorBase == "5")
                {
                    return "002";
                }
                else
                {
                    return "000";
                }
            }
        }

        /// /////////////////////////////////////
        public int? ConocimientoEmbarqueId { get; set; }
        public string ConocimientoEmbarqueDetalleId { get; set; } = null;
        public EstadoContenedorAsignacion Estado { get; set; }
        public int? EIRPId { get; set; } = null;
        public string Observaciones { get; set; } = "";
        public bool ConsolidaFuera { get; set; } = false;
        public bool EsRoleo { get; set; } = false;
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        public int? DocumentoOrigenId { get; set; } = null;
        public int? SecuItem { get; set; } = null;
        public int? ConocimientoEmbarqueAnteriorId { get; set; } = null;
        public string AudiUsuario { get; set; }
        public string EmpresaId { get; set; }
        /// /////////////////////////////////////
        public string AsignacionBookingId { get; set; }
        public int ConsolidacionCodigo { get; set; }
        public int ContenedorNumero { get; set; }
        public string BookingCodigo { get; set; }
        public int BookingNumero { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string EmbarqueNumero { get; set; }
        public string EmbarqueItem { get; set; }
        public long EmbarqueInterno { get; set; }
        public string ConsolidacionObservaciones { get; set; }
        public string ConsolidacionEstadoCodigo { get; set; }
        public string ConsolidacionEstadoDescripcion { get; set; }
        public int PrecintoCodigo { get; set; }
        public string PrecintoNumero { get; set; }
        public string PrecintoTipoProcesoTab { get; set; }
        public string PrecintoTipoProcesoCod { get; set; }
        public string PrecintoTipoProcesoDes { get; set; }
        public string PrecintoTipoPrecintoTab { get; set; }
        public string PrecintoTipoPrecintoCod { get; set; }
        public string PrecintoTipoPrecintoDes { get; set; }
        public decimal? PesoTotal { get; set; }
    }

}
