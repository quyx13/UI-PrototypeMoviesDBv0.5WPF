using System;
using System.Diagnostics;

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
                if (state == State.running)
                {
                    #region Actually Working Area
                    var text = "00h:00m:00s (remaining: 00h:00m:00s)";
                    if (i > 0)
                    {
                        var timeLeft = TimeSpan.FromMilliseconds((number - i) * ((int)timer.Elapsed.TotalMilliseconds / i));
                        text = $"{timer.Elapsed.Hours:D2}h:{timer.Elapsed.Minutes:D2}m:{timer.Elapsed.Seconds:D2}s (remaining: {timeLeft.Hours:D2}h:{timeLeft.Minutes:D2}m:{timeLeft.Seconds:D2}s)";
                    }
                    view.UpdateStatusTextTime(text);
                    view.UpdateTextBox($"{i}\t" + text);
                    view.ScrollToEnd();
                    view.UpdateStatusTextTask($"{string.Format("{0:0,0}", (i + 1))} of {string.Format("{0:0,0}", (number))}");
                    view.UpdateStatusProgressBar();
                    view.UpdateStatusTextPercentage($"{((i + 1) / (double)number * 100):F2}%");

                    i++;
                    #endregion
                }
            }

            state = State.done;
            view.SetStateDone();
        }
    }
}