using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleBa12TmpController
    {
        public DataTable ObtenerDetalleTempCsv(int anioMes)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ObtenerDetalleTmpCsv(anioMes);
        }

        public bool InsertarDetalleBa12TmpBulk(DataTable tabla)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.InsertarDetalleBa12TmpBulk(tabla);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionCantidadRegistros(anioMes);
        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionConteoDetalle(anioMes);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionCampoJustificacion(anioMes);
        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.EliminarCamposDetalleTmp(anioMes);
        }
    }
}
