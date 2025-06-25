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
        public DataTable ObtenerDetalleTempCsv(int anioMes)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.ObtenerDetalleTmpCsv(anioMes);
        }

        public bool InsertarDetalleTempDv17(DataTable tabla)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.InsertarDetalleDv17Tmp(tabla);
        }

        public bool InsertarDetalleDv17TmpBulk(DataTable tabla)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.InsertarDetalleDv17TmpBulk(tabla);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.ValidacionCantidadRegistros(anioMes);
        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.ValidacionConteoDetalle(anioMes);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.ValidacionCampoJustificacion(anioMes);
        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            DetalleDV17Temp detalleDv17Temp = new DetalleDV17Temp();
            return detalleDv17Temp.EliminarCamposDetalleTmp(anioMes);
        }
    }
}
