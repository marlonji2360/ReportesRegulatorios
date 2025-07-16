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

        public bool InsertarDetalleEf14VerBitBulk(DataTable tabla, string usuario)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarDetalleEf14VerBitBulk(tabla, usuario);
        }

        public bool InsertarDetalleEf14BitBulk(DataTable tabla, string usuario)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarDetalleEf14BitBulk(tabla, usuario);
        }

        public DataTable ObtenerDetalleBit(int anioMes)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.ObtenerDetalleBit(anioMes);
        }

        public DataTable ObtenerCambiosBit(int anioMes)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.ObtenerCambiosBit(anioMes);
        }

        public bool EliminarCamposDetalle(int anioMes)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.EliminarCamposDetalle(anioMes);
        }

        public DataTable InsertarNuevosEnDetalle(int anioMes)
        {
            DetalleEf14Bit detalleEf14Bit = new DetalleEf14Bit();
            return detalleEf14Bit.InsertarNuevosEnDetalle(anioMes);
        }
    }
}
