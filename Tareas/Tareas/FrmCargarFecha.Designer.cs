
namespace Vista
{
    partial class FrmCargarFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarFecha));
            this.lblAnio = new System.Windows.Forms.Label();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtDia = new System.Windows.Forms.TextBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.txtMes = new System.Windows.Forms.TextBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.txtHora = new System.Windows.Forms.TextBox();
            this.lblHora = new System.Windows.Forms.Label();
            this.txtMinutos = new System.Windows.Forms.TextBox();
            this.lblMinutos = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnQuitarFecha = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.calendario = new System.Windows.Forms.MonthCalendar();
            this.btnHoy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAnio
            // 
            this.lblAnio.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAnio.Location = new System.Drawing.Point(15, 15);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(120, 30);
            this.lblAnio.TabIndex = 0;
            this.lblAnio.Text = "Año:";
            // 
            // txtAnio
            // 
            this.txtAnio.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtAnio.Location = new System.Drawing.Point(163, 11);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(155, 34);
            this.txtAnio.TabIndex = 1;
            this.txtAnio.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtDia
            // 
            this.txtDia.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtDia.Location = new System.Drawing.Point(163, 111);
            this.txtDia.MaxLength = 2;
            this.txtDia.Name = "txtDia";
            this.txtDia.Size = new System.Drawing.Size(155, 34);
            this.txtDia.TabIndex = 3;
            this.txtDia.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblDia
            // 
            this.lblDia.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDia.Location = new System.Drawing.Point(15, 114);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(120, 30);
            this.lblDia.TabIndex = 2;
            this.lblDia.Text = "Día:";
            // 
            // txtMes
            // 
            this.txtMes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMes.Location = new System.Drawing.Point(163, 62);
            this.txtMes.MaxLength = 2;
            this.txtMes.Name = "txtMes";
            this.txtMes.Size = new System.Drawing.Size(155, 34);
            this.txtMes.TabIndex = 5;
            this.txtMes.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblMes
            // 
            this.lblMes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMes.Location = new System.Drawing.Point(15, 65);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(120, 30);
            this.lblMes.TabIndex = 4;
            this.lblMes.Text = "Mes:";
            // 
            // txtHora
            // 
            this.txtHora.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtHora.Location = new System.Drawing.Point(163, 162);
            this.txtHora.MaxLength = 2;
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(155, 34);
            this.txtHora.TabIndex = 7;
            this.txtHora.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblHora
            // 
            this.lblHora.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHora.Location = new System.Drawing.Point(15, 165);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(120, 30);
            this.lblHora.TabIndex = 6;
            this.lblHora.Text = "Hora:";
            // 
            // txtMinutos
            // 
            this.txtMinutos.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtMinutos.Location = new System.Drawing.Point(163, 209);
            this.txtMinutos.MaxLength = 2;
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(155, 34);
            this.txtMinutos.TabIndex = 9;
            this.txtMinutos.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblMinutos
            // 
            this.lblMinutos.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMinutos.Location = new System.Drawing.Point(15, 212);
            this.lblMinutos.Name = "lblMinutos";
            this.lblMinutos.Size = new System.Drawing.Size(120, 30);
            this.lblMinutos.TabIndex = 8;
            this.lblMinutos.Text = "Minutos:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAceptar.Location = new System.Drawing.Point(399, 342);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(170, 40);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(12, 342);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(170, 40);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnQuitarFecha
            // 
            this.btnQuitarFecha.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuitarFecha.Location = new System.Drawing.Point(205, 342);
            this.btnQuitarFecha.Name = "btnQuitarFecha";
            this.btnQuitarFecha.Size = new System.Drawing.Size(170, 40);
            this.btnQuitarFecha.TabIndex = 13;
            this.btnQuitarFecha.Text = "Quitar fecha";
            this.btnQuitarFecha.UseVisualStyleBackColor = true;
            this.btnQuitarFecha.Click += new System.EventHandler(this.btnQuitarFecha_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpiarCampos.Location = new System.Drawing.Point(349, 58);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(220, 40);
            this.btnLimpiarCampos.TabIndex = 14;
            this.btnLimpiarCampos.Text = "Limpiar";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // calendario
            // 
            this.calendario.Location = new System.Drawing.Point(349, 114);
            this.calendario.Name = "calendario";
            this.calendario.TabIndex = 16;
            this.calendario.TabStop = false;
            this.calendario.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calendario_DateChanged);
            // 
            // btnHoy
            // 
            this.btnHoy.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnHoy.Location = new System.Drawing.Point(349, 7);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(220, 40);
            this.btnHoy.TabIndex = 17;
            this.btnHoy.Text = "Ahora";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // FrmCargarFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 396);
            this.Controls.Add(this.btnHoy);
            this.Controls.Add(this.calendario);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnQuitarFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtMinutos);
            this.Controls.Add(this.lblMinutos);
            this.Controls.Add(this.txtHora);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.txtMes);
            this.Controls.Add(this.lblMes);
            this.Controls.Add(this.txtDia);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.lblAnio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCargarFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAgregarFecha_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtDia;
        private System.Windows.Forms.Label lblDia;
        private System.Windows.Forms.TextBox txtMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.TextBox txtHora;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.TextBox txtMinutos;
        private System.Windows.Forms.Label lblMinutos;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnQuitarFecha;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.MonthCalendar calendario;
        private System.Windows.Forms.Button btnHoy;
    }
}