using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleBa12Controller
    {
        public DataTable ObtenerDetalleCsv(int anioMes, string tipoConexion)
        {
            DetalleBa12 detalleBa12 = new DetalleBa12();
            return detalleBa12.ObtenerDetalleCsv(anioMes, tipoConexion);
        }

        public DataTable ObtenerDetalleTxt(int anioMes, string tipoConexion)
        {
            DetalleBa12 detalleBa12 = new DetalleBa12();
            return detalleBa12.ObtenerDetalleTxt(anioMes, tipoConexion);
        }

        public bool InsertarDetalleBa12Bulk(DataTable tabla, string tipoConexion)
        {
            DetalleBa12 detalleBa12 = new DetalleBa12();
            return detalleBa12.InsertarDetalleBa12Bulk(tabla, tipoConexion);
        }
    }
}
