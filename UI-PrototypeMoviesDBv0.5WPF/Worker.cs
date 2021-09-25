using System;
using System.Threading;

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
            for (int i = 0; i < number;)
            {
                if (state == State.running)
                {
                    #region work
                    view.output += i.ToString() + Environment.NewLine;
                    view.AddUpdate(i, number);
                    i++;
                    Thread.Sleep(1);
                    #endregion
                }
                if (state == State.stopped)
                {
                    return;
                }
            }

            state = State.done;
            view.SetStateDone();
        }
    }
}