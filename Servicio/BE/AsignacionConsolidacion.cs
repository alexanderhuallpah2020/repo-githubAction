using System.ComponentModel.DataAnnotations;

namespace SRV_EdiFileService.Servicio.BE
{
    public class AsignacionConsolidacion
    {
        public int AsignacionId { get; set; } = 0;

        [Required]
        public string AsignacionBookingCodigo { get; set; }

        public string RecaladaCodigo { get; set; }

        public int? EmbarqueId { get; set; }
        public string EmbarqueCodigo { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        public string ClienteCodigo { get; set; }
        public string ClienteRazonSocial { get; set; }

        public string LineaCodigo { get; set; }
        public string LineaDescripcion { get; set; }

        public string PuertoEmbarqueCodigo { get; set; }
        public string PuertoDestinoCodigo { get; set; }

        public string NaveDescripcion { get; set; }
        public string AsignacionTipo { get; } = "C";

        [Required]
        public int? BookingId { get; set; }

        public string EmpresaId { get; set; }
        public string AudiUsuario { get; set; }
        public string AudiFecha { get; set; }
        public int TotalRows { get; set; }

        public int IdDocumentoOrigen { get; set; }

        public List<AsignacionContenedorConsolidacion> ListaContenedores { get; set; } = new List<AsignacionContenedorConsolidacion>();

        public List<AutorizacionContenedorDetalle> autorizacionesContenedores { get; set; } = new List<AutorizacionContenedorDetalle>();


        //Roleo de Número de Booking
        public int? BookingIdRoleo { get; set; }
        [Display(Name = "Booking Nuevo")]
        public string AsignacionBookingCodigoRoleo { get; set; }

    }

}
