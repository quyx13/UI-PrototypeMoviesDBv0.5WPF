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
                case State.ready:
                    worker.state = State.running;
                    work = Task.Factory.StartNew(() => worker.DoWork(number));
                    view.SetStateRunning(number);
                    break;
                case State.running:
                    break;
                case State.paused:
                    worker.state = State.running;
                    view.SetStatePaused();
                    break;
                case State.stopped:
                    // TODO:Reset&Neustart
                    break;
                case State.done:
                    // TODO:Reset&Neustart
                    break;
                default:
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                worker.state = State.paused;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (worker.state == State.running)
            {
                worker.state = State.stopped;
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster
        }
    }
}