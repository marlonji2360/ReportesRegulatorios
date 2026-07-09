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
        public DataTable ObtenerDetalleTempCsv(int anioMes, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ObtenerDetalleTmpCsv(anioMes, tipoConexion);
        }

        public bool InsertarDetalleTf21TmpBulk(DataTable tabla, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.InsertarDetalleTf21TmpBulk(tabla, tipoConexion);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionCantidadRegistros(anioMes, tipoConexion);
        }

        public DataTable ValidacionConteoDetalle(int anioMes, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionConteoDetalle(anioMes, tipoConexion);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.ValidacionCampoJustificacion(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalleTmp(int anioMes, string tipoConexion)
        {
            DetalleTf21Temp detalleTf21Tmp = new DetalleTf21Temp();
            return detalleTf21Tmp.EliminarCamposDetalleTmp(anioMes, tipoConexion);
        }
    }
}
