﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleTf21Bit
    {
        public void LimpiarDataTable(DataTable dataTable)
        {
            string[] columnasInt = new string[]
            {
            "AnioMes", "FECHA", "Fecha_Nacimiento_Constitucion",
            "Fecha_Registro", "Numero_transaccion", "cod_proceso_origen",  "hora_trx"
            };

            string[] columnasFloat = new string[]
            {
            "MONTO_EN_MONEDA_ORIGINAL", "MONTO_EN_DOLARES", "MONTO_mixtoparalelo"
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

        public bool InsertarDetalleTf21BitBulk(DataTable dataTable, string usuario)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_tf21_deta_bit";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("FECHA", "FECHA");
                        bulkCopy.ColumnMappings.Add("TIPO_TRANSFERENCIA", "TIPO_TRANSFERENCIA");
                        bulkCopy.ColumnMappings.Add("TRANSFERENCIA", "TRANSFERENCIA");
                        bulkCopy.ColumnMappings.Add("TIPO_PERSONA_ORD", "TIPO_PERSONA_ORD");
                        bulkCopy.ColumnMappings.Add("TIPO_IDENTIFICACION_ORD", "TIPO_IDENTIFICACION_ORD");
                        bulkCopy.ColumnMappings.Add("ORDEN_CEDULA_ORD", "ORDEN_CEDULA_ORD");
                        bulkCopy.ColumnMappings.Add("NUMERO_IDENTIFICACION_ORD", "NUMERO_IDENTIFICACION_ORD");
                        bulkCopy.ColumnMappings.Add("MUNICIPIO_EMISION_ORD", "MUNICIPIO_EMISION_ORD");
                        bulkCopy.ColumnMappings.Add("Nombre_Juridico_ORD", "Nombre_Juridico_ORD");
                        bulkCopy.ColumnMappings.Add("PRIMER_APELLIDO_ORD", "PRIMER_APELLIDO_ORD");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_APELLIDO_ORD", "SEGUNDO_APELLIDO_ORD");
                        bulkCopy.ColumnMappings.Add("APELLIDO_CASADA_ORD", "APELLIDO_CASADA_ORD");
                        bulkCopy.ColumnMappings.Add("PRIMER_NOMBRE_ORD", "PRIMER_NOMBRE_ORD");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_NOMBRE_ORD", "SEGUNDO_NOMBRE_ORD");
                        bulkCopy.ColumnMappings.Add("CUENTA_A_DEBITAR_ORD", "CUENTA_A_DEBITAR_ORD");
                        bulkCopy.ColumnMappings.Add("TIPO_PERSONA_BEN", "TIPO_PERSONA_BEN");
                        bulkCopy.ColumnMappings.Add("TIPO_IDENTIFICACION_BEN", "TIPO_IDENTIFICACION_BEN");
                        bulkCopy.ColumnMappings.Add("ORDEN_CEDULA_BEN", "ORDEN_CEDULA_BEN");
                        bulkCopy.ColumnMappings.Add("NUMERO_IDENTIFICACION_BEN", "NUMERO_IDENTIFICACION_BEN");
                        bulkCopy.ColumnMappings.Add("MUNICIPIO_EMSION_BEN", "MUNICIPIO_EMSION_BEN");
                        bulkCopy.ColumnMappings.Add("Nombre_Juridico_BEN", "Nombre_Juridico_BEN");
                        bulkCopy.ColumnMappings.Add("PRIMER_APELLIDO_BEN", "PRIMER_APELLIDO_BEN");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_APELLIDO_BEN", "SEGUNDO_APELLIDO_BEN");
                        bulkCopy.ColumnMappings.Add("APELLIDO_CASADA_BEN", "APELLIDO_CASADA_BEN");
                        bulkCopy.ColumnMappings.Add("PRIMER_NOMBRE_BEN", "PRIMER_NOMBRE_BEN");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_NOMBRE_BEN", "SEGUNDO_NOMBRE_BEN");
                        bulkCopy.ColumnMappings.Add("CUENTA_A_ABONAR_BEN", "CUENTA_A_ABONAR_BEN");
                        bulkCopy.ColumnMappings.Add("CODIGO_INSTITUCION_BANCARIA", "CODIGO_INSTITUCION_BANCARIA");
                        bulkCopy.ColumnMappings.Add("NUMERO_REFERENCIA", "NUMERO_REFERENCIA");
                        bulkCopy.ColumnMappings.Add("PAIS", "PAIS");
                        bulkCopy.ColumnMappings.Add("CODIGO_DEPTO_origen", "CODIGO_DEPTO_origen");
                        bulkCopy.ColumnMappings.Add("CODIGO_DEPTO_destino", "CODIGO_DEPTO_destino");
                        bulkCopy.ColumnMappings.Add("CODIGO_AGENCIA", "CODIGO_AGENCIA");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_MONEDA_ORIGINAL", "MONTO_EN_MONEDA_ORIGINAL");
                        bulkCopy.ColumnMappings.Add("TIPO_MONEDA", "TIPO_MONEDA");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_DOLARES", "MONTO_EN_DOLARES");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente_ord", "codigo_cliente_ord");
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
                        bulkCopy.ColumnMappings.Add("cod_proceso_origen", "cod_proceso_origen");
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

        public bool InsertarDetalleTf21VerBitBulk(DataTable dataTable, string usuario)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_tf21_deta_bit";

                        // Mapeo explícito de columnas
                        bulkCopy.ColumnMappings.Add("AnioMes", "AnioMes");
                        bulkCopy.ColumnMappings.Add("FECHA", "FECHA");
                        bulkCopy.ColumnMappings.Add("TIPO_TRANSFERENCIA", "TIPO_TRANSFERENCIA");
                        bulkCopy.ColumnMappings.Add("TRANSFERENCIA", "TRANSFERENCIA");
                        bulkCopy.ColumnMappings.Add("TIPO_PERSONA_ORD", "TIPO_PERSONA_ORD");
                        bulkCopy.ColumnMappings.Add("TIPO_IDENTIFICACION_ORD", "TIPO_IDENTIFICACION_ORD");
                        bulkCopy.ColumnMappings.Add("ORDEN_CEDULA_ORD", "ORDEN_CEDULA_ORD");
                        bulkCopy.ColumnMappings.Add("NUMERO_IDENTIFICACION_ORD", "NUMERO_IDENTIFICACION_ORD");
                        bulkCopy.ColumnMappings.Add("MUNICIPIO_EMISION_ORD", "MUNICIPIO_EMISION_ORD");
                        bulkCopy.ColumnMappings.Add("Nombre_Juridico_ORD", "Nombre_Juridico_ORD");
                        bulkCopy.ColumnMappings.Add("PRIMER_APELLIDO_ORD", "PRIMER_APELLIDO_ORD");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_APELLIDO_ORD", "SEGUNDO_APELLIDO_ORD");
                        bulkCopy.ColumnMappings.Add("APELLIDO_CASADA_ORD", "APELLIDO_CASADA_ORD");
                        bulkCopy.ColumnMappings.Add("PRIMER_NOMBRE_ORD", "PRIMER_NOMBRE_ORD");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_NOMBRE_ORD", "SEGUNDO_NOMBRE_ORD");
                        bulkCopy.ColumnMappings.Add("CUENTA_A_DEBITAR_ORD", "CUENTA_A_DEBITAR_ORD");
                        bulkCopy.ColumnMappings.Add("TIPO_PERSONA_BEN", "TIPO_PERSONA_BEN");
                        bulkCopy.ColumnMappings.Add("TIPO_IDENTIFICACION_BEN", "TIPO_IDENTIFICACION_BEN");
                        bulkCopy.ColumnMappings.Add("ORDEN_CEDULA_BEN", "ORDEN_CEDULA_BEN");
                        bulkCopy.ColumnMappings.Add("NUMERO_IDENTIFICACION_BEN", "NUMERO_IDENTIFICACION_BEN");
                        bulkCopy.ColumnMappings.Add("MUNICIPIO_EMSION_BEN", "MUNICIPIO_EMSION_BEN");
                        bulkCopy.ColumnMappings.Add("Nombre_Juridico_BEN", "Nombre_Juridico_BEN");
                        bulkCopy.ColumnMappings.Add("PRIMER_APELLIDO_BEN", "PRIMER_APELLIDO_BEN");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_APELLIDO_BEN", "SEGUNDO_APELLIDO_BEN");
                        bulkCopy.ColumnMappings.Add("APELLIDO_CASADA_BEN", "APELLIDO_CASADA_BEN");
                        bulkCopy.ColumnMappings.Add("PRIMER_NOMBRE_BEN", "PRIMER_NOMBRE_BEN");
                        bulkCopy.ColumnMappings.Add("SEGUNDO_NOMBRE_BEN", "SEGUNDO_NOMBRE_BEN");
                        bulkCopy.ColumnMappings.Add("CUENTA_A_ABONAR_BEN", "CUENTA_A_ABONAR_BEN");
                        bulkCopy.ColumnMappings.Add("CODIGO_INSTITUCION_BANCARIA", "CODIGO_INSTITUCION_BANCARIA");
                        bulkCopy.ColumnMappings.Add("NUMERO_REFERENCIA", "NUMERO_REFERENCIA");
                        bulkCopy.ColumnMappings.Add("PAIS", "PAIS");
                        bulkCopy.ColumnMappings.Add("CODIGO_DEPTO_origen", "CODIGO_DEPTO_origen");
                        bulkCopy.ColumnMappings.Add("CODIGO_DEPTO_destino", "CODIGO_DEPTO_destino");
                        bulkCopy.ColumnMappings.Add("CODIGO_AGENCIA", "CODIGO_AGENCIA");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_MONEDA_ORIGINAL", "MONTO_EN_MONEDA_ORIGINAL");
                        bulkCopy.ColumnMappings.Add("TIPO_MONEDA", "TIPO_MONEDA");
                        bulkCopy.ColumnMappings.Add("MONTO_EN_DOLARES", "MONTO_EN_DOLARES");
                        bulkCopy.ColumnMappings.Add("Estado", "Estado");
                        bulkCopy.ColumnMappings.Add("Usuario_registro", "Usuario_registro");
                        bulkCopy.ColumnMappings.Add("Fecha_Registro", "Fecha_Registro");
                        bulkCopy.ColumnMappings.Add("Usuario_Modifico", "Usuario_Modifico");
                        bulkCopy.ColumnMappings.Add("Fecha_Modifico", "Fecha_Modifico");
                        bulkCopy.ColumnMappings.Add("Justificacion", "Justificacion");
                        bulkCopy.ColumnMappings.Add("Numero_transaccion", "Numero_transaccion");
                        bulkCopy.ColumnMappings.Add("codigo_cliente_ord", "codigo_cliente_ord");
                        bulkCopy.ColumnMappings.Add("codigo_cliente_ben", "codigo_cliente_ben");
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
                        bulkCopy.ColumnMappings.Add("cod_proceso_origen", "cod_proceso_origen");
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
            string consulta = @"SELECT * FROM DL_CUMPLIMIENTO.dw_repreg_tf21_deta_bit WHERE AnioMes = @AnioMes and tipo = 'NUEVO'";

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
            string consulta = @"DELETE FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta
                                WHERE Numero_transaccion IN ( 
                                                                SELECT rdb.Numero_transaccion 
                                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta_bit rdb 
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
                                          ,FECHA
                                          ,TIPO_TRANSFERENCIA
                                          ,TRANSFERENCIA
                                          ,TIPO_PERSONA_ORD
                                          ,TIPO_IDENTIFICACION_ORD
                                          ,ORDEN_CEDULA_ORD
                                          ,NUMERO_IDENTIFICACION_ORD
                                          ,MUNICIPIO_EMISION_ORD
                                          ,Nombre_Juridico_ORD
                                          ,PRIMER_APELLIDO_ORD
                                          ,SEGUNDO_APELLIDO_ORD
                                          ,APELLIDO_CASADA_ORD
                                          ,PRIMER_NOMBRE_ORD
                                          ,SEGUNDO_NOMBRE_ORD
                                          ,CUENTA_A_DEBITAR_ORD
                                          ,TIPO_PERSONA_BEN
                                          ,TIPO_IDENTIFICACION_BEN
                                          ,ORDEN_CEDULA_BEN
                                          ,NUMERO_IDENTIFICACION_BEN
                                          ,MUNICIPIO_EMSION_BEN
                                          ,Nombre_Juridico_BEN
                                          ,PRIMER_APELLIDO_BEN
                                          ,SEGUNDO_APELLIDO_BEN
                                          ,APELLIDO_CASADA_BEN
                                          ,PRIMER_NOMBRE_BEN
                                          ,SEGUNDO_NOMBRE_BEN
                                          ,CUENTA_A_ABONAR_BEN
                                          ,CODIGO_INSTITUCION_BANCARIA
                                          ,NUMERO_REFERENCIA
                                          ,PAIS
                                          ,CODIGO_DEPTO_origen
                                          ,CODIGO_DEPTO_destino
                                          ,CODIGO_AGENCIA
                                          ,MONTO_EN_MONEDA_ORIGINAL
                                          ,TIPO_MONEDA
                                          ,MONTO_EN_DOLARES
                                          ,Estado
                                          ,Usuario_registro
                                          ,Fecha_Registro
                                          ,Usuario_Modifico
                                          ,Fecha_Modifico
                                          ,Justificacion
                                          ,Numero_transaccion
                                          ,codigo_cliente_ord
                                          ,codigo_cliente_ben
                                          ,mov58_boveda
                                          ,mov59_boveda
                                          ,mov53TC_boveda
                                          ,mon53TC_boveda
                                          ,movmixto_paralelo
                                          ,Trxmixto_paralelo
                                          ,MONTO_mixtoparalelo
                                          ,movotrocli_paralelo
                                          ,Trxotrocli_paralelo
                                          ,Nomotrocli_paralelo
                                          ,hora_trx
                                          ,cajero
                                          ,cod_proceso_origen
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
                                                    Isnull(Convert(Varchar,DRDD.AnioMes),'') + 
                                                    Isnull(Convert(Varchar,DRDD.FECHA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_TRANSFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TRANSFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_PERSONA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_IDENTIFICACION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.ORDEN_CEDULA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUMERO_IDENTIFICACION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MUNICIPIO_EMISION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Nombre_Juridico_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.PRIMER_APELLIDO_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.SEGUNDO_APELLIDO_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.APELLIDO_CASADA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.PRIMER_NOMBRE_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.SEGUNDO_NOMBRE_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CUENTA_A_DEBITAR_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_PERSONA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_IDENTIFICACION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.ORDEN_CEDULA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUMERO_IDENTIFICACION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MUNICIPIO_EMSION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Nombre_Juridico_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.PRIMER_APELLIDO_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.SEGUNDO_APELLIDO_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.APELLIDO_CASADA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.PRIMER_NOMBRE_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.SEGUNDO_NOMBRE_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CUENTA_A_ABONAR_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CODIGO_INSTITUCION_BANCARIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.NUMERO_REFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.PAIS),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CODIGO_DEPTO_origen),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CODIGO_DEPTO_destino),'') + 
                                                    Isnull(Convert(Varchar,DRDD.CODIGO_AGENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MONTO_EN_MONEDA_ORIGINAL),'') + 
                                                    Isnull(Convert(Varchar,DRDD.TIPO_MONEDA),'') + 
                                                    Isnull(Convert(Varchar,DRDD.MONTO_EN_DOLARES),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Estado),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Registro),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Usuario_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Fecha_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Justificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.Numero_transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDD.codigo_cliente_ord),'') + 
                                                    Isnull(Convert(Varchar,DRDD.codigo_cliente_ben),'') + 
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
                                                    Isnull(Convert(Varchar,DRDD.cajero),'') + 
                                                    Isnull(Convert(Varchar,DRDD.cod_proceso_origen),'') KeyOri,'' KeyRev
                                                        FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta DRDD WHERE DRDD.anioMes=@anioMes
	                                            ),
		                                                TB_Y AS 
                                                (		 SELECT DRDDT.Numero_transaccion,
                                                    Isnull(Convert(Varchar,DRDDT.AnioMes),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.FECHA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_TRANSFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TRANSFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_PERSONA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_IDENTIFICACION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.ORDEN_CEDULA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.NUMERO_IDENTIFICACION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MUNICIPIO_EMISION_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Nombre_Juridico_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.PRIMER_APELLIDO_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.SEGUNDO_APELLIDO_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.APELLIDO_CASADA_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.PRIMER_NOMBRE_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.SEGUNDO_NOMBRE_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CUENTA_A_DEBITAR_ORD),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_PERSONA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_IDENTIFICACION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.ORDEN_CEDULA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.NUMERO_IDENTIFICACION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MUNICIPIO_EMSION_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Nombre_Juridico_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.PRIMER_APELLIDO_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.SEGUNDO_APELLIDO_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.APELLIDO_CASADA_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.PRIMER_NOMBRE_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.SEGUNDO_NOMBRE_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CUENTA_A_ABONAR_BEN),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CODIGO_INSTITUCION_BANCARIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.NUMERO_REFERENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.PAIS),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CODIGO_DEPTO_origen),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CODIGO_DEPTO_destino),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.CODIGO_AGENCIA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MONTO_EN_MONEDA_ORIGINAL),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.TIPO_MONEDA),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.MONTO_EN_DOLARES),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Estado),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Usuario_registro),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Fecha_Registro),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Usuario_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Fecha_Modifico),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Justificacion),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.Numero_transaccion),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.codigo_cliente_ord),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.codigo_cliente_ben),'') + 
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
                                                    Isnull(Convert(Varchar,DRDDT.cajero),'') + 
                                                    Isnull(Convert(Varchar,DRDDT.cod_proceso_origen),'')  KeyRev
		                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta_tmp DRDDT WHERE DRDDT.anioMes=@anioMes
                                                ),
                                                TB_CHANGE AS (
                                                SELECT 'ORIGINAL' TP,DRDD2.*
                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta DRDD2
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
                                                FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta_tmp DRDDT2
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

