using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class SistemaPasswordDAO
    {
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;

        /// <summary>
        /// Constructor de SistemaPasswordDAO. Instancia un objeto que permite interacciones con la BBDD - Tabla DATOS_LOG. 
        /// </summary>
        internal SistemaPasswordDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
        }

        /// <summary>
        /// Inserta una password en la BBDD.
        /// </summary>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        internal void InsertarPasswordEnBaseDeDatos()
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(SistemaPassword.Password))
                {
                    string consultaSQL = "INSERT INTO DATOS_LOG (PASSWORD, PASSWORD_ACTIVA) VALUES (@password, @passwordActiva)";

                    this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, 
                        (comando)=>
                        {
                            comando.Parameters.AddWithValue("@password", SistemaPassword.Password);
                            comando.Parameters.AddWithValue("@passwordActiva", true);
                        });
                }
                else
                {
                    throw new ArgumentNullException("Password es NULL");
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar la contraseña en la Base de datos.");
            }
        }

        /// <summary>
        /// Actualiza un elemento en la BBDD.
        /// </summary>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        internal string ActualizarPasswordEnBaseDeDatos()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(SistemaPassword.Password))
                {
                    string consultaSQL = "UPDATE DATOS_LOG SET PASSWORD = @password, PASSWORD_ACTIVA = @passwordActiva WHERE ID_PASSWORD = (SELECT MAX(DATOS_LOG.ID_PASSWORD) FROM DATOS_LOG)";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL,
                        (comando) =>
                        {
                            comando.Parameters.AddWithValue("@password", SistemaPassword.Password);
                            comando.Parameters.AddWithValue("@passwordActiva", SistemaPassword.TienePassword);
                        });
                }
                else
                {
                    throw new ArgumentNullException("Password es NULL");
                }
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido actualizar la contraseña en la Base de datos.");
            }
        }

        /// <summary>
        /// Lee la ultima password cargada en la Base de datos.
        /// </summary>
        /// <returns>True si pudo leer la contraseña, caso contrario False.</returns>
        internal bool LeerPasswordDesdeBaseDeDatos()
        {
            try
            {
                string consultaSQL = "SELECT * FROM DATOS_LOG WHERE ID_PASSWORD = (SELECT MAX(DATOS_LOG.ID_PASSWORD) FROM DATOS_LOG)";

                 this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, 
                 (sqlLector)=>
                 {
                     bool tienePassword;

                     SistemaPassword.Password = sqlLector["PASSWORD"].ToString();
                     string tienePasswordString = sqlLector["PASSWORD_ACTIVA"].ToString();

                     if(int.TryParse(tienePasswordString, out int tienePasswordInt))
                     {
                        tienePassword = tienePasswordInt == 0 ? false : true;
                     }
                     else
                     {
                         _ = bool.TryParse(tienePasswordString, out tienePassword);
                     }

                     SistemaPassword.TienePassword = tienePassword;

                     return true;
                 });

                return this.interaccionConBaseDeDatos.FilasLeidasConExito == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
