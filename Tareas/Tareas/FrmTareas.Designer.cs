
namespace Vista
{
    partial class FrmTareas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTareas));
            this.dtgvTareas = new System.Windows.Forms.DataGridView();
            this.btnAgregarTema = new System.Windows.Forms.Button();
            this.btnTareasVencidas = new System.Windows.Forms.Button();
            this.btnCerrarTareasVencidas = new System.Windows.Forms.Button();
            this.btnTareasPendientes = new System.Windows.Forms.Button();
            this.btnCerrarTareasPendientes = new System.Windows.Forms.Button();
            this.menuOpciones = new System.Windows.Forms.MenuStrip();
            this.agregarTareaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarTodasLasTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorFechaFinalMayorAMenor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorFechaFinalMenorAMayor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorFechaInicialMayorAMenor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorFechaInicialMenorAMayor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorPrioridad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorPrioridadAMB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorPrioridadMAB = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorPrioridadBMA = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorCreacion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorCreacionUltimaAPrimera = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOrdenarPorCreacionPrimeraAUltima = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarTareas = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPorEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPendiente = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarProceso = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarFinalizado = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPorPrioridad = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPrioridadAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPrioridadMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPrioridadBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPorFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarFechaFinalTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarFechaFinalNoTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarFechaInicialTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarFechaInicialNoTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarPorRecordatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarRecordatorioTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFiltrarRecordatorioNoTiene = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSinFiltro = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPassword = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTema = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAzulBasico = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRosaBasico = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerdeBasico = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAzulPrincipal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRojoPrincipal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVerdePrincipal = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNotificaciones = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.lblOrdenamiento = new System.Windows.Forms.Label();
            this.btnReestablecerOrden = new System.Windows.Forms.Button();
            this.btnQuitarFiltro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTareas)).BeginInit();
            this.menuOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvTareas
            // 
            this.dtgvTareas.AllowUserToAddRows = false;
            this.dtgvTareas.AllowUserToDeleteRows = false;
            this.dtgvTareas.AllowUserToResizeColumns = false;
            this.dtgvTareas.AllowUserToResizeRows = false;
            this.dtgvTareas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvTareas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvTareas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgvTareas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvTareas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvTareas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvTareas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvTareas.Location = new System.Drawing.Point(11, 49);
            this.dtgvTareas.MultiSelect = false;
            this.dtgvTareas.Name = "dtgvTareas";
            this.dtgvTareas.RowHeadersVisible = false;
            this.dtgvTareas.RowHeadersWidth = 51;
            this.dtgvTareas.RowTemplate.Height = 29;
            this.dtgvTareas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvTareas.ShowEditingIcon = false;
            this.dtgvTareas.Size = new System.Drawing.Size(1375, 795);
            this.dtgvTareas.TabIndex = 0;
            this.dtgvTareas.TabStop = false;
            this.dtgvTareas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTareas_CellClick);
            this.dtgvTareas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTareas_CellContentClick);
            this.dtgvTareas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTareas_CellDoubleClick);
            // 
            // btnAgregarTema
            // 
            this.btnAgregarTema.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAgregarTema.Font = new System.Drawing.Font("Arial", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarTema.Location = new System.Drawing.Point(1583, 47);
            this.btnAgregarTema.Name = "btnAgregarTema";
            this.btnAgregarTema.Size = new System.Drawing.Size(75, 52);
            this.btnAgregarTema.TabIndex = 0;
            this.btnAgregarTema.Text = "+";
            this.btnAgregarTema.UseVisualStyleBackColor = true;
            this.btnAgregarTema.Click += new System.EventHandler(this.btnAgregarTarea);
            // 
            // btnTareasVencidas
            // 
            this.btnTareasVencidas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTareasVencidas.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTareasVencidas.Location = new System.Drawing.Point(1401, 337);
            this.btnTareasVencidas.Name = "btnTareasVencidas";
            this.btnTareasVencidas.Size = new System.Drawing.Size(261, 51);
            this.btnTareasVencidas.TabIndex = 2;
            this.btnTareasVencidas.TabStop = false;
            this.btnTareasVencidas.Text = "0 Vencidas";
            this.btnTareasVencidas.UseVisualStyleBackColor = true;
            this.btnTareasVencidas.Click += new System.EventHandler(this.btnTareasVencidas_Click);
            // 
            // btnCerrarTareasVencidas
            // 
            this.btnCerrarTareasVencidas.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrarTareasVencidas.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarTareasVencidas.Location = new System.Drawing.Point(1401, 393);
            this.btnCerrarTareasVencidas.Name = "btnCerrarTareasVencidas";
            this.btnCerrarTareasVencidas.Size = new System.Drawing.Size(261, 73);
            this.btnCerrarTareasVencidas.TabIndex = 3;
            this.btnCerrarTareasVencidas.TabStop = false;
            this.btnCerrarTareasVencidas.Text = "Cerrar tareas vencidas";
            this.btnCerrarTareasVencidas.UseVisualStyleBackColor = true;
            this.btnCerrarTareasVencidas.Click += new System.EventHandler(this.btnCerrarTareasVencidas_Click);
            // 
            // btnTareasPendientes
            // 
            this.btnTareasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTareasPendientes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTareasPendientes.Location = new System.Drawing.Point(1401, 472);
            this.btnTareasPendientes.Name = "btnTareasPendientes";
            this.btnTareasPendientes.Size = new System.Drawing.Size(261, 51);
            this.btnTareasPendientes.TabIndex = 4;
            this.btnTareasPendientes.TabStop = false;
            this.btnTareasPendientes.Text = "0 Pendientes";
            this.btnTareasPendientes.UseVisualStyleBackColor = true;
            this.btnTareasPendientes.Click += new System.EventHandler(this.btnTareasPendientes_Click);
            // 
            // btnCerrarTareasPendientes
            // 
            this.btnCerrarTareasPendientes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCerrarTareasPendientes.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarTareasPendientes.Location = new System.Drawing.Point(1401, 528);
            this.btnCerrarTareasPendientes.Name = "btnCerrarTareasPendientes";
            this.btnCerrarTareasPendientes.Size = new System.Drawing.Size(261, 72);
            this.btnCerrarTareasPendientes.TabIndex = 5;
            this.btnCerrarTareasPendientes.TabStop = false;
            this.btnCerrarTareasPendientes.Text = "Cerrar tareas pendientes";
            this.btnCerrarTareasPendientes.UseVisualStyleBackColor = true;
            this.btnCerrarTareasPendientes.Click += new System.EventHandler(this.btnCerrarTareasPendientes_Click);
            // 
            // menuOpciones
            // 
            this.menuOpciones.BackColor = System.Drawing.Color.GreenYellow;
            this.menuOpciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuOpciones.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuOpciones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarTareaToolStripMenuItem,
            this.eliminarTodasLasTareasToolStripMenuItem,
            this.btnOrdenar,
            this.btnFiltrarTareas,
            this.btnPassword,
            this.btnTema});
            this.menuOpciones.Location = new System.Drawing.Point(0, 0);
            this.menuOpciones.Name = "menuOpciones";
            this.menuOpciones.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuOpciones.Size = new System.Drawing.Size(1670, 34);
            this.menuOpciones.TabIndex = 7;
            this.menuOpciones.Text = "menuStrip1";
            // 
            // agregarTareaToolStripMenuItem
            // 
            this.agregarTareaToolStripMenuItem.Name = "agregarTareaToolStripMenuItem";
            this.agregarTareaToolStripMenuItem.Size = new System.Drawing.Size(153, 28);
            this.agregarTareaToolStripMenuItem.Text = "Agregar tarea";
            this.agregarTareaToolStripMenuItem.Click += new System.EventHandler(this.btnAgregarTarea);
            // 
            // eliminarTodasLasTareasToolStripMenuItem
            // 
            this.eliminarTodasLasTareasToolStripMenuItem.Name = "eliminarTodasLasTareasToolStripMenuItem";
            this.eliminarTodasLasTareasToolStripMenuItem.Size = new System.Drawing.Size(257, 28);
            this.eliminarTodasLasTareasToolStripMenuItem.Text = "Eliminar todas las tareas";
            this.eliminarTodasLasTareasToolStripMenuItem.Click += new System.EventHandler(this.eliminarTodasLasTareasToolStripMenuItem_Click);
            // 
            // btnOrdenar
            // 
            this.btnOrdenar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrdenarPorFecha,
            this.btnOrdenarPorPrioridad,
            this.btnOrdenarPorEstado,
            this.btnOrdenarPorCreacion});
            this.btnOrdenar.Name = "btnOrdenar";
            this.btnOrdenar.Size = new System.Drawing.Size(167, 28);
            this.btnOrdenar.Text = "Ordenar tareas";
            // 
            // btnOrdenarPorFecha
            // 
            this.btnOrdenarPorFecha.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrdenarPorFechaFinalMayorAMenor,
            this.btnOrdenarPorFechaFinalMenorAMayor,
            this.btnOrdenarPorFechaInicialMayorAMenor,
            this.btnOrdenarPorFechaInicialMenorAMayor});
            this.btnOrdenarPorFecha.Name = "btnOrdenarPorFecha";
            this.btnOrdenarPorFecha.Size = new System.Drawing.Size(433, 28);
            this.btnOrdenarPorFecha.Text = "Por Fecha";
            // 
            // btnOrdenarPorFechaFinalMayorAMenor
            // 
            this.btnOrdenarPorFechaFinalMayorAMenor.Name = "btnOrdenarPorFechaFinalMayorAMenor";
            this.btnOrdenarPorFechaFinalMayorAMenor.Size = new System.Drawing.Size(366, 28);
            this.btnOrdenarPorFechaFinalMayorAMenor.Text = "Fecha Final: Mayor a Menor";
            this.btnOrdenarPorFechaFinalMayorAMenor.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorFechaFinalMenorAMayor
            // 
            this.btnOrdenarPorFechaFinalMenorAMayor.Name = "btnOrdenarPorFechaFinalMenorAMayor";
            this.btnOrdenarPorFechaFinalMenorAMayor.Size = new System.Drawing.Size(366, 28);
            this.btnOrdenarPorFechaFinalMenorAMayor.Text = "Fecha Final: Menor a Mayor";
            this.btnOrdenarPorFechaFinalMenorAMayor.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorFechaInicialMayorAMenor
            // 
            this.btnOrdenarPorFechaInicialMayorAMenor.Name = "btnOrdenarPorFechaInicialMayorAMenor";
            this.btnOrdenarPorFechaInicialMayorAMenor.Size = new System.Drawing.Size(366, 28);
            this.btnOrdenarPorFechaInicialMayorAMenor.Text = "Fecha Inicial: Mayor a Menor";
            this.btnOrdenarPorFechaInicialMayorAMenor.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorFechaInicialMenorAMayor
            // 
            this.btnOrdenarPorFechaInicialMenorAMayor.Name = "btnOrdenarPorFechaInicialMenorAMayor";
            this.btnOrdenarPorFechaInicialMenorAMayor.Size = new System.Drawing.Size(366, 28);
            this.btnOrdenarPorFechaInicialMenorAMayor.Text = "Fecha Inicial: Menor a Mayor";
            this.btnOrdenarPorFechaInicialMenorAMayor.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorPrioridad
            // 
            this.btnOrdenarPorPrioridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrdenarPorPrioridadAMB,
            this.btnOrdenarPorPrioridadMAB,
            this.btnOrdenarPorPrioridadBMA});
            this.btnOrdenarPorPrioridad.Name = "btnOrdenarPorPrioridad";
            this.btnOrdenarPorPrioridad.Size = new System.Drawing.Size(433, 28);
            this.btnOrdenarPorPrioridad.Text = "Por Prioridad";
            // 
            // btnOrdenarPorPrioridadAMB
            // 
            this.btnOrdenarPorPrioridadAMB.Name = "btnOrdenarPorPrioridadAMB";
            this.btnOrdenarPorPrioridadAMB.Size = new System.Drawing.Size(265, 28);
            this.btnOrdenarPorPrioridadAMB.Text = "Alta - Media - Baja";
            this.btnOrdenarPorPrioridadAMB.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorPrioridadMAB
            // 
            this.btnOrdenarPorPrioridadMAB.Name = "btnOrdenarPorPrioridadMAB";
            this.btnOrdenarPorPrioridadMAB.Size = new System.Drawing.Size(265, 28);
            this.btnOrdenarPorPrioridadMAB.Text = "Media - Alta - Baja";
            this.btnOrdenarPorPrioridadMAB.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorPrioridadBMA
            // 
            this.btnOrdenarPorPrioridadBMA.Name = "btnOrdenarPorPrioridadBMA";
            this.btnOrdenarPorPrioridadBMA.Size = new System.Drawing.Size(265, 28);
            this.btnOrdenarPorPrioridadBMA.Text = "Baja - Media - Alta";
            this.btnOrdenarPorPrioridadBMA.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorEstado
            // 
            this.btnOrdenarPorEstado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente,
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado,
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado});
            this.btnOrdenarPorEstado.Name = "btnOrdenarPorEstado";
            this.btnOrdenarPorEstado.Size = new System.Drawing.Size(433, 28);
            this.btnOrdenarPorEstado.Text = "Por Estado";
            // 
            // btnOrdenarPorEstadoFinalizado_Proceso_Pendiente
            // 
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente.Name = "btnOrdenarPorEstadoFinalizado_Proceso_Pendiente";
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente.Size = new System.Drawing.Size(399, 28);
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente.Text = "Finalizado - Proceso - Pendiente";
            this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorEstadoProceso_Pendiente_Finalizado
            // 
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado.Name = "btnOrdenarPorEstadoProceso_Pendiente_Finalizado";
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado.Size = new System.Drawing.Size(399, 28);
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado.Text = "Proceso - Pendiente - Finalizado";
            this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorEstadoPendiente_Proceso_Finalizado
            // 
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado.Name = "btnOrdenarPorEstadoPendiente_Proceso_Finalizado";
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado.Size = new System.Drawing.Size(399, 28);
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado.Text = "Pendiente - Proceso - Finalizado";
            this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorCreacion
            // 
            this.btnOrdenarPorCreacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOrdenarPorCreacionUltimaAPrimera,
            this.btnOrdenarPorCreacionPrimeraAUltima});
            this.btnOrdenarPorCreacion.Name = "btnOrdenarPorCreacion";
            this.btnOrdenarPorCreacion.Size = new System.Drawing.Size(433, 28);
            this.btnOrdenarPorCreacion.Text = "Por orden de creación (por defecto)";
            // 
            // btnOrdenarPorCreacionUltimaAPrimera
            // 
            this.btnOrdenarPorCreacionUltimaAPrimera.Name = "btnOrdenarPorCreacionUltimaAPrimera";
            this.btnOrdenarPorCreacionUltimaAPrimera.Size = new System.Drawing.Size(376, 28);
            this.btnOrdenarPorCreacionUltimaAPrimera.Text = "Ultima a primera";
            this.btnOrdenarPorCreacionUltimaAPrimera.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnOrdenarPorCreacionPrimeraAUltima
            // 
            this.btnOrdenarPorCreacionPrimeraAUltima.Name = "btnOrdenarPorCreacionPrimeraAUltima";
            this.btnOrdenarPorCreacionPrimeraAUltima.Size = new System.Drawing.Size(376, 28);
            this.btnOrdenarPorCreacionPrimeraAUltima.Text = "Primera a ultima (por defecto)";
            this.btnOrdenarPorCreacionPrimeraAUltima.Click += new System.EventHandler(this.OrdenarTareas);
            // 
            // btnFiltrarTareas
            // 
            this.btnFiltrarTareas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltrarPorEstado,
            this.btnFiltrarPorPrioridad,
            this.btnFiltrarPorFecha,
            this.btnFiltrarPorRecordatorio,
            this.btnSinFiltro});
            this.btnFiltrarTareas.Name = "btnFiltrarTareas";
            this.btnFiltrarTareas.Size = new System.Drawing.Size(145, 28);
            this.btnFiltrarTareas.Text = "Filtrar tareas";
            // 
            // btnFiltrarPorEstado
            // 
            this.btnFiltrarPorEstado.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltrarPendiente,
            this.btnFiltrarProceso,
            this.btnFiltrarFinalizado});
            this.btnFiltrarPorEstado.Name = "btnFiltrarPorEstado";
            this.btnFiltrarPorEstado.Size = new System.Drawing.Size(256, 28);
            this.btnFiltrarPorEstado.Text = "Por Estado";
            // 
            // btnFiltrarPendiente
            // 
            this.btnFiltrarPendiente.Name = "btnFiltrarPendiente";
            this.btnFiltrarPendiente.Size = new System.Drawing.Size(189, 28);
            this.btnFiltrarPendiente.Text = "Pendiente";
            this.btnFiltrarPendiente.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarProceso
            // 
            this.btnFiltrarProceso.Name = "btnFiltrarProceso";
            this.btnFiltrarProceso.Size = new System.Drawing.Size(189, 28);
            this.btnFiltrarProceso.Text = "Proceso";
            this.btnFiltrarProceso.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarFinalizado
            // 
            this.btnFiltrarFinalizado.Name = "btnFiltrarFinalizado";
            this.btnFiltrarFinalizado.Size = new System.Drawing.Size(189, 28);
            this.btnFiltrarFinalizado.Text = "Finalizado";
            this.btnFiltrarFinalizado.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarPorPrioridad
            // 
            this.btnFiltrarPorPrioridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltrarPrioridadAlta,
            this.btnFiltrarPrioridadMedia,
            this.btnFiltrarPrioridadBaja});
            this.btnFiltrarPorPrioridad.Name = "btnFiltrarPorPrioridad";
            this.btnFiltrarPorPrioridad.Size = new System.Drawing.Size(256, 28);
            this.btnFiltrarPorPrioridad.Text = "Por Prioridad";
            // 
            // btnFiltrarPrioridadAlta
            // 
            this.btnFiltrarPrioridadAlta.Name = "btnFiltrarPrioridadAlta";
            this.btnFiltrarPrioridadAlta.Size = new System.Drawing.Size(150, 28);
            this.btnFiltrarPrioridadAlta.Text = "Alta";
            this.btnFiltrarPrioridadAlta.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarPrioridadMedia
            // 
            this.btnFiltrarPrioridadMedia.Name = "btnFiltrarPrioridadMedia";
            this.btnFiltrarPrioridadMedia.Size = new System.Drawing.Size(150, 28);
            this.btnFiltrarPrioridadMedia.Text = "Media";
            this.btnFiltrarPrioridadMedia.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarPrioridadBaja
            // 
            this.btnFiltrarPrioridadBaja.Name = "btnFiltrarPrioridadBaja";
            this.btnFiltrarPrioridadBaja.Size = new System.Drawing.Size(150, 28);
            this.btnFiltrarPrioridadBaja.Text = "Baja";
            this.btnFiltrarPrioridadBaja.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarPorFecha
            // 
            this.btnFiltrarPorFecha.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltrarFechaFinalTiene,
            this.btnFiltrarFechaFinalNoTiene,
            this.btnFiltrarFechaInicialTiene,
            this.btnFiltrarFechaInicialNoTiene});
            this.btnFiltrarPorFecha.Name = "btnFiltrarPorFecha";
            this.btnFiltrarPorFecha.Size = new System.Drawing.Size(256, 28);
            this.btnFiltrarPorFecha.Text = "Por Fecha";
            // 
            // btnFiltrarFechaFinalTiene
            // 
            this.btnFiltrarFechaFinalTiene.Name = "btnFiltrarFechaFinalTiene";
            this.btnFiltrarFechaFinalTiene.Size = new System.Drawing.Size(308, 28);
            this.btnFiltrarFechaFinalTiene.Text = "Fecha Final: Tiene";
            this.btnFiltrarFechaFinalTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarFechaFinalNoTiene
            // 
            this.btnFiltrarFechaFinalNoTiene.Name = "btnFiltrarFechaFinalNoTiene";
            this.btnFiltrarFechaFinalNoTiene.Size = new System.Drawing.Size(308, 28);
            this.btnFiltrarFechaFinalNoTiene.Text = "Fecha Final: No Tiene";
            this.btnFiltrarFechaFinalNoTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarFechaInicialTiene
            // 
            this.btnFiltrarFechaInicialTiene.Name = "btnFiltrarFechaInicialTiene";
            this.btnFiltrarFechaInicialTiene.Size = new System.Drawing.Size(308, 28);
            this.btnFiltrarFechaInicialTiene.Text = "Fecha Inicial: Tiene";
            this.btnFiltrarFechaInicialTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarFechaInicialNoTiene
            // 
            this.btnFiltrarFechaInicialNoTiene.Name = "btnFiltrarFechaInicialNoTiene";
            this.btnFiltrarFechaInicialNoTiene.Size = new System.Drawing.Size(308, 28);
            this.btnFiltrarFechaInicialNoTiene.Text = "Fecha Inicial: No Tiene";
            this.btnFiltrarFechaInicialNoTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarPorRecordatorio
            // 
            this.btnFiltrarPorRecordatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltrarRecordatorioTiene,
            this.btnFiltrarRecordatorioNoTiene});
            this.btnFiltrarPorRecordatorio.Name = "btnFiltrarPorRecordatorio";
            this.btnFiltrarPorRecordatorio.Size = new System.Drawing.Size(256, 28);
            this.btnFiltrarPorRecordatorio.Text = "Por Recordatorio";
            // 
            // btnFiltrarRecordatorioTiene
            // 
            this.btnFiltrarRecordatorioTiene.Name = "btnFiltrarRecordatorioTiene";
            this.btnFiltrarRecordatorioTiene.Size = new System.Drawing.Size(314, 28);
            this.btnFiltrarRecordatorioTiene.Text = "Recordatorio: Tiene";
            this.btnFiltrarRecordatorioTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnFiltrarRecordatorioNoTiene
            // 
            this.btnFiltrarRecordatorioNoTiene.Name = "btnFiltrarRecordatorioNoTiene";
            this.btnFiltrarRecordatorioNoTiene.Size = new System.Drawing.Size(314, 28);
            this.btnFiltrarRecordatorioNoTiene.Text = "Recordatorio: No Tiene";
            this.btnFiltrarRecordatorioNoTiene.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnSinFiltro
            // 
            this.btnSinFiltro.Name = "btnSinFiltro";
            this.btnSinFiltro.Size = new System.Drawing.Size(256, 28);
            this.btnSinFiltro.Text = "Sin Filtro";
            this.btnSinFiltro.Click += new System.EventHandler(this.FiltrarTareas);
            // 
            // btnPassword
            // 
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(133, 28);
            this.btnPassword.Text = "Contraseña";
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnTema
            // 
            this.btnTema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAzulBasico,
            this.btnRosaBasico,
            this.btnVerdeBasico,
            this.btnAzulPrincipal,
            this.btnRojoPrincipal,
            this.btnVerdePrincipal});
            this.btnTema.ForeColor = System.Drawing.Color.White;
            this.btnTema.Name = "btnTema";
            this.btnTema.Size = new System.Drawing.Size(75, 28);
            this.btnTema.Text = "Tema";
            // 
            // btnAzulBasico
            // 
            this.btnAzulBasico.Name = "btnAzulBasico";
            this.btnAzulBasico.Size = new System.Drawing.Size(236, 28);
            this.btnAzulBasico.Text = "Azul Básico";
            this.btnAzulBasico.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // btnRosaBasico
            // 
            this.btnRosaBasico.Name = "btnRosaBasico";
            this.btnRosaBasico.Size = new System.Drawing.Size(236, 28);
            this.btnRosaBasico.Text = "Rosa Básico";
            this.btnRosaBasico.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // btnVerdeBasico
            // 
            this.btnVerdeBasico.Name = "btnVerdeBasico";
            this.btnVerdeBasico.Size = new System.Drawing.Size(236, 28);
            this.btnVerdeBasico.Text = "Verde Básico";
            this.btnVerdeBasico.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // btnAzulPrincipal
            // 
            this.btnAzulPrincipal.Name = "btnAzulPrincipal";
            this.btnAzulPrincipal.Size = new System.Drawing.Size(236, 28);
            this.btnAzulPrincipal.Text = "Azul Principal";
            this.btnAzulPrincipal.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // btnRojoPrincipal
            // 
            this.btnRojoPrincipal.AccessibleDescription = "";
            this.btnRojoPrincipal.Name = "btnRojoPrincipal";
            this.btnRojoPrincipal.Size = new System.Drawing.Size(236, 28);
            this.btnRojoPrincipal.Text = "Rojo Principal";
            this.btnRojoPrincipal.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // btnVerdePrincipal
            // 
            this.btnVerdePrincipal.AccessibleDescription = "";
            this.btnVerdePrincipal.Name = "btnVerdePrincipal";
            this.btnVerdePrincipal.Size = new System.Drawing.Size(236, 28);
            this.btnVerdePrincipal.Text = "Verde Principal";
            this.btnVerdePrincipal.Click += new System.EventHandler(this.CambiarTemaAplicacion);
            // 
            // lblNotificaciones
            // 
            this.lblNotificaciones.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNotificaciones.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNotificaciones.Location = new System.Drawing.Point(1401, 101);
            this.lblNotificaciones.Name = "lblNotificaciones";
            this.lblNotificaciones.Size = new System.Drawing.Size(261, 37);
            this.lblNotificaciones.TabIndex = 8;
            this.lblNotificaciones.Text = "Notificaciones";
            this.lblNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.Lavender;
            this.btnSalir.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(1400, 772);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(262, 72);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Cerrar";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblFiltro
            // 
            this.lblFiltro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFiltro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFiltro.Location = new System.Drawing.Point(1401, 140);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(261, 77);
            this.lblFiltro.TabIndex = 9;
            this.lblFiltro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrdenamiento
            // 
            this.lblOrdenamiento.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOrdenamiento.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrdenamiento.Location = new System.Drawing.Point(1401, 229);
            this.lblOrdenamiento.Name = "lblOrdenamiento";
            this.lblOrdenamiento.Size = new System.Drawing.Size(261, 89);
            this.lblOrdenamiento.TabIndex = 10;
            this.lblOrdenamiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReestablecerOrden
            // 
            this.btnReestablecerOrden.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReestablecerOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReestablecerOrden.Location = new System.Drawing.Point(1469, 47);
            this.btnReestablecerOrden.Name = "btnReestablecerOrden";
            this.btnReestablecerOrden.Size = new System.Drawing.Size(114, 52);
            this.btnReestablecerOrden.TabIndex = 11;
            this.btnReestablecerOrden.Text = "Reestablecer Orden";
            this.btnReestablecerOrden.UseVisualStyleBackColor = true;
            this.btnReestablecerOrden.Click += new System.EventHandler(this.btnRestablecerOrden_Click);
            // 
            // btnQuitarFiltro
            // 
            this.btnQuitarFiltro.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnQuitarFiltro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnQuitarFiltro.Location = new System.Drawing.Point(1397, 47);
            this.btnQuitarFiltro.Name = "btnQuitarFiltro";
            this.btnQuitarFiltro.Size = new System.Drawing.Size(73, 52);
            this.btnQuitarFiltro.TabIndex = 12;
            this.btnQuitarFiltro.Text = "Quitar Filtro";
            this.btnQuitarFiltro.UseVisualStyleBackColor = true;
            this.btnQuitarFiltro.Click += new System.EventHandler(this.btnQuitarFiltro_Click);
            // 
            // FrmTareas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.ClientSize = new System.Drawing.Size(1670, 856);
            this.Controls.Add(this.btnQuitarFiltro);
            this.Controls.Add(this.btnReestablecerOrden);
            this.Controls.Add(this.lblOrdenamiento);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblNotificaciones);
            this.Controls.Add(this.btnCerrarTareasPendientes);
            this.Controls.Add(this.btnTareasPendientes);
            this.Controls.Add(this.btnCerrarTareasVencidas);
            this.Controls.Add(this.btnTareasVencidas);
            this.Controls.Add(this.btnAgregarTema);
            this.Controls.Add(this.dtgvTareas);
            this.Controls.Add(this.menuOpciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuOpciones;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTareas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tareas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTareas_FormClosing);
            this.Load += new System.EventHandler(this.FrmTarea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTareas)).EndInit();
            this.menuOpciones.ResumeLayout(false);
            this.menuOpciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvTareas;
        private System.Windows.Forms.Button btnAgregarTema;
        private System.Windows.Forms.Button btnTareasVencidas;
        private System.Windows.Forms.Button btnCerrarTareasVencidas;
        private System.Windows.Forms.Button btnTareasPendientes;
        private System.Windows.Forms.Button btnCerrarTareasPendientes;
        private System.Windows.Forms.MenuStrip menuOpciones;
        private System.Windows.Forms.ToolStripMenuItem btnTema;
        private System.Windows.Forms.ToolStripMenuItem btnAzulBasico;
        private System.Windows.Forms.ToolStripMenuItem btnRosaBasico;
        private System.Windows.Forms.ToolStripMenuItem btnVerdeBasico;
        private System.Windows.Forms.ToolStripMenuItem btnPassword;
        private System.Windows.Forms.ToolStripMenuItem agregarTareaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarTodasLasTareasToolStripMenuItem;
        private System.Windows.Forms.Label lblNotificaciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripMenuItem btnAzulPrincipal;
        private System.Windows.Forms.ToolStripMenuItem btnRojoPrincipal;
        private System.Windows.Forms.ToolStripMenuItem btnVerdePrincipal;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenar;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorFecha;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorFechaFinalMayorAMenor;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorFechaFinalMenorAMayor;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorPrioridad;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorPrioridadAMB;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorPrioridadMAB;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorPrioridadBMA;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorEstado;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorEstadoFinalizado_Proceso_Pendiente;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorEstadoProceso_Pendiente_Finalizado;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorEstadoPendiente_Proceso_Finalizado;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorCreacion;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorCreacionUltimaAPrimera;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorCreacionPrimeraAUltima;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorFechaInicialMayorAMenor;
        private System.Windows.Forms.ToolStripMenuItem btnOrdenarPorFechaInicialMenorAMayor;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarTareas;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPorEstado;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPorPrioridad;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPorFecha;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPendiente;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarProceso;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPorRecordatorio;
        private System.Windows.Forms.ToolStripMenuItem btnSinFiltro;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarFinalizado;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPrioridadAlta;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPrioridadMedia;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarPrioridadBaja;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarFechaFinalTiene;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarFechaFinalNoTiene;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarFechaInicialTiene;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarFechaInicialNoTiene;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarRecordatorioTiene;
        private System.Windows.Forms.ToolStripMenuItem btnFiltrarRecordatorioNoTiene;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblOrdenamiento;
        private System.Windows.Forms.Button btnReestablecerOrden;
        private System.Windows.Forms.Button btnQuitarFiltro;
    }
}

