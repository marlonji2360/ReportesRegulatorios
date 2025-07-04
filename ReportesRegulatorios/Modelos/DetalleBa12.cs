using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleBa12
    {
        public DetalleBa12() { }

        public DataTable ObtenerDetalleCsv(int anioMes)
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
                                    FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta
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
                                      FROM EDW.DL_CUMPLIMIENTO.dw_repreg_ba12_deta
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_ba12_deta";

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
