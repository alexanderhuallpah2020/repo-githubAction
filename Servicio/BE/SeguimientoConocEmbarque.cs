using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class SeguimientoConocEmbarqueDetalle
    {
        public string cod_reca { get; set; }
        public string regimen { get; set; }

        public string CONEMB_C_NUMERO { get; set; }
        public string PERSONA_C_RAZON_SOCIAL { get; set; }
        public string notify { get; set; }
        public string cod_contenedor { get; set; }
        public string dim_contenedor { get; set; }
        public string yard { get; set; }
        public string prto_origen { get; set; }
        public string prto_destino { get; set; }
        public string prto_embarque { get; set; }
        public string fec_eta { get; set; }
        public string num_viaje { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? fec_retiro_lleno { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? fec_devol_vacio { get; set; }
        public bool NoRetorna { get; set; }

    }

}
