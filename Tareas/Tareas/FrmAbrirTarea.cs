using System;
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
    public partial class FrmAbrirTarea : Form
    {
        public event Action<int> OnCerrarTarea;
        public event Action OnRefrescarDataGrid;

        private Tarea tarea;
        private Tarea tareaAuxiliar;
        private bool esModificacion;

        public FrmAbrirTarea(Tarea tarea, bool esModificacion)
        {
            InitializeComponent();

            this.tarea = tarea;
            this.tareaAuxiliar = this.tarea.ClonarTarea(); 
            this.esModificacion = esModificacion;
        }

        private void FrmAgregarTarea_Load(object sender, EventArgs e)
        {
            this.tarea.OnMensajeError += this.MostrarMensajeError;

            this.Text = this.esModificacion ? "Menú: Modificacion de tarea" : "Menú: Alta de tarea";

            this.cmbBoxEstado.DataSource = Enum.GetValues(typeof(Tarea.EstadoTarea));
            this.cmbBoxEstado.SelectedItem = this.tareaAuxiliar.EstadoDeTarea;

            this.cmbBoxPrioridad.DataSource = Enum.GetValues(typeof(Tarea.Prioridad));
            this.cmbBoxPrioridad.SelectedItem = this.tareaAuxiliar.PrioridadTarea;

            this.lblFechaInicial.Text = this.tareaAuxiliar.FechaInicialCompletaString;
            this.lblFechaFinal.Text = this.tareaAuxiliar.FechaFinalCompletaString;

            this.cBoxRecordatorio.Checked = this.tareaAuxiliar.TieneRecordatorio;

            this.rTxtContenidoTarea.Text = this.tareaAuxiliar.Contenido;

            this.AplicarTemaEnTarea();

            this.rTxtContenidoTarea.Focus();
        }

        private void btnFechaInicial_Click(object sender, EventArgs e)
        {
            FrmCargarFecha fecha = new FrmCargarFecha(this.tareaAuxiliar, false);

            if(fecha.ShowDialog() == DialogResult.OK)
            {
                this.lblFechaInicial.Text = this.tareaAuxiliar.FechaInicialCompletaString;      
            }
        }

        private void btnFechaFinal_Click(object sender, EventArgs e)
        {
            FrmCargarFecha fecha = new FrmCargarFecha(this.tareaAuxiliar, true);

            if (fecha.ShowDialog() == DialogResult.OK)
            {
                this.lblFechaFinal.Text = this.tareaAuxiliar.FechaFinalCompletaString;
            }
        }

        /// <summary>
        /// Aplica un tema en el formulario.
        /// </summary>
        private void AplicarTemaEnTarea()
        {
            if (!this.tareaAuxiliar.CambioElTemaPorDefecto)
            {
                this.AplicarTemaPorDefecto();
            }
            else
            {
                ModificadorDeColor.ColorParaResaltarControles(this.tareaAuxiliar.ColorLetra, this.tareaAuxiliar.ColorLetra == this.tareaAuxiliar.ColorTarea ? 100 : 0, true, this.AplicarColorParaLetra);
                ModificadorDeColor.ColorParaResaltarControles(this.tareaAuxiliar.ColorTarea, -30, true, this.AplicarColorParaFondoConTransparencia);
                ModificadorDeColor.ColorParaResaltarControles(this.tareaAuxiliar.ColorTarea, -30, false, this.AplicarColorParaFondoSinTransparencia);
                ModificadorDeColor.ColorParaResaltarControles(this.tareaAuxiliar.ColorTarea, 50, true, this.AplicarColorParaEfectosEnBotones);
            }
        }

        /// <summary>
        /// Aplica el tema por defecto en el formulario.
        /// </summary>
        private void AplicarTemaPorDefecto()
        {
            this.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlternativo;

                if (control is Label)
                {      
                    control.BackColor = Color.Transparent;
                }
                else if(control is RichTextBox)
                {
                    control.BackColor = FrmTareas.TemaAplicacion.ColorFondoDeControlAlternativo;
                }
                else
                {
                    control.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;

                    if (control is Button boton)
                    {
                        boton.FlatStyle = FlatStyle.Flat;
                        boton.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoDeControl;
                        boton.FlatAppearance.MouseDownBackColor = FrmTareas.TemaAplicacion.ColorMouseOver;
                        boton.FlatAppearance.MouseOverBackColor = FrmTareas.TemaAplicacion.ColorMouseOver;
                        boton.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetra;
                        boton.FlatAppearance.BorderSize = 0;
                    }
                }
            }

            this.tareaAuxiliar.ColorTarea = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;
            this.tareaAuxiliar.ColorLetra = FrmTareas.TemaAplicacion.ColorDeLetra;
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en las letras de controles del formulario.
        /// </summary>
        /// <param name="colorBase">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void AplicarColorParaLetra(Color colorBase, Color colorModificado)
        {
            foreach (Control control in this.Controls)
            {
                control.ForeColor = colorModificado;
            }

            this.tareaAuxiliar.ColorLetra = colorModificado;
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en los fondos de controles del formulario que aceptan transparencia.
        /// </summary>
        /// <param name="colorBase">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void AplicarColorParaFondoConTransparencia(Color colorBase, Color colorModificado)
        {           
            foreach (Control control in this.Controls)
            {
                if (control is Label || control is CheckBox)
                {
                    control.BackColor = Color.Transparent;
                }
                else if (control is Button)
                {
                    control.BackColor = colorModificado;
                }
            }
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en los fondos de controles del formulario que NO aceptan transparencia.
        /// </summary>
        /// <param name="colorBase">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void AplicarColorParaFondoSinTransparencia(Color colorBase, Color colorModificado)
        {
            this.BackColor = colorBase;

            _ = colorModificado;

            foreach (Control control in this.Controls)
            {
                if (control is RichTextBox || control is ComboBox)
                {
                    control.BackColor = colorBase;
                }
            }
        }

        /// <summary>
        /// Carga los colores recibidos por parametros en los efectos de botones.
        /// </summary>
        /// <param name="colorBase">Color original.</param>
        /// <param name="colorModificado">Color modificado.</param>
        private void AplicarColorParaEfectosEnBotones(Color colorBase, Color colorModificado)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button boton)
                {
                    boton.FlatStyle = FlatStyle.Flat;
                    boton.BackColor = colorBase;
                    boton.FlatAppearance.MouseDownBackColor = colorModificado;
                    boton.FlatAppearance.MouseOverBackColor = colorModificado;
                    boton.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = this.tareaAuxiliar.ColorTarea;

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.tareaAuxiliar.ColorTarea = color.Color;
                this.tareaAuxiliar.ColorLetra = color.Color;

                this.tareaAuxiliar.CambioElTemaPorDefecto = true;

                this.AplicarTemaEnTarea();
            }
        }

        private void btnColorLetra_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = this.tareaAuxiliar.ColorLetra;

            if (color.ShowDialog() == DialogResult.OK)
            {
                this.tareaAuxiliar.ColorLetra = color.Color;

                this.tareaAuxiliar.CambioElTemaPorDefecto = true;

                ModificadorDeColor.ColorParaResaltarControles(this.tareaAuxiliar.ColorLetra, this.tareaAuxiliar.ColorLetra == this.tareaAuxiliar.ColorTarea ? 100 : 0, true, this.AplicarColorParaLetra);
            }
        }

        private void btnRestaurarTema_Click(object sender, EventArgs e)
        {
            this.tareaAuxiliar.CambioElTemaPorDefecto = false;

            this.AplicarTemaEnTarea();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {     
            _ = Enum.TryParse(cmbBoxEstado.SelectedValue.ToString(), out Tarea.EstadoTarea estadoTarea);
            this.tareaAuxiliar.EstadoDeTarea = estadoTarea;

            _ = Enum.TryParse(cmbBoxPrioridad.SelectedValue.ToString(), out Tarea.Prioridad prioridadTarea);
            this.tareaAuxiliar.PrioridadTarea = prioridadTarea;

            this.tareaAuxiliar.Contenido = this.rTxtContenidoTarea.Text;
            this.tareaAuxiliar.TieneRecordatorio = this.cBoxRecordatorio.Checked;

            this.tarea.CopiarTarea(this.tareaAuxiliar);            

            if (this.esModificacion)
            {
                this.tarea.ActualizarTareaEnBBDD();
            }
            else
            {
                this.tarea.GuardarTareaEnBBDD();
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void MostrarMensajeError(string mensaje, string titulo)
        {
            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmAgregarTarea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.OnCerrarTarea != null)
            {
                this.OnCerrarTarea.Invoke(this.tareaAuxiliar.IdTarea);
            }

            if(this.DialogResult == DialogResult.OK && this.OnRefrescarDataGrid != null)
            {
                this.OnRefrescarDataGrid.Invoke();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
