using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Modelos
{
    internal class ConexionB
    {
        private SqlConnection conexion;

        public ConexionB()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString;
            conexion = new SqlConnection(connectionString);
        }

        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
