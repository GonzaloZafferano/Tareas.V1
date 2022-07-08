using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ColorARGB
    {
        private int alfa;
        private int rojo;
        private int verde;
        private int azul;

        public ColorARGB(int alfa, int rojo, int verde, int azul)
        {
            this.Alfa = alfa;
            this.Rojo = rojo;
            this.Verde = verde;
            this.Azul = azul;
        }

        public int Alfa { get => alfa; set => alfa = value; }
        public int Rojo { get => rojo; set => rojo = value; }
        public int Verde { get => verde; set => verde = value; }
        public int Azul { get => azul; set => azul = value; }

        /// <summary>
        /// Obtiene un objeto de tipo ColorARGB a partir de una cadena con valores.
        /// </summary>
        /// <param name="cadena">Cadena que contiene los colores.</param>
        /// <param name="caracterSeparador">Caracter que separa los valores de los colores.</param>
        /// <returns>Un objeto de tipo ColorARGB</returns>
        public static ColorARGB ObtenerColorAPartirDeUnaCadena(string cadena, char caracterSeparador)
        {
            int rojo = 0;
            int azul = 0;
            int verde = 0;
            int alfa = 0;

            if(!string.IsNullOrWhiteSpace(cadena))
            {
                List<string> valores = cadena.Split(caracterSeparador, StringSplitOptions.TrimEntries).ToList();

                try
                {
                    if(valores.Count == 4)
                    {
                        alfa = int.Parse(valores[0]);
                        rojo = int.Parse(valores[1]);
                        verde = int.Parse(valores[2]);
                        azul = int.Parse(valores[3]);
                    }
                }
                catch (Exception) { }
            }
            return new ColorARGB(alfa, rojo, verde, azul);
        }

        /// <summary>
        /// Obtiene una cadena con los valores del color recibido por parametro. 
        /// Esta cadena tendra los colores separados a partir del caracter separador indicado.
        /// </summary>
        /// <param name="color">Color que se convertira a cadena.</param>
        /// <param name="caracterSeparador">Caracter que separara los valores de los colores.</param>
        public static string ObtenerCadenaAPartirDeUnColor(ColorARGB color, char caracterSeparador)
        {
            int alfa = 0;
            int rojo = 0;
            int verde = 0;
            int azul = 0;

            if(color is not null)
            {
                alfa = color.Alfa;
                rojo = color.Rojo;
                verde = color.Verde;
                azul = color.Azul;
            }
            return $"{alfa}{caracterSeparador}{rojo}{caracterSeparador}{verde}{caracterSeparador}{azul}";
        }
    }
}
