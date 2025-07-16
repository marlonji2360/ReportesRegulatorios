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
    public partial class frmPantallaPrincipal : Form
    {
        public frmPantallaPrincipal()
        {
            InitializeComponent();
        }

        private void AbrirFormularioEnPanel(Form formularioHijo)
        {
            // Si ya hay un formulario abierto en el panel, lo cerramos.
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            // Configuramos el formulario hijo para que se comporte como un control.
            formularioHijo.TopLevel = false; // Importante: permite que sea un control secundario.
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // Le quitamos los bordes.
            formularioHijo.Dock = DockStyle.Fill; // Hacemos que ocupe todo el espacio del panel.

            // Lo agregamos al panel.
            this.panelContenedor.Controls.Add(formularioHijo);
            this.panelContenedor.Tag = formularioHijo;

            // Lo mostramos.
            formularioHijo.Show();
        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void lblBa12_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmBa12());
        }

        private void lblEf14_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmEf14());
        }

        private void lblDv17_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmDv17());
        }

        private void lblTf21_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmTf21());
        }

        private void lblMe13_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frmMe13());
        }
    }
}
