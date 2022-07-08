using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ordenamiento
    {
        public enum Criterio
        { 
            Fecha_Fin_Menor_A_Mayor, 
            Fecha_Fin_Mayor_A_Menor,
            Fecha_Inicio_Menor_A_Mayor,
            Fecha_Inicio_Mayor_A_Menor,
            Prioridad_Alta_Media_Baja,
            Prioridad_Media_Alta_Baja,
            Prioridad_Baja_Media_Alta,
            Estado_Fin_Proceso_Pendiente,
            Estado_Proceso_Pendiente_Fin,
            Estado_Pendiente_Proceso_Fin,
            Defecto_Creacion_Primera_A_Ultima,
            Defecto_Creacion_Ultima_A_Primera            
        }

        public static event Action<string> OnOrdenar;

        private const string rutaArchivo = "Ordenamiento/Ordenamiento";
        private static List<Tarea> tareasOrdenadas;
        private static Criterio criterioDeOrdenamientoActual;

        static Ordenamiento()
        {
            try
            {
                string criterioDeOrdenamiento = SerializadorJSON<string>.Leer(Ordenamiento.rutaArchivo);

                _ = Enum.TryParse(criterioDeOrdenamiento, out Ordenamiento.Criterio criterio);

                Ordenamiento.criterioDeOrdenamientoActual = criterio;
            }
            catch(Exception)
            {
                Ordenamiento.criterioDeOrdenamientoActual = Criterio.Defecto_Creacion_Primera_A_Ultima;
            }
        }

        public static Criterio CriterioDeOrdenamientoActual
        {
            get
            {
                return Ordenamiento.criterioDeOrdenamientoActual;
            }
            set
            {
                Ordenamiento.criterioDeOrdenamientoActual = value;
            }
        }
        
        /// <summary>
        /// Recibe una lista y la copia, luego ordera la copia, acorde al criterio de ordenamiento de la clase.
        /// </summary>
        /// <param name="tareas">Lista a ordenar.</param>
        /// <returns>Una copia de la lista ordenada. Si recibe una lista nula, retorna null.</returns>
        public static List<Tarea> Ordenar(List<Tarea> tareas)
        {
            if(tareas != null)
            {
                string mensaje = string.Empty;
                Ordenamiento.tareasOrdenadas = tareas.ToList();

                switch(Ordenamiento.criterioDeOrdenamientoActual)
                {
                    case Criterio.Defecto_Creacion_Primera_A_Ultima:
                        mensaje = $"Orden Actual: {Environment.NewLine}Por defecto (Descendente)";
                        break;
                    case Criterio.Defecto_Creacion_Ultima_A_Primera:
                        Ordenamiento.OrdenarPorDefecto_Creacion_Ultima_A_Primera();
                        mensaje = $"Orden Actual: {Environment.NewLine}Por defecto (Ascendente)";
                        break;
                    case Criterio.Estado_Fin_Proceso_Pendiente:
                        Ordenamiento.OrdenarPorEstado_Fin_Proceso_Pendiente();
                        mensaje = $"Orden Actual: {Environment.NewLine}Estado (Finalizado - Proceso - Pendiente)";
                        break;
                    case Criterio.Estado_Pendiente_Proceso_Fin:
                        Ordenamiento.OrdenarPorEstado_Pendiente_Proceso_Fin();
                        mensaje = $"Orden Actual: {Environment.NewLine}Estado (Pendiente - Proceso - Finalizado)";
                        break;
                    case Criterio.Estado_Proceso_Pendiente_Fin:
                        Ordenamiento.OrdenarPorEstado_Proceso_Pendiente_Fin();
                        mensaje = $"Orden Actual: {Environment.NewLine}Estado (Proceso - Pendiente - Finalizado)";
                        break;
                    case Criterio.Prioridad_Alta_Media_Baja:
                        Ordenamiento.OrdenarPorPrioridad_Alta_Media_Baja();
                        mensaje = $"Orden Actual: {Environment.NewLine}Proridad {Environment.NewLine}(Alta - Media - Baja)";
                        break;
                    case Criterio.Prioridad_Baja_Media_Alta:
                        Ordenamiento.OrdenarPorPrioridad_Baja_Media_Alta();
                        mensaje = $"Orden Actual: {Environment.NewLine}Proridad {Environment.NewLine}(Baja - Media - Alta)";
                        break;
                    case Criterio.Prioridad_Media_Alta_Baja:
                        Ordenamiento.OrdenarPorPrioridad_Media_Alta_Baja();
                        mensaje = $"Orden Actual: {Environment.NewLine}Proridad {Environment.NewLine}(Media - Alta - Baja)";
                        break;
                    case Criterio.Fecha_Fin_Mayor_A_Menor:
                        Ordenamiento.OrdenarPorFecha_Fin_Mayor_A_Menor();
                        mensaje = $"Orden Actual: {Environment.NewLine}Fecha Final {Environment.NewLine}(Mayor a Menor)";
                        break;
                    case Criterio.Fecha_Fin_Menor_A_Mayor:
                        Ordenamiento.OrdenarPorFecha_Fin_Menor_A_Mayor();
                        mensaje = $"Orden Actual: {Environment.NewLine}Fecha Final {Environment.NewLine}(Menor a Mayor)";
                        break;
                    case Criterio.Fecha_Inicio_Mayor_A_Menor:
                        Ordenamiento.OrdenarPorFecha_Inicio_Mayor_A_Menor();
                        mensaje = $"Orden Actual: {Environment.NewLine}Fecha Inicial {Environment.NewLine}(Mayor a Menor)";
                        break;
                    case Criterio.Fecha_Inicio_Menor_A_Mayor:
                        Ordenamiento.OrdenarPorFecha_Inicio_Menor_A_Mayor();
                        mensaje = $"Orden Actual: {Environment.NewLine}Fecha Inicial {Environment.NewLine}(Menor a Mayor)";
                        break;
                }

                if(Ordenamiento.OnOrdenar != null)
                {
                    Ordenamiento.OnOrdenar.Invoke(mensaje);
                }

                try
                {
                    SerializadorJSON<string>.Guardar(Ordenamiento.rutaArchivo, Ordenamiento.criterioDeOrdenamientoActual.ToString());
                }
                catch (Exception) { }

                return Ordenamiento.tareasOrdenadas;
            }
            return tareas;
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorFecha_Fin_Menor_A_Mayor'
        /// </summary>
        private static void OrdenarPorFecha_Fin_Menor_A_Mayor()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.TieneFechaFinal && t2.TieneFechaFinal && t1.FechaFinal == t2.FechaFinal)
                {
                    return 0;
                }
                else if(t1.TieneFechaFinal && !t2.TieneFechaFinal ||
                        (t1.TieneFechaFinal && t2.TieneFechaFinal && t1.FechaFinal < t2.FechaFinal))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorFecha_Fin_Mayor_A_Menor'
        /// </summary>
        private static void OrdenarPorFecha_Fin_Mayor_A_Menor()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.TieneFechaFinal && t2.TieneFechaFinal && t1.FechaFinal == t2.FechaFinal)
                {
                    return 0;
                }
                else if((t1.TieneFechaFinal && !t2.TieneFechaFinal) ||
                       (t1.TieneFechaFinal && t2.TieneFechaFinal && t1.FechaFinal > t2.FechaFinal))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorFecha_Inicio_Menor_A_Mayor'
        /// </summary>
        private static void OrdenarPorFecha_Inicio_Menor_A_Mayor()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.TieneFechaInicial && t2.TieneFechaInicial && t1.FechaInicial == t2.FechaInicial)
                {
                    return 0;
                }
                else if (t1.TieneFechaInicial && !t2.TieneFechaInicial ||
                        (t1.TieneFechaInicial && t2.TieneFechaInicial && t1.FechaInicial < t2.FechaInicial))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorFecha_Inicio_Mayor_A_Menor'
        /// </summary>
        private static void OrdenarPorFecha_Inicio_Mayor_A_Menor()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.TieneFechaInicial && t2.TieneFechaInicial && t1.FechaInicial == t2.FechaInicial)
                {
                    return 0;
                }
                else if((t1.TieneFechaInicial && !t2.TieneFechaInicial) ||
                       (t1.TieneFechaInicial && t2.TieneFechaInicial && t1.FechaInicial > t2.FechaInicial))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorPrioridad_Alta_Media_Baja'
        /// </summary>
        private static void OrdenarPorPrioridad_Alta_Media_Baja()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if (t1.PrioridadTarea == t2.PrioridadTarea)
                {
                    return 0;
                }
                else if (t1.PrioridadTarea == Tarea.Prioridad.Alta ||
                        (t1.PrioridadTarea == Tarea.Prioridad.Media && t2.PrioridadTarea == Tarea.Prioridad.Baja))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorPrioridad_Media_Alta_Baja'
        /// </summary>
        private static void OrdenarPorPrioridad_Media_Alta_Baja()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if (t1.PrioridadTarea == t2.PrioridadTarea)
                {
                    return 0;
                }
                else if (t1.PrioridadTarea == Tarea.Prioridad.Media ||
                        (t1.PrioridadTarea == Tarea.Prioridad.Alta && t2.PrioridadTarea == Tarea.Prioridad.Baja))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorPrioridad_Baja_Media_Alta'
        /// </summary>
        private static void OrdenarPorPrioridad_Baja_Media_Alta()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.PrioridadTarea == t2.PrioridadTarea)
                {
                    return 0;
                }
                else if(t1.PrioridadTarea == Tarea.Prioridad.Baja ||
                       (t1.PrioridadTarea == Tarea.Prioridad.Media && t2.PrioridadTarea == Tarea.Prioridad.Alta))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorEstado_Proceso_Pendiente_Fin'
        /// </summary>
        private static void OrdenarPorEstado_Proceso_Pendiente_Fin()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if (t1.EstadoDeTarea == t2.EstadoDeTarea)
                {
                    return 0;
                }
                else if(t1.EstadoDeTarea == Tarea.EstadoTarea.Proceso ||
                       (t1.EstadoDeTarea == Tarea.EstadoTarea.Pendiente && t2.EstadoDeTarea == Tarea.EstadoTarea.Finalizado))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorEstado_Fin_Proceso_Pendiente'
        /// </summary>
        private static void OrdenarPorEstado_Fin_Proceso_Pendiente()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if (t1.EstadoDeTarea == t2.EstadoDeTarea)
                {
                    return 0;
                }
                else if(t1.EstadoDeTarea == Tarea.EstadoTarea.Finalizado ||
                       (t1.EstadoDeTarea == Tarea.EstadoTarea.Proceso && t2.EstadoDeTarea == Tarea.EstadoTarea.Pendiente))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorEstado_Pendiente_Proceso_Fin'
        /// </summary>
        private static void OrdenarPorEstado_Pendiente_Proceso_Fin()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if (t1.EstadoDeTarea == t2.EstadoDeTarea)
                {
                    return 0;
                }
                else if(t1.EstadoDeTarea == Tarea.EstadoTarea.Pendiente ||
                       (t1.EstadoDeTarea == Tarea.EstadoTarea.Proceso && t2.EstadoDeTarea == Tarea.EstadoTarea.Finalizado))
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorDefecto_Creacion_Primera_A_Ultima'
        /// </summary>
        private static void OrdenarPorDefecto_Creacion_Primera_A_Ultima()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.IdTarea > t2.IdTarea)
                {
                    return 1;
                }
                else if(t1.IdTarea < t2.IdTarea)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }    
            });
        }

        /// <summary>
        /// Ordena la lista con el criterio 'PorDefecto_Creacion_Ultima_A_Primera'
        /// </summary>
        private static void OrdenarPorDefecto_Creacion_Ultima_A_Primera()
        {
            Ordenamiento.tareasOrdenadas.Sort((t1, t2) =>
            {
                if(t1.IdTarea > t2.IdTarea)
                {
                    return -1;
                }
                else if(t1.IdTarea < t2.IdTarea)
                {
                    return 1;
                }
                else
                {
                    return 0;
                } 
            });
        }
    }
}
