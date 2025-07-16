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
       
        public bool InsertarDetalleTf21VerBitBulk(DataTable tabla, string usuario)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarDetalleTf21VerBitBulk(tabla, usuario);
        }

        public bool InsertarDetalleTf21BitBulk(DataTable tabla, string usuario)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarDetalleTf21BitBulk(tabla, usuario);
        }
        
        public DataTable ObtenerDetalleBit(int anioMes)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.ObtenerDetalleBit(anioMes);
        }

        public DataTable ObtenerCambiosBit(int anioMes)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.ObtenerCambiosBit(anioMes);
        }

        public bool EliminarCamposDetalle(int anioMes)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.EliminarCamposDetalle(anioMes);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {
            DetalleTf21Bit detalleTf21Bit = new DetalleTf21Bit();
            return detalleTf21Bit.InsertarNuevosEnDetalle(anioMes);
        }
    }
}
