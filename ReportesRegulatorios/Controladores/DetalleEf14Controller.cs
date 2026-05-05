using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleEf14Controller
    {
        public DataTable ObtenerDetalleCsv(int anioMes, string tipoConexion)
        {
            DetalleEf14 detalleEf14 = new DetalleEf14();
            return detalleEf14.ObtenerDetalleCsv(anioMes, tipoConexion);
        }

        public DataTable ObtenerDetalleTxt(int anioMes, string tipoConexion)
        {
            DetalleEf14 detalleEf14 = new DetalleEf14();
            return detalleEf14.ObtenerDetalleTxt(anioMes, tipoConexion);
        }

        public bool InsertarDetalleEf14Bulk(DataTable tabla, string tipoConexion)
        {
            DetalleEf14 detalleEf14 = new DetalleEf14();
            return detalleEf14.InsertarDetalleEf14Bulk(tabla, tipoConexion);
        }
    }
}
