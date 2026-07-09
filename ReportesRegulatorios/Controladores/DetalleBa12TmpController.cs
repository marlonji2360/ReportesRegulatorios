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
        public DataTable ObtenerDetalleTempCsv(int anioMes, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ObtenerDetalleTmpCsv(anioMes, tipoConexion);
        }

        public bool InsertarDetalleBa12TmpBulk(DataTable tabla, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.InsertarDetalleBa12TmpBulk(tabla, tipoConexion);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionCantidadRegistros(anioMes, tipoConexion);
        }

        public DataTable ValidacionConteoDetalle(int anioMes, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionConteoDetalle(anioMes, tipoConexion);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.ValidacionCampoJustificacion(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalleTmp(int anioMes, string tipoConexion)
        {
            DetalleBa12Temp detalleBa12Tmp = new DetalleBa12Temp();
            return detalleBa12Tmp.EliminarCamposDetalleTmp(anioMes, tipoConexion);
        }
    }
}
