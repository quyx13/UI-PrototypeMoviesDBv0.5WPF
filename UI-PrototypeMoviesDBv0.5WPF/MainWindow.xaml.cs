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
                { "textBox", textBox },
                { "statusTextTime", statusTextTime }
            };
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
            Task.Factory.StartNew(() => Worker.DoWork(this.Dispatcher, controls, 10));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // TODO:Settings-Fenster

            //Task.Factory.StartNew(() => DoWork(10));

            Task.Factory.StartNew(() => Worker.DoWork(this.Dispatcher,
                new Dictionary<string, Object>
                {
                    { "btnStart", btnStart},
                    { "imageBtnStart", imgBtnStart },
                    { "textBtnStart", textBtnStart },
                    { "btnSettings", btnSettings},
                    { "imageBtnSettings", imgBtnSettings },
                    { "textBtnSettings", textBtnSettings },
                    { "textBox", textBox }
                }, 10));
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