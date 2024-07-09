using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public enum EstadoOperacion
    {
        SinIniciar = 0,
        EnProgreso = 1,
        Finalizada = 2,
        EnPausa = 3,
        Anulada = 4,
        Cerrada = 5
    }
}
