using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public partial class MainWindow : Window
    {
        private Worker worker;
        private Dictionary<string, Object> controls;

        public MainWindow()
        {
            InitializeComponent();

            controls = new Dictionary<string, object>()
            {
                { "btnStart", btnStart },
                { "btnStartImg", btnStartImg },
                { "btnStartTxt", btnStartTxt },
                { "btnPause", btnPause },
                { "btnPauseImg", btnPauseImg },
                { "btnPauseTxt", btnPauseTxt },
                { "btnStop", btnStop },
                { "btnStopImg", btnStopImg },
                { "btnStopTxt", btnStopTxt },
                { "btnSettings", btnSettings },
                { "btnSettingsImg", btnSettingsImg },
                { "btnSettingsTxt", btnSettingsTxt },
                { "comboBox", comboBox },
                { "textBox", textBox },
                { "statusTextTime", statusTextTime },
                { "statusTextTask", statusTextTask },
                { "statusProgressBar", statusProgressBar },
                { "statusTextPercentage", statusTextPercentage },
                { "statusTextInfo", statusTextInfo },
            };

            worker = new Worker(this.Dispatcher, controls);
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
            worker.state = State.running;
            Task.Factory.StartNew(() => worker.DoWork(10));
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