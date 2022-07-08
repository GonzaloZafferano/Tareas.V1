using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FechaYHora
    {
        private int anio;
        private int mes;
        private int dia;
        private int hora;
        private int minuto;

        public FechaYHora(string anio, string mes, string dia, string hora, string minuto)
        {
            this.Anio = anio;
            this.Mes = mes;
            this.Dia = dia;
            this.Hora = hora;
            this.Minuto = minuto;
        }

        public string Anio
        {
            get
            {
                return this.anio.ToString();
            }
            private set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    if(int.TryParse(value, out int anio))
                    {
                        if(anio >= 1800)
                        {
                            this.anio = anio;
                        }
                        else
                        {
                            throw new DatoInvalidoException("El campo 'Año' es debe ser mayor o igual que 1800.");
                        }
                    }
                    else
                    {
                        throw new DatoInvalidoException("El campo 'Año' es númerico.");
                    }
                }
                else
                {
                    throw new DatoInvalidoException("Debe completar el campo 'Año'.");
                }
            }
        }

        public string Mes
        {
            get
            {
                return this.mes.ToString();
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (int.TryParse(value, out int mes))
                    {
                        this.mes = mes;
                    }
                    else
                    {
                        throw new DatoInvalidoException("El campo 'Mes' es numerico.");
                    }
                }
                else
                {
                    throw new DatoInvalidoException("Debe completar el campo 'Mes'.");
                }
            }
        }

        public string Dia
        {
            get
            {
                return this.dia.ToString();
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (int.TryParse(value, out int dia))
                    {
                        this.dia = dia;
                    }
                    else
                    {
                        throw new DatoInvalidoException("El campo 'Día' es numerico.");
                    }
                }
                else
                {
                    throw new DatoInvalidoException("Debe completar el campo 'Día'.");
                }
            }
        }

        public string Hora
        {
            get
            {
                return this.hora.ToString();
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (int.TryParse(value, out int hora))
                    {
                        this.hora = hora;
                    }
                    else
                    {
                        throw new DatoInvalidoException("El campo 'Hora' es numerico.");
                    }
                }
                else
                {
                    throw new DatoInvalidoException("Debe completar el campo 'Hora'.");
                }
            }
        }

        public string Minuto
        {
            get
            {
                return this.minuto.ToString();
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (int.TryParse(value, out int minuto))
                    {
                        this.minuto = minuto;
                    }
                    else
                    {
                        throw new DatoInvalidoException("El campo 'Minuto' es numerico.");
                    }
                }
                else
                {
                    throw new DatoInvalidoException("Debe completar el campo 'Minuto'.");
                }
            }
        }

        public DateTime Fecha
        {
            get
            {
                try
                {
                    return new DateTime(this.anio, this.mes, this.dia, this.hora, this.minuto, 0);
                }
                catch(Exception)
                {
                    throw new DatoInvalidoException("La fecha es invalida.");
                }
            }
        }

        /// <summary>
        /// Evalua si un dato es valido.
        /// </summary>
        /// <param name="cadena">Cadena a evaluar.</param>
        /// <param name="evaluacionDeDato">Condicion con la que se evaluara la cadena.</param>
        /// <returns>Un string valido.</returns>
        private static string EsDatoValido(string cadena, Predicate<int> evaluacionDeDato)
        {
            if(!string.IsNullOrWhiteSpace(cadena))          
            {
                if(int.TryParse(cadena, out int datoNumerico) && evaluacionDeDato(datoNumerico))
                {
                    return datoNumerico.ToString();
                }

                //return EsDatoValido(cadena.Substring(0, cadena.Length - 1), evaluacionDeDato);
                return FechaYHora.EsDatoValido(cadena[0..^1], evaluacionDeDato);
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene un año valido (1 - 9999).
        /// </summary>
        /// <param name="anio">dato a evaluar</param>
        /// <returns>String con un año valido</returns>
        public static string ObtenerAnioValido(string anio)
        {
            return FechaYHora.EsDatoValido(anio, (a)=> a > 0 && a <= 9999);
        }

        /// <summary>
        /// Obtiene un mes valido (1 - 12).
        /// </summary>
        /// <param name="mes">dato a evaluar.</param>
        /// <returns>String con un mes valido.</returns>
        public static string ObtenerMesValido(string mes)
        {
            return FechaYHora.EsDatoValido(mes, (m) => m > 0 && m <= 12);
        }

        /// <summary>
        /// Obtiene un dia valido (1 - 31). 
        /// </summary>
        /// <param name="dia">dato a evaluar.</param>
        /// <returns>String con un dia valido.</returns>
        public static string ObtenerDiaValido(string dia)
        {
            return FechaYHora.EsDatoValido(dia, (d) => d > 0 && d <= 31);
        }

        /// <summary>
        /// Obtiene una hora valida (0 - 23).
        /// </summary>
        /// <param name="hora">dato a evaluar.</param>
        /// <returns>Un string con una hora valida.</returns>
        public static string ObtenerHoraValida(string hora)
        {
            return FechaYHora.EsDatoValido(hora, (h) => h >= 0 && h <= 23);
        }

        /// <summary>
        /// Obtiene minutos validos (0 - 60).
        /// </summary>
        /// <param name="minuto">dato a evaluar.</param>
        /// <returns>Un String con minutos validos.</returns>
        public static string ObtenerMinutoValido(string minuto)
        {
            return FechaYHora.EsDatoValido(minuto, (m) => m >= 0 && m <= 60);
        }
    }
}
