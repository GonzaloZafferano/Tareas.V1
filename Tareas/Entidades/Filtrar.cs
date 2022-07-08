using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Filtrar
    {
        public enum Filtrado
        {
            Sin_Filtro,
            Estado_Pendiente,
            Estado_Proceso,
            Estado_Finalizado,
            Prioridad_Alta,
            Prioridad_Baja,
            Prioridad_Media,
            Fecha_Final_No_Tiene,
            Fecha_Final_Tiene,
            Fecha_Inicial_Tiene,
            Fecha_Inicial_No_Tiene,
            Recordatorio_Tiene,
            Recordatorio_No_Tiene
        }

        public static event Action<string> OnFiltrar;

        private const string rutaArchivo = "Filtro/Filtro";
        private static List<Tarea> tareasFiltradas;
        private static Filtrado criterioDeFiltroActual;

        static Filtrar()
        {
            try
            {
                string criterioDeFiltro = SerializadorJSON<string>.Leer(Filtrar.rutaArchivo);

                _ = Enum.TryParse(criterioDeFiltro, out Filtrar.Filtrado criterio);

                Filtrar.criterioDeFiltroActual = criterio;
            }
            catch (Exception)
            {
                Filtrar.criterioDeFiltroActual = Filtrado.Sin_Filtro;
            }
        }

        public static Filtrado CriterioDeFiltroActual
        {
            get
            {
                return Filtrar.criterioDeFiltroActual;
            }
            set
            {
                Filtrar.criterioDeFiltroActual = value;
            }
        }

        /// <summary>
        /// Recibe una lista y la copia, luego filtra la copia, acorde al criterio de filtro que tenga establecido la clase.
        /// </summary>
        /// <param name="tareas">Tareas a filtrar.</param>
        /// <returns>Una copia de la lista filtrada. Si el criterio es 'Sin Filtro', retorna la lista completa original de Tareas (Reseteando cualquier filtro aplicado).</returns>
        public static List<Tarea> FiltrarTareas(List<Tarea> tareas)
        {
            if(tareas != null)
            {
                string mensaje = string.Empty;
                Filtrar.tareasFiltradas = tareas.ToList();
                
                switch(Filtrar.criterioDeFiltroActual)
                {
                    case Filtrado.Sin_Filtro:
                        Filtrar.tareasFiltradas = Tarea.Tareas;
                        mensaje = $"Filtro Actual: {Environment.NewLine}Sin Filtro";
                        break;
                    case Filtrado.Estado_Pendiente:
                        Filtrar.FiltrarPorEstado_Pendiente();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Tareas Pendientes";
                        break;
                    case Filtrado.Estado_Proceso:
                        Filtrar.FiltrarPorEstado_Proceso();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Tareas En Proceso";
                        break;
                    case Filtrado.Estado_Finalizado:
                        Filtrar.FiltrarPorEstado_Finalizado();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Tareas Finalizadas";
                        break;
                    case Filtrado.Prioridad_Alta:
                        Filtrar.FiltrarPorPrioridad_Alta();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Prioridad Alta";
                        break;
                    case Filtrado.Prioridad_Baja:
                        Filtrar.FiltrarPorPrioridad_Baja();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Prioridad Baja";
                        break;
                    case Filtrado.Prioridad_Media:
                        Filtrar.FiltrarPorPrioridad_Media();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Prioridad Media";
                        break;
                    case Filtrado.Fecha_Final_No_Tiene:
                        Filtrar.FiltrarPorFecha_Final_No_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Sin Fecha Final";
                        break;
                    case Filtrado.Fecha_Final_Tiene:
                        Filtrar.FiltrarPorFecha_Final_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Con Fecha Final";
                        break;
                    case Filtrado.Fecha_Inicial_Tiene:
                        Filtrar.FiltrarPorFecha_Inicial_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Con Fecha Inicial";
                        break;
                    case Filtrado.Fecha_Inicial_No_Tiene:
                        Filtrar.FiltrarPorFecha_Inicial_No_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Sin Fecha Inicial";
                        break;
                    case Filtrado.Recordatorio_Tiene:
                        Filtrar.FiltrarPorRecordatorio_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Con Recordatorio";
                        break;
                    case Filtrado.Recordatorio_No_Tiene:
                        Filtrar.FiltrarPorRecordatorio_No_Tiene();
                        mensaje = $"Filtro Actual: {Environment.NewLine}Sin Recordatorio";
                        break;                    
                }

                if(Filtrar.OnFiltrar != null)
                {
                    Filtrar.OnFiltrar.Invoke(mensaje);
                }

                try
                {
                    SerializadorJSON<string>.Guardar(Filtrar.rutaArchivo, Filtrar.criterioDeFiltroActual.ToString());
                }
                catch (Exception) { }

                return Filtrar.tareasFiltradas;
            }
            return tareas;
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Estado_Pendiente'
        /// </summary>
        private static void FiltrarPorEstado_Pendiente()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t)=> t.EstadoDeTarea == Tarea.EstadoTarea.Pendiente).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Estado_Proceso'
        /// </summary>
        private static void FiltrarPorEstado_Proceso()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.EstadoDeTarea == Tarea.EstadoTarea.Proceso).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Estado_Finalizado'
        /// </summary>
        private static void FiltrarPorEstado_Finalizado()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.EstadoDeTarea == Tarea.EstadoTarea.Finalizado).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Prioridad_Alta'
        /// </summary>
        private static void FiltrarPorPrioridad_Alta()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.PrioridadTarea == Tarea.Prioridad.Alta).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Prioridad_Baja'
        /// </summary>
        private static void FiltrarPorPrioridad_Baja()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.PrioridadTarea == Tarea.Prioridad.Baja).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Prioridad_Media'
        /// </summary>
        private static void FiltrarPorPrioridad_Media()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.PrioridadTarea == Tarea.Prioridad.Media).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Fecha_Final_No_Tiene'
        /// </summary>
        private static void FiltrarPorFecha_Final_No_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneFechaFinal == false).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Fecha_Final_Tiene'
        /// </summary>
        private static void FiltrarPorFecha_Final_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneFechaFinal == true).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Fecha_Inicial_Tiene'
        /// </summary>
        private static void FiltrarPorFecha_Inicial_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneFechaInicial == true).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Fecha_Inicial_No_Tiene'
        /// </summary>
        private static void FiltrarPorFecha_Inicial_No_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneFechaInicial == false).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Recordatorio_Tiene'
        /// </summary>
        private static void FiltrarPorRecordatorio_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneRecordatorio == true).ToList();
        }

        /// <summary>
        /// Filtra una lista por el criterio 'Recordatorio_No_Tiene'
        /// </summary>
        private static void FiltrarPorRecordatorio_No_Tiene()
        {
            Filtrar.tareasFiltradas = Filtrar.tareasFiltradas.Where((t) => t.TieneRecordatorio == false).ToList();
        }
    }
}
