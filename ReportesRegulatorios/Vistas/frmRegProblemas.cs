using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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

        private void ExportarDataTableAExcel(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "Datos.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dataTable, "Datos");
                            wb.SaveAs(sfd.FileName);
                        }

                        PlayNotificationSound();
                        MessageBox.Show("Datos Exportados Correctamente !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        PlayNotificationSound();
                        MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                PlayNotificationSound();
                MessageBox.Show("No hay datos para Exportar !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PlayNotificationSound()
        {
            bool found = false;
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default\Notification.Default\.Current"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue(null); // pass null to get (Default)
                        if (o != null)
                        {
                            SoundPlayer theSound = new SoundPlayer((String)o);
                            theSound.Play();
                            found = true;
                        }
                    }
                }
            }
            catch
            { }
            if (!found)
                SystemSounds.Beep.Play(); // consolation prize
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ExportarDataTableAExcel((DataTable)dgvListado.DataSource);
        }
    }
}
