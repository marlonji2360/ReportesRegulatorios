using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleEf14Temp
    {
        public DataTable ObtenerDetalleTmpCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT     AnioMes
                                          ,Codigo_Agencia
                                          ,Fecha_Transaccion
                                          ,Numero_transaccion
                                          ,codigo_cliente
                                          ,TIP_MOV
                                          ,MONTO_EN_GTQ
                                          ,TIP_TRANSACCION
                                          ,SUBTIP_TRANSAC
                                          ,numero_cuenta
                                          ,numero_tarjeta
                                          ,cod_sistema
                                          ,Estado
                                          ,Usuario_registro
                                          ,Fecha_Registro
                                          ,Usuario_Modifico
                                          ,Fecha_Modifico
                                          ,Justificacion
                                          ,movexacto_paralelo
                                          ,Trxexacto_paralelo
                                          ,movmixto_paralelo
                                          ,Trxmixto_paralelo
                                          ,movotrocli_paralelo
                                          ,Trxotrocli_paralelo
                                          ,Nomotrocli_paralelo
                                          ,MONTO_mixtoparalelo
                                          ,movmxto58_boveda
                                          ,MONTO_movmxto58
                                          ,movmxto59_boveda
                                          ,MONTO_movmxto59
                                          ,cajero
                                          ,ID_CLTE_VENTANILLA
                                          ,hora_trx
                                          ,NUM_REFERENCIA
                                          ,NUMERO_DOCUMENTO
                                          ,TRX_COMPLEM
                                          ,numero_asiento_contable                                          
                                      FROM DL_CUMPLIMIENTO.dw_repreg_ef14_deta_tmp
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
	                              END RESULTADOok,
	                              CASE
	                              WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                   'NUMERO DE CASOS CORRECTOS '  + Convert(Varchar,RR.CASOS_ORIGEN)
	                              ELSE 
	                                    'NUMERO CASOS INCORRECTOS. ORIGEN ' + Convert(Varchar,RR.CASOS_ORIGEN) + ' A REVISAR ' + Convert(Varchar,RR.CASOS_REVISAR)
	                              END RESULTADO
                        FROM (	SELECT  SUM(XX.CASOS_ORIGEN) CASOS_ORIGEN,
		                                SUM(XX.CASOS_REVISAR) CASOS_REVISAR
		                         FROM (
		                        SELECT COUNT(*) CASOS_ORIGEN, 0 CASOS_REVISAR
		                         FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta DRDD 
		                         UNION 
		                         SELECT 0 CASOS_ORIGEN, COUNT(*) CASOS_REVISAR
		                         FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta_TMP DRDDT
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
            string consulta = @"SELECT CASE WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                1
	                            ELSE 
	                                0
	                            END RESULTADO,
                        CASE 
	                            WHEN RR.CASOS_ORIGEN = RR.CASOS_REVISAR THEN 
	                                'CASOS A DETALLE CORRECTOS '  + Convert(Varchar,RR.CASOS_ORIGEN)
	                            ELSE 
	                                'CASOS A DETALLE INCORRECTOS. ORIGEN ' + Convert(Varchar,RR.CASOS_ORIGEN) + ' A REVISAR ' + Convert(Varchar,RR.CASOS_REVISAR)
	                            END DETALLE
                    FROM (
		                    SELECT  SUM(XXX.CASOS_ORIGEN) CASOS_ORIGEN,
				                            SUM(XXX.CASOS_REVISAR) CASOS_REVISAR
				                        FROM (
						                    SELECT  COUNT(*) CASOS_REVISAR,0 CASOS_ORIGEN
						                    FROM (
							                    SELECT DRDDT.Numero_transaccion
										                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta DRDD,
										                            EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta_TMP DRDDT
										                    WHERE DRDD.AnioMes  = DRDDT.AnioMes
										                        AND  DRDD.Codigo_Agencia  = DRDDT.Codigo_Agencia
										                        AND  DRDD.cajero  = DRDDT.cajero
										                        AND  DRDD.Fecha_Transaccion  = DRDDT.Fecha_Transaccion
										                        AND  DRDD.Numero_transaccion = DRDDT.Numero_transaccion
							                        ) TT
					                            UNION 
								                    SELECT 0 CASOS_REVISAR, COUNT(*) CASOS_ORIGEN 
										                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta DRDD
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
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta_tmp WHERE AnioMes = @anioMes";

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
													SELECT DRDD.Numero_transaccion,
		                                            Isnull(Convert(Varchar,DRDD.AnioMes),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Codigo_Agencia),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Numero_transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.codigo_cliente),'') + 
		                                            Isnull(Convert(Varchar,DRDD.TIP_MOV),'') + 
		                                            Isnull(Convert(Varchar,DRDD.MONTO_EN_GTQ),'') + 
		                                            Isnull(Convert(Varchar,DRDD.TIP_TRANSACCION),'') + 
		                                            Isnull(Convert(Varchar,DRDD.SUBTIP_TRANSAC),'') + 
		                                            Isnull(Convert(Varchar,DRDD.numero_cuenta),'') + 
		                                            Isnull(Convert(Varchar,DRDD.numero_tarjeta),'') + 
		                                            Isnull(Convert(Varchar,DRDD.cod_sistema),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Estado),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Usuario_registro),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Registro),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Usuario_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Justificacion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movexacto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Trxexacto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Trxmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Trxotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Nomotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.MONTO_mixtoparalelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movmxto58_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.MONTO_movmxto58),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movmxto59_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.MONTO_movmxto59),'') + 
		                                            Isnull(Convert(Varchar,DRDD.cajero),'') + 
		                                            Isnull(Convert(Varchar,DRDD.ID_CLTE_VENTANILLA),'') + 
		                                            Isnull(Convert(Varchar,DRDD.hora_trx),'') + 
		                                            Isnull(Convert(Varchar,DRDD.NUM_REFERENCIA),'') + 
		                                            Isnull(Convert(Varchar,DRDD.NUMERO_DOCUMENTO),'') + 
		                                            Isnull(Convert(Varchar,DRDD.TRX_COMPLEM),'') + 
		                                            Isnull(Convert(Varchar,DRDD.numero_asiento_contable),'')  KeyOri,'' KeyRev
													 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta DRDD
													 WHERE DRDD.ANIOMES = @anioMes
												),
													 TB_Y AS
											  (		 SELECT DRDDT.Numero_transaccion,
													'' KeyOri,
													Isnull(Convert(Varchar,DRDDT.AnioMes),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Codigo_Agencia),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Numero_transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.codigo_cliente),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.TIP_MOV),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.MONTO_EN_GTQ),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.TIP_TRANSACCION),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.SUBTIP_TRANSAC),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.numero_cuenta),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.numero_tarjeta),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.cod_sistema),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Estado),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Usuario_registro),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Registro),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Usuario_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Justificacion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movexacto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Trxexacto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Trxmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Trxotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Nomotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.MONTO_mixtoparalelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movmxto58_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.MONTO_movmxto58),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movmxto59_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.MONTO_movmxto59),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.cajero),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.ID_CLTE_VENTANILLA),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.hora_trx),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.NUM_REFERENCIA),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.NUMERO_DOCUMENTO),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.TRX_COMPLEM),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.numero_asiento_contable),'')  KeyRev
													 FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta_tmp DRDDT
													  WHERE DRDDT.ANIOMES = @anioMes
											),
											TB_CHANGE AS (
											SELECT 'ORIGEN' TP,DRDD2.*
											   FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta DRDD2
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
											  FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta_tmp DRDDT2
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
															Isnull(Convert(Varchar,CB.Codigo_Agencia),'') +
															Isnull(Convert(Varchar,CB.Fecha_Transaccion),'') +
															Isnull(Convert(Varchar,CB.codigo_cliente),'') +
															Isnull(Convert(Varchar,CB.Numero_transaccion),'') +
															Isnull(Convert(Varchar,CB.Tipo_Transaccion),'') +
															Isnull(Convert(Varchar,CB.cajero),'') kEYjUST,CB.JUSTIFICACION JUSTIFICACION_NEW,' ' JUSTIFICACION_ORIGEN
														FROM TB_CHANGE_BIS CB
														WHERE CB.TP = 'NEW'
														UNION
														SELECT CB.Numero_transaccion,
															Isnull(Convert(Varchar,CB.Codigo_Agencia),'') +
															Isnull(Convert(Varchar,CB.Fecha_Transaccion),'') +
															Isnull(Convert(Varchar,CB.codigo_cliente),'') +
															Isnull(Convert(Varchar,CB.Numero_transaccion),'') +
															Isnull(Convert(Varchar,CB.Tipo_Transaccion),'') +
															Isnull(Convert(Varchar,CB.cajero),'') kEYjUST,
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

        public bool InsertarDetalleEf14TmpBulk(DataTable dataTable)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_ef14_deta_tmp";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("Codigo_Agencia", "Codigo_Agencia");
                        bulkCopy.ColumnMappings.Add("Fecha_Transaccion", "Fecha_Transaccion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("TIP_MOV", "TIP_MOV");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_GTQ", "MONTO_EN_GTQ");
                        bulkCopy.ColumnMappings.Add("TIP_TRANSACCION", "TIP_TRANSACCION");
                        bulkCopy.ColumnMappings.Add("SUBTIP_TRANSAC", "SUBTIP_TRANSAC");
                        bulkCopy.ColumnMappings.Add("numero_cuenta", "numero_cuenta");
                        bulkCopy.ColumnMappings.Add("numero_tarjeta", "numero_tarjeta");
                        bulkCopy.ColumnMappings.Add("cod_sistema", "cod_sistema");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("movexacto_paralelo", "movexacto_paralelo");
                        bulkCopy.ColumnMappings.Add("Trxexacto_paralelo", "Trxexacto_paralelo");
                        bulkCopy.ColumnMappings.Add("movmixto_paralelo", "movmixto_paralelo");
                        bulkCopy.ColumnMappings.Add("Trxmixto_paralelo", "Trxmixto_paralelo");
                        bulkCopy.ColumnMappings.Add("movotrocli_paralelo", "movotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("Trxotrocli_paralelo", "Trxotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("Nomotrocli_paralelo", "Nomotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("MONTO_mixtoparalelo", "MONTO_mixtoparalelo");
                        bulkCopy.ColumnMappings.Add("movmxto58_boveda", "movmxto58_boveda");
                        bulkCopy.ColumnMappings.Add("MONTO_movmxto58", "MONTO_movmxto58");
                        bulkCopy.ColumnMappings.Add("movmxto59_boveda", "movmxto59_boveda");
                        bulkCopy.ColumnMappings.Add("MONTO_movmxto59", "MONTO_movmxto59");
                        bulkCopy.ColumnMappings.Add("cajero", "cajero");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("ID_CLTE_VENTANILLA", "ID_CLTE_VENTANILLA");
                        bulkCopy.ColumnMappings.Add("hora_trx", "hora_trx");
                        bulkCopy.ColumnMappings.Add("NUM_REFERENCIA", "NUM_REFERENCIA");
                        bulkCopy.ColumnMappings.Add("NUMERO_DOCUMENTO", "NUMERO_DOCUMENTO");
                        bulkCopy.ColumnMappings.Add("TRX_COMPLEM", "TRX_COMPLEM");
                        bulkCopy.ColumnMappings.Add("numero_asiento_contable", "numero_asiento_contable");

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
            "AnioMes", "Fecha_Transaccion", "Fecha_Nacimiento_Constitucion",
            "Fecha_Registro", "Fecha_Modifico", "Numero_transaccion", "hora_trx"
            };

            string[] columnasFloat = new string[]
            {
            "Monto_Moneda_Orginal", "Monto_Dolares", "MONTO_mixtoparalelo"
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
