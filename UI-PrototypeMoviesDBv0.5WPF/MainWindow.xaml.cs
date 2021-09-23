using System.Diagnostics;
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

            worker.state = State.ready;
            view.SetStateReady();
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

            if (work == null)
            {
                Trace.WriteLine("work.Status == null");
            }
            else
            {
                Trace.WriteLine(work.Status);
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var number = 5200;

            switch(worker.state)
            {
                case State.running:
                    break;
                case State.paused:
                    worker.timer.Start();
                    Trace.WriteLine($"restarted with: {worker.timer.ElapsedMilliseconds}");
                    worker.state = State.running;
                    view.SetStateRunning();
                    break;
                case State.ready:
                    view.SetupStatusProgressBar(0, number, 0);
                    goto case State.stopped;
                case State.stopped:
                    goto case State.done;
                case State.done:
                    worker.timer.Restart();
                    Trace.WriteLine($"started with: {worker.timer.ElapsedMilliseconds}");
                    worker.state = State.running;
                    work = Task.Factory.StartNew(() => worker.DoWork(number));
                    view.SetStateRunning();
                    break;
                default:
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                worker.timer.Stop();
                Trace.WriteLine($"paused at: {worker.timer.ElapsedMilliseconds}");
                worker.state = State.paused;
                view.SetStatePaused();
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                worker.state = State.stopped;
                view.SetStateStopped();
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster
        }
    }
}