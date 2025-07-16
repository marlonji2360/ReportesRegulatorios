using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleMe13Bit
    {
        public void LimpiarDataTable(DataTable dataTable)
        {
            string[] columnasInt = new string[]
            {
            "AnioMes", "Fecha_Transaccion", "Numero_transaccion",
            "NUM_REFERENCIA", "Fecha_Registro", "Fecha_Modifico",  "hora_trx"
            };

            string[] columnasFloat = new string[]
            {
            "MONTO_MONEDA_ORIGEN", "MONTO_EN_DOLARES", "MONTO_mixtoparalelo" ,"MONTO_movmxto58", "MONTO_movmxto59"
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

        public bool InsertarDetalleMe13BitBulk(DataTable dataTable, string usuario)
        {
            try
            {
                //Agregamos columas para empatarla con la bitacora
                dataTable.Columns.Add("usuario", typeof(string));
                dataTable.Columns.Add("fecha_hora", typeof(DateTime));
                dataTable.Columns.Add("tipo", typeof(string));

                //Colocamos valores a todas las filas
                foreach (DataRow row in dataTable.Rows)
                {
                    row["usuario"] = usuario;
                    row["fecha_hora"] = DateTime.Now;
                    row["tipo"] = "NUEVO";
                }

                // Limpiar datos antes de insertar
                LimpiarDataTable(dataTable);

                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_me13_deta_bit";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("Codigo_Agencia", "Codigo_Agencia");
                        bulkCopy.ColumnMappings.Add("Fecha_Transaccion", "Fecha_Transaccion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("TRANS", "TRANS");
                        bulkCopy.ColumnMappings.Add("MONEDA", "MONEDA");
                        bulkCopy.ColumnMappings.Add("MONTO_MONEDA_ORIGEN", "MONTO_MONEDA_ORIGEN");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_DOLARES", "MONTO_EN_DOLARES");
                        bulkCopy.ColumnMappings.Add("NUM_REFERENCIA", "NUM_REFERENCIA");
                        bulkCopy.ColumnMappings.Add("TIP_TRANSACCION", "TIP_TRANSACCION");
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
                        bulkCopy.ColumnMappings.Add("hora_trx", "hora_trx");
                        bulkCopy.ColumnMappings.Add("cajero", "cajero");
                        bulkCopy.ColumnMappings.Add("usuario", "usuario");
                        bulkCopy.ColumnMappings.Add("fecha_hora", "fecha_hora");
                        bulkCopy.ColumnMappings.Add("tipo", "tipo");

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

        public bool InsertarDetalleMe13VerBitBulk(DataTable dataTable, string usuario)
        {
            try
            {
                //Agregamos columas para empatarla con la bitacora
                dataTable.Columns.Add("usuario", typeof(string));
                dataTable.Columns.Add("fecha_hora", typeof(DateTime));


                //Colocamos valores a todas las filas
                foreach (DataRow row in dataTable.Rows)
                {
                    row["usuario"] = usuario;
                    row["fecha_hora"] = DateTime.Now;

                }

                // Limpiar datos antes de insertar
                LimpiarDataTable(dataTable);

                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                    {
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_me13_deta_bit";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("Codigo_Agencia", "Codigo_Agencia");
                        bulkCopy.ColumnMappings.Add("Fecha_Transaccion", "Fecha_Transaccion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("TRANS", "TRANS");
                        bulkCopy.ColumnMappings.Add("MONEDA", "MONEDA");
                        bulkCopy.ColumnMappings.Add("MONTO_MONEDA_ORIGEN", "MONTO_MONEDA_ORIGEN");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_DOLARES", "MONTO_EN_DOLARES");
                        bulkCopy.ColumnMappings.Add("NUM_REFERENCIA", "NUM_REFERENCIA");
                        bulkCopy.ColumnMappings.Add("TIP_TRANSACCION", "TIP_TRANSACCION");
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
                        bulkCopy.ColumnMappings.Add("hora_trx", "hora_trx");
                        bulkCopy.ColumnMappings.Add("cajero", "cajero");
                        bulkCopy.ColumnMappings.Add("usuario", "usuario");
                        bulkCopy.ColumnMappings.Add("fecha_hora", "fecha_hora");
                        bulkCopy.ColumnMappings.Add("TP", "tipo");

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

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT * FROM DL_CUMPLIMIENTO.dw_repreg_me13_deta_bit WHERE AnioMes = @AnioMes and tipo = 'NUEVO'";

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

        public bool EliminarCamposDetalle(int anioMes)
        {
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta 
                                WHERE Numero_transaccion IN ( 
                                                                SELECT rdb.Numero_transaccion 
                                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta_bit rdb 
                                                                WHERE rdb.tipo = 'ORIGINAL' AND rdb.AnioMes = @anioMes
                                                            )";

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

        public DataTable ObtenerDetalleBit(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT      AnioMes
                                          ,Codigo_Agencia
                                          ,Fecha_Transaccion
                                          ,Numero_transaccion
                                          ,codigo_cliente
                                          ,TRANS
                                          ,MONEDA
                                          ,MONTO_MONEDA_ORIGEN
                                          ,MONTO_EN_DOLARES
                                          ,NUM_REFERENCIA
                                          ,TIP_TRANSACCION
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
                                          ,hora_trx
                                          ,cajero
                                        usuario,
                                        fecha_hora,
                                        tipo
                                    FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta_bit
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

        public DataTable ObtenerCambiosBit(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"WITH TB_X AS (
		                                            SELECT DRDD.Numero_transaccion,
                                                    Isnull(Convert(Varchar,DRDD.Codigo_Agencia),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Numero_transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.codigo_cliente),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TRANS),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MONEDA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MONTO_MONEDA_ORIGEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MONTO_EN_DOLARES),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUM_REFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIP_TRANSACCION),'') + 
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
                                                    Isnull(Convert(Varchar,DRDD.hora_trx),'') + 
                                                    Isnull(Convert(Varchar,DRDD.cajero),'')  KeyOri,'' KeyRev
                                                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta DRDD WHERE DRDD.anioMes=@anioMes
	                                            ),
		                                                TB_Y AS 
                                                (		 SELECT DRDDT.Numero_transaccion,
                                                    Isnull(Convert(Varchar,DRDDT.Codigo_Agencia),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Fecha_Transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Numero_transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.codigo_cliente),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TRANS),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MONEDA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MONTO_MONEDA_ORIGEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MONTO_EN_DOLARES),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.NUM_REFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIP_TRANSACCION),'') + 
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
                                                    Isnull(Convert(Varchar,DRDDT.hora_trx),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.cajero),'')  KeyRev
		                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta_tmp DRDDT WHERE DRDDT.anioMes=@anioMes
                                                ),
                                                TB_CHANGE AS (
                                                SELECT 'ORIGINAL' TP,DRDD2.*
                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta DRDD2
                                                WHERE DRDD2.anioMes=@anioMes AND DRDD2.Numero_transaccion NOT IN (
										                                                SELECT RR.Numero_transaccion
												                                                FROM (
														                                                SELECT TB_X.numero_transaccion, TB_X.KeyOri,TB_Y.KeyRev 
														                                                FROM TB_X,
														                                                    TB_Y
														                                                WHERE TB_X.KeyOri = TB_Y.KeyRev 
												 		                                            ) RR
									                                                    )
			                                                )
                                            SELECT *
                                                FROM TB_CHANGE
                                            UNION
                                                SELECT 'NUEVO' TP,DRDDT2.*
                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta_tmp DRDDT2
                                                WHERE DRDDT2.anioMes=@anioMes AND DRDDT2.NUMERO_TRANSACCION IN (SELECT C2.Numero_transaccion  FROM TB_CHANGE C2)";
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
    }
}

