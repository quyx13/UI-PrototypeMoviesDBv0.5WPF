using System.Diagnostics;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public class Worker
    {
        public State state;
        public Stopwatch timer = new Stopwatch();
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
                    view.UpdateUi(timer.Elapsed, i, number);
                    i++;
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