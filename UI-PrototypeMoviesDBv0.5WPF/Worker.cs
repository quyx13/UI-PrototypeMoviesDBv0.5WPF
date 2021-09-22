using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public State state;
        private Dispatcher dispatcher;
        private Dictionary<string, Object> controls;

        public Worker(Dispatcher dispatcher, Dictionary<string, Object> controls)
        {
            this.dispatcher = dispatcher;
            this.controls = controls;

            state = State.ready;
            ViewUpdates.SetStateReady(dispatcher, controls);
        }

        public void DoWork(int number)
        {
            var timer = new Stopwatch();
            timer.Start();

            state = State.running;
            ViewUpdates.SetStateRunning(dispatcher, controls, number);
            
            for (int i = 0; i < number; )
            {
                #region Actually Working Area
                i++;

                ViewUpdates.UpdateComboBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateTextBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTime(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTask(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusProgressBar(dispatcher, controls);
                ViewUpdates.UpdateStatusTextPercentage(dispatcher, controls, $"{i}%");
                //ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, $"...step {i}...");
                #endregion
            }

            state = State.done;
            ViewUpdates.SetStateDone(dispatcher, controls);

            timer.Reset();
        }
    }
}