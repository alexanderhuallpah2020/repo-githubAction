//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;
//using System.Transactions;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class AsignacionConsolidacionDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;
//        private readonly AsignacionContenedorDA asignacionContenedorRepository;
//        private readonly IStatusContenedorRepository _statusContenedorRepository;
//        private readonly ISeguimientoContenedorRepository _seguimientoRepository;


//        public AsignacionConsolidacionDA(NCTEntities context, AsignacionContenedorDA asignacionContenedorRepository, IContenedorRepository contenedorRepository, IStatusContenedorRepository _statusContenedorRepository, ISeguimientoContenedorRepository _seguimientoRepository)
//        {
//            _context = context;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//            this.asignacionContenedorRepository = asignacionContenedorRepository;
//            this.contenedorRepository = contenedorRepository;
//            this._statusContenedorRepository = _statusContenedorRepository;
//            this._seguimientoRepository = _seguimientoRepository;
//        }


//        public AsignacionConsolidacion GuardarAsignacionConsolidacion(AsignacionConsolidacion model)
//        {
//            try
//            {
//                using (var scope = new TransactionScope())
//                {
//                    if (model.AsignacionId == 0)
//                    {
//                        model.AsignacionId =
//                            _context.TS_TMASIG_I1(model.EmpresaId, model.AsignacionId, model.FechaAsignacion,
//                                                  model.AsignacionBookingCodigo, model.AsignacionTipo, model.EmbarqueId,
//                                                  model.BookingId, model.AudiUsuario, DateTime.Now)
//                                                .FirstOrDefault()
//                                                .Value;
//                    }
//                    else
//                    {
//                        _context.TS_TMASIG_U1(model.EmpresaId, model.AsignacionId, model.FechaAsignacion,
//                                              model.AsignacionBookingCodigo, model.AsignacionTipo, model.EmbarqueId,
//                                              model.BookingId, model.AudiUsuario, DateTime.Now);
//                    }

//                    if (model.ListaContenedores != null)
//                    {
//                        GuardarDetalles(model);
//                    }

//                    scope.Complete();
//                    return model;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al momento de guardar Asignación de Consolidación", ex);
//            }
//        }

//        public AsignacionConsolidacion ActualizarNumeroBookingAsignacionConsolidacion(AsignacionConsolidacion model)
//        {
//            try
//            {
//                using (var scope = new TransactionScope())
//                {
//                    _context.TS_TMASIG_U2(model.EmpresaId, model.AsignacionId,
//                                            model.AsignacionBookingCodigoRoleo,
//                                            model.BookingIdRoleo, model.AudiUsuario, DateTime.Now);

//                    scope.Complete();
//                    return model;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al momento de guardar el roleo del número de booking de una Asignación de Consolidación", ex);
//            }
//        }



//        private bool GuardarDetalles(AsignacionConsolidacion model)
//        {
//            foreach (var contenedor in model.ListaContenedores)
//            {
//                switch (contenedor.Estado)
//                {
//                    case EstadoContenedorAsignacion.ExistenteEliminado:
//                        //Se guarda la desasignación
//                        _context.TS_TDSEGUI_CONT_I1(model.EmpresaId, model.AsignacionId, contenedor.SeguimientoId, null, contenedor.Observaciones, contenedor.ConsolidaFuera, contenedor.EsRoleo, model.AudiUsuario);
//                        asignacionContenedorRepository.EliminarAsignacionContenedor_Consolidacion(contenedor.EmpresaId, contenedor.AsignacionId, contenedor.SeguimientoId);
//                        // Guardar Status
//                        var paramss = new StatusContenedorParams
//                        {
//                            EmpresaId = model.EmpresaId,
//                            Ops = StatusContenedor.TipoOperacionStatusDesasignacion,
//                            Mov = null,
//                            Est = null,
//                            Zona = null,
//                            Eco = null,
//                            TipoAsignacion = null,
//                            InicioFin = null,
//                            Regimen = null
//                        };

//                        _statusContenedorRepository.GuardarStatusContenedor(paramss, contenedor.SeguimientoId, null, model.AudiUsuario);
//                        break;
//                    case EstadoContenedorAsignacion.Disponible:

//                        var tipoMov = contenedor.ConsolidaFuera ? TipoMovimiento.TipoMovimientoACliente : TipoMovimiento.TipoMovimientoVacioAConsolidar;

//                        contenedor.AsignacionId = model.AsignacionId;
//                        contenedor.FechaAsignacion = model.FechaAsignacion;
//                        contenedor.EmpresaId = model.EmpresaId;
//                        contenedor.AudiUsuario = model.AudiUsuario;
//                        contenedor.ConocimientoEmbarqueId = model.EmbarqueId;
//                        contenedor.EIRPId = CrearEirAsignacion(model.EmpresaId, contenedor.SeguimientoId, tipoMov, "Por Asignación No: " + model.AsignacionId, model.AudiUsuario);

//                        asignacionContenedorRepository.InsertarAsignacionContenedor_Consolidacion(contenedor);

//                        //Se guarda Seguimiento Detalle
//                        _seguimientoRepository.InsertarSeguimientoDetalle(new SeguimientoContenedorDetalle
//                        {
//                            EmpresaId = model.EmpresaId,
//                            SeguimientoId = contenedor.SeguimientoId,
//                            FechaOperacion = DateTime.Now,
//                            AsignacionId = model.AsignacionId,
//                            Audi_Usuario = model.AudiUsuario
//                        });

//                        break;
//                }
//            }

//            return true;
//        }

//        private int CrearEirAsignacion(string empresaId, int seguimientoId, int TipoMovimiento, string observaciones, string usuario)
//        {
//            var TipoIntercambio = "003";

//            return _context.TS_TMEIR_I1(empresaId, 0, seguimientoId, "INT", TipoIntercambio, "EST", "001", TipoMovimiento,
//                                        "ELI", "001", "ECO", "001", null, null, DateTime.Now, false, observaciones,
//                                        null, false, false, 0, 0, 0, true, null, null, null, usuario, DateTime.Now).FirstOrDefault().Value;
//        }

//        public ICollection<AsignacionContenedorConsolidacion> ObtenerContenedoresPorAsignacionConsolidacion(string empresaId, string filtro)
//        {
//            return _mapper.Map<List<AsignacionContenedorConsolidacion>>(_context.TS_TMCONT_Q17(empresaId, filtro));
//        }
//        public ICollection<AsignacionContenedorConsolidacion> ObtenerContenedoresPorRecaladaParaSolicitudServicio(string empresaId, string recalada, string booking, string filtro)
//        {
//            return _mapper.Map<List<AsignacionContenedorConsolidacion>>(_context.TS_TMCONT_Q18(empresaId, recalada, booking, filtro));
//        }

//    }

//}
