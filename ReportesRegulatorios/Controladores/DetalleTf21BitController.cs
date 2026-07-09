using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleTf21BitController
    {
       
        public bool InsertarDetalleTf21VerBitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarDetalleTf21VerBitBulk(tabla, usuario, tipoConexion);
        }

        public bool InsertarDetalleTf21BitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarDetalleTf21BitBulk(tabla, usuario, tipoConexion);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.ObtenerDetalleBit(anioMes, tipoConexion);
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.ObtenerCambiosBit(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.EliminarCamposDetalle(anioMes, tipoConexion);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarNuevosEnDetalle(anioMes, tipoConexion);
        }
    }
}
