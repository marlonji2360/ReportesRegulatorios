using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Modelos
{
    public class DetalleRte
    {
        public DataTable ObtenerDetalleCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT  AnioMes, 
                                        Fecha_transaccion, 
                                        Numero_cuenta, 
                                        Caracteristica_transaccion, 
                                        Tipo_cuenta, 
                                        Tipo_transaccion, 
                                        Tipo_moneda, 
                                        Monto_tmoneda_original,
                                        Monto_dolares,
                                        Municipio_trx, 
                                        Codigo_agencia, 
                                        Procedencia_fondos, 
                                        Finalidad_transaccion, 
                                        Tit_Tipo_cliente, 
                                        Tit_Razon_social,
                                        Tit_Primer_apellido, 
                                        Tit_Segundo_apellido, 
                                        Tit_Apellido_casada, 
                                        Tit_Primer_nombre, 
                                        Tit_Segundo_nombre, 
                                        Tit_Origen_persona, 
                                        Tit_Tipo_identificacion, 
                                        Tit_Otro_tipo_identificacion,
                                        Tit_Numero_identificacion, 
                                        Ctrx_Primer_apellido, 
                                        Ctrx_Segundo_aplellido, 
                                        Ctrx_Apellido_casada, 
                                        Ctrx_Primer_nombre, 
                                        Ctrx_Segundo_nombre, 
                                        Ctrx_Tipo_identificacion, 
                                        Ctrx_Numero_identificacion, 
                                        Ctrx_Nacionalidad, 
                                        No_trx, 
                                        codigo_cliente, 
                                        Estado, 
                                        Usuario_registro, 
                                        Fecha_Registro, 
                                        Usuario_Modifico, 
                                        Fecha_Modifico, 
                                        Justificacion
                                FROM    EDW.DL_CUMPLIMIENTO.dw_repreg_rte_deta
                                WHERE   AnioMes = @AnioMes";

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
            string consulta = @"SELECT
                                        LEFT(CONVERT(CHAR(8), Fecha_transaccion, 112) + REPLICATE(' ', 8), 8)  + '&&' +
                                        LEFT(ISNULL(Numero_cuenta, '') + REPLICATE(' ', 28), 28)   + '&&' +
                                        LEFT(ISNULL(Caracteristica_transaccion, '') + REPLICATE(' ', 2), 2)   + '&&' +
                                        LEFT(ISNULL(Tipo_cuenta, '') + REPLICATE(' ', 2), 2)   + '&&' +
                                        LEFT(ISNULL(Tipo_transaccion, '') + REPLICATE(' ', 3), 3)   + '&&' +
                                        LEFT(ISNULL(Tipo_moneda, '') + REPLICATE(' ', 3), 3)   + '&&' +
                                        LEFT(CAST(CAST(Monto_tmoneda_original AS DECIMAL(38,0)) AS VARCHAR(14)) + REPLICATE(' ', 14), 14)  + '&&' +
                                        LEFT(CAST(CAST(Monto_dolares AS DECIMAL(38,0)) AS VARCHAR(14)) + REPLICATE(' ', 14), 14)  + '&&' +
                                        LEFT(ISNULL(Municipio_trx, '') + REPLICATE(' ', 4), 4)   + '&&' +
                                        LEFT(ISNULL(Codigo_agencia, '') + REPLICATE(' ', 10), 10)   + '&&' +
                                        LEFT(ISNULL(Procedencia_fondos, '') + REPLICATE(' ', 150), 150)   + '&&' +
                                        LEFT(ISNULL(Finalidad_transaccion, '') + REPLICATE(' ', 150), 150)   + '&&' +
                                        LEFT(ISNULL(Tit_Tipo_cliente, '') + REPLICATE(' ', 1), 1)   + '&&' +
                                        LEFT(ISNULL(Tit_Razon_social, '') + REPLICATE(' ', 90), 90)   + '&&' +
                                        LEFT(ISNULL(Tit_Primer_apellido, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Tit_Segundo_apellido, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Tit_Apellido_casada, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Tit_Primer_nombre, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Tit_Segundo_nombre, '') + REPLICATE(' ', 30), 30)   + '&&' +
                                        LEFT(ISNULL(Tit_Origen_persona, '') + REPLICATE(' ', 1), 1)   + '&&' +
                                        LEFT(ISNULL(Tit_Tipo_identificacion, '') + REPLICATE(' ', 1), 1)   + '&&' +
                                        LEFT(ISNULL(Tit_Otro_tipo_identificacion, '') + REPLICATE(' ', 100), 100)   + '&&' +
                                        LEFT(ISNULL(Tit_Numero_identificacion, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Primer_apellido, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Segundo_aplellido, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Apellido_casada, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Primer_nombre, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Segundo_nombre, '') + REPLICATE(' ', 30), 30)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Tipo_identificacion, '') + REPLICATE(' ', 1), 1)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Numero_identificacion, '') + REPLICATE(' ', 15), 15)   + '&&' +
                                        LEFT(ISNULL(Ctrx_Nacionalidad, '') + REPLICATE(' ', 15), 15)   + '&&'
                                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_rte_deta
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

        public bool InsertarDetalleBa12Bulk(DataTable dataTable)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_rte_deta";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("Fecha_transaccion", "Fecha_transaccion");
                        bulkCopy.ColumnMappings.Add("Numero_cuenta", "Numero_cuenta");
                        bulkCopy.ColumnMappings.Add("Caracteristica_transaccion", "Caracteristica_transaccion");
                        bulkCopy.ColumnMappings.Add("Tipo_cuenta", "Tipo_cuenta");
                        bulkCopy.ColumnMappings.Add("Tipo_transaccion", "Tipo_transaccion");
                        bulkCopy.ColumnMappings.Add("Tipo_moneda", "Tipo_moneda");
                        bulkCopy.ColumnMappings.Add("Monto_tmoneda_original", "Monto_tmoneda_original");
                        bulkCopy.ColumnMappings.Add("Monto_dolares", "Monto_dolares");
                        bulkCopy.ColumnMappings.Add("Municipio_trx", "Municipio_trx");
                        bulkCopy.ColumnMappings.Add("Codigo_agencia", "Codigo_agencia");
                        bulkCopy.ColumnMappings.Add("Procedencia_fondos", "Procedencia_fondos");
                        bulkCopy.ColumnMappings.Add("Finalidad_transaccion", "Finalidad_transaccion");
                        bulkCopy.ColumnMappings.Add("Tit_Tipo_cliente", "Tit_Tipo_cliente");
                        bulkCopy.ColumnMappings.Add("Tit_Razon_social", "Tit_Razon_social");
                        bulkCopy.ColumnMappings.Add("Tit_Primer_apellido", "Tit_Primer_apellido");
                        bulkCopy.ColumnMappings.Add("Tit_Segundo_apellido", "Tit_Segundo_apellido");
                        bulkCopy.ColumnMappings.Add("Tit_Apellido_casada", "Tit_Apellido_casada");
                        bulkCopy.ColumnMappings.Add("Tit_Primer_nombre", "Tit_Primer_nombre");
                        bulkCopy.ColumnMappings.Add("Tit_Segundo_nombre", "Tit_Segundo_nombre");
                        bulkCopy.ColumnMappings.Add("Tit_Origen_persona", "Tit_Origen_persona");
                        bulkCopy.ColumnMappings.Add("Tit_Tipo_identificacion", "Tit_Tipo_identificacion");
                        bulkCopy.ColumnMappings.Add("Tit_Otro_tipo_identificacion", "Tit_Otro_tipo_identificacion");
                        bulkCopy.ColumnMappings.Add("Tit_Numero_identificacion", "Tit_Numero_identificacion");
                        bulkCopy.ColumnMappings.Add("Ctrx_Primer_apellido", "Ctrx_Primer_apellido");
                        bulkCopy.ColumnMappings.Add("Ctrx_Segundo_aplellido", "Ctrx_Segundo_aplellido");
                        bulkCopy.ColumnMappings.Add("Ctrx_Apellido_casada", "Ctrx_Apellido_casada");
                        bulkCopy.ColumnMappings.Add("Ctrx_Primer_nombre", "Ctrx_Primer_nombre");
                        bulkCopy.ColumnMappings.Add("Ctrx_Segundo_nombre", "Ctrx_Segundo_nombre");
                        bulkCopy.ColumnMappings.Add("Ctrx_Tipo_identificacion", "Ctrx_Tipo_identificacion");
                        bulkCopy.ColumnMappings.Add("Ctrx_Numero_identificacion", "Ctrx_Numero_identificacion");
                        bulkCopy.ColumnMappings.Add("Ctrx_Nacionalidad", "Ctrx_Nacionalidad");
                        bulkCopy.ColumnMappings.Add("No_trx", "No_trx");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");


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
                "AnioMes", "Fecha_transaccion", "Fecha_Registro", "Fecha_Modifico"
            };

            string[] columnasFloat = new string[]
            {
            "Monto_tmoneda_original", "Monto_dolares"
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
