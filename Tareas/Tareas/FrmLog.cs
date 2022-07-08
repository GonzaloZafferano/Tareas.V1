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
    public partial class FrmLog : Form
    {
        private Tema tema;

        public FrmLog()
        {
            InitializeComponent();
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            this.AplicarTema();

            if(!SistemaPassword.LeerPassword() || !SistemaPassword.TienePassword)
            {
                this.Loguear();
            }
        }

        /// <summary>
        /// Loguea al usuario en el sistema.
        /// </summary>
        private void Loguear()
        {
            this.Hide();

            FrmTareas formularioPrincipal = new FrmTareas(this.tema);

            if(formularioPrincipal.ShowDialog() == DialogResult.OK)
            {
                this.AplicarTema();

                this.Show();
            }
            else
            {
                this.Close();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            SistemaPassword.LeerPassword();

            if (SistemaPassword.VerificarPassword(this.txtPassword.Text))
            {
                this.Loguear();
            }
            else
            {
                MessageBox.Show("La contraseña es invalida. No se puede ingresar.","Aviso: Contraseña invalida.",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Aplica un tema en el formulario.
        /// </summary>
        private void AplicarTema()
        {                       
            this.tema = new Tema(Tema.LeerTemaActual());

            this.BackColor = this.tema.ColorDeFondoAplicacion;

            foreach (Control control in this.Controls)
            {
                control.ForeColor = this.tema.ColorDeLetraAlternativo;

                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                }
                else
                {
                    control.BackColor = this.tema.ColorDeFondoAplicacion;

                    if (control is Button boton)
                    {
                        boton.FlatStyle = FlatStyle.Flat;
                        boton.BackColor = this.tema.ColorDeFondoDeControl;
                        boton.FlatAppearance.MouseDownBackColor = this.tema.ColorMouseOver;
                        boton.FlatAppearance.MouseOverBackColor = this.tema.ColorMouseOver;
                        boton.ForeColor = this.tema.ColorDeLetra;
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
