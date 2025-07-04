using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleBa12Temp
    {
        public DataTable ObtenerDetalleTmpCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT  AnioMes, 
                                        FECHA, 
                                        NOCHEQUE, 
                                        BTIPOPERSONA, 
                                        BNombreJuridico, 
                                        BPrimerApellido, 
                                        BSegundoApellido, 
                                        BApellidoCasada, 
                                        BPrimerNombre, 
                                        BSegundoNombre, 
                                        CTipoPersona, 
                                        CTp_Identificacion, 
                                        CNoOrdenCedula, 
                                        CDPI, 
                                        CNombreJuridico, 
                                        CPrimerApellido, 
                                        CSegundoApellido, 
                                        CApellidoCasada, 
                                        CPrimerNombre, 
                                        CSegundoNombre, 
                                        TipoMoneda, 
                                        MontoMonedaOriginal, 
                                        MontoDolares, 
                                        MedioPagoUtilizado, 
                                        MedioPago, 
                                        codigo_cliente, 
                                        Estado, 
                                        Usuario_registro, 
                                        Fecha_Registro, 
                                        Usuario_Modifico, 
                                        Fecha_Modifico, 
                                        REPLACE(Justificacion, ';', ' ') AS Justificacion,
                                        REPLACE(Observaciones_chk, ';', ' ') AS Observaciones_chk, 
                                        NUM_SOLICITUD, 
                                        COD_SISTEMA_ORIGEN, 
                                        NUM_DOCUMENTO, 
                                        REFERENCIA
                                    FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_tmp
                                    WHERE AnioMes = @AnioMes";

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@AnioMes", anioMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error en un log en lugar de solo imprimirlo
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
            }

            return dt;

        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT
                                         CASE WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                           1
	                                      ELSE 
	                                            0
	                                      END RESULTADO,
	                                      CASE
	                                      WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                           'NUMERO DE CASOS CORRECTOS '  + Convert(Varchar,RR.CASOS_ORIGEN)
	                                      ELSE 
	                                            'NUMERO CASOS INCORRECTOS. ORIGEN ' + Convert(Varchar,RR.CASOS_ORIGEN) + ' A REVISAR ' + Convert(Varchar,RR.CASOS_REVISAR)
	                                      END DETALLE
                                FROM (	SELECT  SUM(XX.CASOS_ORIGEN) CASOS_ORIGEN,
		                                        SUM(XX.CASOS_REVISAR) CASOS_REVISAR
		                                 FROM (
		                                SELECT COUNT(*) CASOS_ORIGEN, 0 CASOS_REVISAR
		                                 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta DRDD 
                                         WHERE DRDD.AnioMes = @anioMes 
		                                 UNION 
		                                 SELECT 0 CASOS_ORIGEN, COUNT(*) CASOS_REVISAR
		                                 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_tmp DRDDT
                                         WHERE DRDDT.AnioMes = @anioMes 
		                                  ) XX
		                                  ) RR";

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@AnioMes", anioMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error en un log en lugar de solo imprimirlo
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
            }

            return dt;

        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT CASE WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 1
	                                      ELSE 
	                                            0
	                                      END RESULTADOok,
                                  CASE 
	                                      WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                           'CASOS A DETALLE CORRECTOS '  + Convert(Varchar,RR.CASOS_ORIGEN)
	                                      ELSE 
	                                            'CASOS A DETALLE INCORRECTOS. ORIGEN ' + Convert(Varchar,RR.CASOS_ORIGEN) + ' A REVISAR ' + Convert(Varchar,RR.CASOS_REVISAR)
	                                      END RESULTADO
                                FROM (
		                                SELECT  SUM(XXX.CASOS_ORIGEN) CASOS_ORIGEN,
				                                        SUM(XXX.CASOS_REVISAR) CASOS_REVISAR
				                                 FROM (
						                                SELECT  COUNT(*) CASOS_REVISAR,0 CASOS_ORIGEN
						                                FROM (
							                                SELECT DRDDT.NOCHEQUE
										                                 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta DRDD,
										                                      EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_TMP DRDDT
										                                WHERE DRDD.AnioMes  = DRDDT.AnioMes
										                                 AND  DRDD.FECHA  = DRDDT.FECHA
										                                 AND  DRDD.NOCHEQUE = DRDDT.NOCHEQUE
							                                 ) TT
					                                     UNION 
								                                SELECT 0 CASOS_REVISAR, COUNT(*) CASOS_ORIGEN 
										                                 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta DRDD
				                                        ) XXX
                                  )  RR";

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@AnioMes", anioMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error en un log en lugar de solo imprimirlo
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
            }

            return dt;

        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_tmp WHERE AnioMes = @anioMes";

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@anioMes", anioMes);
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Puedes usar filasAfectadas para verificar si se eliminó algo
                    return filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                // Aquí podrías registrar el error en un log
                Console.WriteLine($"Error al eliminar datos: {ex.Message}");
                return false;
            }
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"WITH TB_X AS (
												SELECT DRDD.NOCHEQUE,
                                                    Isnull(Convert(Varchar,DRDD.AnioMes),'') + 
                                                    Isnull(Convert(Varchar,DRDD.FECHA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BTIPOPERSONA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BNombreJuridico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BPrimerApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BSegundoApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BApellidoCasada),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BSegundoNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CTipoPersona),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CTp_Identificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CNoOrdenCedula),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CDPI),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CNombreJuridico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CSegundoApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CApellidoCasada),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CSegundoNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TipoMoneda),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MontoMonedaOriginal),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MontoDolares),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MedioPagoUtilizado),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MedioPago),'') + 
                                                    Isnull(Convert(Varchar,DRDD.codigo_cliente),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Estado),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Justificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NOCHEQUE),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Observaciones_chk),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUM_SOLICITUD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.COD_SISTEMA_ORIGEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUM_DOCUMENTO),'') + 
                                                    Isnull(Convert(Varchar,DRDD.REFERENCIA),'') KeyOri,'' KeyRev
                                                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta DRDD WHERE DRDD.anioMes=@anioMes
	                                            ),
		                                                TB_Y AS 
                                                (		 SELECT DRDD.NOCHEQUE,
                                                    '' KeyOri,
		                                            Isnull(Convert(Varchar,DRDD.AnioMes),'') + 
                                                    Isnull(Convert(Varchar,DRDD.FECHA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BTIPOPERSONA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BNombreJuridico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BPrimerApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BSegundoApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BApellidoCasada),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.BSegundoNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CTipoPersona),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CTp_Identificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CNoOrdenCedula),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CDPI),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CNombreJuridico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CSegundoApellido),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CApellidoCasada),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CPrimerNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CSegundoNombre),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TipoMoneda),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MontoMonedaOriginal),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MontoDolares),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MedioPagoUtilizado),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MedioPago),'') + 
                                                    Isnull(Convert(Varchar,DRDD.codigo_cliente),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Estado),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Justificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NOCHEQUE),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Observaciones_chk),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUM_SOLICITUD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.COD_SISTEMA_ORIGEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUM_DOCUMENTO),'') + 
		                                            Isnull(Convert(Varchar,DRDD.REFERENCIA),'')  KeyRev
		                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_tmp DRDDT WHERE DRDDT.anioMes=@anioMes
										),
										TB_CHANGE AS (
										SELECT 'ORIGEN' TP,DRDD2.*
											FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta DRDD2
											WHERE DRDD2.Numero_transaccion NOT IN (
																					SELECT RR.Numero_transaccion
																							FROM (
																									SELECT TB_X.numero_transaccion, TB_X.KeyOri,TB_Y.KeyRev
																									FROM TB_X,
																										TB_Y
																									WHERE TB_X.KeyOri = TB_Y.KeyRev
												 												) RR
																					)
											AND DRDD2.ANIOMES = @anioMes
														)
										,
										TB_CHANGE_BIS AS (			
										SELECT *
											FROM TB_CHANGE
										UNION
										SELECT 'NEW' TP,DRDDT2.*
											FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta_tmp DRDDT2
											WHERE DRDDT2.NUMERO_TRANSACCION IN (SELECT C2.Numero_transaccion  FROM TB_CHANGE C2)
											AND DRDDT2.ANIOMES = @anioMes
											)
											SELECT RRJJ.*
											FROM (
											SELECT RRJ.Numero_transaccion,
													RRJ.KEYJUST,
													MAX(RRJ.JUSTIFICACION_NEW) JUSTIFICACION_NEW,
													MAX(RRJ.JUSTIFICACION_ORIGEN) JUSTIFICACION_ORIGEN
											FROM   (
													SELECT CB.Numero_transaccion,
														Isnull(Convert(Varchar,CB.NUM_DOCUMENTO),'') +
														Isnull(Convert(Varchar,CB.FECHA),'') +
														Isnull(Convert(Varchar,CB.codigo_cliente),'') +
														Isnull(Convert(Varchar,CB.NOCHEQUE),'') +
														Isnull(Convert(Varchar,CB.NUM_SOLICITUD),'') kEYjUST,CB.JUSTIFICACION JUSTIFICACION_NEW,' ' JUSTIFICACION_ORIGEN
													FROM TB_CHANGE_BIS CB
													WHERE CB.TP = 'NEW'
													UNION
													SELECT CB.Numero_transaccion,
														Isnull(Convert(Varchar,CB.NUM_DOCUMENTO),'') +
														Isnull(Convert(Varchar,CB.FECHA),'') +
														Isnull(Convert(Varchar,CB.codigo_cliente),'') +
														Isnull(Convert(Varchar,CB.NOCHEQUE),'') +
														Isnull(Convert(Varchar,CB.Tipo_Transaccion),'') +
														Isnull(Convert(Varchar,CB.NUM_SOLICITUD),'') kEYjUST,
														' ' JUSTIFICACION_NEW,
														CB.JUSTIFICACION JUSTIFICACION_ORIGEN
													FROM TB_CHANGE_BIS CB
													WHERE CB.TP = 'ORIGEN'
													) RRJ
										GROUP BY RRJ.Numero_transaccion,RRJ.KEYJUST
										)
										RRJJ
										WHERE ISNULL(RRJJ.JUSTIFICACION_NEW,' ') = ISNULL(RRJJ.JUSTIFICACION_ORIGEN,' ')
											OR  ISNULL(RRJJ.JUSTIFICACION_NEW,' ') = ' '";

            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                using (SqlCommand cmd = new SqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@AnioMes", anioMes);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(cmd))
                    {
                        adaptador.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // Puedes registrar el error en un log en lugar de solo imprimirlo
                Console.WriteLine($"Error al obtener datos: {ex.Message}");
            }

            return dt;

        }

        public bool InsertarDetalleBa12TmpBulk(DataTable dataTable)
        {
            try
            {
                // Limpiar datos antes de insertar
                LimpiarDataTable(dataTable);

                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.rrdv17_detalle_tmp";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("FECHA", "FECHA");
                        bulkCopy.ColumnMappings.Add("NOCHEQUE", "NOCHEQUE");
                        bulkCopy.ColumnMappings.Add("BTIPOPERSONA", "BTIPOPERSONA");
                        bulkCopy.ColumnMappings.Add("BNombreJuridico", "BNombreJuridico");
                        bulkCopy.ColumnMappings.Add("BPrimerApellido", "BPrimerApellido");
                        bulkCopy.ColumnMappings.Add("BSegundoApellido", "BSegundoApellido");
                        bulkCopy.ColumnMappings.Add("BApellidoCasada", "BApellidoCasada");
                        bulkCopy.ColumnMappings.Add("BPrimerNombre", "BPrimerNombre");
                        bulkCopy.ColumnMappings.Add("BSegundoNombre", "BSegundoNombre");
                        bulkCopy.ColumnMappings.Add("CTipoPersona", "CTipoPersona");
                        bulkCopy.ColumnMappings.Add("CTp_Identificacion", "CTp_Identificacion");
                        bulkCopy.ColumnMappings.Add("CNoOrdenCedula", "CNoOrdenCedula");
                        bulkCopy.ColumnMappings.Add("CDPI", "CDPI");
                        bulkCopy.ColumnMappings.Add("CNombreJuridico", "CNombreJuridico");
                        bulkCopy.ColumnMappings.Add("CPrimerApellido", "CPrimerApellido");
                        bulkCopy.ColumnMappings.Add("CSegundoApellido", "CSegundoApellido");
                        bulkCopy.ColumnMappings.Add("CApellidoCasada", "CApellidoCasada");
                        bulkCopy.ColumnMappings.Add("CPrimerNombre", "CPrimerNombre");
                        bulkCopy.ColumnMappings.Add("CSegundoNombre", "CSegundoNombre");
                        bulkCopy.ColumnMappings.Add("TipoMoneda", "TipoMoneda");
                        bulkCopy.ColumnMappings.Add("MontoMonedaOriginal", "MontoMonedaOriginal");
                        bulkCopy.ColumnMappings.Add("MontoDolares", "MontoDolares");
                        bulkCopy.ColumnMappings.Add("MedioPagoUtilizado", "MedioPagoUtilizado");
                        bulkCopy.ColumnMappings.Add("MedioPago", "MedioPago");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("Observaciones_chk", "Observaciones_chk");
                        bulkCopy.ColumnMappings.Add("NUM_SOLICITUD", "NUM_SOLICITUD");
                        bulkCopy.ColumnMappings.Add("COD_SISTEMA_ORIGEN", "COD_SISTEMA_ORIGEN");
                        bulkCopy.ColumnMappings.Add("NUM_DOCUMENTO", "NUM_DOCUMENTO");
                        bulkCopy.ColumnMappings.Add("REFERENCIA", "REFERENCIA");

                        bulkCopy.WriteToServer(dataTable);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos con BulkCopy: " + ex.Message);
                return false;
            }
        }

        public void LimpiarDataTable(DataTable dataTable)
        {
            string[] columnasInt = new string[]
            {
                "AnioMes", "FECHA", "Fecha_Registro",
                "Fecha_Modifico", "NOCHEQUE"
            };

            string[] columnasFloat = new string[]
            {
            "MontoMonedaOriginal", "MontoDolares"
            };

            foreach (DataRow row in dataTable.Rows)
            {
                foreach (string col in columnasInt)
                {
                    if (!dataTable.Columns.Contains(col)) continue;
                    var valor = row[col];
                    if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()) || !int.TryParse(valor.ToString(), out _))
                    {
                        row[col] = DBNull.Value;
                    }
                }

                foreach (string col in columnasFloat)
                {
                    if (!dataTable.Columns.Contains(col)) continue;
                    var valor = row[col];
                    if (valor == null || string.IsNullOrWhiteSpace(valor.ToString()) || !double.TryParse(valor.ToString(), out _))
                    {
                        row[col] = DBNull.Value;
                    }
                }
            }
        }
    }
}
