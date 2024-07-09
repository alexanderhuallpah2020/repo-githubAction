//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;
//using System.Transactions;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class BookingDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;
//        private readonly IBookingDetalleRepository bookingDetalleRepository;

//        public BookingRepository(NCTEntities entity, IBookingDetalleRepository bookingDetalleRepository)
//        {
//            _context = entity;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//            this.bookingDetalleRepository = bookingDetalleRepository;
//        }

//        public BookingSM InsertarBooking(BookingSM booking)
//        {
//            try
//            {
//                using (var scope = new TransactionScope())
//                {
//                    booking.BookingId = _context.TS_TMBOOK_I1(booking.EmpresaId, booking.BookingId, booking.BookingCodigo, booking.LineaId,
//                                                          booking.NaveId, booking.BookingViajeCodigo, booking.Envio, booking.EntregaCargo,
//                                                          booking.ETA, booking.PuertoTransbordo, booking.PuertoDestino, booking.TermNumero,
//                                                          booking.Cliente, booking.Embarcador, booking.TiTabCondicion, booking.TiCodCondicion,
//                                                          booking.Observaciones, booking.ClaseCargaCodigo, booking.TipoCargaCodigo, booking.Version,
//                                                          booking.RecaladaCodigo, booking.EmbalajeCodigo, booking.CargaCont, booking.AudiUsuario, DateTime.Now)
//                                                          .FirstOrDefault()
//                                                          .Value;

//                    GuardarDetalles(booking);
//                    InsertarEnHistorial(booking);
//                    InsertarClientesAdicionales(booking);

//                    scope.Complete();
//                    return booking;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarBooking", ex);
//            }
//        }

//        public bool ActualizarBooking(BookingSM booking)
//        {
//            try
//            {
//                using (var scope = new TransactionScope())
//                {
//                    _context.TS_TMBOOK_U1(booking.EmpresaId, booking.BookingId, booking.BookingCodigo, booking.LineaId,
//                        booking.NaveId, booking.BookingViajeCodigo, booking.Envio, booking.EntregaCargo,
//                        booking.ETA, booking.PuertoTransbordo, booking.PuertoDestino, booking.TermNumero,
//                        booking.Cliente, booking.Embarcador, booking.TiTabCondicion, booking.TiCodCondicion,
//                        booking.Observaciones, booking.ClaseCargaCodigo, booking.TipoCargaCodigo, booking.Version,
//                        booking.RecaladaCodigo, booking.EmbalajeCodigo, booking.CargaCont, booking.AudiUsuario, DateTime.Now);

//                    GuardarDetalles(booking);
//                    InsertarEnHistorial(booking);
//                    IncrementarVersionBooking(booking);
//                    InsertarClientesAdicionales(booking);

//                    scope.Complete();
//                    return true;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función ActualizarBooking", ex);
//            }
//        }


//        private bool InsertarClientesAdicionales(BookingSM booking)
//        {
//            try
//            {
//                _context.TS_TDBOOK_CLIE_D1(booking.EmpresaId, booking.BookingId);

//                if (booking.TiCodCondicion == "002")
//                {
//                    foreach (var item in booking.listaClientesAdicionales)
//                    {
//                        _context.TS_TDBOOK_CLIE_I1(booking.EmpresaId, booking.BookingId, item.PersonaCodigo);
//                    }
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarClientesAdicionales", ex);
//            }
//        }

//        private bool GuardarDetalles(BookingSM booking)
//        {
//            try
//            {
//                //Insertar o actualizar detalles
//                foreach (var detalle in booking.listaDetalles)
//                {
//                    detalle.BookingId = booking.BookingId;
//                    detalle.EmpresaId = booking.EmpresaId;
//                    detalle.AudiUsuario = booking.AudiUsuario;

//                    if (detalle.BookingDetalleId == 0)
//                    {
//                        bookingDetalleRepository.InsertarBookingDetalle(detalle);
//                    }
//                    else
//                    {
//                        bookingDetalleRepository.ActualizarBookingDetalle(detalle);
//                    }
//                }

//                //Eliminar los detalles que no estan en la nueva lista de booking
//                var listaDetallesAntiguos = bookingDetalleRepository.ObtenerBookingDetallePorBooking(booking.EmpresaId, booking.BookingId);
//                foreach (var detalleAntiguo in listaDetallesAntiguos)
//                {
//                    var detalle = booking.listaDetalles.FirstOrDefault(d => d.BookingDetalleId == detalleAntiguo.BookingDetalleId);

//                    if (detalle == null)
//                    {
//                        bookingDetalleRepository.EliminarBookingDetalle(booking.EmpresaId, booking.BookingId, detalleAntiguo.BookingDetalleId);
//                    }

//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función GuardarDetalles", ex);
//            }
//        }
//        private bool InsertarEnHistorial(BookingSM booking)
//        {
//            try
//            {
//                foreach (var detalle in booking.listaDetalles)
//                {
//                    _context.TS_TMBOOK_HIST_Q1(booking.EmpresaId, booking.BookingId, booking.BookingCodigo, detalle.BookingDetalleId,
//                                               booking.Version, booking.LineaId, booking.NaveId, booking.BookingViajeCodigo, booking.Envio,
//                                               booking.EntregaCargo, booking.ETA, booking.PuertoTransbordo, booking.PuertoDestino,
//                                               booking.TermNumero, booking.Cliente, booking.Embarcador, booking.TiTabCondicion, booking.TiCodCondicion,
//                                               booking.Observaciones, booking.ClaseCargaCodigo, booking.TipoCargaCodigo, detalle.TipoContenedorTabla,
//                                               detalle.TipoCotnenedorCodigo, detalle.DimensionTabla, detalle.DimensionCodigo, detalle.Cantidad,
//                                               detalle.PesoTotal, detalle.ZonaCodigoSalida, detalle.ZonaCodigoRetorno, detalle.Temperatura,
//                                               detalle.ConsolidadoPuerto, booking.EmbalajeCodigo, booking.CargaCont, booking.AudiUsuario, DateTime.Now);
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarEnHistorial", ex);
//            }
//        }

//        private void IncrementarVersionBooking(BookingSM booking)
//        {
//            try
//            {
//                _context.TS_TMBOOK_U2(booking.EmpresaId, booking.BookingId);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarEnHistorial", ex);
//            }
//        }
//    }

//}
