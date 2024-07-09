//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;
//using System.Transactions;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class SeguimientoContenedorDA
//    {
//        private readonly NCTEntities _context;

//        public SeguimientoContenedorDA(NCTEntities entity)
//        {
//            _context = entity;
//        }


//        public bool InsertarSeguimientoDetalle(SeguimientoContenedorDetalle model)
//        {
//            try
//            {
//                _context.TS_TDSEGUI_CONT_I2(model.EmpresaId, model.SeguimientoId, 0, model.FechaOperacion, model.ConsolidacionId,
//                    model.InspeccionId, model.InspeccionSeguridadId, model.AsignacionId, model.UbicacionId, model.MovimientoId,
//                    model.MovimientoDetalleId, model.DesconsolidacionId, model.AperturaId, model.Audi_Usuario, DateTime.Now);

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarSeguimientoDetalle", ex);
//            }
//        }

//    }

//}
