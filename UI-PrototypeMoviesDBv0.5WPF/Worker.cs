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
            var numberDouble = (double)number;

            var timer = new Stopwatch();
            timer.Start();

            state = State.running;
            ViewUpdates.SetStateRunning(dispatcher, controls, number);

            for (int i = 0; i < number; )
            {
                #region Actually Working Area

                if (i > 0)
                {

                    //ViewUpdates.UpdateStatusTextTime(dispatcher, controls, 
                    //    $"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s (remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)");
                    //Trace.WriteLine($"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s (remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)");

                    var timeLeft = TimeSpan.FromMilliseconds((number - i) * ((int)timer.Elapsed.TotalMilliseconds / i));

                    string text = $"number:{number}\t";
                    text += $"i:{i}\t";
                    text += $"elapsed:{(int)timer.Elapsed.TotalMilliseconds}\t";
                    text += $"remaining:{(int)timeLeft.TotalMilliseconds}\t";

                    ViewUpdates.UpdateStatusTextTime(dispatcher, controls, text);

                    ViewUpdates.UpdateTextBox(dispatcher, controls, text);
                }

                ViewUpdates.UpdateStatusTextTime(dispatcher, controls, i.ToString());
                ViewUpdates.UpdateStatusTextTask(dispatcher, controls, 
                    $"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
                ViewUpdates.UpdateStatusProgressBar(dispatcher, controls);
                ViewUpdates.UpdateStatusTextPercentage(dispatcher, controls, 
                    $"{((i + 1) / numberDouble * 100):F2}%");

                i++;
                #endregion
            }

            state = State.done;
            ViewUpdates.SetStateDone(dispatcher, controls);

            timer.Reset();
        }
    }
}