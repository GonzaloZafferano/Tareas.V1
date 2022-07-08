using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    internal class TareaDAO
    {
        private Tarea tarea;
        private List<Tarea> tareas;
        private string resultadoDeLecturaDeBBDD;
        private InteraccionConBaseDeDatos interaccionConBaseDeDatos;

        /// <summary>
        /// Constructor de TareaDAO. Instancia un objeto que permite interacciones con la BBDD - Tabla TAREAS. 
        /// </summary>
        internal TareaDAO()
        {
            this.interaccionConBaseDeDatos = new InteraccionConBaseDeDatos();
            this.tareas = new List<Tarea>();
            this.tarea = null;
            this.resultadoDeLecturaDeBBDD = string.Empty;
        }

        /// <summary>
        /// Retorna una cadena con la cantidad de lineas leidas al realizar una consulta 'SELECT'.
        /// </summary>
        internal string ResultadoDeLecturaDeBBDD
        {
            get
            {
                return this.resultadoDeLecturaDeBBDD;
            }
            private set
            {
                this.resultadoDeLecturaDeBBDD = value;
            }
        }

        /// <summary>
        /// Inserta un elemento en la BBDD.
        /// </summary>
        /// <param name="tarea">Tarea que se cargara en la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        internal string InsertarEnBaseDeDatos(Tarea tarea)
        {
            try
            {
                if (tarea is not null)
                {
                    this.tarea = tarea;

                    string consultaSQL =
                           "INSERT INTO TAREAS (CONTENIDO, ESTADO_TAREA, TIENE_FECHA_INICIAL, FECHA_INICIAL, TIENE_FECHA_FINAL, FECHA_FINAL, TIENE_RECORDATORIO, CAMBIO_TEMA_POR_DEFECTO, COLOR_TAREA, COLOR_LETRA, PRIORIDAD) " +
                           "VALUES(@contenido, @estadoTarea, @tieneFechaInicial, @fechaInicial, @tieneFechaFinal, @fechaFinal, @tieneRecordatorio, @cambioTemaPorDefecto, @colorTarea, @colorLetra, @prioridad)";
                    
                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, this.CargarParametrosSQLParaInsertarRegistro);
                }

                throw new ArgumentNullException("Tarea es NULL");
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar la tarea en la Base de datos.");
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'INSERT', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        private void CargarParametrosSQLParaInsertarRegistro(SqlCommand comando)
        {
            if (comando is not null && this.tarea is not null)
            { 
                this.CargarParametrosDeInsertYUpdate(comando);
            }
            else
            {
                throw new ArgumentNullException("Comando o tarea es NULL");
            }
        }

        /// <summary>
        /// Actualiza un elemento en la BBDD.
        /// </summary>
        /// <param name="tarea">Tarea que se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        internal string ActualizarEnBaseDeDatos(Tarea tarea)
        {
            try
            {
                if (tarea is not null)
                {
                    this.tarea = tarea;

                    string consultaSQL =
                         "UPDATE TAREAS SET CONTENIDO = @contenido, ESTADO_TAREA = @estadoTarea, " +
                         "TIENE_FECHA_INICIAL = @tieneFechaInicial, FECHA_INICIAL = @fechaInicial, " +
                         "TIENE_FECHA_FINAL = @tieneFechaFinal, FECHA_FINAL = @fechaFinal, " +
                         "TIENE_RECORDATORIO = @tieneRecordatorio, CAMBIO_TEMA_POR_DEFECTO = @cambioTemaPorDefecto, " +
                         "COLOR_TAREA = @colorTarea, COLOR_LETRA = @colorLetra, PRIORIDAD = @prioridad WHERE ID_TAREA = @idTarea";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, this.CargarParametrosSQLParaModificarRegistros);
                }
                throw new ArgumentNullException("Tarea es NULL");
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido actualizar la tarea en la Base de datos.");
            }
        }

        /// <summary>
        /// Actualiza el campo 'TIENE_RECORDATORIO' en la BBDD.
        /// </summary>
        /// <param name="tarea">Tarea que se actualizara</param>
        /// <returns>Una cadena con la cantidad de filas afectadas</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        internal string ActualizarRecordatorioDeTareaEnBaseDeDatos(Tarea tarea)
        {
            try
            {
                if (tarea is not null)
                {
                    this.tarea = tarea;

                    string consultaSQL =
                         "UPDATE TAREAS SET TIENE_RECORDATORIO = @tieneRecordatorio WHERE ID_TAREA = @idTarea";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consultaSQL, 
                        (comando)=>
                        {
                            comando.Parameters.AddWithValue("@idTarea", this.tarea.IdTarea);
                            comando.Parameters.AddWithValue("@tieneRecordatorio", this.tarea.TieneRecordatorio);
                        });
                }
                throw new ArgumentNullException("Tarea es NULL");
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido actualizar la tarea en la Base de datos.");
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'UPDATE', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        private void CargarParametrosSQLParaModificarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.tarea is not null)
            {
                comando.Parameters.AddWithValue("@idTarea", this.tarea.IdTarea);

                this.CargarParametrosDeInsertYUpdate(comando);
            }
            else
            {
                throw new ArgumentNullException("Comando o Tarea es NULL");
            }
        }

        /// <summary>
        /// Carga el comando con parametros, para las consultas INSERT y UPDATE.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        private void CargarParametrosDeInsertYUpdate(SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@contenido", this.tarea.Contenido);
            comando.Parameters.AddWithValue("@estadoTarea", this.tarea.EstadoDeTarea);
            comando.Parameters.AddWithValue("@prioridad", this.tarea.PrioridadTarea);
            comando.Parameters.AddWithValue("@tieneFechaInicial", this.tarea.TieneFechaInicial);
            comando.Parameters.AddWithValue("@fechaInicial", this.tarea.FechaInicial);
            comando.Parameters.AddWithValue("@tieneFechaFinal", this.tarea.TieneFechaFinal);
            comando.Parameters.AddWithValue("@fechaFinal", this.tarea.FechaFinal);
            comando.Parameters.AddWithValue("@tieneRecordatorio", this.tarea.TieneRecordatorio);
            comando.Parameters.AddWithValue("@cambioTemaPorDefecto", this.tarea.CambioElTemaPorDefecto);
            comando.Parameters.AddWithValue("@colorTarea", this.tarea.ColorTareaString);
            comando.Parameters.AddWithValue("@colorLetra", this.tarea.ColorLetraString);
        }

        /// <summary>
        /// Elimina un elemento en la BBDD.
        /// </summary>
        /// <param name="tarea">Tarea que se eliminara de la BBDD.</param>
        /// <returns>Una cadena con la cantidad de filas afectadas.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        internal string EliminarDeBaseDeDatos(Tarea tarea)
        {
            try
            {
                if (tarea is not null)
                {
                    this.tarea = tarea;

                    string consulta = "DELETE FROM TAREAS WHERE ID_TAREA = @idTarea";

                    return this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consulta, this.CargarParametrosSQLParaEliminarRegistros);

                }
                throw new ArgumentNullException("Tarea es NULL");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Carga los parametros necesarios en el comando SQL para una consulta de tipo 'DELETE', 
        /// para interactuar con la BBDD.
        /// </summary>
        /// <param name="comando">Comando SQL donde se cargaran parametros</param>
        /// <exception cref="ArgumentNullException">Parametros NULL</exception>
        private void CargarParametrosSQLParaEliminarRegistros(SqlCommand comando)
        {
            if (comando is not null && this.tarea is not null)
            {
                comando.Parameters.AddWithValue("@idTarea", this.tarea.IdTarea);
            }
            else
            {
                throw new ArgumentNullException("Comando o tarea es NULL");
            }
        }

        /// <summary>
        /// Elimina todas las tareas de la Base de Datos.
        /// </summary>
        internal void EliminarTodasLasTareasDeLaBaseDeDatos()
        {
            try
            {         
                string consulta = "DELETE FROM TAREAS";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeModificacionDeRegistros(consulta, (comando) => { });          
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los registros de la Base de datos.
        /// </summary>
        /// <returns>Una lista con todos los registros leidos de la BBDD.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        internal List<Tarea> LeerTodosLosRegistrosDeBaseDeDatos()
        {
            try
            {
                this.tareas.Clear();

                string consultaSQL = "SELECT * FROM TAREAS";

                this.ResultadoDeLecturaDeBBDD = this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSQL, this.LeerSqlData);

                return this.tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Lee todos los datos de una tarea, contenida en el 'SqlDataReader'. 
        /// Posteriormente crea a la tarea y la carga en una lista.
        /// </summary>
        /// <param name="sqlLector">Objeto de tipo SqlDataReader, del cual se leeran los datos.</param>
        /// <returns>True si pudo leer los datos de la tarea correctamente. Caso contrario False.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="DatoInvalidoException">Error al intentar obtener el registro de la BBDD.</exception>
        private bool LeerSqlData(SqlDataReader sqlLector)
        {
            Tarea tarea;

            try
            {
                if (sqlLector is not null)
                {
                    string colorTarea = sqlLector["COLOR_TAREA"].ToString();
                    string colorLetra = sqlLector["COLOR_LETRA"].ToString();
                    string contenido = sqlLector["CONTENIDO"].ToString();
                    _ = int.TryParse(sqlLector["ID_TAREA"].ToString(), out int idTarea);
                    _ = DateTime.TryParse(sqlLector["FECHA_INICIAL"].ToString(), out DateTime fechaInicial);
                    _ = DateTime.TryParse(sqlLector["FECHA_FINAL"].ToString(), out DateTime fechaFinal);

                    _ = int.TryParse(sqlLector["ESTADO_TAREA"].ToString(), out int estadoTareaInt);
                    _ = int.TryParse(sqlLector["PRIORIDAD"].ToString(), out int prioridadTareaInt);
                    _ = int.TryParse(sqlLector["TIENE_FECHA_INICIAL"].ToString(), out int tieneFechaInicialInt);
                    _ = int.TryParse(sqlLector["TIENE_FECHA_FINAL"].ToString(), out int tieneFechaFinalInt);
                    _ = int.TryParse(sqlLector["TIENE_RECORDATORIO"].ToString(), out int tieneRecordatorioInt);
                    _ = int.TryParse(sqlLector["CAMBIO_TEMA_POR_DEFECTO"].ToString(), out int cambioTemaPorDefectoInt);

                    Tarea.Prioridad prioridadTarea = (Tarea.Prioridad)prioridadTareaInt;
                    Tarea.EstadoTarea estadoTarea = (Tarea.EstadoTarea)estadoTareaInt;
                    bool tieneFechaInicial = tieneFechaInicialInt == 0 ? false : true;
                    bool tieneFechaFinal = tieneFechaFinalInt == 0 ? false : true;
                    bool tieneRecordatorio = tieneRecordatorioInt == 0 ? false : true;
                    bool cambioTemaPorDefecto = cambioTemaPorDefectoInt == 0 ? false : true;

                    tarea = new Tarea(idTarea, contenido, estadoTarea, prioridadTarea, fechaInicial, fechaFinal, tieneFechaInicial, tieneFechaFinal, tieneRecordatorio, colorTarea, colorLetra, cambioTemaPorDefecto);
                                      
                    this.tareas.Add(tarea);

                    return true;                    
                }
                throw new DatoInvalidoException("Error al intentar obtener registros de la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene la ultima tarea cargada en la Base de datos.
        /// </summary>
        /// <returns>La ultima tarea cargada en la Base de datos.</returns>
        /// <exception cref="Exception">Relanza la excepcion capturada.</exception>
        /// <exception cref="NullReferenceException">Error al intentar obtener el ultimo elemento de la BBDD.</exception>
        internal Tarea ObtenerUltimaTareaCargadaEnBBDD()
        {
            try
            {
                this.tareas.Clear();

                string consultaSql = "SELECT * FROM TAREAS WHERE ID_TAREA = (SELECT MAX(TAREAS.ID_TAREA) FROM TAREAS)";

                this.interaccionConBaseDeDatos.EjecutarConsultaDeLecturaDeRegistros(consultaSql, this.LeerSqlData);

                if (this.tareas.Count == 1)
                {
                    return this.tareas[0];
                }
                throw new NullReferenceException("No se pudo leer la ultima tarea cargada en la Base de datos");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

