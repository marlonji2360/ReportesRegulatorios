using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleEf14
    {
        public DetalleEf14()
        {

        }

        public DataTable ObtenerDetalleCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT [AnioMes]
                                      ,[Codigo_Agencia]
                                      ,[Fecha_Transaccion]
                                      ,[Numero_transaccion]
                                      ,[codigo_cliente]
                                      ,[TIP_MOV]
                                      ,[MONTO_EN_GTQ]
                                      ,[TIP_TRANSACCION]
                                      ,[SUBTIP_TRANSAC]
                                      ,[numero_cuenta]
                                      ,[numero_tarjeta]
                                      ,[cod_sistema]
                                      ,[Estado]
                                      ,[Usuario_registro]
                                      ,[Fecha_Registro]
                                      ,[Usuario_Modifico]
                                      ,[Fecha_Modifico]
                                      ,[Justificacion]
                                      ,[movexacto_paralelo]
                                      ,[Trxexacto_paralelo]
                                      ,[movmixto_paralelo]
                                      ,[Trxmixto_paralelo]
                                      ,[movotrocli_paralelo]
                                      ,[Trxotrocli_paralelo]
                                      ,[Nomotrocli_paralelo]
                                      ,[MONTO_mixtoparalelo]
                                      ,[movmxto58_boveda]
                                      ,[MONTO_movmxto58]
                                      ,[movmxto59_boveda]
                                      ,[MONTO_movmxto59]
                                      ,[cajero]
                                      ,[ID_CLTE_VENTANILLA]
                                      ,[hora_trx]
                                      ,[NUM_REFERENCIA]
                                      ,[NUMERO_DOCUMENTO]
                                      ,[TRX_COMPLEM]
                                      ,[numero_asiento_contable]
                                  FROM [DL_CUMPLIMIENTO].[dw_repreg_ef14_deta]
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

        public DataTable ObtenerDetalleTxt(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT  LEFT(CONVERT(CHAR(8), Fecha_Transaccion, 112) + REPLICATE(' ', 8), 8)  + '&&' +
                                        LEFT(ISNULL(Tipo_Transaccion, '') + REPLICATE(' ', 3), 3)   + '&&' +
                                        LEFT(ISNULL(TIPO_PERSONA, '') + ' ', 1)    + '&&' +
                                        LEFT(ISNULL(Tipo_Identificacion_persona, '') + ' ', 1)    + '&&' +
                                        LEFT(ISNULL(No_Orden_Cedula, '') + REPLICATE(' ', 3), 3)    + '&&' +
                                        LEFT(ISNULL(Numero_Identificacion_persona, '') + REPLICATE(' ', 20), 20)    + '&&' +
                                        LEFT(ISNULL(Municipio_emision_Cedula, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Primer_Apellido, '') + REPLICATE(' ', 15), 15)    + '&&' +
                                        LEFT(ISNULL(Segundo_Apellido, '') + REPLICATE(' ', 15), 15)    + '&&' +
                                        LEFT(ISNULL(Apellido_Casada, '') + REPLICATE(' ', 15), 15)    + '&&' +
                                        LEFT(ISNULL(Primer_Nombre, '') + REPLICATE(' ', 15), 15)    + '&&' +
                                        LEFT(ISNULL(Segundo_Nombre, '') + REPLICATE(' ', 30), 30)    + '&&' +
                                        LEFT(ISNULL(Nombre_Persona_Juridica, '') + REPLICATE(' ', 150), 150)    + '&&' +
                                        LEFT(CONVERT(CHAR(8), Fecha_Nacimiento_Constitucion, 112) + REPLICATE(' ', 8), 8)    + '&&' +
                                        LEFT(ISNULL(Pais_Nacionalidad_Constitucion, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Actividad_Economica_Persona, '') + REPLICATE(' ', 3), 3)    + '&&' +
                                        LEFT(ISNULL(Direccion, '') + REPLICATE(' ', 150), 150)    + '&&' +
                                        LEFT(ISNULL(Zona, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Departamento, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Municipio, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Origen_Fondos, '') + REPLICATE(' ', 2), 2)    + '&&' +
                                        LEFT(ISNULL(Tipo_Moneda, '') + REPLICATE(' ', 3), 3)    + '&&' +
                                        RIGHT(REPLICATE('0', 14) + ISNULL(CAST(Monto_Moneda_Orginal AS VARCHAR), ''), 14)    + '&&' +
                                        RIGHT(REPLICATE('0', 14) + ISNULL(CAST(Monto_Dolares AS VARCHAR), ''), 14)    + '&&' +
                                        LEFT(ISNULL(Codigo_Agencia, '') + REPLICATE(' ', 10), 10)    + '&&'
                                        Trama
                                      FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ef14_deta
                                      WHERE Estado  = 'P' and Aniomes = @anioMes";

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

        public bool InsertarDetalleEf14Bulk(DataTable dataTable)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_ef14_deta";

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
