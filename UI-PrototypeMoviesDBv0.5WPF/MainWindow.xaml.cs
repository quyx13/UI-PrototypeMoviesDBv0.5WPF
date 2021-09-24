using System.Threading.Tasks;
using System.Windows;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public partial class MainWindow : Window
    {
        private View view;
        private Worker worker;
        private Task work;

        public MainWindow()
        {
            InitializeComponent();

            view = new View(this.Dispatcher, this);
            worker = new Worker(view);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void menuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void menuInfo_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Informations-Dialog
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var number = 5200;

            switch(worker.state)
            {
                case State.ready:
                    view.SetupStatusProgressBar(0, number, 0);
                    goto case State.stopped;
                case State.stopped:
                    goto case State.done;
                case State.done:
                    if (work == null || work.Status == TaskStatus.RanToCompletion)
                    {
                        worker.timer.Restart();
                        worker.state = State.running;
                        work = Task.Factory.StartNew(() => worker.DoWork(number));
                        view.SetStateRunning();
                    }
                    break;
                case State.paused:
                    worker.timer.Start();
                    worker.state = State.running;
                    view.SetStateRunning();
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                worker.timer.Stop();
                worker.state = State.paused;
                view.SetStatePaused();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            switch (worker.state)
            {
                case State.running:
                    worker.timer.Stop();
                    goto case State.paused;
                case State.paused:
                    worker.state = State.stopped;
                    view.SetStateStopped();
                    break;
                case State.stopped:
                    goto case State.done;
                case State.done:
                    worker = new Worker(view);
                    break;
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 1000;)
            {
                view.UpdateTextBox($"{i}");
                i++;
            }
        }
    }
}