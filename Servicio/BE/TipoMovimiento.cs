using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV_EdiFileService.Servicio.BE
{
    public static class TipoMovimiento
    {
        public static int TipoMovimientoACliente = 3;
        public static int TipoMovimientoClienteALlenos = 14;
        public static int TipoMovimientoConsolidadoALleno = 5;
        public static int TipoMovimientoDesconsolidadoAVacio = 13;
        public static int TipoMovimientoDespachoACliente = 15;
        public static int TipoMovimientoEntradaDeCliente = 4;
        public static int TipoMovimientoEntradaDeNave = 1;
        public static int TipoMovimientoEntradaDeNaveNeptunia = 6;
        public static int TipoMovimientoEntradaLlenoDeNave = 9;
        public static int TipoMovimientoLlenoADesconsolidar = 12;
        public static int TipoMovimientoReparacionAVacio = 11;
        public static int TipoMovimientoSalidaANave = 2;
        public static int TipoMovimientoSalidaANaveLleno = 16;
        public static int TipoMovimientoVacioAConsolidar = 8;
        public static int TipoMovimientoVacioAReparacion = 10;

        public static int TipoMovimientoLlenosAAforo = 17;
        public static int TipoMovimientoAforoADesconsolidacion = 18;
        public static int TipoMovimientoAforoALlenos = 22;

        public static int TipoMovimientoVaciosAProcesoDeVentas = 19;

        //Mov Aforo - Consolidacion
        public static int TipoMovimientoVaciosAAforo = 20;
        public static int TipoMovimientoAforoAConsolidacion = 21;

    }
}
