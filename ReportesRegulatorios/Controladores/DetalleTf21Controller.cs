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
        public DataTable ObtenerDetalleCsv(int anioMes)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.ObtenerDetalleCsv(anioMes);
        }

        public DataTable ObtenerDetalleTxt(int anioMes)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.ObtenerDetalleTxt(anioMes);
        }

        public bool InsertarDetalleTf21Bulk(DataTable tabla)
        {
            DetalleTf21 detalleTf21 = new DetalleTf21();
            return detalleTf21.InsertarDetalleTf21Bulk(tabla);
        }
    }
}
