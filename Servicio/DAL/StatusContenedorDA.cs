//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Transactions;
//using SRV_EdiFileService.Servicio.BE;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class StatusContenedorDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;
//        private readonly IArchivoEDIRepository archivoEDIRepository;

//        public StatusContenedorRepository(
//            NCTEntities context,
//            IArchivoEDIRepository archivoEDIRepository
//            )
//        {
//            _context = context;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//            this.archivoEDIRepository = archivoEDIRepository;
//        }

//        public bool GuardarStatusContenedor(StatusContenedorParams param, int seguimientoId, int? docuOrigen, string usuario)
//        {
//            try
//            {
//                using (var scope = new TransactionScope())
//                {
//                    var porConsolidacion = true; //Por el momento no se usa al momento de guardar el status
//                    var tipoStatus = "CONT";
//                    var contenedor = _mapper.Map<Contenedor>(_context.TS_TMCONT_Q26(param.EmpresaId, seguimientoId).FirstOrDefault());

//                    _context.TS_TMLOGS_I1("TS_TCSTAT_CRIT_Q1/CONT -- " + param.EmpresaId + "--" + param.Ops + "--" + param.Mov + "--" + param.Est + "--" + param.Zona + "--" +
//                                                  param.Eco + "--" + param.TipoAsignacion + "--" + param.InicioFin + "--" + param.Regimen + "--" + contenedor.IdLinea + "/" + contenedor.CodContenedor);

//                    if (String.IsNullOrEmpty(param.Tcl))
//                    {
//                        param.Tcl = null;
//                    }

//                    if (param.Tcl == "002" && contenedor.IdLinea == "C00001")
//                    {
//                        var x = "Es autorizar contenedores de Hapag LCL";
//                    }


//                    var status = _context.TS_TCSTAT_CRIT_Q1(param.Tcl != null ? "0000000002" : param.EmpresaId, param.Ops, param.Mov, param.Est, param.Zona,
//                                                  param.Eco, param.TipoAsignacion, param.InicioFin, param.Regimen, contenedor.IdLinea).FirstOrDefault();

//                    if (docuOrigen == null)
//                    {
//                        docuOrigen = _context.TS_TCDOCU_ORIG_Q1(param.EmpresaId, seguimientoId).FirstOrDefault();
//                    }

//                    if (status != null)
//                    {
//                        var ultimostatus = _context.TS_TCALMT_CONT_STAT_Q1(param.EmpresaId, contenedor.CodContenedor).FirstOrDefault().CO_STAT;
//                        if (status.CO_STAT_GENE != ultimostatus)
//                        {
//                            var model = _context.TS_TCALMT_CONT_STAT_I1(param.EmpresaId, status.CO_STAT_GENE, seguimientoId, docuOrigen, porConsolidacion, usuario).ToString();

//                            _context.TS_TMLOGS_I1("Se creó status " + status.CO_STAT_GENE + " para " + contenedor.CodContenedor);

//                            var creacionytransmisioncorrecta = archivoEDIRepository.GenerarEdiStatus(param.EmpresaId, status.CO_STAT_GENE.Trim(), contenedor.CodContenedor, seguimientoId, contenedor.IdLinea, tipoStatus, usuario);
//                            if (!creacionytransmisioncorrecta) { return false; }
//                        }
//                    }
//                    scope.Complete();
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función GuardarStatusContenedor", ex);
//            }
//        }

//    }
//}
