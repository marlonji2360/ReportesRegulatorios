using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleDv17Controller
    {
        public DataTable ObtenerDetalleCsv (int anioMes)
        {
            DetalleDv17 detalleDv17 = new DetalleDv17 ();
            return detalleDv17.ObtenerDetalleCsv(anioMes);
        }

        public DataTable ObtenerDetalleTxt(int anioMes)
        {
            DetalleDv17 detalleDv17 = new DetalleDv17();
            return detalleDv17.ObtenerDetalleTxt(anioMes);
        }

        public bool InsertarDetalleDv17(DataTable tabla)
        {
            DetalleDv17 detalleDv17 = new DetalleDv17 ();
            return detalleDv17.InsertarDetalleDv17 (tabla);
        }

        public bool InsertarDetalleDv17Bulk(DataTable tabla)
        {
            DetalleDv17 detalleDv17 = new DetalleDv17();
            return detalleDv17.InsertarDetalleDv17Bulk(tabla);
        }
    }
}
