using System;
using System.Diagnostics;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public State state;
        private View view;

        public Worker(View view)
        {
            this.view = view;

            state = State.ready;
            view.SetStateReady();
        }

        public void DoWork(int number)
        {
            var timer = new Stopwatch();
            timer.Start();

            state = State.running;
            view.SetStateRunning(number);

            for (int i = 0; i < number; )
            {
                #region Actually Working Area

                view.UpdateTextBox(i.ToString());
                view.ScrollToEnd();
                if (i > 0)
                {
                    var timeLeft = TimeSpan.FromMilliseconds((number - i) * ((int)timer.Elapsed.TotalMilliseconds / i));
                    var text = $"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s (remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)";
                    view.UpdateStatusTextTime(text);
                    view.UpdateTextBox($"{i}\t" + text);
                }
                view.UpdateStatusTextTask($"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
                view.UpdateStatusProgressBar();
                view.UpdateStatusTextPercentage($"{((i + 1) / (double)number * 100):F2}%");

                i++;
                #endregion
            }

            Trace.WriteLine($"{timer.ElapsedMilliseconds}");

            state = State.done;
            view.SetStateDone();
        }
    }
}