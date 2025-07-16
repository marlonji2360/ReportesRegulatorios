using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    internal class EncaEf14Controller
    {
        public DataTable ObtenerEncabezado(int anioMes)
        {
            EncaEf14 encaEf14 = new EncaEf14();
            return encaEf14.ObtenerEncabezado(anioMes);
        }

        public bool ActualizarEncabezado(    int anioMes,
                                                string estado,
                                                string Usuario_genera,
                                                string Fecha_genera,
                                                string Usuario_upd,
                                                string Fecha_upd,
                                                string Usuario_Cierre,
                                                string Fecha_Cierre,
                                                string Doc_cierre
                                            )
        {
            EncaEf14 encaEf14 = new EncaEf14();
            return encaEf14.ActualizarEncabezado(anioMes, estado,Usuario_genera, Fecha_genera, Usuario_upd, Fecha_upd, Usuario_Cierre, Fecha_Cierre, Doc_cierre);
        }
            
    }
}
