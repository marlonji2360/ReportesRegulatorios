using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleBa12BitController
    {
       
        public bool InsertarDetalleBa12VerBitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarDetalleBa12VerBitBulk(tabla, usuario, tipoConexion);
        }

        public bool InsertarDetalleBa12BitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarDetalleBa12BitBulk(tabla, usuario, tipoConexion);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.ObtenerDetalleBit(anioMes, tipoConexion);
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.ObtenerCambiosBit(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.EliminarCamposDetalle(anioMes, tipoConexion);
        }

        public bool ActualizarEstadoBit(int anioMes, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.ActualizarEstadoBit(anioMes, tipoConexion);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarNuevosEnDetalle(anioMes, tipoConexion);
        }
    }
}
