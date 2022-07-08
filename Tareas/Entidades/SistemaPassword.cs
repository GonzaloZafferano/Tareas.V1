using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SistemaPassword
    {
        private static string password;
        private static bool tienePassword;
        private static SistemaPasswordDAO passwordDAO;

        static SistemaPassword()
        {
            SistemaPassword.TienePassword = false;
            SistemaPassword.password = string.Empty;

            SistemaPassword.passwordDAO = new SistemaPasswordDAO();
        }

        public static string Password
        {
            internal get
            {
                return SistemaPassword.password;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("La contraseña esta vacia.");
                }
                else
                {
                    if(value.Length >= 4 && value.Length <= 12)
                    {
                        SistemaPassword.password = value;
                    }
                    else
                    {
                        throw new DatoInvalidoException("La contraseña debe tener entre 4 y 12 caracteres.");
                    }
                }
            }
        }

        public static bool TienePassword { get => tienePassword; set => tienePassword = value; }

        /// <summary>
        /// Verifica que la password recibida por parametro sea correcta.
        /// </summary>
        /// <param name="password">Password que se evaluara.</param>
        /// <returns>True si la password es correcta, caso contrario False.</returns>
        public static bool VerificarPassword(string password)
        {
            if(!string.IsNullOrWhiteSpace(password) && SistemaPassword.Password == password)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Agrega una nueva password en la base de datos.
        /// </summary>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public static void AgregarPassword()
        {
            try
            {
                SistemaPassword.passwordDAO.InsertarPasswordEnBaseDeDatos();
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza la password en la base de datos.
        /// </summary>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        public static void ActualizarPassword()
        {
            try
            {
                SistemaPassword.passwordDAO.ActualizarPasswordEnBaseDeDatos();
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee la password de la base de datos y la carga al sistema.
        /// </summary>
        public static bool LeerPassword()
        {
            return SistemaPassword.passwordDAO.LeerPasswordDesdeBaseDeDatos();           
        }
    }
}
