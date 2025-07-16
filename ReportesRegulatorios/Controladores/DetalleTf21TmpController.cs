using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleTf21TmpController
    {
        public DataTable ObtenerDetalleTempCsv(int anioMes)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ObtenerDetalleTmpCsv(anioMes);
        }

        public bool InsertarDetalleTf21TmpBulk(DataTable tabla)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.InsertarDetalleTf21TmpBulk(tabla);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionCantidadRegistros(anioMes);
        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionConteoDetalle(anioMes);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionCampoJustificacion(anioMes);
        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.EliminarCamposDetalleTmp(anioMes);
        }
    }
}
