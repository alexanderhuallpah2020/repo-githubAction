using System.ComponentModel.DataAnnotations;

namespace SRV_EdiFileService.Servicio.BE
{
    public class AutorizacionContenedor
    {
        public int AsignacionId { get; set; } = 0;
        public int DocumentoOrigenId { get; set; }

        //[Display(Name = "Nota de Embarque")]
        public string DocumentoOrigenCodigo { get; set; }

        //[Display(Name = "Recalada")]
        public string RecaladaNumero { get; set; }
        public int BookingId { get; set; } = 0;

        //[Display(Name = "Booking")]
        public string BookingCodigo { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteRazonSocial { get; set; }
        public string EmpresaId { get; set; }
        public List<AutorizacionContenedorDetalle> Detalles { get; set; } = new List<AutorizacionContenedorDetalle>();
        public string TipoAutorizacion { get; set; }


        /////Desconsolidacion
        public string NaveId { get; set; }
        public string NaveDescripcion { get; set; }
        public string LineaDescripcion { get; set; }
        public string ManifiestoAduana { get; set; }
        public string RegimenDescripcion { get; set; }

        public string TipoOperacionCodigo { get; set; }
        public string TipoAuto { get; set; }
        public bool OperaFuera { get; set; }
        public int Total { get; set; }
        public int TotalAprobado { get; set; }
        public bool finalizado { get; set; }
        public bool EsFinalizadoBl { get; set; }
    }
}
