using SRV_EdiFileService.Servicio.BE;
using SRV_EdiFileService.Servicio.BE.Config;
using SRV_EdiFileService.Servicio.DAL;

namespace SRV_EdiFileService.Servicio.BL
{
    internal class ProcesarEDI
    {
        private ConfigBE config;
        private CoparnDAL dataAccess;

        public ProcesarEDI(ConfigBE _config)
        {
            config = _config;
            dataAccess = new CoparnDAL();
        }

        public int GuardarBooking(Booking booking)
        {
            return dataAccess.GrabarReserva(config, booking);
        }

        public AsignacionConsolidacion GuardarAsignacion(AsignacionConsolidacion asignacionConsolidacion)
        {
            return dataAccess.GrabarAsignacionConsolidacion(config, asignacionConsolidacion);
        }

        public AsignacionConsolidacion ObtenerAsignacion(string codigoBooking)
        {
            AsignacionConsolidacion asignacionConsolidacion = dataAccess.ObtenerAsignacionConsolidacion(config, codigoBooking);
            return asignacionConsolidacion;
        }

        public string AsignarNuevoContenedor(AsignacionContenedorConsolidacion asignacionContenedor)
        {
            return dataAccess.GrabarNuevoContenedor(config, asignacionContenedor);
        }
        public bool EliminarContenedorAsignacion(string codigoBooking, string codigoContenedor)
        {
            return dataAccess.EliminarContenedorReserva(config, codigoContenedor, codigoBooking);
        }

        public string ModificarContenedorAsignacion(AsignacionContenedorConsolidacion asignacionContenedor)
        {
            return dataAccess.ModificarContenedor(config, asignacionContenedor);
        }

        //public int GuardarAutorizacion(AutorizacionContenedorDetalle autorizacionContenedorDetalle)
        //{
        //    return dataAccess.GrabarAutorizacionContenedor(config, autorizacionContenedorDetalle);
        //}
    }
}
