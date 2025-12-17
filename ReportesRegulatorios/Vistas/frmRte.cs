using ClosedXML.Excel;
using Microsoft.Win32;
using ReportesRegulatorios.Controladores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesRegulatorios.Vistas
{
    public partial class frmRte : Form
    {
        public frmRte()
        {
            InitializeComponent();

            btnNuevosRegistros.BackColor = Color.DarkGray;
            btnVerificarModificaciones.BackColor = Color.DarkGray;
            btnBitacoras.BackColor = Color.DarkGray;
            btnGeneraCsv.BackColor = Color.DarkGray;
            btnArchivoIve.BackColor = Color.DarkGray;
            btnFinalizar.BackColor = Color.DarkGray;

            btnNuevosRegistros.Enabled = false;
            btnVerificarModificaciones.Enabled = false;
            btnBitacoras.Enabled = false;
            btnGeneraCsv.Enabled = false;
            btnArchivoIve.Enabled = false;
            btnFinalizar.Enabled = false;
        }

        private void HabilitarBotonoes()
        {
            //btnNuevosRegistros.BackColor = Color.DarkBlue;
            //btnVerificarModificaciones.BackColor = Color.DarkBlue;
            //btnBitacoras.BackColor = Color.DarkBlue;
            btnGeneraCsv.BackColor = Color.DarkBlue;
            btnArchivoIve.BackColor = Color.DarkBlue;
            //btnFinalizar.BackColor = Color.Red;
            btnConsultar.BackColor = Color.DarkBlue;
            //btnNuevosRegistros.Enabled = true;
            //btnVerificarModificaciones.Enabled = true;
            //btnBitacoras.Enabled = true;
            btnGeneraCsv.Enabled = true;
            btnArchivoIve.Enabled = true;
            //btnFinalizar.Enabled = true;
            btnConsultar.Enabled = true;
        }

        private void CalcularEstado(string dtEstado)
        {
            switch (dtEstado)
            {
                case "F":
                    lblEstado.BackColor = Color.Red;
                    lblEstado.ForeColor = Color.White;
                    lblEstado.Text = "Periodo Cerrado";
                    HabilitarBotonoes();
                    btnFinalizar.Enabled = false;
                    btnFinalizar.BackColor = Color.LightGray;
                    btnNuevosRegistros.Enabled = false;
                    btnNuevosRegistros.BackColor = Color.LightGray;
                    btnVerificarModificaciones.Enabled = false;
                    btnVerificarModificaciones.BackColor = Color.LightGray;
                    break;
                case "G":
                    lblEstado.BackColor = Color.Green;
                    lblEstado.ForeColor = Color.White;
                    lblEstado.Text = "Generado";
                    HabilitarBotonoes();
                    break;
                case "V":
                    lblEstado.BackColor = Color.Orange;
                    lblEstado.ForeColor = Color.White;
                    lblEstado.Text = "En Verificación";
                    HabilitarBotonoes();
                    break;
            }
        }
        private void NombreMes(string dtMes)
        {
            switch (dtMes)
            {
                case "01":
                    dtMes = "Enero";
                    break;
                case "02":
                    dtMes = "Febrero";
                    break;
                case "03":
                    dtMes = "Marzo";
                    break;
                case "04":
                    dtMes = "Abril";
                    break;
                case "05":
                    dtMes = "Mayo";
                    break;
                case "06":
                    dtMes = "Junio";
                    break;
                case "07":
                    dtMes = "Julio";
                    break;
                case "08":
                    dtMes = "Agosto";
                    break;
                case "09":
                    dtMes = "Septiembre";
                    break;
                case "10":
                    dtMes = "Octubre";
                    break;
                case "11":
                    dtMes = "Noviembre";
                    break;
                case "12":
                    dtMes = "Diciembre";
                    break;
            }

            cmbMes.Text = dtMes;
        }

        private string NumeroMes(string nombreMes)
        {
            string numeroMes = "00";
            switch (cmbMes.Text)
            {
                case "Enero":
                    numeroMes = "01";
                    break;
                case "Febrero":
                    numeroMes = "02";
                    break;
                case "Marzo":
                    numeroMes = "03";
                    break;
                case "Abril":
                    numeroMes = "04";
                    break;
                case "Mayo":
                    numeroMes = "05";
                    break;
                case "Junio":
                    numeroMes = "06";
                    break;
                case "Julio":
                    numeroMes = "07";
                    break;
                case "Agosto":
                    numeroMes = "08";
                    break;
                case "Septiembre":
                    numeroMes = "09";
                    break;
                case "Octubre":
                    numeroMes = "10";
                    break;
                case "Noviembre":
                    numeroMes = "11";
                    break;
                case "Diciembre":
                    numeroMes = "12";
                    break;
            }
            return numeroMes;
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

        private Boolean Consultar()
        {
            //DeshabilitarBotones();
            btnConsultar.BackColor = Color.DarkBlue;
            btnConsultar.Enabled = true;

            if (cmbMes.Text != "" && txtAnio.Text != "")
            {
                string mes = "00";
                string anioMes;
                DataTable dt = new DataTable();
                mes = NumeroMes(cmbMes.Text);
                anioMes = txtAnio.Text + mes;

                EncaRteController encaRteController = new EncaRteController();
                dt = encaRteController.ObtenerEncabezado(Convert.ToInt32(anioMes));
                if (dt.Rows.Count > 0)
                {


                    string dtAnioMes = dt.Rows[0]["AnioMes"].ToString();
                    string dtEstado = dt.Rows[0]["Estado"].ToString();
                    string dtUsuario_genera = dt.Rows[0]["Usuario_genera"].ToString();
                    string dtFecha_genera = dt.Rows[0]["Fecha_genera"].ToString();
                    string dtUsuario_upd = dt.Rows[0]["Usuario_upd"].ToString();
                    string dtFecha_upd = dt.Rows[0]["Fecha_upd"].ToString();
                    string dtUsuario_Cierre = dt.Rows[0]["Usuario_Cierre"].ToString();
                    string dtFecha_Cierre = dt.Rows[0]["Fecha_Cierre"].ToString();
                    string dtDoc_cierre = dt.Rows[0]["Doc_cierre"].ToString();
                    string dtAnio = dtAnioMes.Substring(0, 4);
                    string dtMes = dtAnioMes.Substring(4, 2);

                    NombreMes(dtMes);
                    CalcularEstado(dtEstado);




                    txtAnio.Text = dtAnio;

                    txtFechaOperado.Text = dtFecha_genera;
                    txtUsuarioOperado.Text = dtUsuario_genera;
                    txtFechaUltimaMod.Text = dtFecha_upd;
                    txtUsuarioUltimaMod.Text = dtUsuario_upd;
                    txtFechaFinalizado.Text = dtFecha_Cierre;
                    txtUsuarioFinalizado.Text = dtUsuario_Cierre;
                    txtLink.Text = dtDoc_cierre;

                    return true;

                    //HabilitarBotonoes();

                }
                else
                {
                    MessageBox.Show("No se encontraron datos para la fecha indicada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Limpiar();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Debe de ingresar los datos de consulta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Limpiar();
                return false;
            }

        }

        private void Limpiar()
        {
            txtUsuarioOperado.Text = "";
            txtFechaOperado.Text = "";
            txtFechaUltimaMod.Text = "";
            txtUsuarioUltimaMod.Text = "";
            txtFechaFinalizado.Text = "";
            txtUsuarioFinalizado.Text = "";
            lblEstado.Text = "";
        }

        private void DeshabilitarBotones()
        {
            btnNuevosRegistros.BackColor = Color.DarkGray;
            btnVerificarModificaciones.BackColor = Color.DarkGray;
            btnBitacoras.BackColor = Color.DarkGray;
            btnGeneraCsv.BackColor = Color.DarkGray;
            btnArchivoIve.BackColor = Color.DarkGray;
            btnFinalizar.BackColor = Color.DarkGray;
            btnConsultar.BackColor = Color.DarkGray;
            btnNuevosRegistros.Enabled = false;
            btnVerificarModificaciones.Enabled = false;
            btnBitacoras.Enabled = false;
            btnGeneraCsv.Enabled = false;
            btnArchivoIve.Enabled = false;
            btnFinalizar.Enabled = false;
            btnConsultar.Enabled = false;
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

        private void ExportarDataTableATxt(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count <= 0)
            {
                PlayNotificationSound();
                MessageBox.Show("No hay suficientes datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo de texto (*.txt)|*.txt";
                sfd.FileName = "Resultado.txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = sfd.FileName;

                try
                {
                    // Si ya existe, eliminarlo
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    StringBuilder sb = new StringBuilder();

                    // Exportar desde la fila 2 (índice 1)
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow row = dataTable.Rows[i];
                        var fields = row.ItemArray.Select(field => field?.ToString()?.Replace("\r", "").Replace("\n", "").Trim());
                        sb.AppendLine(string.Join("|", fields));
                    }

                    File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);

                    PlayNotificationSound();
                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ioEx)
                {
                    PlayNotificationSound();
                    MessageBox.Show("Error de archivo: " + ioEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    PlayNotificationSound();
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Boolean consultar = false;
            consultar = Consultar();

            if (!consultar)
            {
                DeshabilitarBotones();
                btnConsultar.Enabled = true;
                btnConsultar.BackColor = Color.DarkBlue;
            }
        }

        private async void btnGeneraCsv_Click(object sender, EventArgs e)
        {
            if (cmbMes.Text != "" && txtAnio.Text != "")
            {
                DeshabilitarBotones();
                string anioMes = null;
                string mes = null;
                DataTable dt = new DataTable();
                DetalleRteController detalleRteController = new DetalleRteController();

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;

                frmCargando cargando = new frmCargando("descargando Excel...");
                cargando.Show();

                await Task.Run(() =>
                {
                    dt = detalleRteController.ObtenerDetalleCsv(Convert.ToInt32(anioMes));
                });

                cargando.Close();

                //ExportarDataTableACsv(dt);
                ExportarDataTableAExcel(dt);




            }
            Consultar();
        }

        private async void btnArchivoIve_Click(object sender, EventArgs e)
        {
            if (cmbMes.Text != "" && txtAnio.Text != "")
            {
                DeshabilitarBotones();
                string anioMes = null;
                string mes = null;
                DataTable dt = new DataTable();
                DetalleRteController detalleRteController = new DetalleRteController();

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;

                frmCargando cargando = new frmCargando("Generando archivo TXT...");
                cargando.Show();

                await Task.Run(() =>
                {
                    dt = detalleRteController.ObtenerDetalleTxt(Convert.ToInt32(anioMes));
                });

                ExportarDataTableATxt(dt);

                cargando.Close();


            }
            Consultar();
        }
    }
}
