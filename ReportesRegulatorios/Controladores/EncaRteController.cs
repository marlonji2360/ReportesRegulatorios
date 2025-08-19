using ReportesRegulatorios.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportesRegulatorios.Controladores
{
    public class EncaRteController
    {
        public DataTable ObtenerEncabezado(int anioMes)
        {
            EncaRte encaRte = new EncaRte();
            return encaRte.ObtenerEncabezado(anioMes);
        }

        public bool ActualizarEncabezado(int anioMes,
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
            EncaRte encaRte = new EncaRte();
            return encaRte.ActualizarEncabezado(anioMes, estado, Usuario_genera, Fecha_genera, Usuario_upd, Fecha_upd, Usuario_Cierre, Fecha_Cierre, Doc_cierre);
        }
    }
}
