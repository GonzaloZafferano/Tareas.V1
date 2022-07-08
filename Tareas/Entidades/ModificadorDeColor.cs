using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModificadorDeColor
    {
        /// <summary>
        /// Modifica un color base, en la medida de color especificada por parametro (-254 a 254), 
        /// y envia el color original y modificado a un delegado para que los utilice.
        /// </summary>
        /// <param name="colorBase">Color base a partir del cual se crearan otros colores.</param>
        /// <param name="medidaDeColor">Medida en la que se modificaran los colores (puede ser negativo o positivo, entre -254 a 254)</param>
        /// <param name="aceptaAlfa">Determina si el color base y modificado aceptan alfa (transparencia).</param>
        /// <param name="metodoDeAplicacionDeColores">Metodo que aplicara los colores modificados en los controles necesarios.</param>
        public static void ColorParaResaltarControles(Color colorBase, int medidaDeColor, bool aceptaAlfa, Action<Color, Color> metodoDeAplicacionDeColores)
        {
            Predicate<int> esColorValido = medidaDeColor >= 0 ?
                                           color => color + medidaDeColor <= 254 :
                                           color => color + medidaDeColor >= 1;

            int alfa = colorBase.A > 0 ? colorBase.A : 1;
            int rojo = colorBase.R > 0 ? colorBase.R : 1;
            int verde = colorBase.G > 0 ? colorBase.G : 1;
            int azul = colorBase.B > 0 ? colorBase.B : 1;

            alfa = esColorValido(alfa) ? alfa + medidaDeColor : alfa;
            rojo = esColorValido(rojo) ? rojo + medidaDeColor : rojo;
            verde = esColorValido(verde) ? verde + medidaDeColor : verde;
            azul = esColorValido(azul) ? azul + medidaDeColor : azul;

            Color colorModificado;

            if(aceptaAlfa)
            {
                colorModificado = Color.FromArgb(alfa, rojo, verde, azul);
            }
            else
            {
                colorModificado = Color.FromArgb(rojo, verde, azul);
                colorBase = Color.FromArgb(colorBase.R, colorBase.G, colorBase.B);
            }

            if (metodoDeAplicacionDeColores != null)
            {
                metodoDeAplicacionDeColores.Invoke(colorBase, colorModificado);
            }
        }
    }
}
