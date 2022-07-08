using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{ 
    public partial class FrmTareas : Form
    {
        private Dictionary<int,FrmAbrirTarea> tareasPendientesAbiertas;
        private Dictionary<int,FrmAbrirTarea> tareasVencidasAbiertas;
        private List<Tarea> tareasAMostrar;
        private DataGridViewButtonColumn columnaBotonEliminar;
        private DataGridViewCheckBoxColumn columnaTieneRecordatorio;
        private DataGridViewColumn columnaEstadoTarea;
        private DataGridViewColumn columnaPrioridadTarea;
        private DataGridViewColumn columnaContenido;
        private DataGridViewColumn columnaFechaInicial;
        private DataGridViewColumn columnaFechaFinal;
        private CancellationTokenSource tokenDeCancelacion;
        private VerificadorDeTareas verificadorDeTareas;
        private static Tema temaAplicacion;
        private int indiceSeleccionadoDataGrid;

        public FrmTareas(Tema temaAplicacion)
        {
            this.InitializeComponent();
            
            this.dtgvTareas.Width = 1375;
            this.Width = 1688;

            this.tareasPendientesAbiertas = new Dictionary<int, FrmAbrirTarea>();
            this.tareasVencidasAbiertas = new Dictionary<int, FrmAbrirTarea>();

            this.tokenDeCancelacion = new CancellationTokenSource();
            this.verificadorDeTareas = new VerificadorDeTareas(this.tokenDeCancelacion);

            this.indiceSeleccionadoDataGrid = 0;

            FrmTareas.temaAplicacion = temaAplicacion;

            this.tareasAMostrar = Tarea.LeerTareasDesdeBaseDeDatos();
        }          

        public static Tema TemaAplicacion
        {
            get
            {
                return FrmTareas.temaAplicacion;
            }
        }  

        private void FrmTarea_Load(object sender, EventArgs e)
        {
            this.Hide();

            Ordenamiento.OnOrdenar += this.OrdenActual;
            Filtrar.OnFiltrar += FiltroActual;

            this.btnCerrarTareasVencidas.Visible = false;
            this.btnCerrarTareasPendientes.Visible = false;

            this.CrearDataGridBotonEliminar();
            this.CrearDataGridCheckBoxTieneRecordatorio();
            this.CrearDataGridColumnas();

            this.OrganizarDataGrid();

            this.AplicarTema();

            this.verificadorDeTareas.OnTareasPendientes += this.ResaltarBotonDeTareasPendientes;
            this.verificadorDeTareas.OnTareasVencidas += this.ResaltarBotonDeTareasVencidas;
            this.verificadorDeTareas.RevisarEstadoDeTareas();

            this.Show();
        }
        
        private void FiltroActual(string texto)
        {
            this.lblFiltro.Text = texto;
        }

        private void OrdenActual(string texto)
        {
            this.lblOrdenamiento.Text = texto;
        }

        /// <summary>
        /// Crea la columna de botones ('Eliminar') para el datagrid.
        /// </summary>
        private void CrearDataGridBotonEliminar()
        {
            this.columnaBotonEliminar = new DataGridViewButtonColumn();
            this.columnaBotonEliminar.Name = "eliminar";
            this.columnaBotonEliminar.HeaderText = "Eliminar";
            this.columnaBotonEliminar.CellTemplate = new DataGridViewButtonCell();
            this.columnaBotonEliminar.UseColumnTextForButtonValue = true;
            this.columnaBotonEliminar.Text = "-";
        }

        /// <summary>
        /// Crea la columna de checkboxes ('Recordatorio') para el datagrid.
        /// </summary>
        private void CrearDataGridCheckBoxTieneRecordatorio()
        {
            this.columnaTieneRecordatorio = new DataGridViewCheckBoxColumn();
            this.columnaTieneRecordatorio.Name = "recordatorio";
            this.columnaTieneRecordatorio.HeaderText = "Recordatorio";
            this.columnaTieneRecordatorio.CellTemplate = new DataGridViewCheckBoxCell();
            this.columnaTieneRecordatorio.DataPropertyName = "TieneRecordatorio";
        }

        /// <summary>
        /// Crea las columnas de texto ('Tarea', 'Fecha Inicial', 'Estado', 'Fecha Final') para el datagrid.
        /// </summary>
        private void CrearDataGridColumnas()
        {
            this.columnaContenido = new DataGridViewColumn();
            this.columnaContenido.Name = "tarea";
            this.columnaContenido.HeaderText = "Tarea";
            this.columnaContenido.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaContenido.ReadOnly = true;
            this.columnaContenido.DataPropertyName = "Contenido";

            this.columnaFechaInicial = new DataGridViewColumn();
            this.columnaFechaInicial.Name = "fechaInicial";
            this.columnaFechaInicial.HeaderText = "Fecha Inicial";
            this.columnaFechaInicial.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaFechaInicial.ReadOnly = true;
            this.columnaFechaInicial.DataPropertyName = "FechaInicialString";

            this.columnaEstadoTarea = new DataGridViewColumn();
            this.columnaEstadoTarea.Name = "estadoTarea";
            this.columnaEstadoTarea.HeaderText = "Estado";
            this.columnaEstadoTarea.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaEstadoTarea.ReadOnly = true;
            this.columnaEstadoTarea.DataPropertyName = "EstadoDeTarea";

            this.columnaPrioridadTarea = new DataGridViewColumn();
            this.columnaPrioridadTarea.Name = "prioridadTarea";
            this.columnaPrioridadTarea.HeaderText = "Prioridad";
            this.columnaPrioridadTarea.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaPrioridadTarea.ReadOnly = true;
            this.columnaPrioridadTarea.DataPropertyName = "PrioridadTarea";

            this.columnaFechaFinal = new DataGridViewColumn();
            this.columnaFechaFinal.Name = "fechaFinal";
            this.columnaFechaFinal.HeaderText = "Fecha Final";
            this.columnaFechaFinal.CellTemplate = new DataGridViewTextBoxCell();
            this.columnaFechaFinal.ReadOnly = true;
            this.columnaFechaFinal.DataPropertyName = "FechaFinalString";
        }

        /// <summary>
        /// Organiza el datagrid, dando un orden a las columnas y cargando el DataSource.
        /// </summary>
        private void OrganizarDataGrid()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(this.OrganizarDataGrid));
            }
            else
            {
                this.dtgvTareas.RowTemplate.Height = 80;
                this.dtgvTareas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                this.CargarDataSource();

                this.dtgvTareas.Columns.Clear();

                this.dtgvTareas.Columns.AddRange (this.columnaBotonEliminar, this.columnaFechaInicial, this.columnaContenido, this.columnaEstadoTarea, this.columnaPrioridadTarea, this.columnaTieneRecordatorio ,this.columnaFechaFinal);
          
                this.dtgvTareas.Columns["eliminar"].DisplayIndex = 0;
                this.dtgvTareas.Columns["fechaInicial"].DisplayIndex = 1;
                this.dtgvTareas.Columns["tarea"].DisplayIndex = 2;
                this.dtgvTareas.Columns["estadoTarea"].DisplayIndex = 3;
                this.dtgvTareas.Columns["prioridadTarea"].DisplayIndex = 4;
                this.dtgvTareas.Columns["recordatorio"].DisplayIndex = 5;
                this.dtgvTareas.Columns["fechaFinal"].DisplayIndex = 6;

                this.DarEstiloADataGrid();

                this.ColocarColoresEnDataGrid();

                if(this.dtgvTareas.Rows.Count > 0 && this.indiceSeleccionadoDataGrid >= 0 && this.indiceSeleccionadoDataGrid < this.dtgvTareas.Rows.Count)
                {
                    this.dtgvTareas.FirstDisplayedScrollingRowIndex = this.indiceSeleccionadoDataGrid;
                    this.dtgvTareas.Rows[indiceSeleccionadoDataGrid].Selected = true;
                }
            }
        }

        /// <summary>
        /// Carga el DataSource del datagrid.
        /// </summary>
        private void CargarDataSource()
        {
            this.OrdenarYFiltrarListaAntesDeMostrarEnDataGrid();

            BindingList<Tarea> tareas = new BindingList<Tarea>();

            for(int i = 0; i < this.tareasAMostrar.Count; i++)
            {
                tareas.Add(this.tareasAMostrar[i]);
            }

            this.dtgvTareas.DataSource = null;
            this.dtgvTareas.DataSource = tareas;
        }

        /// <summary>
        /// Ordena y filtra la lista para mostrar.
        /// </summary>
        private void OrdenarYFiltrarListaAntesDeMostrarEnDataGrid()
        { 
            this.tareasAMostrar = Filtrar.FiltrarTareas(Tarea.Tareas);

            this.btnQuitarFiltro.Visible = !(Filtrar.CriterioDeFiltroActual == Filtrar.Filtrado.Sin_Filtro);
            this.btnReestablecerOrden.Visible = !(Ordenamiento.CriterioDeOrdenamientoActual == Ordenamiento.Criterio.Defecto_Creacion_Primera_A_Ultima);
    
            this.tareasAMostrar = Ordenamiento.Ordenar(this.tareasAMostrar);         
        }

        /// <summary>
        /// Da estilo a las columnas del datagrid.
        /// </summary>
        private void DarEstiloADataGrid()
        {        
            this.dtgvTareas.Columns["eliminar"].Width = 100;
            this.dtgvTareas.Columns["fechaInicial"].Width = 175;
            this.dtgvTareas.Columns["tarea"].Width = 430;
            this.dtgvTareas.Columns["estadoTarea"].Width = 150;
            this.dtgvTareas.Columns["prioridadTarea"].Width = 150;
            this.dtgvTareas.Columns["recordatorio"].Width = 175;
            this.dtgvTareas.Columns["fechaFinal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            this.dtgvTareas.Columns["eliminar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["fechaInicial"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["tarea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["estadoTarea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["prioridadTarea"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["recordatorio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTareas.Columns["fechaFinal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;         
        }

        /// <summary>
        /// Coloca los colores en todas las filas del datagrid.
        /// </summary>
        private void ColocarColoresEnDataGrid()
        {
            this.dtgvTareas.ColumnHeadersDefaultCellStyle.SelectionBackColor = FrmTareas.TemaAplicacion.ColorSeleccion;
            this.dtgvTareas.ColumnHeadersDefaultCellStyle.SelectionForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlSeleccionar;
            this.dtgvTareas.DefaultCellStyle.SelectionBackColor = FrmTareas.TemaAplicacion.ColorSeleccion;
            this.dtgvTareas.DefaultCellStyle.SelectionForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlSeleccionar;

            this.columnaBotonEliminar.FlatStyle = FlatStyle.Flat;
            this.columnaBotonEliminar.DefaultCellStyle.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;
            this.columnaBotonEliminar.DefaultCellStyle.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;
            this.columnaBotonEliminar.DefaultCellStyle.SelectionBackColor = FrmTareas.TemaAplicacion.ColorSeleccion;
            this.columnaBotonEliminar.DefaultCellStyle.SelectionForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlSeleccionar;

            foreach (DataGridViewRow fila in this.dtgvTareas.Rows)
            {
                Tarea tarea = fila.DataBoundItem as Tarea;

                if(tarea != null && tarea.CambioElTemaPorDefecto)
                {
                    fila.DefaultCellStyle.BackColor = tarea.ColorTarea;
                    fila.DefaultCellStyle.ForeColor = tarea.ColorLetra;
                }
                else
                {
                    fila.DefaultCellStyle.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacionAlternativo;
                    fila.DefaultCellStyle.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlternativo;            
                }
            }                     
        }

        private void dtgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGrid &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count)
            {
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    Tarea tarea = dataGrid.Rows[e.RowIndex].DataBoundItem as Tarea;

                    if (tarea != null)
                    {
                        if (MessageBox.Show($"¿Desea eliminar la tarea? {Environment.NewLine}{tarea}", "Aviso: Eliminacion de tarea",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            tarea.EliminarTareaDeBBDD();

                            this.indiceSeleccionadoDataGrid = e.RowIndex -1;

                            this.OrganizarDataGrid();
                        }
                    }
                }
            }
        }

        private void dtgvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGrid &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count)
            {      
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                    dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    this.indiceSeleccionadoDataGrid = e.RowIndex;


                    Tarea tarea = dataGrid.Rows[e.RowIndex].DataBoundItem as Tarea;

                    tarea.TieneRecordatorio = !tarea.TieneRecordatorio;

                    if(tarea != null)
                    {
                        tarea.ActualizarRecordatorioDeTareaEnBBDD();
                    }

                    this.OrganizarDataGrid();
                }
            }
        }

        private void dtgvTareas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGrid &&
                e.ColumnIndex >= 0 && e.ColumnIndex < dataGrid.Columns.Count &&
                e.RowIndex >= 0 && e.RowIndex < dataGrid.Rows.Count)
            {
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewColumn)
                {
                    Tarea tarea = dataGrid.Rows[e.RowIndex].DataBoundItem as Tarea;

                    if (tarea != null)
                    {
                        this.indiceSeleccionadoDataGrid = e.RowIndex;
                        
                        this.AbrirFormularioDesdeDataGrid(dataGrid, e, tarea);
                    }
                }
            }
        }

        /// <summary>
        /// Abre un formulario a partir de la celda seleccionada del datagrid.
        /// </summary>
        /// <param name="dataGrid">Datagrid.</param>
        /// <param name="e">Objeto con informacion del Evento</param>
        /// <param name="tarea">Tarea seleccionada.</param>
        private void AbrirFormularioDesdeDataGrid(DataGridView dataGrid, DataGridViewCellEventArgs e, Tarea tarea)
        {
            Form formulario = null;

            if(!this.tareasPendientesAbiertas.Keys.Contains(tarea.IdTarea) && !this.tareasVencidasAbiertas.Keys.Contains(tarea.IdTarea))
            {
                string nombre = dataGrid.Columns[e.ColumnIndex].Name;

                if (nombre == "tarea" || nombre == "estadoTarea" || nombre == "prioridadTarea")
                {
                    formulario = new FrmAbrirTarea(tarea, true);
                }
                else if(nombre == "fechaFinal")
                {
                    formulario = new FrmCargarFecha(tarea, true);
                }
                else if(nombre == "fechaInicial")
                {
                    formulario = new FrmCargarFecha(tarea, false);
                }

                if (formulario != null && formulario.ShowDialog() == DialogResult.OK)
                {
                    if(formulario is FrmCargarFecha)
                    {
                        tarea.ActualizarTareaEnBBDD();
                    }

                    this.OrganizarDataGrid();
                }
            }
        }

        private void btnAgregarTarea(object sender, EventArgs e)
        {
            Tarea tarea = new Tarea();

            FrmAbrirTarea tareaNueva = new FrmAbrirTarea(tarea, false);

            tareaNueva.ShowDialog();
            
            this.OrganizarDataGrid();            
        }

        /// <summary>
        /// Resalta el boton de tareas vencidas.
        /// </summary>
        private void ResaltarBotonDeTareasVencidas(bool hayTareasVencidas)
        {
            if (this.btnTareasVencidas.InvokeRequired)
            {
                this.btnTareasVencidas.Invoke(new Action<bool>(this.ResaltarBotonDeTareasVencidas), hayTareasVencidas);
            }
            else
            {
                this.btnTareasVencidas.Text = $"{this.verificadorDeTareas.TotalTareasVencidas} Vencidas";
                this.btnCerrarTareasVencidas.Visible = this.tareasVencidasAbiertas.Count > 0;

                if(hayTareasVencidas)
                {
                    this.btnTareasVencidas.BackColor = this.btnTareasVencidas.BackColor == Color.Red ? Color.White : Color.Red;
                    this.btnTareasVencidas.ForeColor = this.btnTareasVencidas.ForeColor == Color.WhiteSmoke ? Color.Red : Color.WhiteSmoke;
                }
                else
                {
                    this.btnTareasVencidas.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoDeControl;
                    this.btnTareasVencidas.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;
                }
            }
        }

        /// <summary>
        /// Resalta el boton de tareas pendientes.
        /// </summary>
        private void ResaltarBotonDeTareasPendientes(bool hayTareasPendientes)
        {
            if (this.btnTareasPendientes.InvokeRequired)
            {
                this.btnTareasPendientes.Invoke(new Action<bool>(this.ResaltarBotonDeTareasPendientes), hayTareasPendientes);
            }
            else
            {
                this.btnTareasPendientes.Text = $"{this.verificadorDeTareas.TotalTareasPendientes} Pendientes";
                this.btnCerrarTareasPendientes.Visible = this.tareasPendientesAbiertas.Count > 0;

                if(hayTareasPendientes)
                {
                    this.btnTareasPendientes.BackColor = this.btnTareasPendientes.BackColor == Color.Green ? Color.White : Color.Green;
                    this.btnTareasPendientes.ForeColor = this.btnTareasPendientes.ForeColor == Color.WhiteSmoke ? Color.Green : Color.WhiteSmoke;
                }
                else
                {
                    this.btnTareasPendientes.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoDeControl;
                    this.btnTareasPendientes.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;
                }            
            }
        }

        /// <summary>
        /// Cierra todos los formularios que esten en la lista recibida por parametro.
        /// </summary>
        /// <param name="formularios">Formularios para cerrar.</param>
        private void CerrarTodosLosFormulariosAbiertosEnLaLista(Dictionary<int, FrmAbrirTarea> formularios)
        {
            for (int i = formularios.Count -1; i >= 0; i--)
            {
                FrmAbrirTarea tarea = formularios.ElementAt(i).Value;

                if (!tarea.IsDisposed)
                {
                    tarea.Close();
                }
            }
        }   

        private void btnTareasPendientes_Click(object sender, EventArgs e)
        {
            if(this.verificadorDeTareas.TotalTareasPendientes > 0)
            {
                this.indiceSeleccionadoDataGrid = 0;

                this.CerrarTodosLosFormulariosAbiertosEnLaLista(this.tareasPendientesAbiertas);

                this.AbrirTareasPendientes();
            }
        }

        /// <summary>
        /// Abre un formulario para cada tarea que este 'Pendiente', y los agrega en la lista 'tareasPendientesAbiertas'
        /// </summary>
        private void AbrirTareasPendientes()
        {
            this.tareasPendientesAbiertas.Clear();

            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                Tarea tarea = Tarea.Tareas[i];

                if (tarea.TareaEstaPendiente)
                {
                    FrmAbrirTarea formularioDeTareaPendiente = new FrmAbrirTarea(tarea, true);

                    formularioDeTareaPendiente.OnCerrarTarea += this.BorrarTareaYFormularioDeListaDeTareasPendientesAbiertas;
                    formularioDeTareaPendiente.OnRefrescarDataGrid += this.OrganizarDataGrid;

                    formularioDeTareaPendiente.Show();

                    this.tareasPendientesAbiertas.Add(tarea.IdTarea, formularioDeTareaPendiente);
                }
            }
        }

        private void btnCerrarTareasPendientes_Click(object sender, EventArgs e)
        {
            this.CerrarTodosLosFormulariosAbiertosEnLaLista(this.tareasPendientesAbiertas);
        }

        /// <summary>
        /// Borra una tarea y un formulario de la lista 'tareasPendientesAbiertas'
        /// </summary>
        /// <param name="idTarea">Id de la tarea que se quitara de la lista.</param>
        private void BorrarTareaYFormularioDeListaDeTareasPendientesAbiertas(int idTarea)
        {
            this.tareasPendientesAbiertas.Remove(idTarea);
        }

        private void btnTareasVencidas_Click(object sender, EventArgs e)
        {
            if(this.verificadorDeTareas.TotalTareasVencidas > 0)
            {
                this.indiceSeleccionadoDataGrid = 0;

                this.CerrarTodosLosFormulariosAbiertosEnLaLista(this.tareasVencidasAbiertas);

                this.AbrirTareasVencidas();
            }      
        }

        /// <summary>
        /// Abre un formulario para cada tarea que este 'Vencida', y los agrega en la lista 'tareasVencidasAbiertas'
        /// </summary>
        private void AbrirTareasVencidas()
        {
            this.tareasVencidasAbiertas.Clear();

            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                Tarea tarea = Tarea.Tareas[i];

                if (tarea.TareaEstaVencida)
                {
                    FrmAbrirTarea formularioDeTareaVencida = new FrmAbrirTarea(tarea, true);

                    formularioDeTareaVencida.OnCerrarTarea += this.BorrarTareaYFormularioDeListaDeTareasVencidasAbiertas;
                    formularioDeTareaVencida.OnRefrescarDataGrid += this.OrganizarDataGrid;

                    formularioDeTareaVencida.Show();

                    this.tareasVencidasAbiertas.Add(tarea.IdTarea, formularioDeTareaVencida);
                }
            }
        }

        private void btnCerrarTareasVencidas_Click(object sender, EventArgs e)
        {
            this.CerrarTodosLosFormulariosAbiertosEnLaLista(this.tareasVencidasAbiertas);
        }

        /// <summary>
        /// Borra una tarea y un formulario de la lista 'tareasVencidasAbiertas'
        /// </summary>
        /// <param name="idTarea">Id de la tarea que se quitara de la lista.</param>
        private void BorrarTareaYFormularioDeListaDeTareasVencidasAbiertas(int idTarea)
        {
            this.tareasVencidasAbiertas.Remove(idTarea);
        }

        private void CambiarTemaAplicacion(object sender, EventArgs e)
        {
            if(Object.ReferenceEquals(sender, this.btnAzulBasico))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.AzulBasico);
            }
            else if (Object.ReferenceEquals(sender, this.btnRosaBasico))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.RosadoBasico);
            }
            else if (Object.ReferenceEquals(sender, this.btnVerdeBasico))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.VerdeBasico);
            }
            else if (Object.ReferenceEquals(sender, this.btnAzulPrincipal))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.AzulPrincipal);
            }
            else if (Object.ReferenceEquals(sender, this.btnRojoPrincipal))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.RojoPrincipal);
            }
            else if (Object.ReferenceEquals(sender, this.btnVerdePrincipal))
            {
                FrmTareas.temaAplicacion = new Tema(Tema.TemaAplicacion.VerdePrincipal);
            }

            this.AplicarTema();

            this.ColocarColoresEnDataGrid();
        }

        /// <summary>
        /// Aplica un tema en el formulario.
        /// </summary>
        private void AplicarTema()
        {
            foreach (Control control in this.Controls)
            {
                control.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;
                control.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;

                if (control is Label)
                {
                    control.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlternativo;
                    control.BackColor = Color.Transparent;
                }
                else if (control is DataGridView dataGrid)
                {
                    dataGrid.EnableHeadersVisualStyles = false;
                    dataGrid.BackgroundColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;
                    dataGrid.ColumnHeadersDefaultCellStyle.BackColor = FrmTareas.temaAplicacion.ColorEncabezado;
                    dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;
                }
                else if (control is MenuStrip menuStrip)
                {
                    this.AplicarTemaEnMenuStrip(menuStrip);
                }
                else
                {
                    this.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;

                    if (control is Button boton)
                    {  
                        boton.FlatStyle = FlatStyle.Flat;
                        boton.BackColor = FrmTareas.temaAplicacion.ColorDeFondoDeControl;  
                        boton.FlatAppearance.MouseDownBackColor = FrmTareas.TemaAplicacion.ColorMouseOver;
                        boton.FlatAppearance.MouseOverBackColor = FrmTareas.TemaAplicacion.ColorMouseOver;
                        boton.FlatAppearance.BorderSize = 0;
                    }                 
                }
            }
        }

        /// <summary>
        /// Aplica el tema en cada Item del MenuStrip.
        /// </summary>
        /// <param name="menu">Menu strip.</param>
        private void AplicarTemaEnMenuStrip(MenuStrip menu)
        {
            foreach (ToolStripMenuItem menuControl in menu.Items)
            {
                this.AplicarTemaEnMenuStripItems(menuControl);
            }
        }

        /// <summary>
        /// Aplica el tema en el menuStripItem y sus subMenues.
        /// </summary>
        /// <param name="menu">Menu donde se aplicara el tema.</param>
        private void AplicarTemaEnMenuStripItems(ToolStripMenuItem menu)
        {
            menu.BackColor = FrmTareas.TemaAplicacion.ColorEncabezado;
            menu.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;

            foreach (ToolStripMenuItem subMenu in menu.DropDownItems)
            {
                this.AplicarTemaEnMenuStripItems(subMenu);
            }
        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            FrmPassword formularioPassword = new FrmPassword();
            
            if(formularioPassword.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FrmTareas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                if(MessageBox.Show("¿Desea cerrar la aplicacion?","Aviso: cierre aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            if(!e.Cancel)
            {
                this.tokenDeCancelacion.Cancel();
            }
        }

        private void eliminarTodasLasTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro de eliminar TODAS las tareas? Esta operacion no puede revertirse.","Advertencia: Eliminacion de todas las tareas.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Tarea.EliminarTodasLasTareasDeBBDD();

                this.OrganizarDataGrid();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrdenarTareas(object sender, EventArgs e)
        {
            Ordenamiento.Criterio criterioDeOrdenamiento = Ordenamiento.Criterio.Defecto_Creacion_Primera_A_Ultima;

            if(Object.ReferenceEquals(sender, this.btnOrdenarPorCreacionUltimaAPrimera))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Defecto_Creacion_Ultima_A_Primera;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorEstadoFinalizado_Proceso_Pendiente))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Estado_Fin_Proceso_Pendiente;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorEstadoPendiente_Proceso_Finalizado))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Estado_Pendiente_Proceso_Fin;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorEstadoProceso_Pendiente_Finalizado))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Estado_Proceso_Pendiente_Fin;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorFechaFinalMenorAMayor))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Fecha_Fin_Menor_A_Mayor;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorFechaFinalMayorAMenor))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Fecha_Fin_Mayor_A_Menor;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorFechaInicialMenorAMayor))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Fecha_Inicio_Menor_A_Mayor;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorFechaInicialMayorAMenor))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Fecha_Inicio_Mayor_A_Menor;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorPrioridadAMB))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Prioridad_Alta_Media_Baja;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorPrioridadBMA))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Prioridad_Baja_Media_Alta;
            }
            else if (Object.ReferenceEquals(sender, this.btnOrdenarPorPrioridadMAB))
            {
                criterioDeOrdenamiento = Ordenamiento.Criterio.Prioridad_Media_Alta_Baja;
            }

            Ordenamiento.CriterioDeOrdenamientoActual = criterioDeOrdenamiento;

            this.OrganizarDataGrid();
        }

        private void FiltrarTareas(object sender, EventArgs e)
        {
            Filtrar.Filtrado criterioDeFiltrado = Filtrar.Filtrado.Sin_Filtro;

            if(Object.ReferenceEquals(sender, this.btnFiltrarFechaFinalNoTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Fecha_Final_No_Tiene;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarFechaFinalTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Fecha_Final_Tiene;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarFechaInicialNoTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Fecha_Inicial_No_Tiene;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarFechaInicialTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Fecha_Inicial_Tiene;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarFinalizado))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Estado_Finalizado;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarPendiente))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Estado_Pendiente;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarProceso))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Estado_Proceso;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarPrioridadAlta))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Prioridad_Alta;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarPrioridadBaja))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Prioridad_Baja;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarPrioridadMedia))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Prioridad_Media;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarRecordatorioNoTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Recordatorio_No_Tiene;
            }
            else if (Object.ReferenceEquals(sender, this.btnFiltrarRecordatorioTiene))
            {
                criterioDeFiltrado = Filtrar.Filtrado.Recordatorio_Tiene;
            }

            Filtrar.CriterioDeFiltroActual = criterioDeFiltrado;

            this.OrganizarDataGrid();
        }
        
        private void btnQuitarFiltro_Click(object sender, EventArgs e)
        {
            Filtrar.CriterioDeFiltroActual = Filtrar.Filtrado.Sin_Filtro;

            this.OrganizarDataGrid();
        }

        private void btnRestablecerOrden_Click(object sender, EventArgs e)
        {
            Ordenamiento.CriterioDeOrdenamientoActual = Ordenamiento.Criterio.Defecto_Creacion_Primera_A_Ultima;

            this.OrganizarDataGrid();
        }
    }
}
