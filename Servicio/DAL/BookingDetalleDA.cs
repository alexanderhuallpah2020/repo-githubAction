//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SRV_EdiFileService.Servicio.BE;

//namespace SRV_EdiFileService.Servicio.DAL
//{
//    public class BookingDetalleDA
//    {
//        private readonly NCTEntities _context;
//        private readonly IMapper _mapper;

//        public BookingDetalleDA(NCTEntities entity)
//        {
//            _context = entity;
//            _mapper = InfrastructureMapperBootstrap.MapperConfiguration.CreateMapper();
//        }


//        public BookingDetalle InsertarBookingDetalle(BookingDetalle bookingDetalle)
//        {
//            try
//            {
//                bookingDetalle.BookingDetalleId = _context.TS_TDBOOK_I1(bookingDetalle.EmpresaId, bookingDetalle.BookingId, bookingDetalle.BookingDetalleId,
//                                bookingDetalle.TipoContenedorTabla, bookingDetalle.TipoCotnenedorCodigo, bookingDetalle.DimensionTabla,
//                                bookingDetalle.DimensionCodigo, bookingDetalle.Cantidad, bookingDetalle.PesoTotal, bookingDetalle.ZonaCodigoSalida,
//                                bookingDetalle.ZonaCodigoRetorno, bookingDetalle.Temperatura, bookingDetalle.ConsolidadoPuerto,
//                                bookingDetalle.PreCool, bookingDetalle.VentSet, bookingDetalle.Humedad, bookingDetalle.AudiUsuario, DateTime.Now)
//                                .FirstOrDefault()
//                                .Value;

//                return bookingDetalle;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función InsertarBookingDetalle", ex);
//            }
//        }

//        public BookingDetalle ActualizarBookingDetalle(BookingDetalle bookingDetalle)
//        {
//            try
//            {
//                _context.TS_TDBOOK_U1(bookingDetalle.EmpresaId, bookingDetalle.BookingId, bookingDetalle.BookingDetalleId,
//                    bookingDetalle.TipoContenedorTabla, bookingDetalle.TipoCotnenedorCodigo, bookingDetalle.DimensionTabla,
//                    bookingDetalle.DimensionCodigo, bookingDetalle.Cantidad, bookingDetalle.PesoTotal,
//                    bookingDetalle.ZonaCodigoSalida,
//                    bookingDetalle.ZonaCodigoRetorno, bookingDetalle.Temperatura, bookingDetalle.ConsolidadoPuerto,
//                    bookingDetalle.PreCool, bookingDetalle.VentSet, bookingDetalle.Humedad, bookingDetalle.AudiUsuario,
//                    DateTime.Now);

//                return bookingDetalle;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función ActualizarBookingDetalle", ex);
//            }
//        }

//        public bool EliminarBookingDetalle(string empresaId, int bookingId, int bookingDetalleId)
//        {
//            try
//            {
//                _context.TS_TDBOOK_D1(empresaId, bookingId, bookingDetalleId);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("Error en la función EliminarBookingDetalle", ex);
//            }
//        }
//    }

//}
