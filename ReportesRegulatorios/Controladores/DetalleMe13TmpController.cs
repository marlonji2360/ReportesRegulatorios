using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleMe13TmpController
    {
        public DataTable ObtenerDetalleTempCsv(int anioMes)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ObtenerDetalleTmpCsv(anioMes);
        }

        public bool InsertarDetalleMe13TmpBulk(DataTable tabla)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.InsertarDetalleMe13TmpBulk(tabla);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionCantidadRegistros(anioMes);
        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionConteoDetalle(anioMes);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionCampoJustificacion(anioMes);
        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.EliminarCamposDetalleTmp(anioMes);
        }
    }
}
