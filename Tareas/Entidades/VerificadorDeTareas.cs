using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace Entidades
{
    public class VerificadorDeTareas
    {
        public event Action<bool> OnTareasPendientes;
        public event Action<bool> OnTareasVencidas;

        private ConcurrentStack<int> tareasPendientes;
        private ConcurrentStack<int> tareasVencidas;
        private CancellationTokenSource tokenDeCancelacion;

        public VerificadorDeTareas (CancellationTokenSource tokenDeCancelacion)
        {
            this.tokenDeCancelacion = tokenDeCancelacion;
            this.tareasPendientes = new ConcurrentStack<int>();
            this.tareasVencidas = new ConcurrentStack<int>();
        }

        private CancellationToken Token
        {
            get
            {
                return this.tokenDeCancelacion.Token;
            }
        }

        public int TotalTareasPendientes
        {
            get
            {
                return this.tareasPendientes.Count;
            }
        }

        public int TotalTareasVencidas
        {
            get
            {
                return this.tareasVencidas.Count;
            }
        }

        /// <summary>
        /// Crea hilos secundarios que revisaran el estado de las tareas.
        /// </summary>
        public void RevisarEstadoDeTareas()
        {
            Task.Run(this.RevisarTareasPendientes);

            Task.Run(this.RevisarTareasVencidas);
        }

        /// <summary>
        /// Desde un hilo secundario, revisa el estado 'Pendiente' de las tareas.
        /// </summary>
        private void RevisarTareasPendientes()
        {
            Tarea tarea;

            while (!this.Token.IsCancellationRequested)
            {
                this.tareasPendientes.Clear();

                for (int i = 0; i < Tarea.Tareas.Count; i++)
                {
                    tarea = Tarea.Tareas[i];

                    if (tarea.TareaEstaPendiente)
                    {
                        this.tareasPendientes.Push(tarea.IdTarea);
                    }
                }

                if(this.OnTareasPendientes != null)
                {
                    if (this.tareasPendientes.Count > 0)
                    {
                        this.OnTareasPendientes(true);
                    }
                    else
                    {
                        this.OnTareasPendientes(false);
                    }
                }

                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// Desde un hilo secundario, revisa el estado 'Vencido' de las tareas.
        /// </summary>
        private void RevisarTareasVencidas()
        {
            Tarea tarea;

            while (!this.Token.IsCancellationRequested)
            {
                this.tareasVencidas.Clear();

                for (int i = 0; i < Tarea.Tareas.Count; i++)
                {
                    tarea = Tarea.Tareas[i];

                    if (tarea.TareaEstaVencida)
                    {
                        this.tareasVencidas.Push(tarea.IdTarea);
                    }
                }

                if(this.OnTareasVencidas != null)
                {
                    if (this.tareasVencidas.Count > 0)
                    {
                        this.OnTareasVencidas(true);
                    }
                    else
                    {
                        this.OnTareasVencidas(false);
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
