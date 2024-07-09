using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SRV_EdiFileService.Servicio.BE
{
    public class BookingDetalle
    {
        public string EmpresaId { get; set; }
        public int BookingId { get; set; }
        public int BookingDetalleId { get; set; } = 0;
        public string TipoContenedorTabla { get; } = "TCN";
        [Required]
        public string CodigoContenedor { get; set; }
        public string TipoCotnenedorCodigo { get; set; }
        public string EstadoContenedorBase { get; set; }

        public string EstadoContenedor { get
            {
                if (EstadoContenedorBase == "4")
                {
                    return "001";
                } else if (EstadoContenedorBase == "5")
                {
                    return "002";
                } else
                {
                    return "000";
                }
            }
        }

    public string TipoCotnenedorDescripcion { get; set; }
        public string DimensionTabla { get; } = "DIM";
        public string DimensionCodigo { get; set; }
        public string DimensionDescripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal? PesoTotal { get; set; }
        public string ZonaCodigoSalida { get; set; }
        public string ZonaCodigoRetorno { get; set; }
        public decimal? Temperatura { get; set; }

        public bool ConsolidadoPuerto { get; set; } = false;
        public bool PreCool { get; set; } = false;
        public decimal? VentSet { get; set; }
        public decimal? Humedad { get; set; } = 0;

        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; }

        public EstadoEntidad Estado { get; set; } = EstadoEntidad.Leido;

        public int Existente { get; set; } = 0;
    }
}
