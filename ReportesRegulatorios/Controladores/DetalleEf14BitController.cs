using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleEf14BitController
    {

        public bool InsertarDetalleEf14VerBitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarDetalleEf14VerBitBulk(tabla, usuario, tipoConexion);
        }

        public bool InsertarDetalleEf14BitBulk(DataTable tabla, string usuario, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarDetalleEf14BitBulk(tabla, usuario, tipoConexion);
        }

        public DataTable ObtenerDetalleBit(int anioMes, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.ObtenerDetalleBit(anioMes, tipoConexion);
        }

        public DataTable ObtenerCambiosBit(int anioMes, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.ObtenerCambiosBit(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalle(int anioMes, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.EliminarCamposDetalle(anioMes, tipoConexion);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarNuevosEnDetalle(anioMes, tipoConexion);
        }

        public bool ActualizarEstadoBit(int anioMes, string tipoConexion)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.ActualizarEstadoBit(anioMes, tipoConexion);
        }
    }
}
