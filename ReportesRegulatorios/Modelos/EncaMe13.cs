using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Modelos
{
    internal class EncaMe13
    {
        public EncaMe13()
        {

        }

        public DataTable ObtenerEncabezado(int anioMes, string tipoConexion)
        {
            DataTable dt = new DataTable();
            string consulta = "select AnioMes, Estado, Usuario_genera, Fecha_genera, Usuario_upd, Fecha_upd, Usuario_Cierre, Fecha_Cierre, Doc_cierre from DL_CUMPLIMIENTO.dw_repreg_me13_deta_enca where AnioMes=" + anioMes;
            if(tipoConexion == "Principal")
            {
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
            }
            else
            {
                try
                {
                    ConexionContingencia conexion = new ConexionContingencia();
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.AbrirConexion());
                    adaptador.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dt;
        }

        public bool ActualizarEncabezado(
            int anioMes,
            string estado,
            string Usuario_genera,
            string Fecha_genera,
            string Usuario_upd,
            string Fecha_upd,
            string Usuario_Cierre,
            string Fecha_Cierre,
            string Doc_cierre,
            string tipoConexion
        )
        {
            try
            {
                string query = @"
                UPDATE EDW.DL_CUMPLIMIENTO.dw_repreg_me13_deta_enca
                SET 
                    Estado = @Estado,
                    Usuario_genera = @Usuario_genera,
                    Fecha_genera = @Fecha_genera,
                    Usuario_upd = @Usuario_upd,
                    Fecha_upd = @Fecha_upd,
                    Usuario_Cierre = @Usuario_Cierre,
                    Fecha_Cierre = @Fecha_Cierre,
                    Doc_cierre = @Doc_cierre
                WHERE AnioMes = @AnioMes";

                if(tipoConexion == "Principal")
                {
                    Conexion conexion = new Conexion();
                    using (SqlConnection conn = conexion.AbrirConexion())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
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
                }
                else
                {
                    ConexionContingencia conexion = new ConexionContingencia();
                    using (SqlConnection conn = conexion.AbrirConexion())
                    {
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
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
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar datos: " + ex.Message);
                return false;
            }
        }
    }
}
