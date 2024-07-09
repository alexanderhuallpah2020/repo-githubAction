//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;
//using System.Transactions;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class AutorizacionContenedorDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;
//        private readonly IConsolidacionRepository consolidacionRespository;
//        private readonly IDesconsolidacionRepository desconsolidacionRespository;
//        private readonly IDocumentoOrigenRepository documentoOrigenRepository;
//        private readonly ISolicitudServicioRepository solicitudServicioRespository;
//        private readonly IStatusContenedorRepository statusContenedorRespository;
//        private readonly IPTIRepository ptiRepository;
//        private readonly ITarjaRepository tarjaRepository;
//        private readonly IMovimientoRepository movimientoRespository;
//        private readonly IBookingRepository bookingRepository;
//        private readonly IEmailRepository emailRepository;
//        private readonly string _empresaId = "0000000001";

//        public AutorizarContenedorRepository(NCTEntities context, IConsolidacionRepository consolidacionRespository, IDesconsolidacionRepository desconsolidacionRespository,
//            IDocumentoOrigenRepository documentoOrigenRepository, ISolicitudServicioRepository solicitudServicioRespository, IStatusContenedorRepository statusContenedorRespository,
//            IPTIRepository ptiRepository, ITarjaRepository tarjaRepository, IMovimientoRepository movimientoRespository, IBookingRepository bookingRepository,
//            IEmailRepository emailRepository)
//        {
//            _context = context;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//            this.consolidacionRespository = consolidacionRespository;
//            this.desconsolidacionRespository = desconsolidacionRespository;
//            this.documentoOrigenRepository = documentoOrigenRepository;
//            this.solicitudServicioRespository = solicitudServicioRespository;
//            this.statusContenedorRespository = statusContenedorRespository;
//            this.ptiRepository = ptiRepository;
//            this.tarjaRepository = tarjaRepository;
//            this.movimientoRespository = movimientoRespository;
//            this.bookingRepository = bookingRepository;
//            this.emailRepository = emailRepository;
//        }


//        public List<AutorizacionContenedorDetalle> GuardarDetalleAutorizacionBloque(List<AutorizacionContenedorDetalle> detalles, string empresaId, string usuario, TipoAutorizacion tipoAutorizacion, List<ServicioSM> servicios)
//        {
//            try
//            {
//                for (int i = 0; i < detalles.Count; i++)
//                {
//                    using (var scope = new TransactionScope())
//                    {
//                        var docuOrigenDetalle = _mapper.Map<DocumentoOrigenDetalle>(_context.TS_TCDOCU_ORIG_Q10(empresaId, detalles[i].ConocEmbarque, detalles[i].ConEmbarqueItemBase).FirstOrDefault());

//                        detalles[i].EmpresaId = empresaId;
//                        detalles[i].AudiUsuario = usuario;
//                        detalles[i].TiCodAutorizacion = tipoAutorizacion == TipoAutorizacion.Consolidacion ? "001" : tipoAutorizacion == TipoAutorizacion.Desconsolidacion ? "003" : "002";
//                        detalles[i] = guardarDetalleAutorizacion(detalles[i]);

//                        if (tipoAutorizacion == TipoAutorizacion.Consolidacion)
//                        {
//                            //VerificarItem();
//                            GenerarConsolidacion(detalles[i], docuOrigenDetalle);
//                            //if (servicios.Count != 0) {
//                            //    GuardarServiciosAdicionales(detalles[i], servicios);
//                            //}
//                        }
//                        else if (tipoAutorizacion == TipoAutorizacion.Desconsolidacion)
//                        {
//                            GenerarDesconsolidacion(detalles[i], docuOrigenDetalle);
//                            actualizarNoRetorna(detalles[i]);
//                        }
//                        else if (tipoAutorizacion == TipoAutorizacion.Apertura)
//                        {
//                            GenerarApertura(detalles[i], docuOrigenDetalle);
//                        }
//                        else if (tipoAutorizacion == TipoAutorizacion.Aforo_Consolidacion)
//                        {
//                            if (detalles[i].Autorizado == true)
//                            {
//                                GenerarAforoConsolidacion(detalles[i], docuOrigenDetalle);
//                                actualizarAutorizacion(detalles[i]);
//                            }
//                        }
//                        scope.Complete();
//                    }

//                }

//                return detalles;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función GuardarDetalleAutorizacionBloque(Error al momento de guardar detalle de Autorización de Contenedor)" + detalles[0].ToString(), ex);
//            }
//        }

//        public AutorizacionContenedorDetalle guardarDetalleAutorizacion(AutorizacionContenedorDetalle detalle)
//        {
//            try
//            {
//                if (detalle.AutorizacionContenedorId == 0)

//                {
//                    detalle.AutorizacionContenedorId = _context.TS_TMCONT_AUT_I1(detalle.EmpresaId, detalle.AutorizacionContenedorId, detalle.ConocEmbarque,
//                        detalle.SeguimientoId, detalle.Autorizado, detalle.PlanNumero, detalle.Dplr, detalle.TiTabAutorizacion, detalle.TiCodAutorizacion, detalle.Autorizado ? DateTime.Now : (DateTime?)null,
//                        detalle.ServiciosGenerados, detalle.OperacionFuera, detalle.TipoOrigenCarga, detalle.PesoManifiesto, detalle.CantidadManifiesto,
//                        detalle.TiTabOperacion, detalle.TiCodOperacion, detalle.AudiUsuario, DateTime.Now, detalle.ServiciosAdicGenerados).FirstOrDefault().Value;
//                }
//                else
//                {
//                    _context.TS_TMCONT_AUT_U1(detalle.EmpresaId, detalle.AutorizacionContenedorId, detalle.ConocEmbarque,
//                        detalle.SeguimientoId, detalle.Autorizado, detalle.PlanNumero, detalle.Dplr, detalle.TiTabAutorizacion, detalle.TiCodAutorizacion, DateTime.Now,
//                        detalle.ServiciosGenerados, detalle.OperacionFuera, detalle.TipoOrigenCarga, detalle.PesoManifiesto, detalle.CantidadManifiesto,
//                        detalle.TiTabOperacion, detalle.TiCodOperacion, detalle.AudiUsuario, DateTime.Now, detalle.ServiciosAdicGenerados);
//                }
//                return detalle;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función guardarDetalleAutorizacion(Error al momento de guardar detalle de Autorización de Contenedor)", ex);
//            }
//        }

//        public bool GenerarConsolidacion(AutorizacionContenedorDetalle autorizaCont, DocumentoOrigenDetalle docuOrigen)
//        {
//            try
//            {
//                if (autorizaCont.ServiciosGenerados)
//                {
//                    if (autorizaCont.ConsolidacionId == 0)
//                    {
//                        var docu = new DocumentoOrigenDetalle { };
//                        if (docuOrigen == null)
//                        {
//                            docuOrigen = docu;
//                        }

//                        var ST_DESC = "S";
//                        if (autorizaCont.OperacionFuera) { ST_DESC = "N"; }
//                        autorizaCont.ConsolidacionId = consolidacionRespository.GuardarConsolidacionBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario);

//                        #region CambioPendiente

//                        _context.TS_TCSOLI_SERV_D2(autorizaCont.EmpresaId, autorizaCont.ConocEmbarque, autorizaCont.ConEmbarqueItemBase);

//                        //Si es Consolidación dentro se tiene que generar el Item del cntd lleno para generar la SolServicio
//                        if (docuOrigen == null)
//                        {
//                            autorizaCont.ConEmbarqueItemNuevo = documentoOrigenRepository.InsertarItemDetalleConocimientoEmbarque(docu, autorizaCont, TipoGeneracionItemDetalle.ItemContenedorLleno, ST_DESC);
//                        }
//                        else
//                        {
//                            autorizaCont.ConEmbarqueItemNuevo = documentoOrigenRepository.InsertarItemDetalleConocimientoEmbarque(docuOrigen, autorizaCont, TipoGeneracionItemDetalle.ItemContenedorLleno, ST_DESC);
//                        }
//                        #endregion

//                        if (autorizaCont.SolicitudServicioCodigo == null || autorizaCont.SolicitudServicioCodigo == "0")
//                        {
//                            solicitudServicioRespository.CrearSolicitudServicioAutomatica(autorizaCont.EmpresaId, autorizaCont.ConocEmbarque, autorizaCont.TiTabContenedor, autorizaCont.TiCodContenedor, Operacion.Consolidacion, autorizaCont.TiCodOperacion,
//                                                                                          autorizaCont.ConEmbarqueItemNuevo, autorizaCont.Recalada, autorizaCont.ClienteCodigo, autorizaCont.FechaAutorizacion.HasValue ? autorizaCont.FechaAutorizacion.Value : DateTime.Now, autorizaCont.SeguimientoId, autorizaCont.AudiUsuario,
//                                                                                          ConsolidacionId: autorizaCont.ConsolidacionId, contAutorizadoItem: autorizaCont.AutorizacionContenedorId, operacionFuera: autorizaCont.OperacionFuera);
//                        }

//                        //Ahora Actualizamos referencia de AsignacionContenedor a Conoc_Embarque_Detal
//                        //puede ser que se haya insertado uno nuevo o que ya existe y se haya cargado
//                        if (autorizaCont.ConEmbarqueItemNuevo != string.Empty && autorizaCont.ConEmbarqueItemNuevo != null)
//                        {
//                            //if ((autorizaCont.ConEmbarqueItemNuevo == autorizaCont.ConEmbarqueItemBase && docuOrigen.TIPCAR_C_CODIGO_MANIFESTADO == "0004") || autorizaCont.ConEmbarqueItemBase != autorizaCont.ConEmbarqueItemNuevo)
//                            //{
//                            _context.TS_TMASIG_CONT_U2(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.ConEmbarqueItemNuevo);
//                            //}
//                        }
//                    }
//                }

//                if (autorizaCont.Autorizado)
//                {
//                    //Creamos el Status
//                    var paramss = new StatusContParams
//                    {
//                        EmpresaId = autorizaCont.EmpresaId,
//                        Ops = StatusContenedor.TipoOperacionStatusAsignacion,
//                        Mov = null,
//                        Est = null,
//                        Zona = null,
//                        Eco = null,
//                        TipoAsignacion = "C",
//                        InicioFin = null,
//                        Regimen = null
//                    };

//                    if (autorizaCont.BookingId != null)
//                    {
//                        var booking = bookingRepository.ObtenerBooking("0000000001", autorizaCont.BookingId.Value);

//                        if (booking != null && booking.TiCodCondicion == "002")//SI LA CONDICIÓN ES LCL
//                        {
//                            paramss.Tcl = booking.TiCodCondicion;
//                        }

//                    }


//                    statusContenedorRespository.GuardarStatusContenedor(paramss, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario);
//                    //statusContenedorRespository.GuardarStatusContenedorAutorizacion(paramss, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario);

//                    //Creamos la Solicitud de Servicio por el PTI realizado al Cntd Reefer
//                    var PTI = _mapper.Map<PtiSM>(_context.TS_TMPTI_Q2(autorizaCont.EmpresaId, autorizaCont.SeguimientoId).FirstOrDefault());
//                    if (PTI != null)
//                    {
//                        if (PTI.SolicServicioCodigo.Trim() == string.Empty)
//                        {
//                            PTI.Usuario = autorizaCont.AudiUsuario;
//                            PTI.SolicServicioCodigo = ptiRepository.Confirmar(PTI).ToString();
//                            _context.TS_OFIOPER_TCSOLI_SERV_U2(PTI.EmpresaId, PTI.SolicServicioCodigo, autorizaCont.FechaAutorizacion, PTI.Usuario);
//                        }
//                        else
//                        {
//                            throw new Exception("El PTI ya tiene una solicitud Generada");
//                        }
//                    }

//                    //Creación de Movimientos (la creación de EIR en Blanco lo esta haciendo la asignación)
//                    if (autorizaCont.OperacionFuera)
//                    {
//                        var docuOrigenDetalle = _mapper.Map<DocumentoOrigenDetalle>(_context.TS_TCDOCU_ORIG_Q10(autorizaCont.EmpresaId, autorizaCont.ConocEmbarque, autorizaCont.ConEmbarqueItemNuevo).FirstOrDefault());
//                        //Creamos la Tarja ya que no se igresara la consolidación y solo se actualizara desde la GuiaEmbarque
//                        var tarja = new /*/*TarjaSM*/*/
//                        {
//                            EmpresaId = autorizaCont.EmpresaId,
//                            TarjaCodigo = 0,
//                            TipoTarjaTab = "TAR",
//                            TipoTarjaCodigo = "008",
//                            DesconsolidacionNumero = null,
//                            ConsolidacionNumero = autorizaCont.ConsolidacionId,
//                            ConocimientoEmbarqueInterno = (int)docuOrigenDetalle.CONEMB_C_INTERNO,
//                            ConocimientoEmbarqueDetalleInterno = docuOrigenDetalle.COEMDE_C_NUMERO_ITEM.ToString(),
//                            FechaEmision = DateTime.Now,
//                            CargaObservaciones = "Creada por Autorización " + autorizaCont.AutorizacionContenedorId,
//                            TarjaEstado = "1",
//                            CargaCodigo = docuOrigenDetalle.CARGA_C_CODIGO_MANIFESTADO,
//                            TipoCargaCodigo = docuOrigenDetalle.TIPCAR_C_CODIGO_MANIFESTADO,
//                            TipoEmbalajeCodigo = docuOrigenDetalle.TIPEMB_C_CODIGO_MANIFESTADO,
//                            CantidadIngresada = 0,
//                            CantidadSalida = 0,
//                            PesoIngresado = 0,
//                            PesoSalida = 0,
//                            CantidadManifestada = 0,
//                            TipoDesTab = "DES",
//                            TipoDesCod = autorizaCont.TipoOrigenCarga.ToString().PadLeft(3, '0'),
//                            AlmacenCodigo = "PC",
//                            UbicacionAnaquel = "PC",
//                            UbicacionFila = "010",
//                            UbicacionColumna = "020",
//                            UbicacionAltura = "020",
//                            CodTipoEmba = docuOrigenDetalle.TIPEMB_C_CODIGO_MANIFESTADO,
//                            AudiUsuario = autorizaCont.AudiUsuario
//                        };

//                        tarja = tarjaRepository.InsertarTarja2(tarja);

//                        //Creamos los Movimientos
//                        var movimientos = CrearMovimientosAClienteVacio(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario);

//                        CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Salida, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[0], autorizaCont.AudiUsuario);
//                        CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Ingreso, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[1], autorizaCont.AudiUsuario);
//                    }
//                    else
//                    {
//                        if (autorizaCont.TiCodOperacion == "011")
//                        {
//                            //Creamos los Movimientos de Aforo
//                            //var movimientos = CrearMovimientoVaciosAforoConsolidacion(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario).ToList();
//                            //CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Ingreso, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[1], autorizaCont.AudiUsuario);

//                            //var MovIdRetorno = GuardarMovimientoAforoConsolidacion(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario);
//                        }
//                        else
//                        {
//                            //Inserción de EIR para tipo movimiento 5, el movimiento de tipo 8 lo hace en la asignación
//                            _context.TS_TMEIR_I1(autorizaCont.EmpresaId, 0, autorizaCont.SeguimientoId, "INT", "003", "EST", "001", TipoMovimiento.TipoMovimientoConsolidadoALleno,
//                                        "ELI", "001", "ECO", "001", null, null, DateTime.Now, false, "Por Autorización" + autorizaCont.AutorizacionContenedorId,
//                                          null, false, false, 0, 0, 0, true, null, null, null, autorizaCont.AudiUsuario, DateTime.Now).FirstOrDefault();

//                            //Creamos los Movimientos
//                            var movimientos = CrearMovimientoAZonaConsolidacion(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario);
//                        }
//                    }

//                    _context.TS_TMSEGUI_CONT_U2(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, "1", autorizaCont.AudiUsuario, DateTime.Now);
//                    _context.TS_TMLOGS_I1("Actualización de seguimiento para" + autorizaCont.SeguimientoId.ToString());
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error al momento de generar consolidación", ex);
//            }
//        }

//        public bool GenerarApertura(AutorizacionContenedorDetalle autorizaCont, DocumentoOrigenDetalle docuOrigen)
//        {
//            try
//            {
//                if (autorizaCont.ServiciosGenerados)
//                {
//                    if (autorizaCont.AperturaId == 0)
//                    {
//                        autorizaCont.ConEmbarqueItemNuevo = autorizaCont.ConEmbarqueItemBase;
//                        autorizaCont.ActaAperturaId = _context.TS_TMACTA_APER_I1(autorizaCont.EmpresaId, autorizaCont.ActaAperturaId, null, DateTime.Now, null, EstadoActaApertura.Abierto.ToString(),
//                                                autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario).FirstOrDefault();
//                        //Creamos la Apertura en Blanco
//                        autorizaCont.AperturaId = _context.TS_TMAPER_I1(autorizaCont.EmpresaId, autorizaCont.AperturaId, autorizaCont.ActaAperturaId, autorizaCont.SeguimientoId, DateTime.Now,
//                                                EstadoOperacion.EnPausa.ToString(), null, null, null, null, autorizaCont.AudiUsuario, autorizaCont.ConocEmbarque).FirstOrDefault();

//                        autorizaCont.ConEmbarqueItemNuevo = autorizaCont.ConEmbarqueItemBase;
//                        //Se crea Solicitud Servicio
//                        solicitudServicioRespository.CrearSolicitudServicioAutomatica(autorizaCont.EmpresaId, autorizaCont.ConocEmbarque, autorizaCont.TiTabContenedor, autorizaCont.TiCodContenedor, Operacion.Apertura, autorizaCont.TiCodOperacion,
//                                                                                          autorizaCont.ConEmbarqueItemNuevo, autorizaCont.Recalada, autorizaCont.ClienteCodigo, autorizaCont.FechaAutorizacion.HasValue ? autorizaCont.FechaAutorizacion.Value : DateTime.Now, autorizaCont.SeguimientoId, autorizaCont.AudiUsuario,
//                                                                                          AperturaId: autorizaCont.AperturaId.GetValueOrDefault(), contAutorizadoItem: autorizaCont.AutorizacionContenedorId, operacionFuera: autorizaCont.OperacionFuera);
//                    }
//                }

//                if (autorizaCont.Autorizado)
//                {
//                    if (autorizaCont.OperacionFuera)
//                    {

//                    }
//                    else
//                    {
//                        if (autorizaCont.TiCodOperacion == "011")
//                        {
//                            //Creamos los Movimientos de Aforo
//                            var movimientos = CrearMovimientoLlenosAforoDesconsolidacion(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario).ToList();
//                            CrearEIRBlanco_Aforo(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Ingreso, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[1], autorizaCont.AudiUsuario);
//                            actualizarEstadoPrecintos(autorizaCont.SeguimientoId, "003", autorizaCont.AudiUsuario);
//                        }

//                    }
//                }



//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función GenerarApertura(Error al momento de generar apertura)", ex);
//            }
//        }

//        public bool GenerarDesconsolidacion(AutorizacionContenedorDetalle autorizaCont, DocumentoOrigenDetalle docuOrigen)
//        {
//            try
//            {
//                var docu = new DocumentoOrigenDetalle { };
//                if (docuOrigen == null)
//                {
//                    docuOrigen = docu;
//                }
//                var ST_DESC = "S";
//                if (autorizaCont.ServiciosGenerados)
//                {
//                    //Si no se ha creado la Desconsolidación, la creamos
//                    if (autorizaCont.DesconsolidacionId == 0)
//                    {
//                        //Creamos la desconsolidacion en Blanco 
//                        autorizaCont.DesconsolidacionId = desconsolidacionRespository.GuardarDesconsolidacionBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario);

//                        if (autorizaCont.OperacionFuera)
//                        {
//                            //Si es desconsolidacion Fuera la Nota de Embarque solo inserta el item del contenedor
//                            //entonces el item Nuevo que referencia la solicitud es el item anterior
//                            autorizaCont.ConEmbarqueItemNuevo = autorizaCont.ConEmbarqueItemBase;
//                        }
//                        else
//                        {
//                            //Si es DesConsolidacion Dentro inserta 2 item del contenedor vacio y item de la carga
//                            //Insertamos el item de la carga
//                            autorizaCont.ConEmbarqueItemNuevo = documentoOrigenRepository.InsertarItemDetalleConocimientoEmbarque(docuOrigen, autorizaCont, TipoGeneracionItemDetalle.ItemCarga, ST_DESC);
//                            //Insertamos el item del contenedor vacio
//                            autorizaCont.ConEmbarqueItemNuevo = documentoOrigenRepository.InsertarItemDetalleConocimientoEmbarque(docuOrigen, autorizaCont, TipoGeneracionItemDetalle.ItemContenedorVacio, ST_DESC);
//                        }

//                        //Si es Desconsolidación Fuera o Dentro igual se genera la SolServicio
//                        solicitudServicioRespository.CrearSolicitudServicioAutomatica(autorizaCont.EmpresaId, autorizaCont.ConocEmbarque, autorizaCont.TiTabContenedor, autorizaCont.TiCodContenedor, Operacion.Desconsolidacion, autorizaCont.TiCodOperacion,
//                                                                                          autorizaCont.ConEmbarqueItemBase, autorizaCont.Recalada, autorizaCont.ClienteCodigo, autorizaCont.FechaAutorizacion.HasValue ? autorizaCont.FechaAutorizacion.Value : DateTime.Now, autorizaCont.SeguimientoId, autorizaCont.AudiUsuario,
//                                                                                          DesconsolidacionId: autorizaCont.DesconsolidacionId, contAutorizadoItem: autorizaCont.AutorizacionContenedorId, operacionFuera: autorizaCont.OperacionFuera);
//                    }
//                }
//                if (autorizaCont.Autorizado)
//                {
//                    if (autorizaCont.OperacionFuera)
//                    {
//                        //Generamos Movimento de Zona Llenos a Cliente
//                        var movimientos = CrearMovimientosAClienteLleno(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario);

//                        CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Salida, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[0], autorizaCont.AudiUsuario);
//                        CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Ingreso, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[1], autorizaCont.AudiUsuario);
//                    }
//                    else
//                    {
//                        //Creamos los Movimientos
//                        var movimientos = CrearMovimientoAZonaDesconsolidacion(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.AutorizacionContenedorId, autorizaCont.AudiUsuario).ToList();
//                        CrearEIRBlanco(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, autorizaCont.OperacionFuera, DireccionMovimientoContenedor.Ingreso, autorizaCont.TiCodAutorizacion, autorizaCont.AutorizacionContenedorId, movimientos[1], autorizaCont.AudiUsuario);
//                    }

//                    string regimenCodigo = _mapper.Map<List<SeguimientoConocEmbarqueDetalle>>(_context.TS_TDSEGUI_CONT_CONO_EMBA_Q3(autorizaCont.EmpresaId, autorizaCont.SeguimientoId)).FirstOrDefault()?.regimen;

//                    if (regimenCodigo == null)
//                    {
//                        throw new Exception("En la generación del Status no se ha encontrado el BL");
//                    }

//                    if (autorizaCont.OperacionFuera && regimenCodigo == "07")
//                    {
//                        //No hace nada
//                    }
//                    else
//                    {
//                        //Creamos el Status
//                        var paramss = new StatusContenedorParams
//                        {
//                            EmpresaId = autorizaCont.EmpresaId,
//                            Ops = StatusContenedor.TipoOperacionStatusDesconsolidacion,
//                            Mov = null,
//                            Est = null,
//                            Zona = null,
//                            Eco = null,
//                            TipoAsignacion = null,
//                            InicioFin = "F",
//                            Regimen = null
//                        };

//                        statusContenedorRespository.GuardarStatusContenedor(paramss, autorizaCont.SeguimientoId, autorizaCont.ConocEmbarque, autorizaCont.AudiUsuario);
//                    }

//                    _context.TS_TMSEGUI_CONT_U2(autorizaCont.EmpresaId, autorizaCont.SeguimientoId, "1", autorizaCont.AudiUsuario, DateTime.Now);
//                    _context.TS_TMLOGS_I1("Actualización de seguimiento para" + autorizaCont.SeguimientoId.ToString());
//                }


//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función GenerarDesconsolidacion(Error al momento de generar desconsolidación)", ex);
//            }
//        }

//        private int[] CrearMovimientosAClienteVacio(string empresaId, int seguimientoId, int autorizacionId, string usuario)
//        {
//            try
//            {
//                var TipoMovACliente = TipoMovimiento.TipoMovimientoACliente; //Ida
//                var tipoMovDesdeCliente = TipoMovimiento.TipoMovimientoClienteALlenos; //Retorno

//                return CrearMovimientosPorTipo(empresaId, seguimientoId, autorizacionId, usuario, TipoMovACliente, tipoMovDesdeCliente);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientosAClienteVacio(Error al momento de crear movimiento a Cliente Vacio)", ex);
//            }
//        }
//        private int[] CrearMovimientosAClienteLleno(string empresaId, int seguimientoId, int autorizacionId, string usuario)
//        {
//            try
//            {
//                var TipoMovACliente = TipoMovimiento.TipoMovimientoDespachoACliente; //Ida
//                var tipoMovDesdeCliente = TipoMovimiento.TipoMovimientoEntradaDeCliente; //Retorno

//                return CrearMovimientosPorTipo(empresaId, seguimientoId, autorizacionId, usuario, TipoMovACliente, tipoMovDesdeCliente);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientosAClienteLleno(Error al momento de crear movimiento a Cliente Lleno)", ex);
//            }
//        }
//        public int[] CrearMovimientoAZonaConsolidacion(string empresaId, int seguimientoId, int autorizacionId, string usuario)
//        {
//            try
//            {
//                var TipoMovimientoVacioAConsolidar = TipoMovimiento.TipoMovimientoVacioAConsolidar; //tipo 8
//                var TipoMovimientoConsolidadoALleno = TipoMovimiento.TipoMovimientoConsolidadoALleno; // tipo 5

//                //Se puso al revez porque en el caso de los EIRs el úlimo con mov nullo es de tipo 5 y el primer movimiento en crearse tendría que ser el 5, corregir el ingreso de EIRs
//                return CrearMovimientosPorTipo(empresaId, seguimientoId, autorizacionId, usuario, TipoMovimientoConsolidadoALleno, TipoMovimientoVacioAConsolidar);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientoAZonaConsolidacion(Error al momento de crear movimiento a Zona Consolidación)", ex);
//            }
//        }

//        private int[] CrearMovimientoAZonaDesconsolidacion(string empresaId, int seguimientoId, int autorizacionId, string usuario)
//        {
//            try
//            {
//                var MovIda = TipoMovimiento.TipoMovimientoLlenoADesconsolidar;
//                var MovVuelta = TipoMovimiento.TipoMovimientoDesconsolidadoAVacio;

//                return CrearMovimientosPorTipo(empresaId, seguimientoId, autorizacionId, usuario, MovIda, MovVuelta);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientoAZonaDesconsolidacion(Error al momento de crear movimiento a Zona Consolidación)", ex);
//            }
//        }

//        private int[] CrearMovimientoLlenosAforoDesconsolidacion(string empresaId, int seguimientoId, int autorizacionId, string usuario)
//        {
//            try
//            {
//                var MovIda = TipoMovimiento.TipoMovimientoLlenosAAforo;
//                var MovVuelta = TipoMovimiento.TipoMovimientoAforoADesconsolidacion;

//                return CrearMovimientosPorTipo(empresaId, seguimientoId, autorizacionId, usuario, MovIda, MovVuelta);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientoAZonaDesconsolidacion(Error al momento de crear movimiento a Zona Consolidación)", ex);
//            }
//        }



//        private int[] CrearMovimientosPorTipo(string empresaId, int seguimientoId, int autorizacionId, string usuario, int tipoMovIda, int tipoMovRegreso)
//        {
//            try
//            {
//                var MovIda = 0;
//                var MovRetorno = 0;

//                var movVerificado = _context.TS_TCMOVI_CONT_Q8(empresaId, seguimientoId, tipoMovIda, autorizacionId).FirstOrDefault();
//                if (movVerificado != 0)
//                {
//                    MovIda = movVerificado.Value;
//                }
//                else
//                {
//                    //1. Creamos el Movimiento de Ida
//                    var movACos = new MovimientoCabecera
//                    {
//                        EmpresaId = empresaId,
//                        SeguimientoCodigo = seguimientoId,
//                        FechaCreacion = DateTime.Now,
//                        ObservacionesCabecera = "Autorizacion No: " + autorizacionId,
//                        TipoMovimientoCodigo = tipoMovIda,
//                        AudiUsuario = usuario,
//                        ContenedorAutorizadoCodigo = autorizacionId
//                    };
//                    MovIda = movimientoRespository.InsertarMovimiento(movACos);
//                }

//                movVerificado = _context.TS_TCMOVI_CONT_Q8(empresaId, seguimientoId, tipoMovRegreso, autorizacionId).FirstOrDefault();
//                if (movVerificado != 0)
//                {
//                    MovRetorno = movVerificado.Value;
//                }
//                else
//                {
//                    //2. Creamos el Movimiento de Vuelta
//                    var movACos = new MovimientoCabecera
//                    {
//                        EmpresaId = empresaId,
//                        SeguimientoCodigo = seguimientoId,
//                        FechaCreacion = DateTime.Now,
//                        ObservacionesCabecera = "Autorizacion No: " + autorizacionId,
//                        TipoMovimientoCodigo = tipoMovRegreso,
//                        AudiUsuario = usuario,
//                        ContenedorAutorizadoCodigo = autorizacionId
//                    };
//                    MovRetorno = movimientoRespository.InsertarMovimiento(movACos);
//                }

//                return new int[] { MovIda, MovRetorno };
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearMovimientosPorTipo(Error al momento de crear movimientos por tipo)", ex);
//            }
//        }

//        private void CrearEIRBlanco(string empresaId, int seguimientoId, bool OperaFuera, DireccionMovimientoContenedor direccion, string tipoAutorizacion, int autorizacionId, int movimientoId, string usuario)
//        {
//            try
//            {
//                var tipoMovimiento = 0;
//                var tipoIntercambio = "";
//                if (direccion == DireccionMovimientoContenedor.Salida)
//                {
//                    tipoMovimiento = ObtenerParamPorTipoMovimiento(OperaFuera, direccion, tipoAutorizacion == "001" ? TipoEstadoContenedor.Vacio : TipoEstadoContenedor.Lleno);
//                    tipoIntercambio = "002";
//                }
//                else
//                {
//                    tipoMovimiento = ObtenerParamPorTipoMovimiento(OperaFuera, direccion, tipoAutorizacion == "001" ? TipoEstadoContenedor.Lleno : TipoEstadoContenedor.Vacio);
//                    tipoIntercambio = "001";
//                }

//                _context.TS_TMEIR_I1(empresaId, 0, seguimientoId, "INT", tipoIntercambio, null, null, tipoMovimiento,
//                                    null, null, "ECO", "001", null, null, DateTime.Now, false, "Por Autorización" + autorizacionId,
//                                    null, false, false, 0, 0, 0, true, movimientoId, null, null, usuario, DateTime.Now).FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearEIRBlanco(Error al momento de crear EIR en blanco)", ex);
//            }
//        }

//        private void CrearEIRBlanco_Aforo(string empresaId, int seguimientoId, bool OperaFuera, DireccionMovimientoContenedor direccion, string tipoAutorizacion, int autorizacionId, int movimientoId, string usuario)
//        {
//            try
//            {
//                var tipoMovimiento = 0;
//                var tipoIntercambio = "";
//                if (direccion == DireccionMovimientoContenedor.Salida)
//                {
//                    tipoIntercambio = "002";
//                }
//                else
//                {

//                    tipoIntercambio = "001";
//                }

//                tipoMovimiento = TipoMovimiento.TipoMovimientoAforoADesconsolidacion;

//                _context.TS_TMEIR_I1(empresaId, 0, seguimientoId, "INT", tipoIntercambio, null, null, tipoMovimiento,
//                                    null, null, "ECO", "001", null, null, DateTime.Now, false, "Por Autorización" + autorizacionId,
//                                    null, false, false, 0, 0, 0, true, movimientoId, null, null, usuario, DateTime.Now).FirstOrDefault();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función CrearEIRBlanco(Error al momento de crear EIR en blanco)", ex);
//            }
//        }


//        private int ObtenerParamPorTipoMovimiento(bool OperaFuera, DireccionMovimientoContenedor direccion, TipoEstadoContenedor estado)
//        {
//            switch (direccion)
//            {
//                case DireccionMovimientoContenedor.Ingreso:
//                    switch (estado)
//                    {
//                        case TipoEstadoContenedor.Lleno:
//                            if (OperaFuera)
//                            {
//                                return TipoMovimiento.TipoMovimientoClienteALlenos;
//                            }
//                            else
//                            {
//                                return TipoMovimiento.TipoMovimientoConsolidadoALleno;
//                            }
//                        case TipoEstadoContenedor.Vacio:
//                            if (OperaFuera)
//                            {
//                                return TipoMovimiento.TipoMovimientoEntradaDeCliente;
//                            }
//                            else
//                            {
//                                return TipoMovimiento.TipoMovimientoDesconsolidadoAVacio;
//                            }

//                    }
//                    break;
//                case DireccionMovimientoContenedor.Salida:
//                    switch (estado)
//                    {
//                        case TipoEstadoContenedor.Lleno:
//                            if (OperaFuera)
//                            {
//                                return TipoMovimiento.TipoMovimientoDespachoACliente;
//                            }
//                            else
//                            {
//                                return TipoMovimiento.TipoMovimientoLlenoADesconsolidar;
//                            }
//                        case TipoEstadoContenedor.Vacio:
//                            if (OperaFuera)
//                            {
//                                return TipoMovimiento.TipoMovimientoACliente;
//                            }
//                            else
//                            {
//                                return TipoMovimiento.TipoMovimientoVacioAConsolidar;
//                            }

//                    }
//                    break;
//            }

//            throw new Exception("Error en ObtenerParamPorTipoMovimiento");
//        }

//        public AutorizacionContenedor ObtenerAutorizacionContenedoresConsolidacion(string empresaId, int asignacionId)
//        {
//            var modelo = _mapper.Map<AutorizacionContenedor>(_context.TS_TMCONT_AUT_Q1(empresaId, asignacionId).FirstOrDefault());
//            modelo.TipoAutorizacion = TipoAutorizacion.Consolidacion;

//            modelo.Detalles = _mapper.Map<List<AutorizacionContenedorDetalle>>(_context.TS_TMCONT_AUT_Q2(empresaId, modelo.DocumentoOrigenId, modelo.BookingId));
//            modelo.Detalles.ForEach(d => { d.AutorizadoDB = d.Autorizado; d.ServiciosGeneradosDB = d.ServiciosGenerados; d.ServiciosAdicGeneradosDB = d.ServiciosAdicGenerados; });

//            return modelo;
//        }

//        public void actualizarNoRetorna(AutorizacionContenedorDetalle detalle)
//        {
//            try
//            {
//                if (detalle.AutorizacionContenedorId != 0)
//                {
//                    _context.TS_TMCONT_AUT_U2(detalle.EmpresaId, detalle.AutorizacionContenedorId, detalle.NoRetorna);

//                    if (detalle.NoRetorna)
//                    {
//                        _context.TS_TMLOGS_I1("Actualizando seguimiento por NO RETORNA para autorización " + detalle.AutorizacionContenedorId.ToString() + " -  Seguimiento  : " + detalle.SeguimientoId.ToString());
//                        _context.TS_TMSEGUI_CONT_U5(detalle.AutorizacionContenedorId, false);/*Se actualiza seguimiento a 0*/
//                        _context.TS_TMLOGS_I1("Actualizando movimientos para contenedor de autorización " + detalle.AutorizacionContenedorId.ToString() + " -  Seguimiento  : " + detalle.SeguimientoId.ToString());
//                        _context.TS_TCMOVI_CONT_D2(detalle.AutorizacionContenedorId);/*Se actualiza seguimiento a 0*/

//                    }
//                    _context.TS_TMLOGS_I1("Actualizando autorización " + detalle.AutorizacionContenedorId.ToString() + " -  No Retorna : " + detalle.NoRetorna.ToString());
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función actualizarNoRetorna(Error al momento de guardar detalle de Autorización de Contenedor)", ex);
//            }
//        }

//        public int actualizarDatosContenedorizados(int AsignacionId, int ConocEmbarque)
//        {
//            var modelo = ObtenerAutorizacionContenedoresConsolidacion(_empresaId, AsignacionId);

//            var booking = bookingRepository.ObtenerBooking(_empresaId, modelo.BookingId);
//            var act = documentoOrigenRepository.actualizarDatosContenedorizados(ConocEmbarque, booking);
//            return act;
//        }



//        public void actualizarAutorizacion(AutorizacionContenedorDetalle detalle)
//        {
//            try
//            {
//                if (detalle.AutorizacionContenedorId != 0)
//                {
//                    _context.TS_TMCONT_AUT_U3(detalle.EmpresaId, detalle.AutorizacionContenedorId, true);
//                    actualizarEstadoPrecintos(detalle.SeguimientoId, "003", detalle.AudiUsuario);

//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función actualizarAutorizacion(Error al momento de guardar detalle de Autorización de Contenedor)", ex);
//            }
//        }


//        public void actualizarEstadoPrecintos(int seguimientoId, string estadoPrecinto, string audiUsuario)
//        {
//            _context.TS_TMPREC_CONT_U4(seguimientoId, estadoPrecinto, audiUsuario);
//        }
//    }

//}
