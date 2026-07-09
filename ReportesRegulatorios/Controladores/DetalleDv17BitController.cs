using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleDv17BitController
    {
        

        public bool InsertarDetalleDv17VerBitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarDetalleDv17VerBitBulk(tabla, usuario, tipoConexion);
        }        

        public bool InsertarDetalleDv17BitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarDetalleDv17BitBulk(tabla, usuario, tipoConexion);
        }

        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ObtenerDetalleBit(anioMes, tipoConexion);
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ObtenerCambiosBit(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.EliminarCamposDetalle(anioMes, tipoConexion);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarNuevosEnDetalle(anioMes, tipoConexion);
        }

        public Boolean ActualizarEstadoBit(int anioMes, string tipoConexion)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ActualizarEstadoBit(anioMes, tipoConexion);
        }
    }
}
