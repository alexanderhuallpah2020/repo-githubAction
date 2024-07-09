using log4net;
using SRV_EdiFileService.Servicio.BE;
using SRV_EdiFileService.Servicio.BE.Config;
using System.Data;
using System.Data.SqlClient;

namespace SRV_EdiFileService.Servicio.DAL
{
    internal class CoparnDAL
    {
        private ILog _logger;

        public CoparnDAL()
        {
            _logger = LogManager.GetLogger(typeof(CoparnDAL));
        }

        public int GrabarReserva(ConfigBE config, Booking booking)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("SCO.TS_TMBOOK_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", booking.EmpresaId);
                            command.Parameters.AddWithValue("@CO_BOOK", booking.BookingCodigo);
                            command.Parameters.AddWithValue("@ID_LINE", booking.LineaId);
                            command.Parameters.AddWithValue("@NAVE_DESC", booking.NaveDescripcion);
                            command.Parameters.AddWithValue("@NAVE_LLOYD", booking.NaveCodigoLloyd);
                            command.Parameters.AddWithValue("@RUC_CLI", booking.Cliente);
                            command.Parameters.AddWithValue("@NU_VIAJ", booking.BookingViajeCodigo);
                            command.Parameters.AddWithValue("@FE_ENVI", booking.Envio);
                            command.Parameters.AddWithValue("@FE_ENTR_CARG", booking.EntregaCargo);
                            command.Parameters.AddWithValue("@FE_ETA", booking.ETA);
                            command.Parameters.AddWithValue("@ID_PUER_TRANS", booking.PuertoTransbordo);
                            command.Parameters.AddWithValue("@ID_PUER_DEST", booking.PuertoDestino);
                            command.Parameters.AddWithValue("@NU_TERM", booking.TermNumero);
                            command.Parameters.AddWithValue("@TI_TAB_TCL", booking.TiTabCondicion);
                            command.Parameters.AddWithValue("@TI_COD_TCL", booking.TiCodCondicion);
                            command.Parameters.AddWithValue("@OB_MANI", DBNull.Value);
                            command.Parameters.AddWithValue("@TI_CARG", booking.TipoCargaCodigo);
                            command.Parameters.AddWithValue("@CO_CARG", booking.ClaseCargaCodigo);
                            command.Parameters.AddWithValue("@VE_BOOK", booking.Version);
                            command.Parameters.AddWithValue("@CO_RECA", DBNull.Value);
                            command.Parameters.AddWithValue("@ID_TIPO_EMBA", booking.EmbalajeCodigo);
                            command.Parameters.AddWithValue("@CA_CARG_CONT", booking.CargaCont);
                            command.Parameters.AddWithValue("@AU_USER_CREA", booking.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(outputParam);

                            SqlParameter numeroBooking = new SqlParameter("@NU_BOOK", SqlDbType.Int, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(numeroBooking);

                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();
                            if (Convert.IsDBNull(numeroBooking.Value))
                            {
                                throw new Exception(result);
                            }
                            booking.BookingId = Convert.ToInt32(numeroBooking.Value);
                        }


                        using (SqlCommand command = new SqlCommand("SCO.TS_TDBOOK_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", booking.EmpresaId);
                            command.Parameters.AddWithValue("@NU_BOOK", booking.BookingId);
                            command.Parameters.AddWithValue("@ES_CONS_PUERT", 0);
                            command.Parameters.AddWithValue("@ES_PREC", 0);
                            command.Parameters.AddWithValue("@AU_USER_CREA", booking.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);

                            command.Parameters.Add("@CA_BOOK_DETA", SqlDbType.Int);
                            command.Parameters.Add("@PE_BOOK_DETA", SqlDbType.Decimal);
                            command.Parameters.Add("@TE_BOOK_DETA", SqlDbType.Decimal);
                            command.Parameters.Add("@COD_CONT", SqlDbType.Char);
                            command.Parameters.Add("@TI_COD_EST", SqlDbType.Char);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);


                            foreach (var detalle in booking.listaDetalles)
                            {
                                command.Parameters["@CA_BOOK_DETA"].Value = detalle.Cantidad;
                                command.Parameters["@PE_BOOK_DETA"].Value = detalle.PesoTotal is null ? 0 : detalle.PesoTotal;
                                command.Parameters["@TE_BOOK_DETA"].Value = detalle.Temperatura is null ? DBNull.Value : detalle.Temperatura;
                                command.Parameters["@COD_CONT"].Value = detalle.CodigoContenedor;
                                command.Parameters["@TI_COD_EST"].Value = detalle.EstadoContenedor;


                                command.ExecuteNonQuery();
                                result = outputParam.Value.ToString();
                            }
                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al grabar la reserva: " + ex.Message, ex);
                    }
                }
            }
            _logger.Info(result);
            Console.WriteLine(result);
            return booking.BookingId;
        }

        public AsignacionConsolidacion GrabarAsignacionConsolidacion(ConfigBE config, AsignacionConsolidacion asignacionConsolidacion)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionConsolidacion.EmpresaId);
                            command.Parameters.AddWithValue("@FE_ASIG", asignacionConsolidacion.FechaAsignacion);
                            command.Parameters.AddWithValue("@NU_BOOK_ASIG", asignacionConsolidacion.AsignacionBookingCodigo);
                            command.Parameters.AddWithValue("@TI_ASIG", "C");
                            command.Parameters.AddWithValue("@NU_BOOK", asignacionConsolidacion.BookingId);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionConsolidacion.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@RUC_CLI", asignacionConsolidacion.ClienteCodigo);
                            command.Parameters.AddWithValue("@ID_PUER_TRANS", asignacionConsolidacion.PuertoEmbarqueCodigo);
                            command.Parameters.AddWithValue("@ID_PUER_DEST", asignacionConsolidacion.PuertoDestinoCodigo);
                            command.Parameters.AddWithValue("@NAVE_DESC", asignacionConsolidacion.NaveDescripcion);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(outputParam);

                            SqlParameter numeroAsignacion = new SqlParameter("@CO_ASIG", SqlDbType.Int, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(numeroAsignacion);

                            SqlParameter idDocumentoOrigen = new SqlParameter("@ID_DOCU_ORIG", SqlDbType.Int, 500)
                            {
                                Direction = ParameterDirection.Output
                            };
                            command.Parameters.Add(idDocumentoOrigen);

                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();
                            asignacionConsolidacion.AsignacionId = Convert.ToInt32(numeroAsignacion.Value);
                            asignacionConsolidacion.IdDocumentoOrigen = Convert.ToInt32(idDocumentoOrigen.Value);
                        }


                        using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionConsolidacion.EmpresaId);
                            command.Parameters.AddWithValue("@CO_ASIG", asignacionConsolidacion.AsignacionId);
                            command.Parameters.AddWithValue("@ES_CONS_FUER", 0);
                            command.Parameters.AddWithValue("@ES_ROLE", 0);
                            command.Parameters.AddWithValue("@FE_ASIG", asignacionConsolidacion.FechaAsignacion);
                            command.Parameters.AddWithValue("@CO_TIPO_MOVI", TipoMovimiento.TipoMovimientoACliente);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionConsolidacion.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@NU_DOCU_ORIG", asignacionConsolidacion.AsignacionBookingCodigo);

                            command.Parameters.Add("@CONEMB_C_INTERNO", SqlDbType.Int);
                            command.Parameters.Add("@COD_CONT", SqlDbType.Char);
                            command.Parameters.Add("@TI_COD_EST", SqlDbType.Char);
                            command.Parameters.Add("@PE_BOOK_DETA", SqlDbType.Decimal);
                            command.Parameters.Add("@DE_MERC", SqlDbType.VarChar);
                            command.Parameters.Add("@CA_CONT", SqlDbType.Int);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);


                            foreach (var detalle in asignacionConsolidacion.ListaContenedores)
                            {
                                command.Parameters["@CONEMB_C_INTERNO"].Value = asignacionConsolidacion.IdDocumentoOrigen;
                                command.Parameters["@COD_CONT"].Value = detalle.ContenedorCodigo;
                                command.Parameters["@TI_COD_EST"].Value = detalle.EstadoContenedor;
                                command.Parameters["@PE_BOOK_DETA"].Value = detalle.PesoTotal is null ? 0 : detalle.PesoTotal;
                                command.Parameters["@DE_MERC"].Value = detalle.Cantidad + " CONTENEDORES LLENOS";
                                command.Parameters["@CA_CONT"].Value = detalle.Cantidad;


                                command.ExecuteNonQuery();
                                result = outputParam.Value.ToString();
                            }
                        }

                        using (SqlCommand command = new SqlCommand("SCO.TMCONT_AUT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionConsolidacion.EmpresaId);
                            command.Parameters.AddWithValue("@CO_NEMB", asignacionConsolidacion.IdDocumentoOrigen);
                            command.Parameters.AddWithValue("@ES_AUTO", 0);
                            command.Parameters.AddWithValue("@TI_COD_TAU", TipoAutorizacion.Consolidacion);
                            command.Parameters.AddWithValue("@ES_SER_GENE", 1);
                            command.Parameters.AddWithValue("@ES_OPER_FUER", 1);
                            command.Parameters.AddWithValue("@TI_ORIG_CARG", 1);
                            command.Parameters.AddWithValue("@PE_MNFS", 0);
                            command.Parameters.AddWithValue("@CA_MNFS", 0);
                            command.Parameters.AddWithValue("@TI_COD_TTO", "008"); //Preguntar por aforo
                            command.Parameters.AddWithValue("@CO_SERV_ADIC", 0);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionConsolidacion.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@COD_CONT", SqlDbType.Char);
                            command.Parameters.AddWithValue("@FEC_AUTO", SqlDbType.DateTime);


                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);

                            foreach (var detalle in asignacionConsolidacion.autorizacionesContenedores)
                            {
                                command.Parameters["@COD_CONT"].Value = detalle.ContenedorNumero;
                                command.Parameters["@FEC_AUTO"].Value = detalle.FechaAutorizacion;


                                command.ExecuteNonQuery();
                                result = outputParam.Value.ToString();
                            }

                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al grabar la asignacion: " + ex.Message, ex);
                    }
                }
            }
            Console.WriteLine(result);
            _logger.Info(result);

            return asignacionConsolidacion;
        }

        public string ModificarContenedor(ConfigBE config, AsignacionContenedorConsolidacion asignacionContenedor)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_AUT_D1_COPARN", connection, transaction))
                        {

                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@CO_BOOK", asignacionContenedor.BookingCodigo);
                            command.Parameters.AddWithValue("@CO_CONT", asignacionContenedor.ContenedorCodigo);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);
                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();
                            Console.WriteLine(result);
                            _logger.Info(result);
                        }

                        using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionContenedor.EmpresaId);
                            command.Parameters.AddWithValue("@CO_ASIG", asignacionContenedor.AsignacionId);
                            command.Parameters.AddWithValue("@ES_CONS_FUER", 0);
                            command.Parameters.AddWithValue("@ES_ROLE", 0);
                            command.Parameters.AddWithValue("@FE_ASIG", asignacionContenedor.FechaAsignacion);
                            command.Parameters.AddWithValue("@CO_TIPO_MOVI", TipoMovimiento.TipoMovimientoACliente);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionContenedor.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@CONEMB_C_INTERNO", asignacionContenedor.DocumentoOrigenId);
                            command.Parameters.AddWithValue("@COD_CONT", asignacionContenedor.ContenedorCodigo);
                            command.Parameters.AddWithValue("@TI_COD_EST", asignacionContenedor.EstadoContenedor);
                            command.Parameters.AddWithValue("@PE_BOOK_DETA", asignacionContenedor.PesoTotal is null ? 0 : asignacionContenedor.PesoTotal);
                            command.Parameters.AddWithValue("@DE_MERC", asignacionContenedor.Cantidad + " CONTENEDORES LLENOS");
                            command.Parameters.AddWithValue("@CA_CONT", asignacionContenedor.Cantidad);
                            command.Parameters.AddWithValue("@NU_DOCU_ORIG", asignacionContenedor.BookingCodigo);


                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);
                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();

                        }

                        using (SqlCommand command = new SqlCommand("SCO.TMCONT_AUT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionContenedor.EmpresaId);
                            command.Parameters.AddWithValue("@CO_NEMB", asignacionContenedor.DocumentoOrigenId);
                            command.Parameters.AddWithValue("@ES_AUTO", 0);
                            command.Parameters.AddWithValue("@TI_COD_TAU", TipoAutorizacion.Consolidacion);
                            command.Parameters.AddWithValue("@ES_SER_GENE", 1);
                            command.Parameters.AddWithValue("@ES_OPER_FUER", 1);
                            command.Parameters.AddWithValue("@TI_ORIG_CARG", 1);
                            command.Parameters.AddWithValue("@PE_MNFS", 0);
                            command.Parameters.AddWithValue("@CA_MNFS", 0);
                            command.Parameters.AddWithValue("@TI_COD_TTO", "008"); //Preguntar por aforo
                            command.Parameters.AddWithValue("@CO_SERV_ADIC", 0);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionContenedor.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@COD_CONT", asignacionContenedor.ContenedorCodigo);
                            command.Parameters.AddWithValue("@FEC_AUTO", asignacionContenedor.FechaAsignacion);


                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);
                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();
                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al grabar la asignacion: " + ex.Message, ex);
                    }
                }
            }
            _logger.Info(result);
            return result;
        }

        public string GrabarNuevoContenedor(ConfigBE config, AsignacionContenedorConsolidacion asignacionContenedor)
        {
            string result = "";

            using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionContenedor.EmpresaId);
                            command.Parameters.AddWithValue("@CO_ASIG", asignacionContenedor.AsignacionId);
                            command.Parameters.AddWithValue("@ES_CONS_FUER", 0);
                            command.Parameters.AddWithValue("@ES_ROLE", 0);
                            command.Parameters.AddWithValue("@FE_ASIG", asignacionContenedor.FechaAsignacion);
                            command.Parameters.AddWithValue("@CO_TIPO_MOVI", TipoMovimiento.TipoMovimientoACliente);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionContenedor.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@CONEMB_C_INTERNO", asignacionContenedor.DocumentoOrigenId);
                            command.Parameters.AddWithValue("@COD_CONT", asignacionContenedor.ContenedorCodigo);
                            command.Parameters.AddWithValue("@TI_COD_EST", asignacionContenedor.EstadoContenedor);
                            command.Parameters.AddWithValue("@NU_DOCU_ORIG", asignacionContenedor.BookingCodigo);
                            command.Parameters.AddWithValue("@PE_BOOK_DETA", asignacionContenedor.PesoTotal is null ? 0 : asignacionContenedor.PesoTotal);
                            command.Parameters.AddWithValue("@DE_MERC", asignacionContenedor.Cantidad + " CONTENEDORES LLENOS");
                            command.Parameters.AddWithValue("@CA_CONT", asignacionContenedor.Cantidad);

                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);
                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();

                        }

                        using (SqlCommand command = new SqlCommand("SCO.TMCONT_AUT_I1_COPARN", connection, transaction))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@ID_EMPR", asignacionContenedor.EmpresaId);
                            command.Parameters.AddWithValue("@CO_NEMB", asignacionContenedor.DocumentoOrigenId);
                            command.Parameters.AddWithValue("@ES_AUTO", 0);
                            command.Parameters.AddWithValue("@TI_COD_TAU", TipoAutorizacion.Consolidacion);
                            command.Parameters.AddWithValue("@ES_SER_GENE", 1);
                            command.Parameters.AddWithValue("@ES_OPER_FUER", 1);
                            command.Parameters.AddWithValue("@TI_ORIG_CARG", 1);
                            command.Parameters.AddWithValue("@PE_MNFS", 0);
                            command.Parameters.AddWithValue("@CA_MNFS", 0);
                            command.Parameters.AddWithValue("@TI_COD_TTO", "008"); //Preguntar por aforo
                            command.Parameters.AddWithValue("@CO_SERV_ADIC", 0);
                            command.Parameters.AddWithValue("@AU_USER_CREA", asignacionContenedor.AudiUsuario);
                            command.Parameters.AddWithValue("@AU_FECH_CREA", DateTime.Now);
                            command.Parameters.AddWithValue("@COD_CONT", asignacionContenedor.ContenedorCodigo);
                            command.Parameters.AddWithValue("@FEC_AUTO", asignacionContenedor.FechaAsignacion);


                            SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                            {
                                Direction = ParameterDirection.Output
                            };

                            command.Parameters.Add(outputParam);
                            command.ExecuteNonQuery();
                            result = outputParam.Value.ToString();
                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al grabar la asignacion: " + ex.Message, ex);
                    }
                }
            }
            _logger.Info(result);
            return result;
        }

        public bool EliminarContenedorReserva(ConfigBE config, string codigoContenedor, string codigoBooking)
        {
            bool result = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_AUT_D1_COPARN", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CO_BOOK", codigoBooking);
                        command.Parameters.AddWithValue("@CO_CONT", codigoContenedor);

                        SqlParameter outputParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 500)
                        {
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(outputParam);
                        command.ExecuteNonQuery();
                        result = true;
                        Console.WriteLine(outputParam.Value.ToString());
                        _logger.Info(result);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al grabar la asignacion: " + ex.Message, ex);

            }

            return result;
        }


        public AsignacionConsolidacion ObtenerAsignacionConsolidacion(ConfigBE config, string codigoBooking)
        {
            AsignacionConsolidacion asignacion = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(config.ConexionBaseDeDatos))
                {
                    using (SqlCommand command = new SqlCommand("SCO.TS_TMASIG_CONT_Q1_COPARN", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CO_BOOK", codigoBooking ?? (object)DBNull.Value);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                asignacion = new AsignacionConsolidacion()
                                {
                                    AsignacionId = Convert.ToInt32(reader["CO_ASIG"].ToString()),
                                    IdDocumentoOrigen = Convert.ToInt32(reader["ID_DOCU_ORIG"].ToString()),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar la primera nave: " + ex.Message, ex);
            }

            return asignacion;
        }

    }
}
