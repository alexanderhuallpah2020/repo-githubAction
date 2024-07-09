using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public enum DireccionMovimientoContenedor
    {
        Salida,
        Ingreso
    }

    public enum TipoEstadoContenedor
    {
        Vacio = 1,
        Lleno = 2
    }
}
