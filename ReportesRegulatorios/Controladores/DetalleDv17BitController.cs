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
        

        public bool InsertarDetalleDv17VerBitBulk(DataTable tabla, string usuario)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarDetalleDv17VerBitBulk(tabla, usuario);
        }

        

        public bool InsertarDetalleDv17BitBulk(DataTable tabla, string usuario)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarDetalleDv17BitBulk(tabla, usuario);
        }

        public DataTable ObtenerDetalleBit(int anioMes)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ObtenerDetalleBit(anioMes);
        }

        public DataTable ObtenerCambiosBit(int anioMes)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ObtenerCambiosBit(anioMes);
        }

        public bool EliminarCamposDetalle(int anioMes)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.EliminarCamposDetalle(anioMes);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.InsertarNuevosEnDetalle(anioMes);
        }

        public Boolean ActualizarEstadoBit(int anioMes)
        {
            DetalleDv17Bit detalleDv17Bit = new DetalleDv17Bit();
            return detalleDv17Bit.ActualizarEstadoBit(anioMes);
        }
    }
}
