using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class Contenedor
    {
        public string idEmp { get; set; }
        public int NumContenedor { get; set; } = 0;

        [Required]
        public string CodContenedor { get; set; }

        public string IdLinea { get; set; }
        public string DescLinea { get; set; }

        public string TiTabClase { get; set; } = "CLA";
        public string TiCodClase { get; set; }
        public string TiDescClase { get; set; }

        public string TiTabDimension { get; set; } = "DIM";
        public string TiCodDimension { get; set; }
        public string TiDescDimension { get; set; }


        public string TiTabContenedor { get; set; } = "TCN";
        public string TiCodContenedor { get; set; }
        public string TiDescContenedor { get; set; }


        public string TiTabMaterial { get; set; } = "MAT";
        public string TiCodMaterial { get; set; }
        public string TiDescMaterial { get; set; }


        public string TiTabColor { get; set; } = "COL";
        public string TiCodColor { get; set; }
        public string TiDescColor { get; set; }


        public string TiTabEstado { get; set; } = "EST";
        [Required]
        public string TiCodEstado { get; set; }
        public string TiDescEstado { get; set; }

        public string TiTabCondicion { get; set; } = "ECO";
        [Required]
        public string TiCodCondicion { get; set; }
        public string TiDescCondicion { get; set; }


        public string TiTabLimpieza { get; set; } = "ELI";
        public string TiCodLimpieza { get; set; }
        public string TiDescLimpieza { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FecFabricacion { get; set; }

        public bool Refeer { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Número inválido")]
        public decimal Tara { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Número inválido")]

        public decimal CargaMaxima { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Número inválido")]

        public decimal Cubicaje { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FecVenciAIT { get; set; }
        public string NumAIT { get; set; }

        public bool Limpieza { get; set; }

        [Required]
        public bool Cerrado { get; set; }

        public bool Inactivo { get; set; }

        public string TiTabRefrigeracion { get; set; } = "EQR";
        public string TiCodRefrigeracion { get; set; }
        public string TiDescRefrigeracion { get; set; }


        public string TiTabFabricante { get; set; } = "FBR";
        public string TiCodFabricante { get; set; }
        public string TiDescFabricante { get; set; }

        public string AudiUsuario { get; set; }
        public string AudiFecha { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Número inválido")]

        public decimal? Tara_Real { get; set; }

        public string Estado { get; set; }

        ///////////////////////////////////
        public int TotalRows { get; set; }

        public void SetTabTipos()
        {
            this.TiTabClase = "CLA";
            this.TiTabDimension = "DIM";
            this.TiTabContenedor = "TCN";
            this.TiTabMaterial = "MAT";
            this.TiTabColor = "COL";
            this.TiTabEstado = "EST";
            this.TiTabCondicion = "ECO";
            this.TiTabLimpieza = "ELI";
            this.TiTabRefrigeracion = "EQR";
            this.TiTabFabricante = "FBR";

            this.Refeer = this.TiCodContenedor == "002" || this.TiCodContenedor == "008";
        }

        //CONSULTA DE STATUS
        public string num_EIR { get; set; }
        public string cod_deposito { get; set; }
        public string cod_puerto { get; set; }
        public string num_viaje { get; set; }
        public string precinto { get; set; }
        public string booking { get; set; }
        public string num_CR { get; set; }
        public string enviado { get; set; }
        public string Observaciones { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public string StatusD { get; set; }
        public string VSL { get; set; }
        public string VOY { get; set; }
        public string Temp { get; set; }
        public string Unit { get; set; }
        public string Vent { get; set; }
        public string CMHPCT { get; set; }
        public string SEALCA { get; set; }
        public string SEALCU { get; set; }
        public string SEALSH { get; set; }
        public string SEALTO { get; set; }

        [Required]
        public string SizeType { get; set; }

        // PARA SEGUIMIENTO/MOVIMIENTO
        public int SeguimientoCodigo { get; set; }
        public string SeguimientoEstado { get; set; }
        public int MovimientoCabeceraCodigo { get; set; }

    }
}
