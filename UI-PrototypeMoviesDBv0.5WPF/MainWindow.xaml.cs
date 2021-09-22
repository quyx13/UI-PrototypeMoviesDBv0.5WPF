using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace UI_PrototypeMoviesDBv0._5WPF
{
    public partial class MainWindow : Window
    {
        private Dictionary<string, Object> controls;

        public MainWindow()
        {
            InitializeComponent();

            controls = new Dictionary<string, object>()
            {
                { "btnStart", btnStart },
                { "btnStartImg", btnStartImg },
                { "btnStartTxt", btnStartTxt },
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

            statusTextTime.Text = "00h:00m:00s (remaining: 00h:00m:00s)";
            statusTextTask.Text = "0 of 0";
            statusProgressBar.Value = 0;
            statusProgressBar.Minimum = 0;
            statusProgressBar.Maximum = 1;
            statusTextPercentage.Text = "0%";
            statusTextInfo.Text = "Ready";
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
            var worker = new Worker();

            if (!worker.run)
            {
                worker.run = true;
                Task.Factory.StartNew(() => worker.DoWork(this.Dispatcher, controls, 10));
            }
            else
            {
                worker.run = false;
            }            
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