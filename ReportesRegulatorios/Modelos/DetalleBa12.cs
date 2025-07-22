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
            string consulta = @"SELECT LEFT(CONVERT(CHAR(8), FECHA, 112) + REPLICATE(' ', 8), 8)  +
                                        LEFT(ISNULL(NOCHEQUE, '') + REPLICATE(' ', 15), 15)   +
                                        LEFT(ISNULL(BTIPOPERSONA, '') + REPLICATE(' ', 1), 1)   +
                                        CASE When BTIPOPERSONA = 'J' Then
                                                  LEFT(ISNULL(BNombreJuridico, '') + REPLICATE(' ', 75), 75)   
                                             When BTIPOPERSONA != 'J' Then
                                                  LEFT(ISNULL(BPrimerApellido, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(BSegundoApellido, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(BApellidoCasada, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(BPrimerNombre, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(BSegundoNombre, '') + REPLICATE(' ', 15), 15)   
                                        END +
                                        LEFT(ISNULL(CTipoPersona, '') + REPLICATE(' ', 1), 1)   +
                                        LEFT(ISNULL(CTp_Identificacion, '') + REPLICATE(' ', 1), 1)   +
                                        LEFT(ISNULL(CNoOrdenCedula, '') + REPLICATE(' ', 3), 3)   +
                                        LEFT(ISNULL(CDPI, '') + REPLICATE(' ', 20), 20)   +
                                        CASE When CTipoPersona = 'J' Then
                                                  LEFT(ISNULL(CNombreJuridico, '') + REPLICATE(' ', 75), 75)   
                                             When CTipoPersona != 'J' Then     
                                                  LEFT(ISNULL(CPrimerApellido, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(CSegundoApellido, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(CApellidoCasada, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(CPrimerNombre, '') + REPLICATE(' ', 15), 15)   +
                                                  LEFT(ISNULL(CSegundoNombre, '') + REPLICATE(' ', 15), 15)   
                                        END +
                                        LEFT(ISNULL(TipoMoneda, '') + REPLICATE(' ', 3), 3)   +
                                        RIGHT(REPLICATE('0', 14) + ISNULL(CAST(MontoMonedaOriginal AS VARCHAR), ''), 14)    +
                                        RIGHT(REPLICATE('0', 14) + ISNULL(CAST(MontoDolares AS VARCHAR), ''), 14)    +
                                        LEFT(ISNULL(MedioPagoUtilizado, '') + REPLICATE(' ', 1), 1)   +
                                        LEFT(ISNULL(MedioPago, '') + REPLICATE(' ', 500), 500)
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
