using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Modelos
{
    internal class Encabezado
    {
        int AnioMes;
        string Estado ;
        string Usuario_genera ;
        string Fecha_genera ;
        string Usuario_upd ;
        string Fecha_upd ;
        string Usuario_Cierre ;
        string Fecha_Cierre ;
        string Doc_cierre;

        public Encabezado()
        {

        }

        public DataTable ObtenerEncabezado(int anioMes)
        {
            DataTable dt = new DataTable();
            string consulta = "select * from DL_CUMPLIMIENTO.rrdv17_detalle_enca where AnioMes=" + anioMes;
            try
            {
                Conexion conexion = new Conexion();
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.AbrirConexion());
                adaptador.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dt;
        }

        public bool ActualizarEncabezado(    int anioMes, 
                                                string estado, 
                                                string Usuario_genera, 
                                                string Fecha_genera,
                                                string Usuario_upd,
                                                string Fecha_upd,
                                                string Usuario_Cierre,
                                                string Fecha_Cierre,
                                                string Doc_cierre
                                            )
        {
            try
            {
                Conexion conexion = new Conexion();
                using (SqlConnection conn = conexion.AbrirConexion())
                {
                   
                    using (SqlCommand cmd = new SqlCommand("DL_CUMPLIMIENTO.PRC_Actualizar_DV17_ENCA", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agrega todos los parámetros (ejemplo con algunos)
                        cmd.Parameters.AddWithValue("@AnioMes", anioMes);
                        cmd.Parameters.AddWithValue("@Estado", estado);
                        cmd.Parameters.AddWithValue("@Usuario_genera", Usuario_genera);
                        cmd.Parameters.AddWithValue("@Fecha_genera", Fecha_genera);
                        cmd.Parameters.AddWithValue("@Usuario_upd", Usuario_upd);
                        cmd.Parameters.AddWithValue("@Fecha_upd", Fecha_upd);
                        cmd.Parameters.AddWithValue("@Usuario_Cierre", Usuario_Cierre);
                        cmd.Parameters.AddWithValue("@Fecha_Cierre", Fecha_Cierre);
                        cmd.Parameters.AddWithValue("@Doc_cierre", Doc_cierre);
                        

                        cmd.ExecuteNonQuery();
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
