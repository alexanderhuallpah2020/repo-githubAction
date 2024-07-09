using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public class StatusContenedorParams
    {
        public string EmpresaId { get; set; }
        public string Ops { get; set; }
        public string Mov { get; set; }
        public string Est { get; set; }
        public string Zona { get; set; }
        public string Eco { get; set; }
        public string TipoAsignacion { get; set; }
        public string InicioFin { get; set; }
        public string Regimen { get; set; }

        public int TipoMovimientoCodigo { get; set; }

        //Se agregó como condición para el evento stuffing
        public string Tcl { get; set; }
    }
}
