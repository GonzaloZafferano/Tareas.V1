using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Vista
{
    public partial class FrmCargarFecha : Form
    {
        private Tarea tareaAuxiliar;
        private bool esFechaFinal;

        public FrmCargarFecha(Tarea tareaAuxiliar, bool esFechaFinal)
        {
            InitializeComponent();

            this.tareaAuxiliar = tareaAuxiliar;
            this.esFechaFinal = esFechaFinal;
        }    

        private void FrmAgregarFecha_Load(object sender, EventArgs e)
        {
            this.AplicarTema();

            this.calendario.MinDate = new DateTime(1800, 1, 1);
            this.calendario.MaxDate = new DateTime(2200, 12, 29);
            this.calendario.MaxSelectionCount = 1;

            this.Text = this.esFechaFinal ? "Menu: Asignar fecha final" : "Menu: Asignar fecha inicial";
        
            if(this.esFechaFinal && this.tareaAuxiliar.TieneFechaFinal)
            {
                this.CargarFecha(this.tareaAuxiliar.FechaFinal);
            }
            else if(!this.esFechaFinal && this.tareaAuxiliar.TieneFechaInicial)
            {
                this.CargarFecha(this.tareaAuxiliar.FechaInicial);
            }
            else
            {
                this.CargarFecha(DateTime.Now);
            }
        } 

        /// <summary>
        /// Carga la fecha recibida por parametro, en los distintos textbox.
        /// </summary>
        /// <param name="fecha">Fecha que se cargara.</param>
        private void CargarFecha(DateTime fecha)
        {
            this.txtAnio.Text = fecha.Year.ToString();
            this.txtMes.Text = fecha.Month.ToString();
            this.txtDia.Text = fecha.Day.ToString();
            this.txtHora.Text = fecha.Hour.ToString();
            this.txtMinutos.Text = fecha.Minute.ToString();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if(Object.ReferenceEquals(sender, this.txtAnio))
            {
                this.txtAnio.Text = FechaYHora.ObtenerAnioValido(this.txtAnio.Text);
            }
            else if (Object.ReferenceEquals(sender, this.txtMes))
            {
                this.txtMes.Text = FechaYHora.ObtenerMesValido(this.txtMes.Text);
            }
            else if (Object.ReferenceEquals(sender, this.txtDia))
            {
                this.txtDia.Text = FechaYHora.ObtenerDiaValido(this.txtDia.Text);
            }
            else if (Object.ReferenceEquals(sender, this.txtHora))
            {
                this.txtHora.Text = FechaYHora.ObtenerHoraValida(this.txtHora.Text);
            }
            else if (Object.ReferenceEquals(sender, this.txtMinutos))
            {
                this.txtMinutos.Text = FechaYHora.ObtenerMinutoValido(this.txtMinutos.Text);
            }

            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
        }        

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                FechaYHora fecha = new FechaYHora(this.txtAnio.Text, this.txtMes.Text, this.txtDia.Text, this.txtHora.Text, this.txtMinutos.Text);

                if(this.esFechaFinal)
                {
                    if(!this.tareaAuxiliar.TieneFechaInicial || fecha.Fecha >= this.tareaAuxiliar.FechaInicial)
                    {
                        this.tareaAuxiliar.FechaFinal = fecha.Fecha;
                        this.tareaAuxiliar.TieneFechaFinal = true;
                    }
                    else
                    {
                        throw new DatoInvalidoException($"La fecha final ({fecha.Fecha}) no puede ser menor que la fecha inicial ({this.tareaAuxiliar.FechaInicial}).");
                    }
                }
                else
                {
                    if(!this.tareaAuxiliar.TieneFechaFinal || fecha.Fecha<= this.tareaAuxiliar.FechaFinal)
                    {
                        this.tareaAuxiliar.FechaInicial = fecha.Fecha;
                        this.tareaAuxiliar.TieneFechaInicial = true;
                    }
                    else
                    {
                        throw new DatoInvalidoException($"La fecha inicial ({fecha.Fecha}) no puede ser mayor que la fecha final ({this.tareaAuxiliar.FechaFinal}).");
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch(DatoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Error en carga de datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            this.txtAnio.Clear();
            this.txtMes.Clear();
            this.txtDia.Clear();
            this.txtHora.Clear();
            this.txtMinutos.Clear();
        }

        private void btnQuitarFecha_Click(object sender, EventArgs e)
        {
            if(this.esFechaFinal)
            {
                this.tareaAuxiliar.TieneFechaFinal = false;
            }
            else
            {
                this.tareaAuxiliar.TieneFechaInicial = false;
            }

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Aplica un tema en el formulario.
        /// </summary>
        private void AplicarTema()
        {
            this.BackColor = FrmTareas.TemaAplicacion.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.ForeColor = FrmTareas.TemaAplicacion.ColorDeLetraAlternativo;

                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
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
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.CargarFecha(calendario.SelectionStart);
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            this.CargarFecha(DateTime.Now);
        }
    }
}
