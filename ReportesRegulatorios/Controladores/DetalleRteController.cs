using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    public class DetalleRteController
    {
        public DataTable ObtenerDetalleCsv(int anioMes)
        {
            DetalleRte detalleRte = new DetalleRte();
            return detalleRte.ObtenerDetalleCsv(anioMes);
        }

        public DataTable ObtenerDetalleTxt(int anioMes)
        {
            DetalleRte detalleRte = new DetalleRte();
            return detalleRte.ObtenerDetalleTxt(anioMes);
        }

        public bool InsertarDetalleBa12Bulk(DataTable tabla)
        {
            DetalleRte detalleRte = new DetalleRte();
            return detalleRte.InsertarDetalleBa12Bulk(tabla);
        }
    }
}
