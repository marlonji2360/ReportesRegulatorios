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
       
        public bool InsertarDetalleMe13VerBitBulk(DataTable tabla, string usuario)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarDetalleMe13VerBitBulk(tabla, usuario);
        }

        public bool InsertarDetalleMe13BitBulk(DataTable tabla, string usuario)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarDetalleMe13BitBulk(tabla, usuario);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.ObtenerDetalleBit(anioMes);
        }

        public DataTable ObtenerCambiosBit(int anioMes)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.ObtenerCambiosBit(anioMes);
        }

        public bool EliminarCamposDetalle(int anioMes)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.EliminarCamposDetalle(anioMes);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {
            DetalleMe13Bit detalleMe13Bit = new DetalleMe13Bit();
            return detalleMe13Bit.InsertarNuevosEnDetalle(anioMes);
        }
    }
}
