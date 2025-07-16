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
    public partial class frmTf21 : Form
    {
        public frmTf21()
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

        private void HabilitarBotonoes()
        {
            btnNuevosRegistros.BackColor = Color.DarkBlue;
            btnVerificarModificaciones.BackColor = Color.DarkBlue;
            btnBitacoras.BackColor = Color.DarkBlue;
            btnGeneraCsv.BackColor = Color.DarkBlue;
            btnArchivoIve.BackColor = Color.DarkBlue;
            btnFinalizar.BackColor = Color.Red;
            btnConsultar.BackColor = Color.DarkBlue;
            btnNuevosRegistros.Enabled = true;
            btnVerificarModificaciones.Enabled = true;
            btnBitacoras.Enabled = true;
            btnGeneraCsv.Enabled = true;
            btnArchivoIve.Enabled = true;
            btnFinalizar.Enabled = true;
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

        private void ExportarDataTableACsv(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = "Datos.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            PlayNotificationSound();
                            fileError = true;
                            MessageBox.Show("No es posible guardar el archivo CSV" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();

                            // Escribir encabezados
                            IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                            sb.AppendLine(string.Join(";", columnNames));

                            // Escribir filas
                            foreach (DataRow row in dataTable.Rows)
                            {
                                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                                sb.AppendLine(string.Join(";", fields));
                            }

                            File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                            PlayNotificationSound();
                            MessageBox.Show("Datos Exportados Correctamente !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            PlayNotificationSound();
                            MessageBox.Show("Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            if (dataTable == null || dataTable.Rows.Count <= 1)
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
                    for (int i = 1; i < dataTable.Rows.Count; i++)
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

        private void VerificarModificaciones(DataTable tabla, string anioMes, string usuario, string fechaActual, string usuarioOperado, string fechaOperado, string link)
        {
            EncaTf21Controller encaTf21Controller = new EncaTf21Controller();
            DetalleTf21TmpController detalleTf21TmpController = new DetalleTf21TmpController();
            DetalleTf21BitController detalleTf21BitController = new DetalleTf21BitController();
            DetalleTf21Controller detalleTf21Controller = new DetalleTf21Controller();

            bool resultado = false;

            detalleTf21TmpController.EliminarCamposDetalleTmp(Convert.ToInt32(anioMes));
            resultado = detalleTf21TmpController.InsertarDetalleTf21TmpBulk(tabla);

            DataTable validacionCantidadRegistros = detalleTf21TmpController.ValidacionCantidadRegistros(Convert.ToInt32(anioMes));
            string resultadoCantidadRegistros = validacionCantidadRegistros.Rows[0]["RESULTADO"].ToString();
            string detalleCantidadRegistros = validacionCantidadRegistros.Rows[0]["DETALLE"].ToString();

            DataTable validacionConteoDetalle = detalleTf21TmpController.ValidacionConteoDetalle(Convert.ToInt32(anioMes));
            string resultadoConteoDetalle = validacionConteoDetalle.Rows[0]["RESULTADO"].ToString();
            string detalleConteoDetalle = validacionConteoDetalle.Rows[0]["DETALLE"].ToString();

            DataTable validacionJustificacion = detalleTf21TmpController.ValidacionCampoJustificacion(Convert.ToInt32(anioMes));

            if (resultado && resultadoCantidadRegistros == "1" && resultadoConteoDetalle == "1" && validacionJustificacion.Rows.Count == 0)
            {
                PlayNotificationSound();
                MessageBox.Show("Datos Validados Correctamente, Espere mientras se guardan los cambios", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                encaTf21Controller.ActualizarEncabezado(Convert.ToInt32(anioMes), "V", usuarioOperado, fechaOperado, usuario, fechaActual, null, null, link);

                DataTable dtVerificacion = detalleTf21BitController.ObtenerCambiosBit(Convert.ToInt32(anioMes));
                detalleTf21BitController.InsertarDetalleTf21VerBitBulk(dtVerificacion, usuario);
                detalleTf21BitController.EliminarCamposDetalle(Convert.ToInt32(anioMes));

                DataTable dtNuevosRegistrosEnDetalle = detalleTf21BitController.InsertarNuevosEnDetalle(Convert.ToInt32(anioMes));
                detalleTf21Controller.InsertarDetalleTf21Bulk(dtNuevosRegistrosEnDetalle);

                PlayNotificationSound();
                MessageBox.Show("Cambios guardados correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!resultado)
            {
                PlayNotificationSound();
                MessageBox.Show("Datos NO ingresados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (resultadoCantidadRegistros == "0")
            {
                PlayNotificationSound();
                MessageBox.Show("Cantidad de Registros No Coinciden: " + detalleCantidadRegistros, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (resultadoConteoDetalle == "0")
            {
                PlayNotificationSound();
                MessageBox.Show("Cantidad de Registros No Coinciden: " + detalleConteoDetalle, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (validacionJustificacion.Rows.Count > 0)
            {
                PlayNotificationSound();
                MessageBox.Show("Cantidad de Registros Sin cambios en la justificación: " + validacionJustificacion.Rows.Count.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                frmRegProblemas frm = new frmRegProblemas(validacionJustificacion);
                frm.ShowDialog();
            }


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

                EncaTf21Controller encaTf21Controller = new EncaTf21Controller();
                dt = encaTf21Controller.ObtenerEncabezado(Convert.ToInt32(anioMes));
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

        private DataTable LeerCsvEnDataTable(string rutaArchivo)
        {
            DataTable dataTable = new DataTable();

            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                bool esPrimeraLinea = true;
                while (!reader.EndOfStream)
                {
                    string linea = reader.ReadLine();
                    string[] valores = linea.Split('|');

                    if (esPrimeraLinea)
                    {
                        foreach (string columna in valores)
                        {
                            dataTable.Columns.Add(columna);
                        }
                        esPrimeraLinea = false;
                    }
                    else
                    {
                        dataTable.Rows.Add(valores);
                    }
                }
            }

            return dataTable;
        }

        private void ProcesoNuevosRegistros(DataTable tabla, string anioMes, string usuario, string fechaActual, string usuarioOperado, string fechaOperado, string link)
        {
            DetalleTf21Controller detalleTf21Controller = new DetalleTf21Controller();
            bool resultado = detalleTf21Controller.InsertarDetalleTf21Bulk(tabla);

            if (resultado)
            {
                EncaTf21Controller encaTf21Controller = new EncaTf21Controller();
                DetalleTf21BitController detalleTf21BitController = new DetalleTf21BitController();

                encaTf21Controller.ActualizarEncabezado(Convert.ToInt32(anioMes),
                                                          "V",
                                                          usuarioOperado,
                                                          fechaOperado,
                                                          usuario,
                                                          fechaActual,
                                                          null,
                                                          null,
                                                          link);

                detalleTf21BitController.InsertarDetalleTf21BitBulk(tabla, usuario);

                PlayNotificationSound();
                MessageBox.Show("Datos Exportados Correctamente", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Consultar();
            }
            else
            {
                PlayNotificationSound();
                MessageBox.Show("Datos NO Exportados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private async void btnNuevosRegistros_Click(object sender, EventArgs e)
        {
            DeshabilitarBotones();
            DataTable tabla = null;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Selecciona un archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("¿Desea agregar los registros de este archivo?", "Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string rutaArchivo = openFileDialog.FileName;
                    tabla = LeerCsvEnDataTable(rutaArchivo);

                    if (tabla.Rows.Count > 0)
                    {
                        // ✅ Extraer información del formulario
                        string mes = NumeroMes(cmbMes.Text);
                        string anio = txtAnio.Text;
                        string anioMes = anio + mes;
                        string usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(8);
                        string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                        string usuarioOperado = string.IsNullOrEmpty(txtUsuarioOperado.Text) ? usuario : txtUsuarioOperado.Text;
                        string fechaOperado = string.IsNullOrEmpty(txtFechaOperado.Text) ? fechaActual : txtFechaOperado.Text;
                        string link = txtLink.Text;

                        frmCargando cargando = new frmCargando("Insertando nuevos registros...");
                        cargando.Show();

                        await Task.Run(() =>
                        {
                            ProcesoNuevosRegistros(tabla, anioMes, usuario, fechaActual, usuarioOperado, fechaOperado, link);
                        });

                        cargando.Close();
                    }
                    else
                    {
                        PlayNotificationSound();
                        MessageBox.Show("Archivo Sin Registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            HabilitarBotonoes();
        }

        private async void btnVerificarModificaciones_Click(object sender, EventArgs e)
        {
            DeshabilitarBotones();
            DataTable tabla = new DataTable();
            tabla = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.Title = "Selecciona un archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DialogResult res = MessageBox.Show("¿Desea validar este el arhivo?", "Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    // Acción a realizar si el usuario hace clic en Sí
                    string rutaArchivo = openFileDialog.FileName;
                    tabla = LeerCsvEnDataTable(rutaArchivo);

                    if (tabla.Rows.Count > 0)
                    {
                        string mes = NumeroMes(cmbMes.Text);
                        string anio = txtAnio.Text;
                        string anioMes = anio + mes;
                        string usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(8);
                        string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                        string usuarioOperado = string.IsNullOrEmpty(txtUsuarioOperado.Text) ? usuario : txtUsuarioOperado.Text;
                        string fechaOperado = string.IsNullOrEmpty(txtFechaOperado.Text) ? fechaActual : txtFechaOperado.Text;
                        string link = txtLink.Text;

                        frmCargando cargando = new frmCargando("Verificando modificaciones...");
                        cargando.Show();

                        await Task.Run(() =>
                        {
                            VerificarModificaciones(tabla, anioMes, usuario, fechaActual, usuarioOperado, fechaOperado, link);
                        });

                        cargando.Close();
                    }
                    else
                    {
                        PlayNotificationSound();
                        MessageBox.Show("Archivo sin registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            Consultar();
            HabilitarBotonoes();
        }

        private void btnBitacoras_Click(object sender, EventArgs e)
        {
            if (cmbMes.Text != "" && txtAnio.Text != "")
            {

                string anioMes = null;
                string mes = null;
                DataTable dt = new DataTable();
                DetalleTf21BitController detalleTf21BitController = new DetalleTf21BitController();

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;
                dt = detalleTf21BitController.ObtenerDetalleBit(Convert.ToInt32(anioMes));

                ExportarDataTableACsv(dt);

            }
        }

        private void btnGeneraCsv_Click(object sender, EventArgs e)
        {
            if (cmbMes.Text != "" && txtAnio.Text != "")
            {

                string anioMes = null;
                string mes = null;
                DataTable dt = new DataTable();
                DetalleTf21Controller detalleTf21Controller = new DetalleTf21Controller();

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;
                dt = detalleTf21Controller.ObtenerDetalleCsv(Convert.ToInt32(anioMes));

                ExportarDataTableACsv(dt);

            }
        }

        private void btnArchivoIve_Click(object sender, EventArgs e)
        {
            if (cmbMes.Text != "" && txtAnio.Text != "")
            {

                string anioMes = null;
                string mes = null;
                DataTable dt = new DataTable();
                DetalleTf21Controller detalleTf21Controller = new DetalleTf21Controller();

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;
                dt = detalleTf21Controller.ObtenerDetalleTxt(Convert.ToInt32(anioMes));

                ExportarDataTableATxt(dt);

            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (!txtLink.Text.Equals(""))
            {
                EncaTf21Controller encaTf21Controller = new EncaTf21Controller();
                string mes = "00";
                string anioMes;

                mes = NumeroMes(cmbMes.Text);

                anioMes = txtAnio.Text + mes;
                string usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Substring(8);
                string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
                string usuarioOperado = null;
                string fechaOperado = null;


                if (txtUsuarioOperado.Text == "")
                {
                    usuarioOperado = usuario;
                }
                else
                {
                    usuarioOperado = txtUsuarioOperado.Text;
                }

                if (txtFechaOperado.Text == "")
                {
                    fechaOperado = fechaActual;
                }
                else
                {
                    fechaOperado = txtFechaOperado.Text;
                }

                encaTf21Controller.ActualizarEncabezado(Convert.ToInt32(anioMes),
                                                                "F",
                                                                usuarioOperado,
                                                                fechaOperado,
                                                                usuario,
                                                                fechaActual,
                                                                usuario,
                                                                fechaActual,
                                                                txtLink.Text
                                                             );

            }
            else
            {
                PlayNotificationSound();
                MessageBox.Show("Favor ingresar el link del resguardo del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Consultar();
        }

        private void btnCopiarConclusion_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(txtLink.Text, true);
                MessageBox.Show("Texto copiado al portapapeles de Windows.",
                    "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al copiar texto al portapapeles: " +
                    Environment.NewLine + err.Message, "Error al copiar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
