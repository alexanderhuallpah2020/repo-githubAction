//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;
//using System.Transactions;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class AsignacionContenedorDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;


//        public AsignacionContenedorDA(NCTEntities context)
//        {
//            _context = context;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//        }

//        public bool InsertarAsignacionContenedor_Consolidacion(AsignacionContenedorConsolidacion model)
//        {
//            _context.TS_TMASIG_CONT_I1(model.EmpresaId, model.AsignacionContenedorId, model.AsignacionId, model.SeguimientoId,
//                                       model.EIRPId, model.Observaciones, model.ConsolidaFuera, model.EsRoleo, model.FechaAsignacion,
//                                       model.ConocimientoEmbarqueId, model.ConocimientoEmbarqueDetalleId, model.DocumentoOrigenId,
//                                       model.SecuItem, model.ConocimientoEmbarqueAnteriorId, model.AudiUsuario, DateTime.Now);

//            return true;
//        }

//        public bool EliminarAsignacionContenedor_Consolidacion(string empresaId, int asignacionId, int seguimientoId)
//        {
//            TODO cambiar la manera de eliminar, por el primary de la tabla(CO_ASIG_CONT)
//            _context.TS_TMASIG_CONT_D1(empresaId, asignacionId, seguimientoId);

//            return true;
//        }

//        public ICollection<TmAsignacionContenedor> ObtenerAsignacionContenedor_Consolidacion(
//            string empresaId, int asignacionId)
//        {
//            return _mapper.Map<List<TmAsignacionContenedor>>(_context.TS_TMASIG_CONT_Q1(empresaId, asignacionId));
//        }

//        public bool RolearContenedoresAsignados(AsignacionConsolidacion modelo)
//        {
//            var contenedoresACambiar = modelo.ListaContenedores.Where(c => c.AsignacionId != modelo.AsignacionId);

//            using (var scope = new TransactionScope())
//            {
//                foreach (var contenedor in contenedoresACambiar)
//                {
//                    TODO en este foreach se deben hacer los siquientes pasos(al momento de implementar el modulo
//                         no se contaba con las tablas, ni con sus modulos correspondientes)
//                              - Crear un ConocimientoEmbarqueDetalle
//                              -Actualizar la tabla SGC_Consolidacion
//                              - Actualizar la tabla SGC_Tarja
//                              - Actualizar la tabla OfiOper.OfiOper.TDDOCU_CONT_REF
//                              - Actualizar las solicitudes de servicio OfiOper.OfiOper.TCSOLI_SERV
//                              - como referencia to do esto se encuentra en SGC_ASIGSU_RoleaOperacionCompleta
//                    /*_context.TS_TMASIG_CONT_U1(contenedor.AsignacionContenedorId, modelo.AsignacionId, modelo.EmbarqueId, 0,
//                        modelo.AudiUsuario, DateTime.Now);*/
//                    _context.TS_TMASIG_CONT_U1(modelo.EmpresaId, contenedor.AsignacionId, contenedor.SeguimientoId, modelo.AsignacionId, "");
//                }

//                scope.Complete();
//            }

//            return true;

//        }
//        public ICollection<TmAsignacionContenedor> ObtenerPreAsignacionesContenedor(string empresaId, string recalada,
//           int? booking, DateTime? fecha)
//        {
//            _context.Database.CommandTimeout = 300;
//            return _mapper.Map<List<TmAsignacionContenedor>>(_context.TS_TMASIG_CONT_Q2(empresaId, recalada, booking, fecha));
//        }
//    }

//}
