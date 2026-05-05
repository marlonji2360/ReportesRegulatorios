using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleDv17TmpController
    {
        public DataTable ObtenerDetalleTempCsv(int anioMes, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.ObtenerDetalleTmpCsv(anioMes, tipoConexion);
        }

        public bool InsertarDetalleTempDv17(DataTable tabla, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.InsertarDetalleDv17Tmp(tabla, tipoConexion);
        }

        public bool InsertarDetalleDv17TmpBulk(DataTable tabla, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.InsertarDetalleDv17TmpBulk(tabla, tipoConexion);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.ValidacionCantidadRegistros(anioMes, tipoConexion);
        }

        public DataTable ValidacionConteoDetalle(int anioMes, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.ValidacionConteoDetalle(anioMes, tipoConexion);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.ValidacionCampoJustificacion(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalleTmp(int anioMes, string tipoConexion)
        {
            DetalleDv17Temp detalleDv17Temp = new DetalleDv17Temp();
            return detalleDv17Temp.EliminarCamposDetalleTmp(anioMes, tipoConexion);
        }
    }
}
