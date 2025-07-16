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
        public DataTable ObtenerDetalleTempCsv(int anioMes)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ObtenerDetalleTmpCsv(anioMes);
        }

        public bool InsertarDetalleEf14TmpBulk(DataTable tabla)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.InsertarDetalleEf14TmpBulk(tabla);
        }

        public DataTable ValidacionCantidadRegistros(int anioMes)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionCantidadRegistros(anioMes);
        }

        public DataTable ValidacionConteoDetalle(int anioMes)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionConteoDetalle(anioMes);
        }

        public DataTable ValidacionCampoJustificacion(int anioMes)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.ValidacionCampoJustificacion(anioMes);
        }

        public bool EliminarCamposDetalleTmp(int anioMes)
        {
            DetalleEf14Temp detalleEf14Tmp = new DetalleEf14Temp();
            return detalleEf14Tmp.EliminarCamposDetalleTmp(anioMes);
        }
    }
}
