using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ReportesRegulatorios.Vistas
{
    public partial class frmCargando : Form
    {
        public frmCargando(string mensaje = "Procesando, por favor espere...")
        {
            InitializeComponent();
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 30;

            lblMensaje.Text = mensaje;
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            
        }
    }
}
