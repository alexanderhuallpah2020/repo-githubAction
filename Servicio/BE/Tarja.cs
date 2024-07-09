using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class Tarja
    {
        public string EmpresaId { get; set; }
        [Display(Name = "Número")]
        public int TarjaCodigo { get; set; }
        public string TipoTarjaCodigo { get; set; }
        public string TipoTarjaTab { get; set; } = "TAR";
        [Display(Name = "Tipo Tarja")]
        [Required]
        [Range(1, 100000000,
        ErrorMessage = "Seleccione Tipo de Tarja")]
        public string TipoTarjaDescripcion { get; set; }
        [Required]
        public string TipoCargaCodigo { get; set; }
        [Display(Name = "Carga")]
        public string TipoCargaDescripcion { get; set; }
        public string ClaseCargaCodigo { get; set; }
        [Display(Name = "Tipo de Carga")]
        public string ClaseCargaDescripcion { get; set; }
        public string TipoEmbalajeCodigo { get; set; }
        public string TipoEmbalajeTab { get; set; } = "EMB";
        [Display(Name = "Embalaje")]
        public string TipoEmbalajeDescripcion { get; set; }
        public long MovimientoBalanzaCodigo { get; set; } //comboBox
        [Display(Name = "Movimiento Balanza")]
        public string MovimientoBalanzaNumero { get; set; }
        [Display(Name = "Cantidad")]
        public decimal? CantidadSalida { get; set; } = 0;
        [Display(Name = "Peso")]
        public decimal? PesoSalida { get; set; } = 0;
        [Display(Name = "Fecha Emisión")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEmision { get; set; } = DateTime.Now;
        public bool EstadoTarjaCodigo { get; set; } = true;
        [Display(Name = "Estado")]
        public string EstadoTarjaDescripcion { get; set; }
        [Display(Name = "Observaciones")]
        public string TarjaObservaciones { get; set; }
        [Display(Name = "Observaciones")]
        public string CargaObservaciones { get; set; }
        [Display(Name = "Parcial")]
        public short? TarjaItem { get; set; }
        [Display(Name = "Carga")]
        public string CargaCodigo { get; set; }
        public int TotalRows { get; set; }

        //
        //public int? ConsolidacionNumero { get; set; }
        public int? ConsolidacionNumero { get; set; }
        public int? DesconsolidacionNumero { get; set; }
        public int ConocimientoEmbarqueInterno { get; set; }
        public string ConocimientoEmbarqueDetalleInterno { get; set; }
        public string CamionPlaca { get; set; }
        public string AudiUsuario { get; set; }
        public DateTime AudiFecha { get; set; } = DateTime.Now;
        //public List<BultoDetalleSM> listaBultos { get; set; } = new List<BultoDetalleSM>();
        public TarjaVehiculo tarjaVehiculo { get; set; } = new TarjaVehiculo();
        //otros
        public string TipoMovimientoRef { get; set; }
        public string TCTarjaNumeroRef { get; set; }
        public int? TarjaRef { get; set; }
        public decimal? CantidadIngresada { get; set; }
        public decimal? PesoIngresado { get; set; }
        public string CodTipoEmba { get; set; }
        public decimal? CantidadManifestada { get; set; }
        public string TipoDesCod { get; set; }
        public string TipoDesTab { get; set; }
        public string TipoDesDescripcion { get; set; }
        public string AlmacenCodigo { get; set; }
        public string UbicacionAnaquel { get; set; }
        public string UbicacionFila { get; set; }
        public string UbicacionColumna { get; set; }
        public string UbicacionAltura { get; set; }
        public short? ConsolidacionDetalleItem { get; set; }
        public string TarjaEstado { get; set; }
        public bool SeObtuvoCargas { get; set; }

        // pesos
        public decimal? promedioPorEmbalaje { get; set; }

        //Almacen
        public string tipoalmacenCodigo { get; set; } = "002";
        public string tipoalmacenDescripcion { get; set; }
        public string almacenDescripcion { get; set; }
        //public string almacenUbicacionCodigo { get; set; }
        public string almacenUbicacionDescripcion { get; set; }

        public bool EsTransferenciaCarga { get; set; } = false;

        public bool MovimientoBalanzaEstadoCierre { get; set; } = false;

        //PARA LOS LOGS
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;

    }

}
