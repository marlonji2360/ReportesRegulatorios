using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class DetalleEf14TmpController
    {
        public DataTable ObtenerDetalleTempCsv(int anioMes, string tipoConexion)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ObtenerDetalleTmpCsv(anioMes, tipoConexion);
        }

        public bool InsertarDetalleEf14TmpBulk(DataTable tabla, string tipoConexion )
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.InsertarDetalleEf14TmpBulk(tabla, tipoConexion);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes, string tipoConexion)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionCantidadRegistros(anioMes, tipoConexion);
        }

        public DataTable ValidacionConteoDetalle(int anioMes, string tipoConexion)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionConteoDetalle(anioMes, tipoConexion);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes, string tipoConexion)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionCampoJustificacion(anioMes, tipoConexion);
        }

        public bool EliminarCamposDetalleTmp(int anioMes, string tipoConexion)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.EliminarCamposDetalleTmp(anioMes, tipoConexion);
        }
    }
}
