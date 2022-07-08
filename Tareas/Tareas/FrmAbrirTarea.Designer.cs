
namespace Vista
{
    partial class FrmAbrirTarea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbrirTarea));
            this.rTxtContenidoTarea = new System.Windows.Forms.RichTextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cBoxRecordatorio = new System.Windows.Forms.CheckBox();
            this.cmbBoxEstado = new System.Windows.Forms.ComboBox();
            this.lblFechaFinal = new System.Windows.Forms.Label();
            this.btnFechaInicial = new System.Windows.Forms.Button();
            this.btnFechaFinal = new System.Windows.Forms.Button();
            this.lblFechaInicial = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblEstadoTarea = new System.Windows.Forms.Label();
            this.lblContenidoTarea = new System.Windows.Forms.Label();
            this.btnColorLetra = new System.Windows.Forms.Button();
            this.btnRestaurarTema = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbBoxPrioridad = new System.Windows.Forms.ComboBox();
            this.lblPrioridadTarea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rTxtContenidoTarea
            // 
            this.rTxtContenidoTarea.BackColor = System.Drawing.Color.White;
            this.rTxtContenidoTarea.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rTxtContenidoTarea.Location = new System.Drawing.Point(12, 50);
            this.rTxtContenidoTarea.Name = "rTxtContenidoTarea";
            this.rTxtContenidoTarea.Size = new System.Drawing.Size(575, 320);
            this.rTxtContenidoTarea.TabIndex = 0;
            this.rTxtContenidoTarea.TabStop = false;
            this.rTxtContenidoTarea.Text = "";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregar.Location = new System.Drawing.Point(397, 708);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(190, 45);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Aceptar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cBoxRecordatorio
            // 
            this.cBoxRecordatorio.AutoSize = true;
            this.cBoxRecordatorio.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cBoxRecordatorio.Location = new System.Drawing.Point(11, 579);
            this.cBoxRecordatorio.Name = "cBoxRecordatorio";
            this.cBoxRecordatorio.Size = new System.Drawing.Size(263, 33);
            this.cBoxRecordatorio.TabIndex = 2;
            this.cBoxRecordatorio.TabStop = false;
            this.cBoxRecordatorio.Text = "Activar recordatorio";
            this.cBoxRecordatorio.UseVisualStyleBackColor = true;
            // 
            // cmbBoxEstado
            // 
            this.cmbBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxEstado.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbBoxEstado.FormattingEnabled = true;
            this.cmbBoxEstado.Location = new System.Drawing.Point(333, 459);
            this.cmbBoxEstado.Name = "cmbBoxEstado";
            this.cmbBoxEstado.Size = new System.Drawing.Size(254, 35);
            this.cmbBoxEstado.TabIndex = 3;
            this.cmbBoxEstado.TabStop = false;
            // 
            // lblFechaFinal
            // 
            this.lblFechaFinal.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFechaFinal.Location = new System.Drawing.Point(333, 640);
            this.lblFechaFinal.Name = "lblFechaFinal";
            this.lblFechaFinal.Size = new System.Drawing.Size(254, 38);
            this.lblFechaFinal.TabIndex = 4;
            this.lblFechaFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFechaInicial
            // 
            this.btnFechaInicial.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechaInicial.Location = new System.Drawing.Point(12, 386);
            this.btnFechaInicial.Name = "btnFechaInicial";
            this.btnFechaInicial.Size = new System.Drawing.Size(300, 50);
            this.btnFechaInicial.TabIndex = 5;
            this.btnFechaInicial.TabStop = false;
            this.btnFechaInicial.Text = "Fecha inicial (opcional)";
            this.btnFechaInicial.UseVisualStyleBackColor = true;
            this.btnFechaInicial.Click += new System.EventHandler(this.btnFechaInicial_Click);
            // 
            // btnFechaFinal
            // 
            this.btnFechaFinal.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFechaFinal.Location = new System.Drawing.Point(11, 634);
            this.btnFechaFinal.Name = "btnFechaFinal";
            this.btnFechaFinal.Size = new System.Drawing.Size(300, 50);
            this.btnFechaFinal.TabIndex = 6;
            this.btnFechaFinal.TabStop = false;
            this.btnFechaFinal.Text = "Fecha final (opcional)";
            this.btnFechaFinal.UseVisualStyleBackColor = true;
            this.btnFechaFinal.Click += new System.EventHandler(this.btnFechaFinal_Click);
            // 
            // lblFechaInicial
            // 
            this.lblFechaInicial.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFechaInicial.Location = new System.Drawing.Point(333, 392);
            this.lblFechaInicial.Name = "lblFechaInicial";
            this.lblFechaInicial.Size = new System.Drawing.Size(254, 38);
            this.lblFechaInicial.TabIndex = 7;
            this.lblFechaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnColor
            // 
            this.btnColor.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnColor.Location = new System.Drawing.Point(331, 573);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(125, 46);
            this.btnColor.TabIndex = 9;
            this.btnColor.TabStop = false;
            this.btnColor.Text = "Color tarea";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblEstadoTarea
            // 
            this.lblEstadoTarea.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEstadoTarea.Location = new System.Drawing.Point(12, 455);
            this.lblEstadoTarea.Name = "lblEstadoTarea";
            this.lblEstadoTarea.Size = new System.Drawing.Size(301, 41);
            this.lblEstadoTarea.TabIndex = 10;
            this.lblEstadoTarea.Text = "Estado de la tarea:";
            this.lblEstadoTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblContenidoTarea
            // 
            this.lblContenidoTarea.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblContenidoTarea.Location = new System.Drawing.Point(12, 9);
            this.lblContenidoTarea.Name = "lblContenidoTarea";
            this.lblContenidoTarea.Size = new System.Drawing.Size(267, 38);
            this.lblContenidoTarea.TabIndex = 11;
            this.lblContenidoTarea.Text = "Tarea:";
            // 
            // btnColorLetra
            // 
            this.btnColorLetra.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnColorLetra.Location = new System.Drawing.Point(462, 573);
            this.btnColorLetra.Name = "btnColorLetra";
            this.btnColorLetra.Size = new System.Drawing.Size(125, 46);
            this.btnColorLetra.TabIndex = 12;
            this.btnColorLetra.TabStop = false;
            this.btnColorLetra.Text = "Color letra";
            this.btnColorLetra.UseVisualStyleBackColor = true;
            this.btnColorLetra.Click += new System.EventHandler(this.btnColorLetra_Click);
            // 
            // btnRestaurarTema
            // 
            this.btnRestaurarTema.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRestaurarTema.Location = new System.Drawing.Point(369, 9);
            this.btnRestaurarTema.Name = "btnRestaurarTema";
            this.btnRestaurarTema.Size = new System.Drawing.Size(218, 36);
            this.btnRestaurarTema.TabIndex = 13;
            this.btnRestaurarTema.TabStop = false;
            this.btnRestaurarTema.Text = "Restablecer tema";
            this.btnRestaurarTema.UseVisualStyleBackColor = true;
            this.btnRestaurarTema.Click += new System.EventHandler(this.btnRestaurarTema_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(11, 708);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(190, 45);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmbBoxPrioridad
            // 
            this.cmbBoxPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxPrioridad.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbBoxPrioridad.FormattingEnabled = true;
            this.cmbBoxPrioridad.Location = new System.Drawing.Point(333, 514);
            this.cmbBoxPrioridad.Name = "cmbBoxPrioridad";
            this.cmbBoxPrioridad.Size = new System.Drawing.Size(254, 35);
            this.cmbBoxPrioridad.TabIndex = 14;
            this.cmbBoxPrioridad.TabStop = false;
            // 
            // lblPrioridadTarea
            // 
            this.lblPrioridadTarea.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrioridadTarea.Location = new System.Drawing.Point(12, 510);
            this.lblPrioridadTarea.Name = "lblPrioridadTarea";
            this.lblPrioridadTarea.Size = new System.Drawing.Size(301, 41);
            this.lblPrioridadTarea.TabIndex = 15;
            this.lblPrioridadTarea.Text = "Prioridad de la tarea:";
            this.lblPrioridadTarea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmAbrirTarea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 765);
            this.Controls.Add(this.lblPrioridadTarea);
            this.Controls.Add(this.cmbBoxPrioridad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnRestaurarTema);
            this.Controls.Add(this.btnColorLetra);
            this.Controls.Add(this.lblContenidoTarea);
            this.Controls.Add(this.lblEstadoTarea);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblFechaInicial);
            this.Controls.Add(this.btnFechaFinal);
            this.Controls.Add(this.btnFechaInicial);
            this.Controls.Add(this.lblFechaFinal);
            this.Controls.Add(this.cmbBoxEstado);
            this.Controls.Add(this.cBoxRecordatorio);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.rTxtContenidoTarea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbrirTarea";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgregarTarea_FormClosing);
            this.Load += new System.EventHandler(this.FrmAgregarTarea_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtContenidoTarea;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.CheckBox cBoxRecordatorio;
        private System.Windows.Forms.ComboBox cmbBoxEstado;
        private System.Windows.Forms.Label lblFechaFinal;
        private System.Windows.Forms.Button btnFechaInicial;
        private System.Windows.Forms.Button btnFechaFinal;
        private System.Windows.Forms.Label lblFechaInicial;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblEstadoTarea;
        private System.Windows.Forms.Label lblContenidoTarea;
        private System.Windows.Forms.Button btnColorLetra;
        private System.Windows.Forms.Button btnRestaurarTema;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbBoxPrioridad;
        private System.Windows.Forms.Label lblPrioridadTarea;
    }
}