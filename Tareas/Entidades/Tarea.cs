using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Entidades
{
    public class Tarea
    {
        public enum EstadoTarea { Pendiente, Proceso, Finalizado };
        public enum Prioridad { Alta, Media, Baja };

        public event Action<string, string> OnMensajeError;
        public static event Action<string, string> OnLecturaDeBBDD;

        private static TareaDAO tareaDAO;
        private static List<Tarea> tareas;
        private int idTarea;
        private string contenido;
        private EstadoTarea estadoTarea;
        private Prioridad prioridad;
        private DateTime fechaInicial;
        private DateTime fechaFinal;
        private bool tieneFechaInicial;
        private bool tieneFechaFinal;
        private bool tieneRecordatorio;
        private ColorARGB colorTarea;
        private ColorARGB colorLetra;
        private bool cambioElTemaPorDefecto;

        static Tarea()
        {
            Tarea.tareas = new List<Tarea>();
            Tarea.tareaDAO = new TareaDAO();
        }

        public Tarea()
        {
            this.IdTarea = 0;
            this.Contenido = "";
            this.TieneFechaFinal = false;
            this.tieneFechaInicial = false;
            this.TieneRecordatorio = false;
            this.CambioElTemaPorDefecto = false;
            this.EstadoDeTarea = EstadoTarea.Pendiente;
            this.PrioridadTarea = Prioridad.Baja;
        }

        internal Tarea(int idTarea, string contenido, EstadoTarea estadoTarea, Prioridad prioridadTarea, DateTime fechaInicial, DateTime fechaFinal, bool tieneFechaInicial, bool tieneFechaFinal, bool tieneRecordatorio, string colorTarea, string colorLetra, bool cambioElTemaPorDefecto)
        {
            this.IdTarea = idTarea;
            this.Contenido = contenido;
            this.EstadoDeTarea = estadoTarea;
            this.FechaInicial = fechaInicial;
            this.FechaFinal = fechaFinal;
            this.TieneFechaInicial = tieneFechaInicial;
            this.TieneFechaFinal = tieneFechaFinal;
            this.TieneRecordatorio = tieneRecordatorio;
            this.ColorTareaString = colorTarea;
            this.ColorLetraString = colorLetra;
            this.PrioridadTarea = prioridadTarea;
            this.CambioElTemaPorDefecto = cambioElTemaPorDefecto;
        }

        [Browsable(false)]
        public DateTime FechaInicial
        {
            get
            {
                if (this.tieneFechaInicial)
                {
                    return this.fechaInicial;
                }
                return DateTime.Now;
            }
            set
            {
                this.fechaInicial = value;
            }
        }             

        /// <summary>
        /// Obtiene un valor para la fecha inicial (dia/mes/año), en formato String.
        /// </summary>
        public string FechaInicialString
        {
            get
            {
                if (this.TieneFechaInicial)
                {
                    return this.FechaInicial.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "S/F";
                }
            }
        }

        [Browsable(false)]
        /// <summary>
        /// Obtiene un valor para la fecha inicial (dia/mes/año - hora:minutos), en formato String.
        /// </summary>
        public string FechaInicialCompletaString
        {
            get
            {
                if (this.TieneFechaInicial)
                {
                    return this.FechaInicial.ToString("dd/MM/yyyy - hh:mm");
                }
                else
                {
                    return "-";
                }
            }
        }

        [Browsable(false)]
        public DateTime FechaFinal
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.fechaFinal;
                }
                return DateTime.Now;
            }
            set
            {
                this.fechaFinal = value;
            }
        }

        /// <summary>
        /// Obtiene un valor para la fecha final (dia/mes/año), en formato String.
        /// </summary>
        public string FechaFinalString
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.FechaFinal.ToString("dd/MM/yyyy");
                }
                else
                {
                    return "S/F";
                }
            }
        }

        [Browsable(false)]
        /// <summary>
        /// Obtiene un valor para la fecha final (dia/mes/año - hora:minutos), en formato String.
        /// </summary>
        public string FechaFinalCompletaString
        {
            get
            {
                if (this.TieneFechaFinal)
                {
                    return this.FechaFinal.ToString("dd/MM/yyyy - hh:mm");
                }
                else
                {
                    return "-";
                }
            }
        } 

        [Browsable(false)]
        public Color ColorTarea
        {
            get
            {
                if(this.colorTarea == null)
                {
                    return Color.White;
                }
                return Color.FromArgb(this.colorTarea.Alfa, this.colorTarea.Rojo, this.colorTarea.Verde, this.colorTarea.Azul);
            }
            set
            {
                this.colorTarea = new ColorARGB(value.A, value.R, value.G, value.B);
            }
        }

        [Browsable(false)]
        public string ColorTareaString
        {
            get
            {
                return ColorARGB.ObtenerCadenaAPartirDeUnColor(this.colorTarea, '-');
            }
            set
            {
                this.colorTarea = ColorARGB.ObtenerColorAPartirDeUnaCadena(value, '-');
            }
        }

        [Browsable(false)]
        public ColorARGB ColorTareaARGB
        {
            get
            {
                if (this.colorTarea == null)
                {
                    this.colorTarea = new ColorARGB(255, 255, 255, 255);
                }
                return this.colorTarea;
            }
            set
            {
                if (value == null)
                {
                    value = new ColorARGB(255, 255, 255, 255);
                }
                this.colorTarea = value;
            }
        }

        [Browsable(false)]
        public Color ColorLetra
        {
            get
            {
                if (this.colorLetra == null)
                {
                    return Color.Black;
                }
                return Color.FromArgb(this.colorLetra.Alfa, this.colorLetra.Rojo, this.colorLetra.Verde, this.colorLetra.Azul);
            }
            set
            {
                this.colorLetra = new ColorARGB(value.A, value.R, value.G, value.B);
            }
        }

        [Browsable(false)]
        public string ColorLetraString
        {
            get
            {
                return ColorARGB.ObtenerCadenaAPartirDeUnColor(this.colorLetra, '-');
            }
            set
            {
                this.colorLetra = ColorARGB.ObtenerColorAPartirDeUnaCadena(value, '-');
            }
        }

        [Browsable(false)]
        public ColorARGB ColorLetraARGB
        {
            get
            {
                if (this.colorLetra == null)
                {
                    this.colorLetra = new ColorARGB(0, 0, 0, 0);
                }
                return this.colorLetra;
            }
            set
            {
                if (value == null)
                {
                    value = new ColorARGB(0, 0, 0, 0);
                }
                this.colorLetra = value;
            }
        }

        [Browsable(false)]
        public bool TareaEstaVencida
        {
            get
            {
                return this.EstadoDeTarea != Tarea.EstadoTarea.Finalizado &&
                       this.TieneRecordatorio &&
                       this.TieneFechaFinal &&
                       this.FechaFinal <= DateTime.Now;
            }
        }

        [Browsable(false)]
        public bool TareaEstaPendiente
        {
            get
            {
                return this.EstadoDeTarea == Tarea.EstadoTarea.Pendiente &&
                       this.TieneRecordatorio &&
                       this.TieneFechaFinal &&
                       this.FechaFinal > DateTime.Now;
            }
        }

        public string Contenido { get => this.contenido; set => this.contenido = value; }

        public Prioridad PrioridadTarea { get => prioridad; set => prioridad = value; }

        public EstadoTarea EstadoDeTarea { get => this.estadoTarea; set => this.estadoTarea = value; }

        public bool TieneRecordatorio { get => this.tieneRecordatorio; set => this.tieneRecordatorio = value; }

        [Browsable(false)]
        public bool CambioElTemaPorDefecto { get => cambioElTemaPorDefecto; set => cambioElTemaPorDefecto = value; }

        [Browsable(false)]
        public bool TieneFechaInicial { get => this.tieneFechaInicial; set => this.tieneFechaInicial = value; }

        [Browsable(false)]
        public bool TieneFechaFinal { get => this.tieneFechaFinal; set => this.tieneFechaFinal = value; }
             
        [Browsable(false)]
        public int IdTarea { get => this.idTarea; set => this.idTarea = value; }

        [Browsable(false)]
        public static List<Tarea> Tareas { get => Tarea.tareas; private set => Tarea.tareas = value; }

        /// <summary>
        /// Muestra la informacion de la tarea.
        /// </summary>
        /// <returns>Un string con informacion de la tarea.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tarea: {this.Contenido}");
            sb.AppendLine($"Prioridad: {this.PrioridadTarea}");
            sb.AppendLine($"Fecha inicial: {this.FechaInicialString}");
            sb.AppendLine($"Estado: {this.EstadoDeTarea}");
            sb.AppendLine($"Fecha final: {this.FechaFinalString}");

            return sb.ToString();
        }

        /// <summary>
        /// Clona una tarea
        /// </summary>
        /// <returns></returns>
        public Tarea ClonarTarea()
        {
            return new Tarea(this.IdTarea, this.Contenido, this.EstadoDeTarea, this.PrioridadTarea, this.FechaInicial, 
                this.FechaFinal, this.TieneFechaInicial, this.TieneFechaFinal, this.TieneRecordatorio, 
                this.ColorTareaString, this.ColorLetraString, this.CambioElTemaPorDefecto);
        }

        /// <summary>
        /// Copia la tarea recibida por parametro en la tarea invocadora.
        /// </summary>
        /// <param name="tarea">Tarea a copiar.</param>
        public void CopiarTarea(Tarea tarea)
        {
            if(tarea != null)
            {
                this.IdTarea = tarea.IdTarea;
                this.Contenido = tarea.Contenido;
                this.EstadoDeTarea = tarea.EstadoDeTarea;
                this.FechaInicial = tarea.FechaInicial;
                this.FechaFinal = tarea.FechaFinal;
                this.TieneFechaInicial = tarea.TieneFechaInicial;
                this.TieneFechaFinal = tarea.TieneFechaFinal;
                this.TieneRecordatorio = tarea.TieneRecordatorio;
                this.ColorTareaString = tarea.ColorTareaString;
                this.ColorLetraString = tarea.ColorLetraString;
                this.CambioElTemaPorDefecto = tarea.CambioElTemaPorDefecto;
                this.PrioridadTarea = tarea.PrioridadTarea;
            }
        }

        /// <summary>
        /// Lee todas las tareas de la BBDD y las retorna en una lista.
        /// </summary>
        /// <returns>Una lista con todas las tareas de la BBDD. Si no hay tareas en la BBDD, o ha ocurrido un error al intentar cargarlas, retorna una lista vacia.</returns>
        public static List<Tarea> LeerTareasDesdeBaseDeDatos()
        {
            try
            {
                Tarea.Tareas = Tarea.tareaDAO.LeerTodosLosRegistrosDeBaseDeDatos();

                return Tarea.Tareas;
            }
            catch (Exception)
            {
                if (Tarea.OnLecturaDeBBDD != null)
                {
                    Tarea.OnLecturaDeBBDD.Invoke("No se han podido cargar Tareas desde la base de datos. Se iniciara una nueva lista de tareas.", "Error al intentar cargar tareas desde BBDD.");
                }
                return Tarea.Tareas;
            }
        }

        /// <summary>
        /// Agrega una tarea a la lista de tareas.
        /// </summary>
        private static void AgregarTareaALista(Tarea tarea)
        {
            if (tarea is not null && !tarea.ExisteTareaEnLista())
            {
                Tarea.Tareas.Add(tarea);
            }
            else
            {
                throw new NullReferenceException("No se ha podido agregar la tarea.");
            }
        }

        /// <summary>
        /// Elimina una tarea de la lista de tareas.
        /// </summary>
        private void EliminarTareaDeLista()
        {
            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                if (this.IdTarea == Tarea.Tareas[i].IdTarea)
                {
                    this.TieneRecordatorio = false;

                    Tarea.Tareas.RemoveAt(i);

                    break;
                }
            }
        }

        /// <summary>
        /// Evalua si una tarea existe en la lista de tareas, por su Id.
        /// </summary>
        /// <returns>True si la tarea ya esta cargada, caso contrario False.</returns>
        private bool ExisteTareaEnLista()
        {
            for (int i = 0; i < Tarea.Tareas.Count; i++)
            {
                if (Tarea.Tareas[i].IdTarea == this.IdTarea)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Guarda la tarea en la BBDD y en la lista del sistema y la retorna con el ID que se le otorgo.
        /// </summary>
        /// <returns>La tarea con el ID que se le otorgo en la BBDD. En caso de error, retorna null.</returns>
        public Tarea GuardarTareaEnBBDD()
        {
            try
            {
                Tarea tareaConID;

                if (this.IdTarea == 0 || !this.ExisteTareaEnLista())
                {
                    Tarea.tareaDAO.InsertarEnBaseDeDatos(this);

                    tareaConID = Tarea.tareaDAO.ObtenerUltimaTareaCargadaEnBBDD();

                    Tarea.AgregarTareaALista(tareaConID);

                    return tareaConID;
                }
            }
            catch (Exception ex)
            {
                if (this.OnMensajeError != null)
                {
                    this.OnMensajeError.Invoke(ex.Message, "Error al interactuar con la Base de datos.");
                }
            }
            return null;
        }

        /// <summary>
        /// Actualiza una tarea en la BBDD.
        /// </summary>
        public void ActualizarTareaEnBBDD()
        {
            try
            {
                Tarea.tareaDAO.ActualizarEnBaseDeDatos(this);
            }
            catch (Exception ex)
            {
                if (this.OnMensajeError != null)
                {
                    this.OnMensajeError.Invoke(ex.Message, "Error al interactuar con la Base de datos.");
                }
            }
        }

        /// <summary>
        /// Actualiza el recordatorio de una tarea en la BBDD.
        /// </summary>
        public void ActualizarRecordatorioDeTareaEnBBDD()
        {
            try
            {
                Tarea.tareaDAO.ActualizarRecordatorioDeTareaEnBaseDeDatos(this);
            }
            catch (Exception ex)
            {
                if (this.OnMensajeError != null)
                {
                    this.OnMensajeError.Invoke(ex.Message, "Error al interactuar con la Base de datos.");
                }
            }
        }

        /// <summary>
        /// Elimina una tarea de la BBDD y de la lista de tareas.
        /// </summary>
        public void EliminarTareaDeBBDD()
        {
            try
            {
                Tarea.tareaDAO.EliminarDeBaseDeDatos(this);

                this.EliminarTareaDeLista();
            }
            catch(Exception ex)
            {
                if(this.OnMensajeError != null)
                {
                    this.OnMensajeError.Invoke(ex.Message, "Error al intentar borrar.");
                }
            }
        }        

        /// <summary>
        /// Elimina todas las tareas de la Base de datos y del sistema.
        /// </summary>
        /// <exception cref="Exception">Error.</exception>
        public static void EliminarTodasLasTareasDeBBDD()
        {
            try
            {
                Tarea.tareaDAO.EliminarTodasLasTareasDeLaBaseDeDatos();
                Tarea.Tareas.Clear();
            }
            catch(Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
