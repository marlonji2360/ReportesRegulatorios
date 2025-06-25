using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesRegulatorios.Vistas
{
    public partial class frmRegProblemas : Form
    {
        public frmRegProblemas(DataTable data)
        {
            InitializeComponent();
            dgvListado.DataSource = data;
        }

        private void frmListadoRegistrosProblemas_Load(object sender, EventArgs e)
        {

        }
    }
}
