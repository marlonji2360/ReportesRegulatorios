namespace ReportesRegulatorios.Vistas
{
    partial class frmDv17
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDv17));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaOperado = new System.Windows.Forms.TextBox();
            this.txtUsuarioOperado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuarioUltimaMod = new System.Windows.Forms.TextBox();
            this.txtFechaUltimaMod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUsuarioFinalizado = new System.Windows.Forms.TextBox();
            this.txtFechaFinalizado = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGeneraCsv = new System.Windows.Forms.Button();
            this.btnArchivoIve = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnNuevosRegistros = new System.Windows.Forms.Button();
            this.btnVerificarModificaciones = new System.Windows.Forms.Button();
            this.btnBitacoras = new System.Windows.Forms.Button();
            this.btnCopiarConclusion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(207, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "REPORTE REGULATORIO DV-17";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(245, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(245, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label4.Location = new System.Drawing.Point(220, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estado";
            // 
            // cmbMes
            // 
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Location = new System.Drawing.Point(298, 63);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(121, 21);
            this.cmbMes.TabIndex = 4;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(298, 90);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(121, 20);
            this.txtAnio.TabIndex = 5;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnConsultar.Location = new System.Drawing.Point(460, 64);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(92, 37);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Lime;
            this.lblEstado.Location = new System.Drawing.Point(303, 125);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 20);
            this.lblEstado.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label5.Location = new System.Drawing.Point(202, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Link Doc.";
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(298, 159);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(254, 20);
            this.txtLink.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label6.Location = new System.Drawing.Point(208, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Operado";
            // 
            // txtFechaOperado
            // 
            this.txtFechaOperado.Enabled = false;
            this.txtFechaOperado.Location = new System.Drawing.Point(304, 235);
            this.txtFechaOperado.Name = "txtFechaOperado";
            this.txtFechaOperado.Size = new System.Drawing.Size(121, 20);
            this.txtFechaOperado.TabIndex = 11;
            // 
            // txtUsuarioOperado
            // 
            this.txtUsuarioOperado.Enabled = false;
            this.txtUsuarioOperado.Location = new System.Drawing.Point(431, 235);
            this.txtUsuarioOperado.Name = "txtUsuarioOperado";
            this.txtUsuarioOperado.Size = new System.Drawing.Size(121, 20);
            this.txtUsuarioOperado.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label7.Location = new System.Drawing.Point(306, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Fecha";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label8.Location = new System.Drawing.Point(433, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Usuario";
            // 
            // txtUsuarioUltimaMod
            // 
            this.txtUsuarioUltimaMod.Enabled = false;
            this.txtUsuarioUltimaMod.Location = new System.Drawing.Point(431, 264);
            this.txtUsuarioUltimaMod.Name = "txtUsuarioUltimaMod";
            this.txtUsuarioUltimaMod.Size = new System.Drawing.Size(121, 20);
            this.txtUsuarioUltimaMod.TabIndex = 17;
            // 
            // txtFechaUltimaMod
            // 
            this.txtFechaUltimaMod.Enabled = false;
            this.txtFechaUltimaMod.Location = new System.Drawing.Point(304, 264);
            this.txtFechaUltimaMod.Name = "txtFechaUltimaMod";
            this.txtFechaUltimaMod.Size = new System.Drawing.Size(121, 20);
            this.txtFechaUltimaMod.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label9.Location = new System.Drawing.Point(121, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(165, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Última Modificación";
            // 
            // txtUsuarioFinalizado
            // 
            this.txtUsuarioFinalizado.Enabled = false;
            this.txtUsuarioFinalizado.Location = new System.Drawing.Point(431, 293);
            this.txtUsuarioFinalizado.Name = "txtUsuarioFinalizado";
            this.txtUsuarioFinalizado.Size = new System.Drawing.Size(121, 20);
            this.txtUsuarioFinalizado.TabIndex = 20;
            // 
            // txtFechaFinalizado
            // 
            this.txtFechaFinalizado.Enabled = false;
            this.txtFechaFinalizado.Location = new System.Drawing.Point(304, 293);
            this.txtFechaFinalizado.Name = "txtFechaFinalizado";
            this.txtFechaFinalizado.Size = new System.Drawing.Size(121, 20);
            this.txtFechaFinalizado.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.label10.Location = new System.Drawing.Point(195, 293);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Finalizado";
            // 
            // btnGeneraCsv
            // 
            this.btnGeneraCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(155)))));
            this.btnGeneraCsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGeneraCsv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneraCsv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnGeneraCsv.Location = new System.Drawing.Point(224, 438);
            this.btnGeneraCsv.Name = "btnGeneraCsv";
            this.btnGeneraCsv.Size = new System.Drawing.Size(130, 65);
            this.btnGeneraCsv.TabIndex = 21;
            this.btnGeneraCsv.Text = "Genera CSV";
            this.btnGeneraCsv.UseVisualStyleBackColor = false;
            this.btnGeneraCsv.Click += new System.EventHandler(this.btnGeneraCsv_Click);
            // 
            // btnArchivoIve
            // 
            this.btnArchivoIve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(155)))));
            this.btnArchivoIve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchivoIve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivoIve.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnArchivoIve.Location = new System.Drawing.Point(360, 438);
            this.btnArchivoIve.Name = "btnArchivoIve";
            this.btnArchivoIve.Size = new System.Drawing.Size(130, 65);
            this.btnArchivoIve.TabIndex = 22;
            this.btnArchivoIve.Text = "Archivo IVE";
            this.btnArchivoIve.UseVisualStyleBackColor = false;
            this.btnArchivoIve.Click += new System.EventHandler(this.btnArchivoIve_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnFinalizar.Location = new System.Drawing.Point(496, 438);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(130, 65);
            this.btnFinalizar.TabIndex = 23;
            this.btnFinalizar.Text = "Cerrar Periodo";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnNuevosRegistros
            // 
            this.btnNuevosRegistros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(155)))));
            this.btnNuevosRegistros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevosRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevosRegistros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnNuevosRegistros.Location = new System.Drawing.Point(224, 367);
            this.btnNuevosRegistros.Name = "btnNuevosRegistros";
            this.btnNuevosRegistros.Size = new System.Drawing.Size(130, 65);
            this.btnNuevosRegistros.TabIndex = 24;
            this.btnNuevosRegistros.Text = "Nuevos Registros";
            this.btnNuevosRegistros.UseVisualStyleBackColor = false;
            this.btnNuevosRegistros.Click += new System.EventHandler(this.btnNuevosRegistros_Click);
            // 
            // btnVerificarModificaciones
            // 
            this.btnVerificarModificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(155)))));
            this.btnVerificarModificaciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificarModificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificarModificaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnVerificarModificaciones.Location = new System.Drawing.Point(360, 367);
            this.btnVerificarModificaciones.Name = "btnVerificarModificaciones";
            this.btnVerificarModificaciones.Size = new System.Drawing.Size(130, 65);
            this.btnVerificarModificaciones.TabIndex = 25;
            this.btnVerificarModificaciones.Text = "Verificar Modificaciones";
            this.btnVerificarModificaciones.UseVisualStyleBackColor = false;
            this.btnVerificarModificaciones.Click += new System.EventHandler(this.btnVerificarModificaciones_Click);
            // 
            // btnBitacoras
            // 
            this.btnBitacoras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(155)))));
            this.btnBitacoras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBitacoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.btnBitacoras.Location = new System.Drawing.Point(496, 367);
            this.btnBitacoras.Name = "btnBitacoras";
            this.btnBitacoras.Size = new System.Drawing.Size(130, 65);
            this.btnBitacoras.TabIndex = 26;
            this.btnBitacoras.Text = "Bitacoras";
            this.btnBitacoras.UseVisualStyleBackColor = false;
            this.btnBitacoras.Click += new System.EventHandler(this.btnBitacoras_Click);
            // 
            // btnCopiarConclusion
            // 
            this.btnCopiarConclusion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopiarConclusion.Image = ((System.Drawing.Image)(resources.GetObject("btnCopiarConclusion.Image")));
            this.btnCopiarConclusion.Location = new System.Drawing.Point(580, 152);
            this.btnCopiarConclusion.Name = "btnCopiarConclusion";
            this.btnCopiarConclusion.Size = new System.Drawing.Size(33, 33);
            this.btnCopiarConclusion.TabIndex = 95;
            this.btnCopiarConclusion.UseVisualStyleBackColor = true;
            this.btnCopiarConclusion.Click += new System.EventHandler(this.btnCopiarConclusion_Click);
            // 
            // frmDv17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 539);
            this.Controls.Add(this.btnCopiarConclusion);
            this.Controls.Add(this.btnBitacoras);
            this.Controls.Add(this.btnVerificarModificaciones);
            this.Controls.Add(this.btnNuevosRegistros);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnArchivoIve);
            this.Controls.Add(this.btnGeneraCsv);
            this.Controls.Add(this.txtUsuarioFinalizado);
            this.Controls.Add(this.txtFechaFinalizado);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUsuarioUltimaMod);
            this.Controls.Add(this.txtFechaUltimaMod);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtUsuarioOperado);
            this.Controls.Add(this.txtFechaOperado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.cmbMes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDv17";
            this.Text = "Reporte DV-17";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaOperado;
        private System.Windows.Forms.TextBox txtUsuarioOperado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuarioUltimaMod;
        private System.Windows.Forms.TextBox txtFechaUltimaMod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUsuarioFinalizado;
        private System.Windows.Forms.TextBox txtFechaFinalizado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGeneraCsv;
        private System.Windows.Forms.Button btnArchivoIve;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnNuevosRegistros;
        private System.Windows.Forms.Button btnVerificarModificaciones;
        private System.Windows.Forms.Button btnBitacoras;
        private System.Windows.Forms.Button btnCopiarConclusion;
    }
}