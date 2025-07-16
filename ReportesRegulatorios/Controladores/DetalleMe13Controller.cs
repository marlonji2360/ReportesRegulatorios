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
        public DataTable ObtenerDetalleCsv(int anioMes)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.ObtenerDetalleCsv(anioMes);
        }

        public DataTable ObtenerDetalleTxt(int anioMes)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.ObtenerDetalleTxt(anioMes);
        }

        public bool InsertarDetalleMe13Bulk(DataTable tabla)
        {
            DetalleMe13 detalleMe13 = new DetalleMe13();
            return detalleMe13.InsertarDetalleMe13Bulk(tabla);
        }
    }
}
