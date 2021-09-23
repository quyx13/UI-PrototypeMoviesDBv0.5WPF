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
            switch(worker.state)
            {
                case State.ready:
                    worker.state = State.running;
                    work = Task.Factory.StartNew(() => worker.DoWork(5200));
                    break;
                case State.running:
                    break;
                case State.paused:
                    break;
                case State.stopped:
                    break;
                case State.done:
                    break;
                default:
                    break;
            }
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            worker.state = State.paused;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            worker.state = State.stopped;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster

            //Task.Factory.StartNew(() => DoWork(10));
        }

        //private void DoWork(int number)
        //{
        //    for (int i = 1; i <= number; i++)
        //    {
        //        Dispatcher.BeginInvoke(new Action(() => 
        //        { 
        //            textBox.AppendText(i.ToString() + Environment.NewLine); 
        //        }), DispatcherPriority.Background);

        //        Thread.Sleep(1000);
        //    }

        //    Trace.WriteLine("Done");
        //}
    }
}