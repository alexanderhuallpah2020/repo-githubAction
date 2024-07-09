using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class Booking
    {
        public string EmpresaId { get; set; }
        public int BookingId { get; set; } = 0;

        [Required]
        public string BookingCodigo { get; set; }

        [Required]
        public string LineaId { get; set; }

        [Required]
        public string NaveDescripcion { get; set; }

        [Required]
        public string NaveCodigoLloyd { get; set; }

        [Required]
        public string BookingViajeCodigo { get; set; }

        public DateTime? Envio { get; set; }

        public DateTime? EntregaCargo { get; set; }

        public DateTime? ETA { get; set; }

        public string PuertoTransbordo { get; set; }

        public string PuertoDestino { get; set; }

        public string TermNumero { get; set; } /////////

        [Required]
        public string Cliente { get; set; }

        public string Embarcador { get; set; }
        public string TiTabCondicion { get; } = "TCL";

        public string TiCodCondicion { get; set; }

        public string Observaciones { get; set; }

        [Required]
        public string ClaseCargaCodigo { get; set; }

        [Required]
        public string TipoCargaCodigo { get; set; }

        public int Version { get; set; } = 1;

        public string RecaladaCodigo { get; set; }

        public string EmbalajeCodigo { get; set; } /////////

        public int CargaCont { get; set; }

        ///////////////////////////
        public List<BookingDetalle> listaDetalles { get; set; } = new List<BookingDetalle>();
        public List<Persona> listaClientesAdicionales { get; set; } = new List<Persona>();
        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; }
        public string imoClass { get; set; }

    }
}
