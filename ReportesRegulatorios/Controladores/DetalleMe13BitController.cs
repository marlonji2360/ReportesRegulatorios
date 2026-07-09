using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleMe13BitController
    {
       
        public bool InsertarDetalleMe13VerBitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarDetalleMe13VerBitBulk(tabla, usuario, tipoConexion);
        }

        public bool InsertarDetalleMe13BitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarDetalleMe13BitBulk(tabla, usuario, tipoConexion);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.ObtenerDetalleBit(anioMes, tipoConexion);
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.ObtenerCambiosBit(anioMes, tipoConexion);
        }

        public bool ActualizarEstadoBit(int anioMes, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.ActualizarEstadoBit(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.EliminarCamposDetalle(anioMes, tipoConexion);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarNuevosEnDetalle(anioMes, tipoConexion);
        }
    }
}
