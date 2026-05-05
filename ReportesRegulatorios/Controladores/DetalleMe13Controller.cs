using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleMe13Controller
    {
        public DataTable ObtenerDetalleCsv(int anioMes, string tipoConexion)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.ObtenerDetalleCsv(anioMes, tipoConexion);
        }

        public DataTable ObtenerDetalleTxt(int anioMes, string tipoConexion)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.ObtenerDetalleTxt(anioMes, tipoConexion);
        }

        public bool InsertarDetalleMe13Bulk(DataTable tabla, string tipoConexion)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.InsertarDetalleMe13Bulk(tabla, tipoConexion);
        }
    }
}
