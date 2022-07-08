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
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        private void FrmPassword_Load(object sender, EventArgs e)
        {
            this.Text = SistemaPassword.TienePassword ? "Menu: Modificar contraseña" : "Menu: Agregar contraseña";
            this.btnAceptar.Text = SistemaPassword.TienePassword ? "Modificar contraseña" : "Activar contraseña";

            this.lblIngresePasswordActual.Text = SistemaPassword.TienePassword ? "Ingrese contraseña actual:" : "Actualmente sin contraseña.";
            this.btnRemoverPassword.Visible = SistemaPassword.TienePassword;
            this.txtPasswordActual.Visible = SistemaPassword.TienePassword;

            this.AplicarTema();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtPasswordActual.Visible && !SistemaPassword.VerificarPassword(this.txtPasswordActual.Text))
                {
                    throw new DatoInvalidoException("La 'contraseña actual' es invalida.");
                }

                if(this.txtConfirmarPasswordNueva.Text == this.txtPasswordNueva.Text)
                {  
                    SistemaPassword.Password = this.txtConfirmarPasswordNueva.Text;

                    if(SistemaPassword.TienePassword)
                    {
                        SistemaPassword.ActualizarPassword();
                    }
                    else
                    {
                        SistemaPassword.AgregarPassword();
                    }

                    MessageBox.Show($"La contraseña se ha {(SistemaPassword.TienePassword ? "modificado" : "activado")} exitosamente! Se cerrara la sesion.", $"Aviso: Contraseña {(SistemaPassword.TienePassword ? "modificada" : "activada")}.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    SistemaPassword.TienePassword = true;

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new DatoInvalidoException("La 'contraseña nueva' no coincide con la 'contraseña confirmada'.");
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Debe completar todos los campos para operar.", "Aviso: Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DatoInvalidoException ex)
            {
                MessageBox.Show(ex.Message, "Aviso: Datos invalidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error al intentar guardar cambios. Por favor reintente más tarde.", "Aviso: Error al intentar guardar cambios.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoverPassword_Click(object sender, EventArgs e)
        {
            SistemaPassword.TienePassword = false;

            SistemaPassword.ActualizarPassword();

            MessageBox.Show("Contraseña removida exitosamente!", "Aviso: Contraseña removida.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
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
    }
}
