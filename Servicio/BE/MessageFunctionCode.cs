using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public enum MessageFunctionCode
    {
        /// <summary>
        /// Cancellation: Elimina un contenedor de la reserva, reduciendo el total de contenedores asignados a la reserva.
        /// </summary>
        Cancellation = 1,

        /// <summary>
        /// Addition: Agrega un nuevo contenedor a una reserva existente, incrementando el total de contenedores bajo esa reserva específica.
        /// </summary>
        Addition = 2,

        /// <summary>
        /// Replacement: Modifica un contenedor ya asociado a una reserva, pudiendo cambiar el tipo, tamaño o ubicación del contenedor.
        /// </summary>
        Replacement = 5,

        /// <summary>
        /// Original: Crea una nueva reserva de contenedor, indicando una nueva entrada en el sistema.
        /// </summary>
        Original = 9
    }
}
