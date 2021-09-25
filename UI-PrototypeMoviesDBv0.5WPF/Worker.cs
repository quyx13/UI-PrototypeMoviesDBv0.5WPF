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
                    view.AddUpdate(i, number);
                    i++;
                    Thread.Sleep(666);
                    #endregion
                }
                if (state == State.stopped)
                {
                    view.timer.Stop();
                    return;
                }
            }

            state = State.done;
            view.SetStateDone();
        }
    }
}