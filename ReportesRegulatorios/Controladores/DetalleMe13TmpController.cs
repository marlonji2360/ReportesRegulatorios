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
        public DataTable ObtenerDetalleTempCsv(int anioMes, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ObtenerDetalleTmpCsv(anioMes, tipoConexion);
        }

        public bool InsertarDetalleMe13TmpBulk(DataTable tabla, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.InsertarDetalleMe13TmpBulk(tabla, tipoConexion);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionCantidadRegistros(anioMes, tipoConexion);
        }

        public DataTable ValidacionConteoDetalle(int anioMes, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionConteoDetalle(anioMes, tipoConexion);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.ValidacionCampoJustificacion(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalleTmp(int anioMes, string tipoConexion)
        {
            DetalleMe13Temp detalleMe13Tmp = new DetalleMe13Temp();
            return detalleMe13Tmp.EliminarCamposDetalleTmp(anioMes, tipoConexion);
        }
    }
}
