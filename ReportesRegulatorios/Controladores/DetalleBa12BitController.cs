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
       
        public bool InsertarDetalleBa12VerBitBulk(DataTable tabla, string usuario)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarDetalleBa12VerBitBulk(tabla, usuario);
        }

        public bool InsertarDetalleBa12BitBulk(DataTable tabla, string usuario)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarDetalleBa12BitBulk(tabla, usuario);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.ObtenerDetalleBit(anioMes);
        }

        public DataTable ObtenerCambiosBit(int anioMes)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.ObtenerCambiosBit(anioMes);
        }

        public bool EliminarCamposDetalle(int anioMes)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.EliminarCamposDetalle(anioMes);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {
            DetalleBa12Bit detalleBa12Bit = new DetalleBa12Bit();
            return detalleBa12Bit.InsertarNuevosEnDetalle(anioMes);
        }
    }
}
