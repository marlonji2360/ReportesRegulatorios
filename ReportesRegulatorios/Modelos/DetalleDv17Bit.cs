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
        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT  AnioMes, 
                            Fecha_Transaccion, 
                            Tipo_Transaccion, 
                            TIPO_PERSONA, 
                            Tipo_Identificacion_persona, 
                            No_Orden_Cedula, 
                            Numero_Identificacion_persona, 
                            Municipio_emision_Cedula, 
                            Primer_Apellido, 
                            Segundo_Apellido, 
                            Apellido_Casada, 
                            Primer_Nombre, 
                            Segundo_Nombre, 
                            Nombre_Persona_Juridica, 
                            Fecha_Nacimiento_Constitucion, 
                            Pais_Nacionalidad_Constitucion, 
                            Actividad_Economica_Persona, 
                            REPLACE(Direccion, ';', ' ') AS Direccion, 
                            Zona, 
                            Departamento, 
                            Municipio, 
                            Origen_Fondos, 
                            Tipo_Moneda, 
                            Monto_Moneda_Orginal, 
                            Monto_Dolares, 
                            Codigo_Agencia, 
                            Estado, 
                            Usuario_registro, 
                            Fecha_Registro, 
                            Usuario_Modifico, 
                            Fecha_Modifico, 
                            REPLACE(Justificacion, ';', ' ') AS Justificacion, 
                            Numero_transaccion, 
                            codigo_cliente, 
                            mov58_boveda, 
                            mov59_boveda, 
                            mov53TC_boveda, 
                            mon53TC_boveda, 
                            movmixto_paralelo, 
                            Trxmixto_paralelo, 
                            MONTO_mixtoparalelo, 
                            movotrocli_paralelo, 
                            Trxotrocli_paralelo, 
                            Nomotrocli_paralelo, 
                            hora_trx, 
                            cajero,
                            usuario ,
	                        fecha_hora ,
	                        tipo
                        FROM EDW.DL_CUMPLIMIENTO.rrdv17_detalle_bit
                        WHERE AnioMes = @AnioMes";

            if(tipoConexion == "Principal")
            {
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
            }
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
            }
            return dt;
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
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
            if(tipoConexion == "Principal")
            {
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
            }
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
             }

            return dt;

        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.rrdv17_detalle 
                                WHERE Numero_transaccion IN ( 
                                                                SELECT rdb.Numero_transaccion 
                                                                FROM EDW.DL_CUMPLIMIENTO.rrdv17_detalle_bit rdb 
                                                                WHERE rdb.tipo = 'ORIGINAL' AND rdb.AnioMes = @anioMes AND  rdb.EstadoBitacora = 'P'
                                                            )";

            if(tipoConexion == "Principal")
            {
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
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
        }

        public bool InsertarDetalleDv17BitBulk(DataTable dataTable, string usuario, string tipoConexion)
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

                if(tipoConexion == "Principal")
                {
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
                            bulkCopy.ColumnMappings.Add("EstadoBitacora", "EstadoBitacora");
                            dataTable.Columns.Add("EstadoBitacora", typeof(string));

                            bulkCopy.WriteToServer(dataTable);
                        }
                    }
                }
                else
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
                            bulkCopy.ColumnMappings.Add("EstadoBitacora", "EstadoBitacora");
                            dataTable.Columns.Add("EstadoBitacora", typeof(string));

                            bulkCopy.WriteToServer(dataTable);
                        }
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

        public bool InsertarDetalleDv17VerBitBulk(DataTable dataTable, string usuario, string tipoConexion)
        {
            try
            {
                //Agregamos columas para empatarla con la bitacora
                dataTable.Columns.Add("usuario", typeof(string));
                dataTable.Columns.Add("fecha_hora", typeof(DateTime));
                dataTable.Columns.Add("EstadoBitacora", typeof(string));


                //Colocamos valores a todas las filas
                foreach (DataRow row in dataTable.Rows)
                {
                    row["usuario"] = usuario;
                    row["fecha_hora"] = DateTime.Now;
                    row["EstadoBitacora"] = "P";

                }

                // Limpiar datos antes de insertar
                LimpiarDataTable(dataTable);

                if(tipoConexion == "Principal")
                {
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
                            bulkCopy.ColumnMappings.Add("EstadoBitacora", "EstadoBitacora");

                            bulkCopy.WriteToServer(dataTable);
                        }
                    }
                }
                else
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
                            bulkCopy.ColumnMappings.Add("EstadoBitacora", "EstadoBitacora");

                            bulkCopy.WriteToServer(dataTable);
                        }
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

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT * FROM DL_CUMPLIMIENTO.rrdv17_detalle_bit WHERE AnioMes = @AnioMes and tipo = 'NUEVO' AND EstadoBitacora ='P'";

            if(tipoConexion == "Principal")
            {
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
            }
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
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
             }           

            return dt;

        }

        public bool ActualizarEstadoBit(int anioMes, string tipoConexion)
        {
            string consulta = @"UPDATE EDW.DL_CUMPLIMIENTO.rrdv17_detalle_bit 
                                SET EstadoBitacora = 'V'  
                                WHERE AnioMes = @anioMes";

            if (tipoConexion == "Principal")
            {
                try
                {
                    Conexion conexion = new Conexion();
                    using (SqlConnection conn = conexion.AbrirConexion())
                    using (SqlCommand cmd = new SqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@anioMes", anioMes);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Aquí podrías registrar el error en un log
                    Console.WriteLine($"Error al actualizar datos: {ex.Message}");
                    return false;
                }
            }
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
                    using (SqlConnection conn = conexion.AbrirConexion())
                    using (SqlCommand cmd = new SqlCommand(consulta, conn))
                    {
                        cmd.Parameters.AddWithValue("@anioMes", anioMes);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Aquí podrías registrar el error en un log
                    Console.WriteLine($"Error al actualizar datos: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
