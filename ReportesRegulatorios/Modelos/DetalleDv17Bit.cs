using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleDv17Bit
    {
        public Boolean InsertarDetalleVeriDv17Bit(DataTable dataTable, string usuario)
        {
            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                       
                        using (SqlCommand cmd = new SqlCommand("DL_CUMPLIMIENTO.PRC_Insertar_DV17_bit", conn))
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
                            cmd.Parameters.AddWithValue("@usuario", usuario);
                            cmd.Parameters.AddWithValue("@tipo", row["TP"]);

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

        public Boolean InsertarDetalleNuevoDv17Bit(DataTable dataTable, string usuario)
        {
            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                    foreach (DataRow row in dataTable.Rows)
                    {

                        using (SqlCommand cmd = new SqlCommand("DL_CUMPLIMIENTO.PRC_Insertar_DV17_bit", conn))
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
                            cmd.Parameters.AddWithValue("@usuario", usuario);
                            cmd.Parameters.AddWithValue("@tipo", "NUEVO");

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

        public DataTable ObtenerDetalleBit(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT * FROM DL_CUMPLIMIENTO.rrdv17_detalle_bit WHERE AnioMes = @AnioMes";

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
		                                            Isnull(Convert(Varchar,DRDD.AnioMes),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Tipo_Transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.TIPO_PERSONA),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Tipo_Identificacion_persona),'') + 
		                                            Isnull(Convert(Varchar,DRDD.No_Orden_Cedula),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Numero_Identificacion_persona),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Municipio_emision_Cedula),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Primer_Apellido),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Segundo_Apellido),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Apellido_Casada),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Primer_Nombre),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Segundo_Nombre),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Nombre_Persona_Juridica),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Nacimiento_Constitucion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Pais_Nacionalidad_Constitucion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Actividad_Economica_Persona),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Direccion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Zona),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Departamento),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Municipio),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Origen_Fondos),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Tipo_Moneda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Monto_Moneda_Orginal),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Monto_Dolares),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Codigo_Agencia),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Estado),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Usuario_registro),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Registro),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Usuario_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Fecha_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Justificacion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Numero_transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDD.codigo_cliente),'') + 
		                                            Isnull(Convert(Varchar,DRDD.mov58_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.mov59_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.mov53TC_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.mon53TC_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Trxmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.MONTO_mixtoparalelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.movotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Trxotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.Nomotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDD.hora_trx),'') + 
		                                            Isnull(Convert(Varchar,DRDD.cajero),'') KeyOri,'' KeyRev
		                                                FROM EDW.DL_CUMPLIMIENTO.RRDV17_DETALLE DRDD WHERE DRDD.anioMes=@anioMes
	                                            ),
		                                                TB_Y AS 
                                                (		 SELECT DRDDT.Numero_transaccion,
                                                    '' KeyOri,
		                                            Isnull(Convert(Varchar,DRDDT.AnioMes),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Tipo_Transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.TIPO_PERSONA),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Tipo_Identificacion_persona),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.No_Orden_Cedula),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Numero_Identificacion_persona),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Municipio_emision_Cedula),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Primer_Apellido),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Segundo_Apellido),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Apellido_Casada),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Primer_Nombre),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Segundo_Nombre),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Nombre_Persona_Juridica),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Nacimiento_Constitucion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Pais_Nacionalidad_Constitucion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Actividad_Economica_Persona),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Direccion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Zona),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Departamento),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Municipio),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Origen_Fondos),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Tipo_Moneda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Monto_Moneda_Orginal),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Monto_Dolares),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Codigo_Agencia),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Estado),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Usuario_registro),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Registro),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Usuario_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Fecha_Modifico),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Justificacion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Numero_transaccion),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.codigo_cliente),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.mov58_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.mov59_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.mov53TC_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.mon53TC_boveda),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Trxmixto_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.MONTO_mixtoparalelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.movotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Trxotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.Nomotrocli_paralelo),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.hora_trx),'') + 
		                                            Isnull(Convert(Varchar,DRDDT.cajero),'')  KeyRev
		                                                FROM EDW.DL_CUMPLIMIENTO.RRDV17_DETALLE_TMP DRDDT WHERE DRDDT.anioMes=@anioMes
                                                ),
                                                TB_CHANGE AS (
                                                SELECT 'ORIGINAL' TP,DRDD2.*
                                                FROM EDW.DL_CUMPLIMIENTO.RRDV17_DETALLE DRDD2
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
                                                FROM EDW.DL_CUMPLIMIENTO.RRDV17_DETALLE_TMP DRDDT2
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


        public bool EliminarCamposDetalle(int anioMes)
        {
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.rrdv17_detalle 
                                WHERE Numero_transaccion IN ( 
                                                                SELECT rdb.Numero_transaccion 
                                                                FROM EDW.DL_CUMPLIMIENTO.rrdv17_detalle_bit rdb 
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

        public bool InsertarDetalleDv17BitBulk(DataTable dataTable, string usuario)
        {
            try
            {
                //Agregamos columas para empatarla con la bitacora
                dataTable.Columns.Add("usuario", typeof(string));
                dataTable.Columns.Add("fecha_hora" , typeof(DateTime));
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.rrdv17_detalle_bit";

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

        public bool InsertarDetalleDv17VerBitBulk(DataTable dataTable, string usuario)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.rrdv17_detalle_bit";

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

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT * FROM DL_CUMPLIMIENTO.rrdv17_detalle_bit WHERE AnioMes = @AnioMes and tipo = 'NUEVO'";

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
