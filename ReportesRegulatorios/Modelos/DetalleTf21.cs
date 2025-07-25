﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ReportesRegulatorios.Modelos
{
    internal class DetalleTf21
    {
        public DataTable ObtenerDetalleCsv(int anioMes)
        {

            DataTable dt = new DataTable();
            string consulta = @"SELECT [AnioMes]
                                      ,[FECHA]
                                      ,[TIPO_TRANSFERENCIA]
                                      ,[TRANSFERENCIA]
                                      ,[TIPO_PERSONA_ORD]
                                      ,[TIPO_IDENTIFICACION_ORD]
                                      ,[ORDEN_CEDULA_ORD]
                                      ,[NUMERO_IDENTIFICACION_ORD]
                                      ,[MUNICIPIO_EMISION_ORD]
                                      ,[Nombre_Juridico_ORD]
                                      ,[PRIMER_APELLIDO_ORD]
                                      ,[SEGUNDO_APELLIDO_ORD]
                                      ,[APELLIDO_CASADA_ORD]
                                      ,[PRIMER_NOMBRE_ORD]
                                      ,[SEGUNDO_NOMBRE_ORD]
                                      ,[CUENTA_A_DEBITAR_ORD]
                                      ,[TIPO_PERSONA_BEN]
                                      ,[TIPO_IDENTIFICACION_BEN]
                                      ,[ORDEN_CEDULA_BEN]
                                      ,[NUMERO_IDENTIFICACION_BEN]
                                      ,[MUNICIPIO_EMSION_BEN]
                                      ,[Nombre_Juridico_BEN]
                                      ,[PRIMER_APELLIDO_BEN]
                                      ,[SEGUNDO_APELLIDO_BEN]
                                      ,[APELLIDO_CASADA_BEN]
                                      ,[PRIMER_NOMBRE_BEN]
                                      ,[SEGUNDO_NOMBRE_BEN]
                                      ,[CUENTA_A_ABONAR_BEN]
                                      ,[CODIGO_INSTITUCION_BANCARIA]
                                      ,[NUMERO_REFERENCIA]
                                      ,[PAIS]
                                      ,[CODIGO_DEPTO_origen]
                                      ,[CODIGO_DEPTO_destino]
                                      ,[CODIGO_AGENCIA]
                                      ,[MONTO_EN_MONEDA_ORIGINAL]
                                      ,[TIPO_MONEDA]
                                      ,[MONTO_EN_DOLARES]
                                      ,[Estado]
                                      ,[Usuario_registro]
                                      ,[Fecha_Registro]
                                      ,[Usuario_Modifico]
                                      ,[Fecha_Modifico]
                                      ,[Justificacion]
                                      ,[Numero_transaccion]
                                      ,[codigo_cliente_ord]
                                      ,[codigo_cliente_ben]
                                      ,[mov58_boveda]
                                      ,[mov59_boveda]
                                      ,[mov53TC_boveda]
                                      ,[mon53TC_boveda]
                                      ,[movmixto_paralelo]
                                      ,[Trxmixto_paralelo]
                                      ,[MONTO_mixtoparalelo]
                                      ,[movotrocli_paralelo]
                                      ,[Trxotrocli_paralelo]
                                      ,[Nomotrocli_paralelo]
                                      ,[hora_trx]
                                      ,[cajero]
                                      ,[cod_proceso_origen]
                                  FROM [DL_CUMPLIMIENTO].[dw_repreg_tf21_deta]
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
            string consulta = @"select
		LEFT(CONVERT(CHAR(8), Fecha, 112) + REPLICATE(' ', 8), 8)  + '&&' +
		LEFT(ISNULL(TIPO_TRANSFERENCIA, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(TRANSFERENCIA, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(TIPO_PERSONA_ORD, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(TIPO_IDENTIFICACION_ORD, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(ORDEN_CEDULA_ORD, '') + REPLICATE(' ', 3), 3)   + '&&' +
		LEFT(ISNULL(NUMERO_IDENTIFICACION_ORD, '') + REPLICATE(' ', 20), 20)   + '&&' +
		LEFT(ISNULL(MUNICIPIO_EMISION_ORD, '') + REPLICATE(' ', 4), 4)   + '&&' +
	   CASE
           WHEN TIPO_PERSONA_ORD = 'J' THEN
		       	LEFT(ISNULL(SUBSTRING(Nombre_Juridico_ORD, 1, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_ORD, 16, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_ORD, 31, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_ORD, 46, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
			    LEFT(ISNULL(SUBSTRING(Nombre_Juridico_ORD, 61, 30) , '') + REPLICATE(' ', 30), 30)
		   WHEN TIPO_PERSONA_ORD != 'J' THEN
				LEFT(ISNULL(PRIMER_APELLIDO_ORD, '') + REPLICATE(' ', 15), 15)   + '&&' +
				LEFT(ISNULL(SEGUNDO_APELLIDO_ORD, '') + REPLICATE(' ', 15), 15)   + '&&' +
				LEFT(ISNULL(APELLIDO_CASADA_ORD, '') + REPLICATE(' ', 15), 15)   + '&&' +
				LEFT(ISNULL(PRIMER_NOMBRE_ORD, '') + REPLICATE(' ', 15), 15)   + '&&' +
				LEFT(ISNULL(SEGUNDO_NOMBRE_ORD, '') + REPLICATE(' ', 30), 30)   
		END + '&&' +
		LEFT(ISNULL(CUENTA_A_DEBITAR_ORD, '') + REPLICATE(' ', 28), 28)   + '&&' +
		LEFT(ISNULL(TIPO_PERSONA_BEN, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(TIPO_IDENTIFICACION_BEN, '') + REPLICATE(' ', 1), 1)   + '&&' +
		LEFT(ISNULL(ORDEN_CEDULA_BEN, '') + REPLICATE(' ', 3), 3)   + '&&' +
		LEFT(ISNULL(NUMERO_IDENTIFICACION_BEN, '') + REPLICATE(' ', 20), 20)   + '&&' +
		LEFT(ISNULL(MUNICIPIO_EMSION_BEN, '') + REPLICATE(' ', 4), 4)   + '&&' +
		CASE
           WHEN TIPO_PERSONA_BEN = 'J' THEN
		       	LEFT(ISNULL(SUBSTRING(Nombre_Juridico_BEN, 1, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_BEN, 16, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_BEN, 31, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
                LEFT(ISNULL(SUBSTRING(Nombre_Juridico_BEN, 46, 15) , '') + REPLICATE(' ', 15), 15)   + '&&' +
			    LEFT(ISNULL(SUBSTRING(Nombre_Juridico_BEN, 61, 30) , '') + REPLICATE(' ', 30), 30)
		   WHEN TIPO_PERSONA_BEN != 'J' THEN
			    LEFT(ISNULL(PRIMER_APELLIDO_BEN, '') + REPLICATE(' ', 15), 15)   + '&&' +
		        LEFT(ISNULL(SEGUNDO_APELLIDO_BEN, '') + REPLICATE(' ', 15), 15)   + '&&' +
		        LEFT(ISNULL(APELLIDO_CASADA_BEN, '') + REPLICATE(' ', 15), 15)   + '&&' +
		        LEFT(ISNULL(PRIMER_NOMBRE_BEN, '') + REPLICATE(' ', 15), 15)   + '&&' +
		        LEFT(ISNULL(SEGUNDO_NOMBRE_BEN, '') + REPLICATE(' ', 30), 30)
		END + '&&' +
	    LEFT(ISNULL(CUENTA_A_ABONAR_BEN, '') + REPLICATE(' ', 28), 28)   + '&&' +
		LEFT(ISNULL(CODIGO_INSTITUCION_BANCARIA, '') + REPLICATE(' ', 5), 5)   + '&&' +
		LEFT(ISNULL(NUMERO_REFERENCIA, '') + REPLICATE(' ', 50), 50)   + '&&' +
		LEFT(ISNULL(PAIS, '') + REPLICATE(' ', 2), 2)   + '&&' +
		LEFT(ISNULL(CODIGO_DEPTO_origen, '') + REPLICATE(' ', 2), 2)   + '&&' +
		LEFT(ISNULL(CODIGO_DEPTO_destino, '') + REPLICATE(' ', 2), 2)   + '&&' +
		LEFT(ISNULL(CODIGO_AGENCIA, '') + REPLICATE(' ', 10), 10)   + '&&' +
		--RIGHT(REPLICATE('0', 14) + ISNULL(CAST(MONTO_EN_MONEDA_ORIGINAL AS VARCHAR), ''), 14)    + '&&' +
		LEFT(CONVERT(CHAR(14), MONTO_EN_MONEDA_ORIGINAL*100, 112) + REPLICATE(' ', 14), 14) + '&&' +
		LEFT(ISNULL(TIPO_MONEDA, '') + REPLICATE(' ', 3), 3)   + '&&' +
		--RIGHT(REPLICATE('0', 14) + ISNULL(CAST(MONTO_EN_DOLARES AS VARCHAR), ''), 14)    + '&&'
		LEFT(CONVERT(CHAR(14), MONTO_EN_DOLARES*100, 112) + REPLICATE(' ', 14), 14) + '&&'
    Trama
                                     FROM EDW.DL_CUMPLIMIENTO.dw_repreg_tf21_deta
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

        public bool InsertarDetalleTf21Bulk(DataTable dataTable)
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
                        bulkCopy.DestinationTableName = "DL_CUMPLIMIENTO.dw_repreg_tf21_deta";

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
            "AnioMes", "FECHA", "Fecha_Nacimiento_Constitucion", "Fecha_modifico",
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
    }
}
