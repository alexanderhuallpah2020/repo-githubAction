using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class AutorizacionContenedorDetalle
    {
        public string EmpresaId { get; set; }
        public int AutorizacionContenedorId { get; set; } = 0;
        public int SeguimientoId { get; set; }
        public int ConocEmbarque { get; set; }
        public bool Autorizado { get; set; } = false;
        public int? PlanNumero { get; set; } = 0;
        public short? Dplr { get; set; } = 0;
        public string TiTabAutorizacion { get; } = "TAU";
        public string TiCodAutorizacion { get; set; }
        public bool ServiciosGenerados { get; set; } = false;
        public bool ServiciosAdicGenerados { get; set; } = false;
        public bool OperacionFuera { get; set; } = false;
        public DateTime? FechaAutorizacion { get; set; }
        public short? TipoOrigenCarga { get; set; }
        public decimal? CantidadManifiesto { get; set; }
        public decimal? PesoManifiesto { get; set; }

        [Display(Name = "Contenedor")]
        public string ContenedorCodigo { get; set; }
        public string ContenedorNumero { get; set; }
        public int ContenedorNum { get; set; }
        public string ClienteCodigo { get; set; }
        public string ConEmbarqueItemBase { get; set; }
        public string ConEmbarqueItemNuevo { get; set; }
        public string TiTabContenedor { get; } = "TCN";
        public string TiCodContenedor { get; set; }
        public string TiTabDimension { get; } = "DIM";
        public string TiCodDimension { get; set; }

        [Display(Name = "Tipo")]
        public string TiDesContenedor { get; set; }

        [Display(Name = "Dimensión")]
        public string TiDesDimension { get; set; }
        public string TiDesClase { get; set; }
        public string TiDesEstado { get; set; }
        public bool EsRefeer { get; set; }
        public bool EstaLimpio { get; set; }
        public int? BookingId { get; set; }
        public string BookingCodigo { get; set; }
        public int AsignacionId { get; set; }

        [Display(Name = "EIR")]
        public string EIREstado { get; set; }
        public string SolicitudServicioCodigo { get; set; }

        [Display(Name = "Carga")]
        public string TipoCargaDescripcion { get; set; }
        public bool MovimientoTerminado { get; set; }
        public int ConsolidacionId { get; set; } = 0;
        public int? AperturaId { get; set; } = 0;
        public int? ActaAperturaId { get; set; } = 0;
        public int DesconsolidacionId { get; set; }
        public string TiTabOperacion { get; } = "TTO";
        public string TiCodOperacion { get; set; }
        public string TiCodServicio { get; set; }
        public string AudiUsuario { get; set; }

        /////////
        public string Recalada { get; set; }

        //////
        public bool AutorizadoDB { get; set; }
        public bool Aforo { get; set; }
        public bool ServiciosGeneradosDB { get; set; }
        public bool ServiciosAdicGeneradosDB { get; set; }
        /////
        public int ActaCodigo { get; set; }

        public List<ItemDesconsolidacion> ItemsDesconsolidacion { get; set; } = new List<ItemDesconsolidacion>();

        public bool NoRetorna { get; set; } = false;
        public bool EsDocuCont { get; set; } = false;
        public bool EsMovRegistrado { get; set; } = false;

        public bool GeneraItemUnico { get; set; } = false;
    }
}
