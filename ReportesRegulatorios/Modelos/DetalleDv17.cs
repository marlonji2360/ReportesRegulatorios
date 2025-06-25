using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleDv17
    {
         

        public DetalleDv17()
        {

        }

        public DataTable ObtenerDetalleCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM DL_CUMPLIMIENTO.rrdv17_detalle WHERE AnioMes = @AnioMes";

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

        public bool InsertarDetalleDv17Bulk(DataTable dataTable)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.rrdv17_detalle";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("Fecha_Transaccion", "Fecha_Transaccion");
                        bulkCopy.ColumnMappings.Add("Tipo_Transaccion", "Tipo_Transaccion");
                        bulkCopy.ColumnMappings.Add("TIPO_PERSONA", "TIPO_PERSONA");
                        bulkCopy.ColumnMappings.Add("Tipo_Identificacion_persona", "Tipo_Identificacion_persona");
                        bulkCopy.ColumnMappings.Add("No_Orden_Cedula", "No_Orden_Cedula");
                        bulkCopy.ColumnMappings.Add("Numero_Identificacion_persona", "Numero_Identificacion_persona");
                        bulkCopy.ColumnMappings.Add("Municipio_emision_Cedula", "Municipio_emision_Cedula");
                        bulkCopy.ColumnMappings.Add("Primer_Apellido", "Primer_Apellido");
                        bulkCopy.ColumnMappings.Add("Segundo_Apellido", "Segundo_Apellido");
                        bulkCopy.ColumnMappings.Add("Apellido_Casada", "Apellido_Casada");
                        bulkCopy.ColumnMappings.Add("Primer_Nombre", "Primer_Nombre");
                        bulkCopy.ColumnMappings.Add("Segundo_Nombre", "Segundo_Nombre");
                        bulkCopy.ColumnMappings.Add("Nombre_Persona_Juridica", "Nombre_Persona_Juridica");
                        bulkCopy.ColumnMappings.Add("Fecha_Nacimiento_Constitucion", "Fecha_Nacimiento_Constitucion");
                        bulkCopy.ColumnMappings.Add("Pais_Nacionalidad_Constitucion", "Pais_Nacionalidad_Constitucion");
                        bulkCopy.ColumnMappings.Add("Actividad_Economica_Persona", "Actividad_Economica_Persona");
                        bulkCopy.ColumnMappings.Add("Direccion", "Direccion");
                        bulkCopy.ColumnMappings.Add("Zona", "Zona");
                        bulkCopy.ColumnMappings.Add("Departamento", "Departamento");
                        bulkCopy.ColumnMappings.Add("Municipio", "Municipio");
                        bulkCopy.ColumnMappings.Add("Origen_Fondos", "Origen_Fondos");
                        bulkCopy.ColumnMappings.Add("Tipo_Moneda", "Tipo_Moneda");
                        bulkCopy.ColumnMappings.Add("Monto_Moneda_Orginal", "Monto_Moneda_Orginal");
                        bulkCopy.ColumnMappings.Add("Monto_Dolares", "Monto_Dolares");
                        bulkCopy.ColumnMappings.Add("Codigo_Agencia", "Codigo_Agencia");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente", "codigo_cliente");
                        bulkCopy.ColumnMappings.Add("mov58_boveda", "mov58_boveda");
                        bulkCopy.ColumnMappings.Add("mov59_boveda", "mov59_boveda");
                        bulkCopy.ColumnMappings.Add("mov53TC_boveda", "mov53TC_boveda");
                        bulkCopy.ColumnMappings.Add("mon53TC_boveda", "mon53TC_boveda");
                        bulkCopy.ColumnMappings.Add("movmixto_paralelo", "movmixto_paralelo");
                        bulkCopy.ColumnMappings.Add("Trxmixto_paralelo", "Trxmixto_paralelo");
                        bulkCopy.ColumnMappings.Add("MONTO_mixtoparalelo", "MONTO_mixtoparalelo");
                        bulkCopy.ColumnMappings.Add("movotrocli_paralelo", "movotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("Trxotrocli_paralelo", "Trxotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("Nomotrocli_paralelo", "Nomotrocli_paralelo");
                        bulkCopy.ColumnMappings.Add("hora_trx", "hora_trx");
                        bulkCopy.ColumnMappings.Add("cajero", "cajero");

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

        public bool InsertarDetalleDv17(DataTable dataTable)
        {
            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("DL_CUMPLIMIENTO.PRC_Insertar_DV17", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Agrega todos los parámetros (ejemplo con algunos)
                            cmd.Parameters.AddWithValue("@AnioMes", row["AnioMes"]);
                            cmd.Parameters.AddWithValue("@Fecha_Transaccion", row["Fecha_Transaccion"]);
                            cmd.Parameters.AddWithValue("@Tipo_Transaccion", row["Tipo_Transaccion"]);
                            cmd.Parameters.AddWithValue("@TIPO_PERSONA", row["TIPO_PERSONA"]);
                            cmd.Parameters.AddWithValue("@Tipo_Identificacion_persona", row["Tipo_Identificacion_persona"]);
                            cmd.Parameters.AddWithValue("@No_Orden_Cedula", row["No_Orden_Cedula"]);
                            cmd.Parameters.AddWithValue("@Numero_Identificacion_persona", row["Numero_Identificacion_persona"]);
                            cmd.Parameters.AddWithValue("@Municipio_emision_Cedula", row["Municipio_emision_Cedula"]);
                            cmd.Parameters.AddWithValue("@Primer_Apellido", row["Primer_Apellido"]);
                            cmd.Parameters.AddWithValue("@Segundo_Apellido", row["Segundo_Apellido"]);
                            cmd.Parameters.AddWithValue("@Apellido_Casada", row["Apellido_Casada"]);
                            cmd.Parameters.AddWithValue("@Primer_Nombre", row["Primer_Nombre"]);
                            cmd.Parameters.AddWithValue("@Segundo_Nombre", row["Segundo_Nombre"]);
                            cmd.Parameters.AddWithValue("@Nombre_Persona_Juridica", row["Nombre_Persona_Juridica"]);
                            cmd.Parameters.AddWithValue("@Fecha_Nacimiento_Constitucion", row["Fecha_Nacimiento_Constitucion"]);
                            cmd.Parameters.AddWithValue("@Pais_Nacionalidad_Constitucion", row["Pais_Nacionalidad_Constitucion"]);
                            cmd.Parameters.AddWithValue("@Actividad_Economica_Persona", row["Actividad_Economica_Persona"]);
                            cmd.Parameters.AddWithValue("@Direccion", row["Direccion"]);
                            cmd.Parameters.AddWithValue("@Zona", row["Zona"]);
                            cmd.Parameters.AddWithValue("@Departamento", row["Departamento"]);
                            cmd.Parameters.AddWithValue("@Municipio", row["Municipio"]);
                            cmd.Parameters.AddWithValue("@Origen_Fondos", row["Origen_Fondos"]);
                            cmd.Parameters.AddWithValue("@Tipo_Moneda", row["Tipo_Moneda"]);
                            cmd.Parameters.AddWithValue("@Monto_Moneda_Orginal", row["Monto_Moneda_Orginal"]);
                            cmd.Parameters.AddWithValue("@Monto_Dolares", row["Monto_Dolares"]);
                            cmd.Parameters.AddWithValue("@Codigo_Agencia", row["Codigo_Agencia"]);
                            cmd.Parameters.AddWithValue("@Estado", row["Estado"]);
                            cmd.Parameters.AddWithValue("@Usuario_registro", row["Usuario_registro"]);
                            cmd.Parameters.AddWithValue("@Fecha_Registro", row["Fecha_Registro"]);
                            cmd.Parameters.AddWithValue("@Usuario_Modifico", row["Usuario_Modifico"]);
                            cmd.Parameters.AddWithValue("@Fecha_Modifico", row["Fecha_Modifico"]);
                            cmd.Parameters.AddWithValue("@Justificacion", row["Justificacion"]);
                            cmd.Parameters.AddWithValue("@Numero_transaccion", row["Numero_transaccion"]);
                            cmd.Parameters.AddWithValue("@codigo_cliente", row["codigo_cliente"]);
                            cmd.Parameters.AddWithValue("@mov58_boveda", row["mov58_boveda"]);
                            cmd.Parameters.AddWithValue("@mov59_boveda", row["mov59_boveda"]);
                            cmd.Parameters.AddWithValue("@mov53TC_boveda", row["mov53TC_boveda"]);
                            cmd.Parameters.AddWithValue("@mon53TC_boveda", row["mon53TC_boveda"]);
                            cmd.Parameters.AddWithValue("@movmixto_paralelo", row["movmixto_paralelo"]);
                            cmd.Parameters.AddWithValue("@Trxmixto_paralelo", row["Trxmixto_paralelo"]);
                            cmd.Parameters.AddWithValue("@MONTO_mixtoparalelo", row["MONTO_mixtoparalelo"]);
                            cmd.Parameters.AddWithValue("@movotrocli_paralelo", row["movotrocli_paralelo"]);
                            cmd.Parameters.AddWithValue("@Trxotrocli_paralelo", row["Trxotrocli_paralelo"]);
                            cmd.Parameters.AddWithValue("@Nomotrocli_paralelo", row["Nomotrocli_paralelo"]);
                            cmd.Parameters.AddWithValue("@hora_trx", row["hora_trx"]);
                            cmd.Parameters.AddWithValue("@cajero", row["cajero"]);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar datos: " + ex.Message);
                return false;
            }
        }

    }
}
