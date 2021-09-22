using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public enum State
    {
        ready,
        running,
        paused,
        stopped,
        done
    }

    public class Worker
    {
        public State state = State.ready;

        public void DoWork(Dispatcher dispatcher, Dictionary<string, Object> controls, int number)
        {
            var timer = new Stopwatch();
            timer.Start();

            this.state = State.running;
            ViewUpdates.SetStateRunning(dispatcher, controls, number);
            
            for (int i = 0; i < number; )
            {
                #region Actually Working Area
                ViewUpdates.UpdateComboBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateTextBox(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTime(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusTextTask(dispatcher, controls, $"...step {i}...");
                ViewUpdates.UpdateStatusProgressBar(dispatcher, controls);
                ViewUpdates.UpdateStatusTextPercentage(dispatcher, controls, $"{i}%");
                //ViewUpdates.UpdateStatusTextInfo(dispatcher, controls, $"...step {i}...");

                Thread.Sleep(1000);

                i++;
                #endregion
            }

            this.state = State.done;
            ViewUpdates.SetStateDone(dispatcher, controls);

            timer.Reset();
        }
    }
}