using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class MovimientoCabecera
    {
        public string EmpresaId { get; set; }
        public int MovimientoCabeceraCodigo { get; set; }
        public int SeguimientoCodigo { get; set; }
        public string SeguimientoEstado { get; set; }
        [Required(ErrorMessage = "Seleccionar contenedor")]
        public string ContenedorCodigo { get; set; }
        public int ContenedorNumero { get; set; }
        [Required(ErrorMessage = "Seleccionar tipo de movimiento")]
        public int TipoMovimientoCodigo { get; set; }
        public string TipoMovimientoDescripcion { get; set; }
        public long MovimientoBalanzaId { get; set; }
        public string MovimientoBalanzaCodigo { get; set; }
        public string PlacaCamionCodigo { get; set; }
        public string ZonaOrigenDescripcion { get; set; }
        public string ZonaOrigen { get; set; }
        public string ZonaDestinoDescripcion { get; set; }
        public string ZonaDestino { get; set; }
        [Required(ErrorMessage = "Seleccionar punto de control")]
        public string ZonaPuntoControl { get; set; }
        public string ZonaPuntoControlDescripcion { get; set; }
        public string ZonaPuntoSgteControl { get; set; }
        public string ZonaPuntoSgteControlDescripcion { get; set; }
        [Required(ErrorMessage = "Ingresar fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        //[Required(ErrorMessage = "Ingresar fecha de ejecución")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEjecucion { get; set; } // = DateTime.Now;
        public int TiempoEstimado { get; set; }
        public string ObservacionesCabecera { get; set; }
        public int TemperaturaCodigo { get; set; }
        public decimal? LecturaReefer { get; set; } //Temperatura
        public int HumedadCodigo { get; set; }
        public decimal? LecturaHumedad { get; set; }
        public int PreEnfriadoCodigo { get; set; }
        public decimal? LecturaPreEnfriado { get; set; }
        public int VentilacionCodigo { get; set; }

        public decimal? LecturaVentilacion { get; set; }
        public bool EstadoPrecintoVerificado { get; set; }
        public string PrecintosMovimiento { get; set; }
        public string TipoPrecinto { get; set; }
        public string LineaNaviera { get; set; }
        public string LineaNombre { get; set; }
        public string TipoLecturaContReefer { get; set; }
        public int? NumeroAsignacion { get; set; }
        public int? ContenedorAutorizadoCodigo { get; set; }
        public int ContenedorMovido { get; set; }
        public string Booking { get; set; }
        public string Recalada { get; set; }
        public string Embarque { get; set; }
        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; } = DateTime.Now;
        public int TotalRows { get; set; }

        public List<MovimientoDetalle> MovimientoDetalle { get; set; } = new List<MovimientoDetalle>();

        public TiposBusquedaContenedor TipoBusquedaContenedor { get; } = TiposBusquedaContenedor.moduloEIR;

        public int ContenedorId { get; set; } = 0;
        public string TipoMovimientoId { get; set; }

        //PARA RECEPCION DE NAVE//
        public string ZonaDestinoNueva { get; set; }

        #region Para Consultas de Movimientos
        public string Cliente { get; set; }
        public string BL { get; set; }
        public string Dimension { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public decimal Tara { get; set; }
        public decimal Payload { get; set; }
        public Int16 Item { get; set; }
        public string PtoControl { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaControl { get; set; }
        public string Observaciones { get; set; }
        public string TipoRegistro { get; set; }
        public bool Registrado { get; set; }
        public string TipoSeguimiento { get; set; }

        #endregion

        #region adicionales para consulta de EIR
        public string Clase { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; }
        public int Dias { get; set; }
        public int Anio { get; set; }
        public string Condicion { get; set; }
        public string Situacion { get; set; }
        public string Limpieza { get; set; }
        public int NroEIR { get; set; }
        #endregion

        [DataType(DataType.Date)]
        public DateTime? FecFabricacion { get; set; }

        public bool Refeer { get; set; }
        public string EsRefeer { get; set; }

        [Required]
        public decimal MontoTara { get; set; }
        [Required]
        public decimal CargaMaxima { get; set; }
        public string TiTabClase { get; set; } = "CLA";
        public string TiCodClase { get; set; }
        public string TiDescClase { get; set; }

        public string TiTabDimension { get; set; } = "DIM";
        public string TiCodDimension { get; set; }
        public string TiDescDimension { get; set; }
        public string TiTabContenedor { get; set; } = "TCN";
        public string TiCodContenedor { get; set; }
        public string TiDescContenedor { get; set; }
        public int EIRCodigo { get; set; }
        public int BookingId { get; set; }
        public int AsignacionId { get; set; }
        [Required]
        public string AsignacionBookingCodigo { get; set; }
        public string ClienteRazonSocial { get; set; }
        public int EmbarqueId { get; set; }
        public int ItemEmbarque { get; set; }
        public int PesoManifestado { get; set; }
        public int CargaManifestada { get; set; }
        public int ConsolidacionCodigo { get; set; }

        public string AlertaStatus { get; set; }
        public string AlertaTransmision { get; set; }
        public string RegimenCodigo { get; set; }
    }

}
