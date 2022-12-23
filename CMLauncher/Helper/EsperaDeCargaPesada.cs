using CMLauncher.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace CMLauncher
{

    class EsperaDeCargaPesada
    {
        // Bandera booleana que indica cuando el proceso está siendo ejecutado o ha sido detenido
        private bool HeavyProcessStopped;

        // Expone el contexto de sincronización en la clase entera 
        private readonly SynchronizationContext SyncContext;

        // Crear los 2 contenedores de callbacks
        public event EventHandler<Helper.EsperaDeCarga> Callback1;
        public event EventHandler<Helper.EsperaDeCarga> Callback2;

        // Constructor de la clase HeavyTask
        public EsperaDeCargaPesada()
        {
            // Importante actualizar el valor de SyncContext en el constructor con
            // el valor de SynchronizationContext del AsyncOperationManager
            SyncContext = AsyncOperationManager.SynchronizationContext;
        }

        // Método para iniciar el proceso
        public void Start()
        {
            Thread thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
        }

        // Método para detener el proceso
        public void Stop()
        {
            HeavyProcessStopped = true;
        }

        // Método donde la lógica principal de tu tarea se ejecuta
        private void Run()
        {
            while (!HeavyProcessStopped)
            {
                Thread.Sleep(2000);
                SyncContext.Post(e => triggerCallback1(
                    new Helper.EsperaDeCarga("Algo de información de prueba")
                ), null);
                Thread.Sleep(2000);
                SyncContext.Post(e => triggerCallback2(
                    new Helper.EsperaDeCarga("Algo de información de prueba")
                ), null);
                // La tarea heavy task finaliza, así que hay que detenerla.
                Stop();
            }
        }


        // Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
        private void triggerCallback1(Helper.EsperaDeCarga response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            Callback1?.Invoke(this, response);
        }

        private void triggerCallback2(Helper.EsperaDeCarga response)
        {
            // Si el segundo callback existe, ejecutarlo con la información dada
            Callback2?.Invoke(this, response);
        }
    }
}