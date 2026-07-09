using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleTf21Controller
    {
        public DataTable ObtenerDetalleCsv(int anioMes, string tipoConexion)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.ObtenerDetalleCsv(anioMes, tipoConexion);
        }

        public DataTable ObtenerDetalleTxt(int anioMes, string tipoConexion)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.ObtenerDetalleTxt(anioMes, tipoConexion);
        }

        public bool InsertarDetalleTf21Bulk(DataTable tabla, string tipoConexion)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.InsertarDetalleTf21Bulk(tabla, tipoConexion);
        }
    }
}
